namespace Core.Domain.DomainModel
{
    public partial class OrderItem
    {
        public int Id { get; set; }

        public int OrdrId { get; set; }

        public int? Quantity { get; set; }

        public double? Price { get; set; }

        public Order Ordr { get; set; }
    }
}
