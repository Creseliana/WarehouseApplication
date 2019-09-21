using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WarehouseApplication.DB;
using WarehouseApplication.Windows;

namespace WarehouseApplication.Pages
{
    /// <summary>
    /// Page for user database (user table)
    /// </summary>
    public partial class UserListPage : Page
    {
        public UserListPage()
        {
            InitializeComponent();
            users.ItemsSource = UserDB.userDB;
        }

        /// <summary>
        /// Navigates to page with product data base
        /// </summary>
        private void ProductPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductListPage());
        }

        /// <summary>
        /// Creates dialog window with user adding interface
        /// </summary>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
        }

        /// <summary>
        /// Creates dialog window with user editing interface
        /// </summary>
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditUserWindow editUserWindow = new EditUserWindow();
            editUserWindow.ShowDialog();
        }

        /// <summary>
        /// Creates dialog window with user deleting interface
        /// </summary>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteUserWindow deleteUserWindow = new DeleteUserWindow();
            deleteUserWindow.ShowDialog();
        }

        /// <summary>
        /// Navigates to login page
        /// </summary>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?",
                    "Подтверждение", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new LoginPage());
            }
        }
    }
}
