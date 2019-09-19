using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WarehouseApplication.DB;
using WarehouseApplication.Windows;

namespace WarehouseApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class UserListPage : Page
    {
        public UserListPage()
        {
            InitializeComponent();

            users.ItemsSource = UserDB.userDB;
        }

        private void ProductPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductListPage());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditUserWindow editUserWindow = new EditUserWindow();
            editUserWindow.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteUserWindow deleteUserWindow = new DeleteUserWindow();
            deleteUserWindow.ShowDialog();
        }

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
