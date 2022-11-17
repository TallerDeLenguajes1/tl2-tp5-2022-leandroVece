using AutoMapper;
using cadeteria.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.SQLite;

namespace VuiwModels
{

    class Mapper
    {
        private List<PedidoViewModel> listaPedido;

        private List<CadeteViewModel> listaCadete;

        public Mapper()
        {
            this.listaPedido = new List<PedidoViewModel>();
            this.listaCadete = new List<CadeteViewModel>();
        }

        public List<PedidoViewModel> ListaPedido { get => listaPedido; set => listaPedido = value; }
        public List<CadeteViewModel> ListaCadete { get => listaCadete; set => listaCadete = value; }

        public static SQLiteConnection conexion(){
            var cadenaConexion = @"Data Source = cadeteria.db;version=3";
            var conection = new SQLiteConnection(cadenaConexion);
            
            return conection;
        }

        public void GetPedidoCadete(){

            var conection = conexion();
            conection.Open();

            var queryString = "Select * from cadetes Inner Join cadetePedido using (id_cadete) inner Join pedidos using (id_pedido);";
            var comando = new SQLiteCommand(queryString,conection);
            List<string> lista = new List<string>();
            using (var rader = comando.ExecuteReader())
            {
                while (rader.Read())
                {
                    //lista.Add(rader.GetString(0));  //AQUI ESTA EL PROBLEMA
                    Console.WriteLine(rader.GetInt32(0));
                    
                }
                conection.Close();
            }
        }

        public void GetPedidoCadeteById(int id){

            var conection = conexion();
            conection.Open();

            var queryString = "Select * from cadetes Inner Join cadetePedido using (id_cadete) inner Join pedidos using (id_pedido) Where cadetes.Id_cadete =" +id;
            var comando = new SQLiteCommand(queryString,conection);
            List<string> lista = new List<string>();
            using (var rader = comando.ExecuteReader())
            {
                while (rader.Read())
                {
                    Console.WriteLine("LLEGO");
                    //lista.Add(rader.GetString(0));  //AQUI ESTA EL PROBLEMA
                    Console.WriteLine(rader.GetInt32(0));
                    
                }
                conection.Close();
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

        public void deleteClientePedido(string numero){
            var connection = Mapper.conexion();
            connection.Open();
            var queryString = string.Format("Delete From clientePedido Where id_cadete = {0};", numero);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();
            
        }
        public void CreateClientePedido(int id1,int id2){
            var connection = Mapper.conexion();
            connection.Open();
            var queryString = string.Format("Insert Into clientePedido (id_cliente,id_pedido) Values ('{0}','{1}',);",id1,id2);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();
        }


    }

   
}