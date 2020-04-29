using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrudDemo.Data.Model
{
    public class ProductDetailModel
    {

        public long ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }
        
        [Required]
        public long? CategoryId { get; set; }

        [Required]
        public long? SupplierId { get; set; }

        [Required]
        public string QuantityPerUnit { get; set; }

        [Required]
        [Range(0, 999)]
        public long? UnitsInStock { get; set; }

        [Required]
        [Range(0, 999)]
        public long? UnitsOnOrder { get; set; }

    }
}
