using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WarehouseApplication.DB;

namespace WarehouseApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
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

        private void ProductNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            productName = ProductNameTextBox.Text;
        }

        private void ProductAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            strProductAmount = ProductAmountTextBox.Text;
        }

        private bool GetProductAmount()
        {
            return Int32.TryParse(strProductAmount, out productAmount);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
            }
            else if (!GetProductAmount())
            {
                MessageBox.Show("Количество должно быть целочисленным значением", "Ошибка");
                ProductAmountTextBox.Clear();
            }
            else if (productAmount == 0)
            {
                MessageBox.Show("Количество должно быть больше нуля", "Ошибка");
                ProductAmountTextBox.Clear();
            }
            else
            {
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
        }
    }
}
