using AutoMapper;
using cadeteria.Models;
using System.ComponentModel.DataAnnotations;

namespace VuiwModels
{

    class CadeteriaViewModel
    {
        List<PedidoViewModel> listaPedido = new List<PedidoViewModel>();

        List<CadeteUpdateViewModel> listaCadete = new List<CadeteUpdateViewModel>(); 
    }
    
}