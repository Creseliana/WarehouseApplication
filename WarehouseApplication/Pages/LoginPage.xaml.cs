using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WarehouseApplication.DB;
using WarehouseApplication.Exceptions;
using WarehouseApplication.Service;
using WarehouseApplication.Users;

namespace WarehouseApplication.Pages
{
    /// <summary>
    /// Page for user authorisation
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

        /// <summary>
        /// Gets user login input
        /// </summary>
        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            inputLogin = Login.Text;
        }

        /// <summary>
        /// Gets user password input
        /// </summary>
        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            inputPassword = Password.Password;
        }

        /// <summary>
        /// Checks user input login and password
        /// If user with such login and password exists than navigates to page with product database
        /// </summary>
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(inputLogin) || string.IsNullOrWhiteSpace(inputPassword))
                    throw new EmptyFieldException();

                user = Auth.CheckUser(inputLogin, inputPassword, UserDB.userDB);

                if (user == null) throw new WrongDataFieldException();

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
            catch (EmptyFieldException exeption)
            {
                MessageBox.Show(exeption.ErrorMessage, exeption.Error);
            }
            catch (WrongDataFieldException)
            {
                MessageBox.Show("Логин или пароль введены неверно.\nПовторите ввод.", "Ошибка");
            }
        }

        /// <summary>
        /// Auth for users without login and password
        /// </summary>
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
