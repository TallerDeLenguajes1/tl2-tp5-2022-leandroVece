using System.Data.SQLite;
using AutoMapper;
using cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cadeteria;

public class PedidoRepository : IPedidoRepository 
{
    public PedidoRepository ()
    { 
        
    }

    public  SQLiteConnection Conexion(){
            var cadenaConexion = @"Data Source = cadeteria.db;version=3";
            return new SQLiteConnection(cadenaConexion);
    }
    public List<Pedido> GetPedido(){

            var conection = Conexion();
            conection.Open();

            var queryString = "Select * From pedidos";
            var comando = new SQLiteCommand(queryString,conection);
            List<Pedido> lista = new List<Pedido>();
            using (var rader = comando.ExecuteReader())
            {
                while (rader.Read())
                {
                    Pedido aux = new Pedido(rader.GetInt32(0).ToString(),rader.GetString(1),rader.GetString(2));
                    lista.Add(aux);
                }
                conection.Close();
                return lista;
            }
        }
        public Pedido GetPedidoById(string Numero){
            Pedido nuevo;
            var conection = Conexion();
            conection.Open();

            var queryString = "Select * From pedidos Where id_pedido =" + Numero;
            var comando = new SQLiteCommand(queryString,conection);
            using (var rader = comando.ExecuteReader())
            {
                rader.Read();
                nuevo = new Pedido(rader.GetInt32(0).ToString(),rader.GetString(1),rader.GetString(2));
                conection.Close();
                return nuevo;
            }
        }

         public void Update(Pedido nuevo){

            var connection = Conexion();
            connection.Open();
            var queryString = string.Format("UPDATE pedidos SET obj = '{0}', estado = '{1}' WHERE id_pedido = {2};", nuevo.Obs,nuevo.Estado, nuevo.Numero);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();

        }
        public void Delete(string numero){
            var connection = Conexion();
            connection.Open();
            var queryString = string.Format("Delete From pedidos Where id_pedido = {0};", numero);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();

        } 
        public void Create(Pedido nuevo, int Id_cliente){

            
            var connection = Conexion();
            connection.Open();
            var queryString = string.Format("Insert Into pedidos (obj,estado,id_cliente) Values ('{0}','{1}','{2}');", nuevo.Obs, nuevo.Estado,Id_cliente);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();
        }

}