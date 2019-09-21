using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WarehouseApplication.DB;
using WarehouseApplication.Exceptions;

namespace WarehouseApplication.Windows
{
    /// <summary>
    /// Dialog window for deleting product
    /// </summary>
    public partial class DeleteProductWindow : Window
    {
        private string productName;
        private readonly ProductDB productDB = new ProductDB();

        public DeleteProductWindow()
        {
            Uri iconUri = new Uri("icon.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
        }

        /// <summary>
        /// Gets user input product name from the text box that should be deleted
        /// </summary>
        private void ProductNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            productName = ProductNameTextBox.Text;
        }

        /// <summary>
        /// Checks user input and deletes product by product name
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productName)) throw new EmptyFieldException();
                if (productDB.CheckProductName(productName)) throw new ProductDataFieldException();

                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту продукцию?",
                        "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    productDB.DeleteProduct(productName);
                    MessageBox.Show("Продукция успешно удалена", "Выполнено");
                    this.DialogResult = true;
                }
            }
            catch (ProductDataFieldException exception)
            {
                MessageBox.Show(exception.ErrorMessageNoExist, exception.Error);
            }
            catch (EmptyFieldException exception)
            {
                MessageBox.Show(exception.ErrorMessage, exception.Error);
            }
        }
    }
}
