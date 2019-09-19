using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WarehouseApplication.DB;

namespace WarehouseApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindowxaml.xaml
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

        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            login = LoginTextBox.Text;
        }

        private void NewNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            newUserName = NewNameTextBox.Text;
        }

        private void NewLoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            newUserLogin = NewLoginTextBox.Text;
        }

        private void NewPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            newUserPassword = NewPasswordBox.Password;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newUserName) || string.IsNullOrWhiteSpace(newUserLogin)
                || string.IsNullOrWhiteSpace(newUserPassword))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
            }
            else
            {
                if (userDB.CheckLogin(login))
                {
                    MessageBox.Show("Пользователя с таким логином не существует", "Ошибка");
                }
                else if (!userDB.CheckLogin(newUserLogin))
                {
                    MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка");
                }
                else
                {
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
            }
        }
    }
}
