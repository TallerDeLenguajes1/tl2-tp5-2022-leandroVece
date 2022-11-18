using AutoMapper;
using cadeteria.Models;
using System.ComponentModel.DataAnnotations;

namespace VuiwModels
{

    class CadeteriaViewModel
    {
        private string nombre;
        private string telefono;

        [Required] [StringLength(100)] 
        public string Nombre { get => nombre; set => nombre = value; }

        [Required] [StringLength(15)] 
        public string Telefono { get => telefono; set => telefono = value; }
         public List<CadeteViewModel> ListaCadete { get => listaCadete; set => listaCadete = value; }

        List<CadeteViewModel> listaCadete = new List<CadeteViewModel>(); 
    }

    
    
}