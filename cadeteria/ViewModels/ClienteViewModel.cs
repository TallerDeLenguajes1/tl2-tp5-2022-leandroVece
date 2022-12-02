using AutoMapper;
using cadeteria.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.SQLite;

namespace VuiwModels
{

    public class ClienteViewModel
    {
        private int id;
        private string nombre,direccion, telefono;

        private string datosReferencia;
        public int Id { get => id; set => id = value; }
        [Required] [StringLength(120)] 
        public string Nombre { get => nombre; set => nombre = value; }
        [Required] [StringLength(120)] 
        public string Direccion { get => direccion; set => direccion = value; }
        [Required] [StringLength(15)] 
        public string Telefono { get => telefono; set => telefono = value; }
        [Required] [StringLength(200)] 
        public string DatosReferencia { get => datosReferencia; set => datosReferencia = value; }

    }

    
    
}