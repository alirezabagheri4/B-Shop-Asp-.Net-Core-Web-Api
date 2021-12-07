namespace Shop.Domain.Model
{
    public partial class Product
    {
        public int Id { get; set; }

        public int? ProductGroupId { get; set; }

        public int? UserId { get; set; }

        public string Name { get; set; }

        public double? Price { get; set; }

        public byte? Status { get; set; }

        public ProductGroup ProductGroup { get; set; }
    }
}
