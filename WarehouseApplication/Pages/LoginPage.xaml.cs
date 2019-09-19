using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WarehouseApplication.DB;
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

        public LoginPage()
        {
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
            }
            else
            {
                user = Auth.CheckUser(inputLogin, inputPassword, UserDB.userDB);
                if (user != null)
                {
                    if (user.Role == AbstractUser.ADMIN)
                    {
                        NavigationService.Navigate(new ProductListPage());
                    }
                    else if (user.Role == AbstractUser.MANAGER)
                    {
                        ProductListPage productListPage = new ProductListPage();
                        productListPage.UserPage.Visibility = Visibility.Collapsed;
                        NavigationService.Navigate(productListPage);
                    }
                }
                else
                {
                    MessageBox.Show("Логин или пароль введены неверно.\nПовторите ввод.", "Ошибка");
                }
            }
        }

        private void SubmitWithoutAuth_Click(object sender, RoutedEventArgs e)
        {
            ProductListPage productListPage = new ProductListPage();
            productListPage.UserPage.Visibility = Visibility.Collapsed;
            productListPage.Add.Visibility = Visibility.Collapsed;
            productListPage.Edit.Visibility = Visibility.Collapsed;
            productListPage.Delete.Visibility = Visibility.Collapsed;
            NavigationService.Navigate(productListPage);
        }
    }
}
