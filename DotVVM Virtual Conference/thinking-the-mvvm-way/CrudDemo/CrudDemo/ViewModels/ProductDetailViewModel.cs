using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudDemo.Data.Model;
using CrudDemo.Data.Services;
using DotVVM.Framework.ViewModel;

namespace CrudDemo.ViewModels
{
    public class ProductDetailViewModel : MasterPageViewModel
    {
        private readonly ProductsService productsService;
        private readonly PickerService pickerService;

        [FromRoute("Id")]
        public long Id { get; set; }

        public bool IsNew => Id == 0;

        public ProductDetailModel CurrentProduct { get; set; }


        [Bind(Direction.ServerToClientFirstRequest)]
        public List<CategoryPickerModel> Categories { get; set; }

        [Bind(Direction.ServerToClientFirstRequest)]
        public List<SupplierPickerModel> Suppliers { get; set; }


        public ProductDetailViewModel(ProductsService productsService, PickerService pickerService)
        {
            this.productsService = productsService;
            this.pickerService = pickerService;
        }


        public override Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                // load pickers
                Categories = pickerService.GetCategories();
                Suppliers = pickerService.GetSuppliers();

                // load current product
                if (IsNew)
                {
                    CurrentProduct = new ProductDetailModel();
                }
                else
                {
                    CurrentProduct = productsService.GetProductById(Id);
                }
            }

            return base.PreRender();
        }

        public void Save()
        {
            productsService.SaveProduct(CurrentProduct);
            Context.RedirectToRoute("ProductList");
        }
    }
}
