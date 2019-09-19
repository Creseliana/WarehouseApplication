using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WarehouseApplication.DB;

namespace WarehouseApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для DeleteUserWindow.xaml
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

        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            login = LoginTextBox.Text;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Поле логин должно быть заполнено", "Ошибка");
            }
            else if (userDB.CheckLogin(login))
            {
                MessageBox.Show("Пользователя с таким логином не существует", "Ошибка");
            }
            else if (login.Equals("admin"))
            {
                MessageBox.Show("Нельзя удалить пользователя Администратор", "Ошибка");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этого пользователя?",
                    "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    userDB.DeleteUser(login);
                    MessageBox.Show("Пользователь успешно удален", "Выполнено");
                    this.DialogResult = true;
                }
            }
        }
    }
}
