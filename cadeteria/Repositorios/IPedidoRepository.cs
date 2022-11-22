using cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;


namespace cadeteria;


public interface IPedidoRepository
{
    SQLiteConnection Conexion();
    public void Update(Pedido pedido);
    public void Delete(string numero);
    public void Create(Pedido pedido,int Id_cliente);

    List<Pedido> GetPedido();
    Pedido GetPedidoById(string Numero);

}

