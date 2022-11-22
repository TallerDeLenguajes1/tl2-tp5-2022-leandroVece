using System.Data.SQLite;
using AutoMapper;
using cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cadeteria;

public class CadeteRepository : ICadeteRepository
{
    public CadeteRepository()
    { 
        
    }

    public  SQLiteConnection Conexion(){
            var cadenaConexion = @"Data Source = cadeteria.db;version=3";
            return new SQLiteConnection(cadenaConexion);
    }
    public List<Cadete> GetCadete(){

        var connection = Conexion();
        connection.Open();

        var queryString = "Select * From cadetes";
        var comando = new SQLiteCommand(queryString,connection);
        List<Cadete> lista = new List<Cadete>();
        using (var reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                Cadete aux = new Cadete(reader.GetInt32(0), reader.GetString(1),reader.GetString(2),Convert.ToString(reader.GetInt32(3)));
                lista.Add(aux);
            }
            connection.Close();
        }
        return lista;
    }

    public Cadete GetCadeteById(int id){
        var connection =Conexion();
        connection.Open();

        var queryString = "Select * From cadetes Where id_cadete =" +id;
        var comando = new SQLiteCommand(queryString,connection);
        using (var reader = comando.ExecuteReader())
        {
            reader.Read();
            Cadete aux = new Cadete(reader.GetInt32(0), reader.GetString(1),reader.GetString(2), Convert.ToString(reader.GetInt32(3)));
            connection.Close();
        return aux;
        }

    }

    public void Update(Cadete cadete){

        var connection = Conexion();
        connection.Open();
        var queryString = string.Format("UPDATE cadetes SET nombre = '{0}', direccion = '{1}', telefono = '{2}' WHERE id_cadete = {3};", cadete.Nombre,cadete.Direccion,cadete.Telefono,cadete.Id);
        var comando = new SQLiteCommand(queryString,connection);
        comando.ExecuteNonQuery();
        connection.Close();

    } 
    public void Delete(int id){
        var connection = Conexion();
        connection.Open();
        var queryString = string.Format("Delete From cadetes Where id_cadete = {0};", id);
        var comando = new SQLiteCommand(queryString,connection);
        comando.ExecuteNonQuery();
        connection.Close();

    } 
    public void Create(Cadete cadete){
        
        var connection = Conexion();
        connection.Open();
        var queryString = string.Format("Insert Into cadetes (nombre,direccion,telefono) Values ('{0}','{1}','{2}');", cadete.Nombre,cadete.Direccion,cadete.Telefono);
        var comando = new SQLiteCommand(queryString,connection);
        comando.ExecuteNonQuery();
        connection.Close();

    }

}