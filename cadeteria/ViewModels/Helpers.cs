using AutoMapper;
using cadeteria.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.SQLite;

namespace VuiwModels
{

    class Helpers
    {

        private int id_cadete;
        private List<PedidoViewModel> listaPedido;

        public Helpers()
        {
            this.listaPedido = new List<PedidoViewModel>();
            
        }

        public List<PedidoViewModel> ListaPedido { get => listaPedido; set => listaPedido = value; }
        public int Id_cadete { get => id_cadete; set => id_cadete = value; }

        public SQLiteConnection conexion(){
            var cadenaConexion = @"Data Source = cadeteria.db;version=3";
            var conection = new SQLiteConnection(cadenaConexion);
            
            return conection;
        }

        public  List<Pedido> GetPedidoCadete(){

            var conection = conexion();
            conection.Open();

            var queryString = "Select * from cadetes Inner Join cadetePedido using (id_cadete) inner Join pedidos using (id_pedido);";
            var comando = new SQLiteCommand(queryString,conection);
            using (var reader = comando.ExecuteReader())
            {
                List<Pedido> lista = new List<Pedido>();

                while (reader.Read())
                {
                    //Console.WriteLine()
                    Pedido pedidoAux = new Pedido(reader.GetInt32(5).ToString(),reader.GetString(6),reader.GetString(7));    
                    lista.Add(pedidoAux);
                }

                conection.Close();
                return lista;
            }
        }

        public List<Pedido> GetPedidoCadeteById(int id){

            var conection = conexion();
            conection.Open();
            var queryString = "Select * from cadetes Inner Join cadetePedido using (id_cadete) inner Join pedidos using (id_pedido) Where cadetes.Id_cadete =" +id;
            var comando = new SQLiteCommand(queryString,conection);
            
            using (var reader = comando.ExecuteReader())
            {
                 List<Pedido> lista = new List<Pedido>();

                while (reader.Read())
                {
                    Pedido pedidoAux = new Pedido(reader.GetInt32(5).ToString(),reader.GetString(6),reader.GetString(7));    
                    lista.Add(pedidoAux);
                }

                conection.Close();
                return lista;
            }
            
        }

        public List<Pedido> GetPedidoCliente(){

            var conection = conexion();
            conection.Open();

            var queryString = "Select * from pedidos Inner Join clientes Where clientes.id_cliente = pedidos.id_cliente ";
            var comando = new SQLiteCommand(queryString,conection);
            List<Pedido> lista = new List<Pedido>();
            using (var rader = comando.ExecuteReader())
            {
                while (rader.Read())
                {
                    Pedido aux = new Pedido(rader.GetInt32(0).ToString(), rader.GetString(1), rader.GetString(2));
                    Cliente auxCliente = new Cliente(rader.GetInt32(4),rader.GetString(5),rader.GetString(6),rader.GetInt32(7).ToString(), rader.GetString(8));
                    aux.Cliente = auxCliente;
                    //Console.WriteLine(rader.GetInt32(4));
                    /*aux.Cliente.Id = rader.GetInt32(4);
                    aux.Cliente.Nombre = rader.GetString(5);
                    aux.Cliente.Direccion = rader.GetString(6);
                    aux.Cliente.Telefono = rader.GetInt32(7).ToString();*/  
                    lista.Add(aux);                  
                }
                conection.Close();
                return lista;
            }
        }           
        
        public Pedido GetPedidoClienteById(string numero){

            var conection = conexion();
            conection.Open();

            var queryString = "Select * from pedidos Where id_pedido =" + numero;
            var comando = new SQLiteCommand(queryString,conection);
            using (var rader = comando.ExecuteReader())
            {         
                Pedido aux = new Pedido(rader.GetInt32(0).ToString(), rader.GetString(1), rader.GetString(2));
                conection.Close();
                return aux;
            }
        } 

        public void DeleteCadetePedido(string numero){
            var connection = conexion();
            connection.Open();
            var queryString = string.Format("Delete From cadetePedido Where id_pedido = {0};", numero);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();

        }

        public void CreateCadetePedido(string numero,int id){
            var connection = conexion();
            connection.Open();
            var queryString = string.Format("Insert Into cadetePedido (id_cadete,id_pedido) Values ('{0}','{1}')", id,numero);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();

        }


    }

   
}