using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using DotVVM.Framework.ViewModel;

namespace WebFormsDemo.v2.ViewModels
{
    public class SiteViewModel : DotvvmViewModelBase
    {
        public void SignOut()
        {
            FormsAuthentication.SignOut();
            Context.RedirectToLocalUrl("~/");
        }
    }
}

