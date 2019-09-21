using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WarehouseApplication.DB;
using WarehouseApplication.Exceptions;

namespace WarehouseApplication.Windows
{
    /// <summary>
    /// Dialog window for editing users
    /// </summary>
    public partial class EditUserWindow : Window
    {
        private string login;
        private string newUserName;
        private string newUserLogin;
        private string newUserPassword;
        private readonly UserDB userDB = new UserDB();

        public EditUserWindow()
        {
            Uri iconUri = new Uri("icon.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
        }

        /// <summary>
        /// Gets user input login from the text box that should be changed
        /// </summary>
        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            login = LoginTextBox.Text;
        }

        /// <summary>
        /// Gets user input new user name from the text box
        /// </summary>
        private void NewNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            newUserName = NewNameTextBox.Text;
        }

        /// <summary>
        /// Gets user input new user login from the text box
        /// </summary>
        private void NewLoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            newUserLogin = NewLoginTextBox.Text;
        }

        /// <summary>
        /// Gets user input new user password from the text box
        /// </summary>
        private void NewPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            newUserPassword = NewPasswordBox.Password;
        }

        /// <summary>
        /// Checks user input and edits user in the database by login
        /// </summary>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newUserName) || string.IsNullOrWhiteSpace(newUserLogin)
                   || string.IsNullOrWhiteSpace(newUserPassword)) throw new EmptyFieldException();
                if (userDB.CheckLogin(login)) throw new UserDataFieldException(false);
                if (!userDB.CheckLogin(newUserLogin)) throw new UserDataFieldException(true);

                if (userDB.EditUser(login, newUserLogin, newUserPassword, newUserName))
                {
                    MessageBox.Show("Пользователь успешно изменен", "Выполнено");
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Неопознанная ошибка изменения пользователя.", "Ошибка");
                    this.DialogResult = true;
                }
            }
            catch (UserDataFieldException exception)
            {
                if (!exception.UserExist)
                {
                    MessageBox.Show(exception.ErrorMessageNoExist, exception.Error);
                }
                else MessageBox.Show(exception.ErrorMessageExist, exception.Error);
            }
            catch (EmptyFieldException exception)
            {
                MessageBox.Show(exception.ErrorMessage, exception.Error);
            }
        }
    }
}
