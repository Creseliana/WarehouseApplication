using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WarehouseApplication.Service;
using WarehouseApplication.Users;

namespace WarehouseApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private string inputLogin;
        private string inputPassword;
        private AbstractUser user;
        private string path = "userDB.bin";
        private List<AbstractUser> userList = new List<AbstractUser>();

        public LoginPage()
        {
            if(!MethodsDB.WriteUsersFromFile(path, userList))
            {
                MessageBox.Show("Ошибка получения пользователей", "Ошибка");
                Application.Current.Shutdown();
            }
            InitializeComponent();
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            inputLogin = Login.Text;
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            inputPassword = Password.Password;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputLogin) || string.IsNullOrWhiteSpace(inputPassword))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
            } else
            {
                user = Auth.CheckUser(inputLogin, inputPassword, userList);
                if(user != null)
                {
                    NavigationService.Navigate(new Page1());
                }
                else
                {
                    MessageBox.Show("Логин или пароль введены неверно.\nПовторите ввод.", "Ошибка");
                }
            }
        }

        private void SubmitWithoutAuth_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
