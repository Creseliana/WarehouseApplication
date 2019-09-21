namespace WarehouseApplication.DB
{
    /// <summary>
    /// Interface for product database
    /// </summary>
    interface IProductDB
    {
        /// <summary>
        /// Adds new product to existing database
        /// </summary>
        /// <param name="name">String, new product name</param>
        /// <param name="amount">Integer, new product amount</param>
        /// <returns>
        /// true - when adding was sucessful
        /// false - when adding failed
        /// </returns>
        bool AddProduct(string name, int amount);

        /// <summary>
        /// Edits existing product by name
        /// </summary>
        /// <param name="name">String, name of the product that should be edited</param>
        /// <param name="newName">String, new name for the product</param>
        /// <param name="newAmount">Integer, new amount for the product</param>
        /// <returns>
        /// true - when editing was sucessful
        /// false - when editing failed
        /// </returns>
        bool EditProduct(string name, string newName, int newAmount);

        /// <summary>
        /// Deletes existing product by name
        /// </summary>
        /// <param name="name">String, name of the product that should be deleted</param>
        /// <returns>
        /// true - when deleting was sucessful
        /// false - when deleting failed
        /// </returns>
        bool DeleteProduct(string name);

        /// <summary>
        /// Changes amount of existing product
        /// </summary>
        /// <param name="name">String, name of the product that should be changed</param>
        /// <param name="amount">Integer, new product amount</param>
        /// <returns>
        /// true - when changing was sucessful
        /// false - when changing failed
        /// </returns>
        bool ChangeProductAmount(string name, int amount);

        /// <summary>
        /// Checks database for product with such name
        /// </summary>
        /// <param name="name">String, product name</param>
        /// <returns>
        /// true - when there is no product with such name
        /// false - when product with such name was found
        /// </returns>
        bool CheckProductName(string name);

        /// <summary>
        /// Sort products by specified parameters
        /// </summary>
        /// <param name="byName">Boolean, true when should be sorted by name</param>
        /// <param name="byAmount">Boolean, true when should be sorted by amount</param>
        /// <param name="ascending">Boolean, true when should be sorted in ascending order</param>
        /// <param name="descending">Boolean, true when should be sorted in decsending order</param>
        /// <returns>
        /// true - was sorted sucessfully
        /// false - sortig failed
        /// </returns>
        bool SortProducts(bool byName, bool byAmount, bool ascending, bool descending);
    }
}
