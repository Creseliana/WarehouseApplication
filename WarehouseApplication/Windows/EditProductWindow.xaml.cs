using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WarehouseApplication.DB;
using WarehouseApplication.Exceptions;

namespace WarehouseApplication.Windows
{
    /// <summary>
    /// Dialog window for editing products
    /// </summary>
    public partial class EditProductWindow : Window
    {
        private string productName;
        private string newProductName;
        private string strNewProductAmount;
        private int newProductAmount;
        private bool productNameTextBoxEnabled = false;
        private bool productAmountTextBoxEnabled = false;
        private readonly ProductDB productDB = new ProductDB();

        public EditProductWindow()
        {
            Uri iconUri = new Uri("icon.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
        }

        /// <summary>
        /// Gets user input product name that should be edited
        /// </summary>
        private void ProductNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            productName = ProductNameTextBox.Text;
        }

        /// <summary>
        /// Gets user input new product name from the text box
        /// </summary>
        private void NewProductNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            newProductName = NewProductNameTextBox.Text;
            productNameTextBoxEnabled = NewProductNameTextBox.IsEnabled;
        }

        /// <summary>
        /// Gets user input new product amount from the text box as string
        /// </summary>
        private void NewProductAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            strNewProductAmount = NewProductAmountTextBox.Text;
            productAmountTextBoxEnabled = NewProductAmountTextBox.IsEnabled;
        }

        /// <summary>
        /// Tries parse product amount string into integer value
        /// </summary>
        /// <returns>
        /// true - string parsed into integer successfully
        /// </returns>
        private bool GetProductAmount()
        {
            return Int32.TryParse(strNewProductAmount, out newProductAmount);
        }

        /// <summary>
        /// Checks user input and edits product in the database by product name
        /// </summary>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!productNameTextBoxEnabled)
                {
                    if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(strNewProductAmount))
                        throw new EmptyFieldException();
                }
                if (!productAmountTextBoxEnabled)
                {
                    if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(newProductName))
                        throw new EmptyFieldException();
                }
                if (productAmountTextBoxEnabled && !GetProductAmount()) throw new WrongDataFieldException();
                if (productAmountTextBoxEnabled && newProductAmount == 0) throw new WrongDataFieldException();
                if (productDB.CheckProductName(productName)) throw new ProductDataFieldException(false);
                if (!productDB.CheckProductName(newProductName)) throw new ProductDataFieldException(true);

                if (productDB.EditProduct(productName, newProductName, newProductAmount))
                {
                    MessageBox.Show("Продукция успешно изменена", "Выполнено");
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Неопознанная ошибка изменения продукции", "Ошибка");
                    this.DialogResult = true;
                }
            }
            catch (ProductDataFieldException exception)
            {
                if (!exception.ProductExist)
                {
                    MessageBox.Show(exception.ErrorMessageNoExist, exception.Error);
                }
                else
                {
                    MessageBox.Show(exception.ErrorMessageExist, exception.Error);
                }
            }
            catch (WrongDataFieldException exception)
            {
                MessageBox.Show(exception.ErrorMessage, exception.Error);
                NewProductAmountTextBox.Clear();
            }
            catch (EmptyFieldException exception)
            {
                MessageBox.Show(exception.ErrorMessage, exception.Error);
            }
        }
    }
}
