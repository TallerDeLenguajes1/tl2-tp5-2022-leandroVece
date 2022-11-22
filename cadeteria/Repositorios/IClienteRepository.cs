using cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;


namespace cadeteria;


public interface IClienteRepository
{
    SQLiteConnection Conexion();
    public void Update(Cliente cliente);
    public void Delete(int id);
    public void Create(Cliente cliente);

    List<Cliente> GetCliente();
    Cliente GetClienteById(int id);

}

