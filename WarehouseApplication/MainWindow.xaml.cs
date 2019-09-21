using System;
using System.Windows;
using System.Windows.Media.Imaging;
using WarehouseApplication.DB;
using WarehouseApplication.Service;

namespace WarehouseApplication
{
    /// <summary>
    /// Creates main window for application.
    /// Gets user database and product database from files
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Uri iconUri = new Uri("icon.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            if (!MethodsDB.WriteUsersFromFile(UserDB.pathUserDB, UserDB.userDB))
            {
                MessageBox.Show("Ошибка считывания базы данных пользователей", "Ошибка");
                Application.Current.Shutdown();
            }
            if (!MethodsDB.WriteProductsFromFile(ProductDB.pathProductDB, ProductDB.productDB))
            {
                MessageBox.Show("Ошибка считывания базы данных продукции", "Ошибка");
                Application.Current.Shutdown();
            }
            InitializeComponent();
        }
    }
}
