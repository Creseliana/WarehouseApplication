using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WarehouseApplication.DB;
using WarehouseApplication.Exceptions;

namespace WarehouseApplication.Windows
{
    /// <summary>
    /// Dialog window for adding users (managers)
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private string newUserName;
        private string newUserLogin;
        private string newUserPassword;
        private readonly UserDB userDB = new UserDB();

        public AddUserWindow()
        {
            Uri iconUri = new Uri("icon.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
        }

        /// <summary>
        /// Gets user input new user name from the text box
        /// </summary>
        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            newUserName = NameTextBox.Text;
        }

        /// <summary>
        /// Gets user input new user login from the text box
        /// </summary>
        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            newUserLogin = LoginTextBox.Text;
        }

        /// <summary>
        /// Gets user input new user password from the text box
        /// </summary>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            newUserPassword = PasswordBox.Password;
        }

        /// <summary>
        /// Checks user input and adds new user to the database
        /// </summary>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newUserName) || string.IsNullOrWhiteSpace(newUserLogin)
                || string.IsNullOrWhiteSpace(newUserPassword)) throw new EmptyFieldException();
                if (!userDB.CheckLogin(newUserLogin)) throw new UserDataFieldException();

                if (userDB.AddUser(newUserLogin, newUserPassword, newUserName))
                {
                    MessageBox.Show("Пользователь успешно добавлен", "Выполнено");
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Неопознанная ошибка добавления пользователя.", "Ошибка");
                    this.DialogResult = true;
                }
            }
            catch (UserDataFieldException exception)
            {
                MessageBox.Show(exception.ErrorMessageExist, exception.Error);
                LoginTextBox.Clear();
            }
            catch (EmptyFieldException exception)
            {
                MessageBox.Show(exception.ErrorMessage, exception.Error);
            }
        }
    }
}
