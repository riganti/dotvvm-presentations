using System.Collections.Generic;
using System.Linq;
using CrudDemo.Data.Data;
using CrudDemo.Data.Model;

namespace CrudDemo.Data.Services
{
    public class PickerService
    {
        private readonly NorthwindContext db;

        public PickerService(NorthwindContext db)
        {
            this.db = db;
        }

        public List<CategoryPickerModel> GetCategories()
        {
            return db.Categories
                .OrderBy(c => c.CategoryName)
                .Select(c => new CategoryPickerModel()
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName
                })
                .ToList();
        }

        public List<SupplierPickerModel> GetSuppliers()
        {
            return db.Suppliers
                .OrderBy(s => s.CompanyName)
                .Select(s => new SupplierPickerModel()
                {
                    SupplierId = s.SupplierId,
                    CompanyName = s.CompanyName
                })
                .ToList();
        }
    }
}