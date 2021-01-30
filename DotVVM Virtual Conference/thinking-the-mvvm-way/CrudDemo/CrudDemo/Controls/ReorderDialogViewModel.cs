using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CrudDemo.Data.Services;
using DotVVM.Framework.ViewModel;

namespace CrudDemo.Controls
{
    public class ReorderDialogViewModel : DotvvmViewModelBase
    {
        private readonly ProductsService productsService;

        public long ProductId { get; set; }

        [Range(0, 99)]
        public long QuantityToReorder { get; set; }

        public bool IsDialogOpen { get; set; }

        public event Action ReorderCompleted;

        
        public ReorderDialogViewModel(ProductsService productsService)
        {
            this.productsService = productsService;
        }

        public void ShowDialog(long productId)
        {
            ProductId = productId;
            QuantityToReorder = 1;

            IsDialogOpen = true;
        }

        public void Reorder()
        {
            productsService.ReorderProduct(ProductId, QuantityToReorder);

            IsDialogOpen = false;
            ReorderCompleted?.Invoke();
        }

        public void HideDialog()
        {
            IsDialogOpen = false;
        }

    }
}
