namespace WarehouseApplication.Products
{
    class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public Product(int id, string name, int amount)
        {
            this.Id = id;
            this.Name = name;
            this.Amount = amount;
        }

        public static bool operator >(Product product1, Product product2)
        {
            return product1.Amount > product2.Amount;
        }

        public static bool operator <(Product product1, Product product2)
        {
            return product1.Amount < product2.Amount;
        }
    }
}
