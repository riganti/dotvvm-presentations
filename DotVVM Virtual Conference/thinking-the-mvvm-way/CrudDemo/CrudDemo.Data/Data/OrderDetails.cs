using System;
using System.Collections.Generic;

namespace CrudDemo.Data.Data
{
    public partial class OrderDetails
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public byte[] UnitPrice { get; set; }
        public long Quantity { get; set; }
        public double Discount { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
