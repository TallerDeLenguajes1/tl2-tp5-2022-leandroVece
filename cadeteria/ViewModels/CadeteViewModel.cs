using AutoMapper;
using cadeteria.Models;
using System.ComponentModel.DataAnnotations;

namespace VuiwModels
{

    class CadeteViewModel
    {
        private int id;
        private string nombre,direccion, telefono;
        private List<PedidoViewModel> listpedido = new List<PedidoViewModel>();

        public int Id { get => id; set => id = value; }
        [Required] [StringLength(120)] 
        public string Nombre { get => nombre; set => nombre = value; }
        [Required] [StringLength(120)] 
        public string Direccion { get => direccion; set => direccion = value; }
        [Required] [StringLength(15)] 
        public string Telefono { get => telefono; set => telefono = value; }


        internal List<PedidoViewModel> Listpedido { get => listpedido; set => listpedido = value; }
    }

    
    
}