using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Authentication.Mvc.ViewModel
{
    public class ProdutoViewModel
    {
        //[HiddenInput(DisplayValue = false)]
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Campo obrigátorio")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigátorio")]
        [DisplayName("Preço")]
        [Range(typeof(decimal),"0", "999999999")]
        public decimal Preco { get; set; }
    }
}