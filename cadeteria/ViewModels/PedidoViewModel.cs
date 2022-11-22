using AutoMapper;
using cadeteria.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.SQLite;

namespace VuiwModels
{

    class PedidoViewModel
    {
        private string numero ,obs;
        private string estado;

        private int id_cliente;
        
        //siguiendo la teoria de composicion si creo clientes desde la clase pedido este se eliminara cuando elimine el pedido
        ClienteViewModel cliente = new ClienteViewModel();

        public string Numero { get => numero; set => numero = value; }
        [Required] [StringLength(100)] 
        public string Obs { get => obs; set => obs = value; }
        public ClienteViewModel Cliente { get => cliente; set => cliente = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Id_cliente { get => id_cliente; set => id_cliente = value; }

              
    } 
    
    
}