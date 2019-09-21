using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WarehouseApplication.DB;
using WarehouseApplication.Exceptions;

namespace WarehouseApplication.Windows
{
    /// <summary>
    /// Dialog window for deleting users
    /// </summary>
    public partial class DeleteUserWindow : Window
    {
        private string login;
        private readonly UserDB userDB = new UserDB();

        public DeleteUserWindow()
        {
            Uri iconUri = new Uri("icon.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
        }

        /// <summary>
        /// Gets user input login from the text box that should be deleted
        /// </summary>
        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            login = LoginTextBox.Text;
        }

        /// <summary>
        /// Checks user input and deletes user by login
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(login)) throw new EmptyFieldException();
                if (userDB.CheckLogin(login)) throw new UserDataFieldException();

                if (login.Equals("admin"))
                {
                    MessageBox.Show("Нельзя удалить пользователя Администратор", "Ошибка");
                    return;
                }
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этого пользователя?",
                        "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    userDB.DeleteUser(login);
                    MessageBox.Show("Пользователь успешно удален", "Выполнено");
                    this.DialogResult = true;
                }
            }
            catch (UserDataFieldException exception)
            {
                MessageBox.Show(exception.ErrorMessageNoExist, exception.Error);
            }
            catch (EmptyFieldException exception)
            {
                MessageBox.Show(exception.ErrorMessage, exception.Error);
            }
        }
    }
}
