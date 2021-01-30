using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CrudDemo.Controls;
using CrudDemo.Data.Model;
using CrudDemo.Data.Services;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;

namespace CrudDemo.ViewModels
{
    public class ProductListViewModel2 : MasterPageViewModel
    {
        private readonly ProductsService productsService;

        public GridViewDataSet<ProductListModel> Products { get; set; } = new GridViewDataSet<ProductListModel>()
        {
            PagingOptions =
            {
                PageSize = 15
            },
            SortingOptions =
            {
                SortExpression = nameof(ProductListModel.ProductName)
            }
        };

        public ProductFilter Filter { get; set; } = new ProductFilter();

        public ReorderDialogViewModel ReorderDialog { get; set; }


        public ProductListViewModel2(ProductsService productsService, 
            ReorderDialogViewModel reorderDialogViewModel)
        {
            this.productsService = productsService;

            ReorderDialog = reorderDialogViewModel;
            ReorderDialog.ReorderCompleted += () =>
            {
                Products.RequestRefresh();
            };
        }


        public override Task PreRender()
        {
            if (Products.IsRefreshRequired)
            {
                // use IQueryable - paging and sorting will be done automatically
                var queryable = productsService.GetProductsQuery(Filter);
                Products.LoadFromQueryable(queryable);

                // if you don't use IQueryable, you can fill the GridViewDataSet manually:
                // 
                // Products.Items = yourItems;
                // Products.PagingOptions.TotalItemsCount = totalCount;
                // Products.IsRefreshRequired = false;
            }

            return base.PreRender();
        }

        public void ApplyFilters()
        {
            Products.RequestRefresh();
        }
    }
}
