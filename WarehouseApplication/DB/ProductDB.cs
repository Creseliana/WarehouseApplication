using System.Collections.ObjectModel;
using WarehouseApplication.Products;
using WarehouseApplication.Service;

namespace WarehouseApplication.DB
{
    /// <summary>
    /// Implements interface <see cref="IProductDB"/>
    /// Keeps file path to .bin file with database
    /// Keeps information from database in ObservableCollection
    /// </summary>
    sealed class ProductDB : IProductDB
    {
        public static ObservableCollection<Product> productDB = new ObservableCollection<Product>();
        public static readonly string pathProductDB = "productDB.bin";

        public bool AddProduct(string name, int amount)
        {
            if (string.IsNullOrWhiteSpace(name) || amount <= 0) return false;
            productDB.Add(new Product(GetNextId(), name, amount));
            MethodsDB.WriteProductsToFile(pathProductDB, productDB);
            return true;
        }

        public bool EditProduct(string name, string newName, int newAmount)
        {
            for (int i = 0; i < productDB.Count; i++)
            {
                if (productDB[i].Name.Equals(name))
                {
                    if (newName == null) newName = productDB[i].Name;
                    if (newAmount == 0) newAmount = productDB[i].Amount;
                    Product product = new Product(productDB[i].Id, newName, newAmount);
                    productDB.RemoveAt(i);
                    productDB.Insert(i, product);
                    MethodsDB.WriteProductsToFile(pathProductDB, productDB);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteProduct(string name)
        {
            for (int i = 0; i < productDB.Count; i++)
            {
                if (productDB[i].Name.Equals(name))
                {
                    productDB.RemoveAt(i);
                    MethodsDB.WriteProductsToFile(pathProductDB, productDB);
                    return true;
                }
            }
            return false;
        }

        public bool ChangeProductAmount(string name, int amount)
        {
            for (int i = 0; i < productDB.Count; i++)
            {
                if (productDB[i].Name.Equals(name))
                {
                    Product product = new Product(productDB[i].Id, name, productDB[i].Amount + amount);
                    productDB.RemoveAt(i);
                    productDB.Insert(i, product);
                    MethodsDB.WriteProductsToFile(pathProductDB, productDB);
                    return true;
                }
            }
            return false;
        }

        public bool CheckProductName(string name)
        {
            for (int i = 0; i < productDB.Count; i++)
            {
                if (productDB[i].Name.Equals(name)) return false;
            }
            return true;
        }

        public bool SortProducts(bool byName, bool byAmount, bool ascending, bool descending)
        {
            if (byAmount && ascending)
            {
                ShakerSortAsecendingByAmount();
            }
            else if (byAmount && descending)
            {
                ShakerSortDescendingByAmount();
            }
            else if (byName && ascending)
            {
                ShakerSortAsecendingByName();
            }
            else if (byName && descending)
            {
                ShakerSortDescendingByName();
            }
            else return false;
            return true;
        }

        /// <summary>
        /// Shaker sorting by amount in decsending order
        /// </summary>
        private void ShakerSortDescendingByAmount()
        {
            for (int i = 0; i < productDB.Count / 2; i++)
            {
                bool swapFlag = false;
                for (int j = i; j < productDB.Count - i - 1; j++)
                {
                    if (productDB[j] < productDB[j + 1])
                    {
                        productDB.Move(j, j + 1);
                        swapFlag = true;
                    }
                }
                for (int j = productDB.Count - 2 - i; j > i; j--)
                {
                    if (productDB[j - 1] < productDB[j])
                    {
                        productDB.Move(j - 1, j);
                        swapFlag = true;
                    }
                }
                if (!swapFlag) break;
            }
        }

        /// <summary>
        /// Shaker sorting by amount in acsending order
        /// </summary>
        private void ShakerSortAsecendingByAmount()
        {
            for (int i = 0; i < productDB.Count / 2; i++)
            {
                bool swapFlag = false;
                for (int j = i; j < productDB.Count - i - 1; j++)
                {
                    if (productDB[j] > productDB[j + 1])
                    {
                        productDB.Move(j, j + 1);
                        swapFlag = true;
                    }
                }
                for (int j = productDB.Count - 2 - i; j > i; j--)
                {
                    if (productDB[j - 1] > productDB[j])
                    {
                        productDB.Move(j - 1, j);
                        swapFlag = true;
                    }
                }
                if (!swapFlag) break;
            }
        }

        /// <summary>
        /// Shaker sorting by name in decsending order
        /// </summary>
        private void ShakerSortDescendingByName()
        {
            for (int i = 0; i < productDB.Count / 2; i++)
            {
                bool swapFlag = false;
                for (int j = i; j < productDB.Count - i - 1; j++)
                {
                    if (string.Compare(productDB[j].Name, productDB[j + 1].Name) < 0)
                    {
                        productDB.Move(j, j + 1);
                        swapFlag = true;
                    }
                }
                for (int j = productDB.Count - 2 - i; j > i; j--)
                {
                    if (string.Compare(productDB[j - 1].Name, productDB[j].Name) < 0)
                    {
                        productDB.Move(j - 1, j);
                        swapFlag = true;
                    }
                }
                if (!swapFlag) break;
            }
        }

        /// <summary>
        /// Shaker sorting by name in acsending order
        /// </summary>
        private void ShakerSortAsecendingByName()
        {
            for (int i = 0; i < productDB.Count / 2; i++)
            {
                bool swapFlag = false;
                for (int j = i; j < productDB.Count - i - 1; j++)
                {
                    if (string.Compare(productDB[j].Name, productDB[j + 1].Name) > 0)
                    {
                        productDB.Move(j, j + 1);
                        swapFlag = true;
                    }
                }
                for (int j = productDB.Count - 2 - i; j > i; j--)
                {
                    if (string.Compare(productDB[j - 1].Name, productDB[j].Name) > 0)
                    {
                        productDB.Move(j - 1, j);
                        swapFlag = true;
                    }
                }
                if (!swapFlag) break;
            }
        }

        /// <summary>
        /// Searches in database for the biggest product ID
        /// </summary>
        /// <returns>
        /// The biggest product ID + 1 (next ID for new product)
        /// </returns>
        private int GetNextId()
        {
            int biggestId = productDB[0].Id;
            for (int i = 1; i < productDB.Count; i++)
            {
                if (biggestId < productDB[i].Id)
                {
                    biggestId = productDB[i].Id;
                }
            }
            return biggestId + 1;
        }
    }
}
