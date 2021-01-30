using System;
using System.Collections.Generic;

namespace CrudDemo.Data.Data
{
    public partial class InternationalOrders
    {
        public long OrderId { get; set; }
        public string CustomsDescription { get; set; }
        public byte[] ExciseTax { get; set; }

        public virtual Orders Order { get; set; }
    }
}
