using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WarehouseApplication.DB;

namespace WarehouseApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для DeleteProductWindow.xaml
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

        private void ProductNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            productName = ProductNameTextBox.Text;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("Поле наименование должно быть заполнено", "Ошибка");
            }
            else if (productDB.CheckProductName(productName))
            {
                MessageBox.Show("Продукции с таким наименованием не существует", "Ошибка");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту продукцию?",
                    "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    productDB.DeleteProduct(productName);
                    MessageBox.Show("Продукция успешно удалена", "Выполнено");
                    this.DialogResult = true;
                }
            }
        }
    }
}
