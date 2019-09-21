using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WarehouseApplication.DB;
using WarehouseApplication.Windows;

namespace WarehouseApplication.Pages
{
    /// <summary>
    /// Page for product database (product table)
    /// </summary>
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();
            products.ItemsSource = ProductDB.productDB;
        }

        /// <summary>
        /// Navigates to page with user data base
        /// </summary>
        private void UserPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserListPage());
        }

        /// <summary>
        /// Creates dialog window with product sorting interface
        /// </summary>
        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            SortProductWindow sortProductWindow = new SortProductWindow();
            sortProductWindow.ShowDialog();
        }

        /// <summary>
        /// Creates dialog window with product adding interface
        /// </summary>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ShowDialog();
        }

        /// <summary>
        /// Creates dialog window with product editing interface
        /// </summary>
        private void EditName_Click(object sender, RoutedEventArgs e)
        {
            EditProductWindow editProductWindow = new EditProductWindow();
            editProductWindow.NewProductAmountTextBox.IsEnabled = false;
            editProductWindow.ShowDialog();
        }

        /// <summary>
        /// Creates dialog window with product editing interface
        /// </summary>
        private void EditAmount_Click(object sender, RoutedEventArgs e)
        {
            EditProductWindow editProductWindow = new EditProductWindow();
            editProductWindow.NewProductNameTextBox.IsEnabled = false;
            editProductWindow.ShowDialog();
        }

        /// <summary>
        /// Creates dialog window with product deleting interface
        /// </summary>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteProductWindow deleteProductWindow = new DeleteProductWindow();
            deleteProductWindow.ShowDialog();
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
