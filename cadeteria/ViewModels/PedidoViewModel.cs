using AutoMapper;
using cadeteria.Models;
using System.ComponentModel.DataAnnotations;

namespace VuiwModels
{

    class PedidoViewModel
    {
        private string numero ,obs;
        private string estado;
        int idCadete;
        int idCliente;
        
        //siguiendo la teoria de composicion si creo clientes desde la clase pedido este se eliminara cuando elimine el pedido
        ClienteViewModel cliente;

        public string Numero { get => numero; set => numero = value; }
        public string Obs { get => obs; set => obs = value; }
        public ClienteViewModel Cliente { get => cliente; set => cliente = value; }
        public string Estado { get => estado; set => estado = value; }
        public int IdCadete { get => idCadete; set => idCadete = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
    }

    
    
}