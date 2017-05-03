using Authentication.Mvc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authentication.Mvc.Store
{
  
    public class Carrinho
    {
        public List<ProdutoViewModel> Produtos { get; set;  }

        public Carrinho()
        {
            this.Produtos = new List<ProdutoViewModel>();
        }
    }
}