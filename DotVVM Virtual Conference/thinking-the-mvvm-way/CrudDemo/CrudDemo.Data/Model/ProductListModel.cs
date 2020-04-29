using System;
using System.Collections.Generic;
using System.Text;

namespace CrudDemo.Data.Model
{
    public class ProductListModel
    {

        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public string QuantityPerUnit { get; set; }
        public long? UnitsInStock { get; set; }
        public long? UnitsOnOrder { get; set; }

    }
}
