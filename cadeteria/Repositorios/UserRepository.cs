using System.Data.SQLite;
using AutoMapper;
using cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cadeteria;

public class UserRepository : IUserRepository
{
    public UserRepository()
    { 
        
    }

    public  SQLiteConnection Conexion(){
            var cadenaConexion = @"Data Source = cadeteria.db;version=3";
            return new SQLiteConnection(cadenaConexion);
    }
    public List<Usuario> GetUsuario(){

        var connection = Conexion();
        connection.Open();

        var queryString = "Select * From usuarios";
        var comando = new SQLiteCommand(queryString,connection);
        List<Usuario> lista = new List<Usuario>();
        using (var reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                Usuario aux = new Usuario(reader.GetInt32(0), reader.GetString(1),reader.GetString(2), reader.GetString(3));
                lista.Add(aux);
            }
            connection.Close();
        }
        return lista;
    }

    public Usuario GetUsuarioById(int id){
        var connection =Conexion();
        connection.Open();

        var queryString = "Select * From usuarios Where id_user =" +id;
        var comando = new SQLiteCommand(queryString,connection);
        using (var reader = comando.ExecuteReader())
        {
            reader.Read();
            Usuario aux = new Usuario(reader.GetInt32(0), reader.GetString(1),reader.GetString(2), reader.GetString(3));
            connection.Close();
        return aux;
        }


    }
    public Usuario GetUsuarioByLogin(string Username, string password){
        try
        {
            var connection =Conexion();
            connection.Open();

            var queryString = string.Format("Select * From usuarios Where usuario = '{0}' And password = '{1}';",Username,password );
            var comando = new SQLiteCommand(queryString,connection);
            using (var reader = comando.ExecuteReader())
            {
                reader.Read();
                Usuario aux = new Usuario(reader.GetInt32(0), reader.GetString(1),reader.GetString(2), reader.GetString(3));
                connection.Close();
            return aux;
            }
            
        }
        catch (System.Exception)
        {
            return null;
        }

    }

    public void Update(Usuario user){

        var connection = Conexion();
        connection.Open();
        var queryString = string.Format("UPDATE usuarios SET usuario = '{0}', password = '{1}', rol = '{2}' WHERE id_user = {3};", user.Nombre,user.Contra,user.Rol,user.Id);
        var comando = new SQLiteCommand(queryString,connection);
        comando.ExecuteNonQuery();
        connection.Close();

    } 
    public void Delete(int id){
        var connection = Conexion();
        connection.Open();
        var queryString = string.Format("Delete From usuarios Where id_user = {0};", id);
        var comando = new SQLiteCommand(queryString,connection);
        comando.ExecuteNonQuery();
        connection.Close();

    } 
    public void Create(Usuario user){
        
        var connection = Conexion();
        connection.Open();
        var queryString = string.Format("Insert Into usuarios (usuario,password,rol) Values ('{0}','{1}','{2}');", user.Nombre,user.Contra,user.Rol);
        var comando = new SQLiteCommand(queryString,connection);
        comando.ExecuteNonQuery();
        connection.Close();

    }

}