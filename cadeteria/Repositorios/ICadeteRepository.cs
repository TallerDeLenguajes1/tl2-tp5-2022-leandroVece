using cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;


namespace cadeteria;


public interface ICadeteRepository
{
    SQLiteConnection Conexion();
    public void Update(Cadete cadete);
    public void Delete(int id);
    public void Create(Cadete cadete);

    List<Cadete> GetCadete();
    Cadete GetCadeteById(int id);

}

