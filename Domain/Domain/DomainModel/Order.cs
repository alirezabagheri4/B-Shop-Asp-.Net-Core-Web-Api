using System;
using System.Collections.Generic;

namespace Shop.Domain.Model
{
    public partial class Order
    {
        public Order() { OrderItem = new HashSet<OrderItem>(); }

        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public int? UserId { get; set; }

        public double? TotalPrice { get; set; }

        public DateTime? SubmitDate { get; set; }

        public byte? Status { get; set; }

        public Order IdNavigation { get; set; }

        public Order InverseIdNavigation { get; set; }

        public ICollection<OrderItem> OrderItem { get; set; }
    }
}
