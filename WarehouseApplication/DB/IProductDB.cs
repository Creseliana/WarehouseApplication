namespace WarehouseApplication.DB
{
    interface IProductDB
    {
        bool AddProduct(string name, int amount);
        bool EditProduct(string name, string newName, int newAmount);
        bool DeleteProduct(string name);
        bool ChangeProductAmount(string name, int amount);
        bool CheckProductName(string name);
        bool SortProducts(bool byName, bool byAmount, bool ascending, bool descending);
    }
}
