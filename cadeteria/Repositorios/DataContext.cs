using System.Data.SQLite;
using AutoMapper;
using cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace cadeteria;


public class DataContext
{
    private readonly IUserRepository user;
    private readonly ICadeteRepository cadete;

    private readonly IClienteRepository cliente;

    private readonly IPedidoRepository pedido;


    DataContext(IUserRepository user, ICadeteRepository cadete, IClienteRepository cliente, IPedidoRepository pedido)
    {
        this.User = user;
        this.Cadete = cadete;
        this.Cliente = cliente;
        this.Pedido = pedido;
    }

    public IUserRepository User { get; set; }
    public ICadeteRepository Cadete { get; set; }
    public IClienteRepository Cliente { get; set; }
    public IPedidoRepository Pedido { get; set; }
}
