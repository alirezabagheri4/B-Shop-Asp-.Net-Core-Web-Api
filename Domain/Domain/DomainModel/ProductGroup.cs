using System.Collections.Generic;

namespace Shop.Domain.Model
{
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
