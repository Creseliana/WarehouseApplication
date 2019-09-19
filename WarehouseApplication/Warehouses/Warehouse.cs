namespace WarehouseApplication.Warehouses
{
    class Warehouse : IWarehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Fullness { get; set; }

        public Warehouse(int id, string name, int capacity, int fullness)
        {
            this.Id = id;
            this.Name = name;
            this.Capacity = capacity;
            this.Fullness = fullness;
        }
    }
}
