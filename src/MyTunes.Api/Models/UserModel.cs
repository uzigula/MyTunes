using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTunes.Api.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name="Nombre Usuario")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100,ErrorMessage="El {0} debe ser de al menos {1} caracteres de longitud",MinimumLength=6 )]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Password")]
        [Compare("Password",ErrorMessage="Los passwords deben ser iguales")]
        public string ConfirmPassword { get; set; }

    }
}