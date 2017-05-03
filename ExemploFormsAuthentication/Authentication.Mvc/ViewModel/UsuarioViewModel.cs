using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Mvc.ViewModel
{
    public class UsuarioViewModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigátorio")]
        [MaxLength(100,ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        [DisplayName("Usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigátorio")]
        [DataType(DataType.Password)]
        [DisplayName("Senha")]
        public string Password { get; set; }
        
        [NotMapped]
        [Required(ErrorMessage = "Campo obrigátorio")]
        [Compare("Password")]
        [DisplayName("Confirmar senha")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}