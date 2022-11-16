using AutoMapper;
using cadeteria.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.SQLite;

namespace VuiwModels
{

    class PedidoViewModel
    {
        private string numero ,obs;
        private string estado;
        
        //siguiendo la teoria de composicion si creo clientes desde la clase pedido este se eliminara cuando elimine el pedido
        ClienteViewModel cliente = new ClienteViewModel();

        public string Numero { get => numero; set => numero = value; }
        [Required] [StringLength(100)] 
        public string Obs { get => obs; set => obs = value; }
        public ClienteViewModel Cliente { get => cliente; set => cliente = value; }
        public string Estado { get => estado; set => estado = value; }

        public List<Pedido> GetPedido(){

            var conection = Mapper.conexion();
            conection.Open();

            var queryString = "Select * From pedidos";
            var comando = new SQLiteCommand(queryString,conection);
            List<Pedido> lista = new List<Pedido>();
            using (var rader = comando.ExecuteReader())
            {
                while (rader.Read())
                {
                    Pedido aux = new Pedido(rader.GetString(0),rader.GetString(1),rader.GetString(2));
                    lista.Add(aux);
                }
                conection.Close();
                return lista;
            }
        }
        public Pedido GetPedidoById(string Numero){
            Pedido nuevo;
            var conection = Mapper.conexion();
            conection.Open();

            var queryString = "Select * From pedidos Where id_pedido =" + Numero;
            var comando = new SQLiteCommand(queryString,conection);
            using (var rader = comando.ExecuteReader())
            {
                rader.Read();
                nuevo = new Pedido(rader.GetString(0),rader.GetString(1),rader.GetString(2));
                conection.Close();
                return nuevo;
            }
        }

         public void Update(Pedido nuevo){

            var connection = Mapper.conexion();
            connection.Open();
            var queryString = string.Format("UPDATE pedidos SET obs = '{0}', estado = '{1}' WHERE id_pedido = {2};", nuevo.Obs,nuevo.Estado, nuevo.Numero);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();

        }
        public void UpdateEstado(Pedido nuevo){

            var connection = Mapper.conexion();
            connection.Open();
            var queryString = string.Format("UPDATE pedidos SET  estado = '{0}' WHERE id_pedido = {1};", nuevo.Estado, nuevo.Numero);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();

        } 
        public void Delete(string numero){
            var connection = Mapper.conexion();
            connection.Open();
            var queryString = string.Format("Delete From pedidos Where id_pedido = {0};", numero);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();

        } 
        public void Create(Pedido nuevo){
            var connection = Mapper.conexion();
            connection.Open();
            var queryString = string.Format("Insert Into pedidos (obj,estado) Values ('{0}','{1}');", nuevo.Obs, nuevo.Estado);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();

        }
              
    } 
    
    
}