using cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;


namespace cadeteria;


public interface IUserRepository
{
    SQLiteConnection Conexion();
    public void Update(Usuario user);
    public void Delete(int id);
    public void Create(Usuario user);

    List<Usuario> GetUsuario();
    Usuario GetUsuarioById(int id);
    Usuario GetUsuarioByLogin(string Username, string password);


}

