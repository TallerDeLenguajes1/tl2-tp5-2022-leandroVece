using AutoMapper;
using cadeteria.Models;
using VuiwModels;

    public class perfilDeMapeo : Profile
    {
        public perfilDeMapeo()
        {
            CreateMap<Cadete, CadeteViewModel>().ReverseMap();
            CreateMap<Pedido,PedidoViewModel>().ReverseMap();
            CreateMap<Cliente,ClienteViewModel>().ReverseMap();
        }
    }
