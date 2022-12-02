using System.Data.SQLite;
using AutoMapper;
using cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cadeteria;

public class ClienteRepository : IClienteRepository
{
    public ClienteRepository()
    { 
        
    }

    public  SQLiteConnection Conexion(){
            var cadenaConexion = @"Data Source = cadeteria.db;version=3";
            return new SQLiteConnection(cadenaConexion);
    }
    public List<Cliente> GetCliente(){

            var conection = Conexion();
            conection.Open();

            var queryString = "Select * From clientes";
            var comando = new SQLiteCommand(queryString,conection);
            List<Cliente> lista = new List<Cliente>();
            using (var reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    Cliente aux = new Cliente(reader.GetInt32(0), reader.GetString(1),reader.GetString(2),Convert.ToString(reader.GetInt32(3)),reader.GetString(4));
                    lista.Add(aux);
                }
                conection.Close();
                return lista;
            }
        }  

        public Cliente GetClienteById(int id){
            Cliente cliente;
            var conection = Conexion();
            conection.Open();

            var queryString = "Select * From clientes Where id_cliente = " +id;
            var comando = new SQLiteCommand(queryString,conection);
            using (var reader = comando.ExecuteReader())
            {
                reader.Read();
                cliente = new Cliente(reader.GetInt32(0),reader.GetString(1),reader.GetString(2),reader.GetInt32(3).ToString(),reader.GetString(4));
                conection.Close();
            }

            return cliente;
        } 

        public void Update(Cliente cliente){

            var connection = Conexion();
            connection.Open();
            var queryString = string.Format("UPDATE clientes SET nombre = '{0}', direccion = '{1}', telefono = '{2}', referencia = '{3}' WHERE id_cliente = {4};", cliente.Nombre,cliente.Direccion,cliente.Telefono,cliente.DatosReferencia, cliente.Id);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();

        } 
        public void Delete(int id){
            var connection = Conexion();
            connection.Open();
            var queryString = string.Format("Delete From clientes Where id_cliente = {0};", id);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();

        } 
        public void Create(Cliente cliente){
            var connection = Conexion();
            connection.Open();
            var queryString = string.Format("Insert Into clientes (nombre,direccion,telefono,referencia) Values ('{0}','{1}','{2}','{3}');", cliente.Nombre,cliente.Direccion,cliente.Telefono,cliente.DatosReferencia);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();

        }

}