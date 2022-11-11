using AutoMapper;
using cadeteria.Models;
using System.ComponentModel.DataAnnotations;

namespace VuiwModels
{

    class CyPViewModel
    {
        private List<PedidoViewModel> listaPedido;

        private List<CadeteViewModel> listaCadete;

        public CyPViewModel()
        {
            this.listaPedido = new List<PedidoViewModel>();
            this.listaCadete = new List<CadeteViewModel>();
        }

        public List<PedidoViewModel> ListaPedido { get => listaPedido; set => listaPedido = value; }
        public List<CadeteViewModel> ListaCadete { get => listaCadete; set => listaCadete = value; }
    }

    
    
}