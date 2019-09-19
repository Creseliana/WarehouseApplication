using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WarehouseApplication.DB;

namespace WarehouseApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        private string productName;
        private string newProductName;
        private string strNewProductAmount;
        private int newProductAmount;
        private readonly ProductDB productDB = new ProductDB();

        public EditProductWindow()
        {
            Uri iconUri = new Uri("icon.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
        }

        private void ProductNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            productName = ProductNameTextBox.Text;
        }

        private void NewProductNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            newProductName = NewProductNameTextBox.Text;
        }

        private void NewProductAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            strNewProductAmount = NewProductAmountTextBox.Text;
        }

        private bool GetProductAmount()
        {
            return Int32.TryParse(strNewProductAmount, out newProductAmount);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(newProductName))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
            }
            else if (!GetProductAmount())
            {
                MessageBox.Show("Количество должно быть целочисленным значением", "Ошибка");
                NewProductAmountTextBox.Clear();
            }
            else if (newProductAmount == 0)
            {
                MessageBox.Show("Количество должно быть больше нуля", "Ошибка");
                NewProductAmountTextBox.Clear();
            }
            else
            {
                if (productDB.CheckProductName(productName))
                {
                    MessageBox.Show("Продукции с таким наименованием не существует", "Ошибка");
                }
                else if (!productDB.CheckProductName(newProductName))
                {
                    MessageBox.Show("Продукция с таким наименованием уже существует", "Ошибка");
                }
                else
                {
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
            }
        }
    }
}
