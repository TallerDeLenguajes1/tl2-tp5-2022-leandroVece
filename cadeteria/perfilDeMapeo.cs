using AutoMapper;
using cadeteria.Models;
using VuiwModels;

    public class perfilDeMapeo : Profile
    {
        public perfilDeMapeo()
        {
            CreateMap<Usuario, UserViewModel>().ReverseMap();
            CreateMap<Usuario, UserLoginViewModel>().ReverseMap();
            CreateMap<Usuario, UserUpdateViewModel>().ReverseMap();

            CreateMap<Cadete, CadeteViewModel>().ReverseMap();
            CreateMap<Cadete,CadeteUpdateViewModel>().ReverseMap();

            CreateMap<Pedido,PedidoViewModel>().ReverseMap();
            CreateMap<Cliente,ClienteViewModel>().ReverseMap();
        }
    }
