using System;
using System.Collections.Generic;

namespace CrudDemo.Data.Data
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long? SupplierId { get; set; }
        public long? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public byte[] UnitPrice { get; set; }
        public long? UnitsInStock { get; set; }
        public long? UnitsOnOrder { get; set; }
        public long? ReorderLevel { get; set; }
        public byte[] Discontinued { get; set; }
        public byte[] DiscontinuedDate { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Suppliers Supplier { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
