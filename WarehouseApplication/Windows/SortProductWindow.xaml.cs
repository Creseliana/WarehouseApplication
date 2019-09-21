using System;
using System.Windows;
using System.Windows.Media.Imaging;
using WarehouseApplication.DB;

namespace WarehouseApplication.Windows
{
    /// <summary>
    /// Dialog window for sorting products
    /// </summary>
    public partial class SortProductWindow : Window
    {
        bool byName = false;
        bool byAmount = false;
        bool ascending = false;
        bool descending = false;
        private readonly ProductDB productDB = new ProductDB();

        public SortProductWindow()
        {
            Uri iconUri = new Uri("icon.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
        }

        /// <summary>
        /// Sets true if user chose sorting by name
        /// </summary>
        private void ByName_Checked(object sender, RoutedEventArgs e)
        {
            byName = true;
            byAmount = false;
        }

        /// <summary>
        /// Sets true if user chose sorting by amount
        /// </summary>
        private void ByAmount_Checked(object sender, RoutedEventArgs e)
        {
            byAmount = true;
            byName = false;
        }

        /// <summary>
        /// Sets true if user chose sorting in ascending order
        /// </summary>
        private void Ascending_Checked(object sender, RoutedEventArgs e)
        {
            ascending = true;
            descending = false;
        }

        /// <summary>
        /// Sets true if user chose sorting in descending order
        /// </summary>
        private void Descending_Checked(object sender, RoutedEventArgs e)
        {
            descending = true;
            ascending = false;
        }

        /// <summary>
        /// Sorts products by specified parameters
        /// </summary>
        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            if (!productDB.SortProducts(byName, byAmount, ascending, descending))
            {
                MessageBox.Show("Необходимо выбрать параметры сортировки", "Ошибка");
            }
            else this.DialogResult = true;
        }
    }
}
