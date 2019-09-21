using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WarehouseApplication.DB;
using WarehouseApplication.Exceptions;

namespace WarehouseApplication.Windows
{
    /// <summary>
    /// Dialog window for adding products
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private string productName;
        private string strProductAmount;
        private int productAmount;
        private readonly ProductDB productDB = new ProductDB();

        public AddProductWindow()
        {
            Uri iconUri = new Uri("icon.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
        }

        /// <summary>
        /// Gets user input product name from the text box
        /// </summary>
        private void ProductNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            productName = ProductNameTextBox.Text;
        }

        /// <summary>
        /// Gets user input product amount from the text box as string
        /// </summary>
        private void ProductAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            strProductAmount = ProductAmountTextBox.Text;
        }

        /// <summary>
        /// Tries parse product amount string into integer value
        /// </summary>
        /// <returns>
        /// true - string parsed into integer successfully
        /// </returns>
        private bool GetProductAmount()
        {
            return Int32.TryParse(strProductAmount, out productAmount);
        }

        /// <summary>
        /// Checks user input and adds product to the database
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(strProductAmount))
                    throw new EmptyFieldException();
                if (!GetProductAmount()) throw new WrongDataFieldException();
                if (productAmount == 0) throw new WrongDataFieldException();

                if (!productDB.CheckProductName(productName))
                {
                    MessageBoxResult result = MessageBox.Show("Продукция с таким наименованием уже существует.\n" +
                        "Хотите изменить добавить к количеству у существущего?", "Подтверждение", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (productDB.ChangeProductAmount(productName, productAmount))
                        {
                            MessageBox.Show("Продукция успешно добавлена", "Выполнено");
                            this.DialogResult = true;
                        }
                    }
                }
                else
                {
                    if (productDB.AddProduct(productName, productAmount))
                    {
                        MessageBox.Show("Продукция успешно добавлена", "Выполнено");
                        this.DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("Неопознанная ошибка добавления продукции", "Ошибка");
                        this.DialogResult = true;
                    }
                }
            }
            catch (WrongDataFieldException exception)
            {
                MessageBox.Show(exception.ErrorMessage, exception.Error);
                ProductAmountTextBox.Clear();
            }
            catch (EmptyFieldException exception)
            {
                MessageBox.Show(exception.ErrorMessage, exception.Error);
            }
        }
    }
}
