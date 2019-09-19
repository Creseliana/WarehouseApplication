using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WarehouseApplication.DB;

namespace WarehouseApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
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

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            newUserName = NameTextBox.Text;
        }

        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            newUserLogin = LoginTextBox.Text;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            newUserPassword = PasswordBox.Password;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newUserName) || string.IsNullOrWhiteSpace(newUserLogin)
                || string.IsNullOrWhiteSpace(newUserPassword))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
            }
            else
            {
                if (!userDB.CheckLogin(newUserLogin))
                {
                    MessageBox.Show("Пользователь с таким логином существует", "Ошибка");
                    LoginTextBox.Clear();
                }
                else
                {
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
            }
        }
    }
}
