using AutoMapper;
using cadeteria.Models;
using System.ComponentModel.DataAnnotations;

namespace VuiwModels
{

     public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre de usuario")] 
        [Display(Name = "Usuario")] 
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La contraseña debe tener al menos 3 caracteres")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [Compare("Password", ErrorMessage = "Ambas contraseñas deben ser iguales")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Reingrese la contraseña")]
        public string PasswordRetry { get; set; }

        [Display(Name = "Error")]
        public string Message { get; set; }
    }


    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Debe ingresar un nombre de usuario")]
        [StringLength(100)]
        [Display(Name = "Usuario")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Error")]
        public string Message { get; set; }
    }


    public class UserUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre de usuario")] 
        [StringLength(100)] 
        [Display(Name = "Usuario")] 
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La contraseña debe tener al menos 3 caracteres")]
        [Display(Name = "Nueva Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [Compare("Password", ErrorMessage = "Ambas contraseñas deben ser iguales")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Reingrese la contraseña")]
        public string PasswordRetry { get; set; }


        [Display(Name = "Error")]
        public string Message { get; set; }
    }

}
