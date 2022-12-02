using System.Data.SQLite;
using AutoMapper;
using cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace cadeteria;
public interface IDataContext
{
    public IUserRepository User { get; set; }
    public ICadeteRepository Cadete { get; set; }
    public IClienteRepository Cliente { get; set; }
    public IPedidoRepository Pedido { get; set; }
}

public class DataContext:IDataContext
{
    private  IUserRepository user;
    private  ICadeteRepository cadete;

    private IClienteRepository cliente;

    private IPedidoRepository pedido;


    public DataContext(IUserRepository user)
    {
         this.User = user;
        // this.Cadete = cadete;
        // this.Cliente = cliente;
        // this.Pedido = pedido;
    }

    
    public IUserRepository User { get; set; }
    public ICadeteRepository Cadete { get; set; }
    public IClienteRepository Cliente { get; set; }
    public IPedidoRepository Pedido { get; set; }
   
}
