namespace WarehouseApplication.Products
{
    /// <summary>
    /// Class for creating product objects
    /// Unique ID for each product, product name, product amount
    /// </summary>
    class Product : IProduct
    {
        /// <value>Gets and sets unique product ID</value>
        public int Id { get; set; }

        /// <value>Gets and sets product name</value>
        public string Name { get; set; }

        /// <value>Gets and sets product amount</value>
        public int Amount { get; set; }

        public Product(int id, string name, int amount)
        {
            this.Id = id;
            this.Name = name;
            this.Amount = amount;
        }

        /// <summary>
        /// Overridden comparison operator, compare products by amount
        /// </summary>
        /// <param name="product1">Product object</param>
        /// <param name="product2">Product object</param>
        /// <returns>
        /// true - first product amount bigger than second
        /// false - second product amount bigger than first
        /// </returns>
        public static bool operator >(Product product1, Product product2)
        {
            return product1.Amount > product2.Amount;
        }

        /// <summary>
        /// Overridden comparison operator, compare products by amount
        /// </summary>
        /// <param name="product1"></param>
        /// <param name="product2"></param>
        /// true - first product amount less than second
        /// false - second product amount less than first
        /// <returns></returns>
        public static bool operator <(Product product1, Product product2)
        {
            return product1.Amount < product2.Amount;
        }
    }
}
