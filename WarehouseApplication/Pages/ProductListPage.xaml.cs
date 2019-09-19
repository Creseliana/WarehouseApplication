using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WarehouseApplication.DB;
using WarehouseApplication.Windows;

namespace WarehouseApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();
            products.ItemsSource = ProductDB.productDB;
        }

        private void UserPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserListPage());
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            SortProductWindow sortProductWindow = new SortProductWindow();
            sortProductWindow.ShowDialog();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditProductWindow editProductWindow = new EditProductWindow();
            editProductWindow.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteProductWindow deleteProductWindow = new DeleteProductWindow();
            deleteProductWindow.ShowDialog();
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
