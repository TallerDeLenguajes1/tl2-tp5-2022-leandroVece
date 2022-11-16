using AutoMapper;
using cadeteria.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.SQLite;

namespace VuiwModels
{

    class ClienteViewModel
    {
        private int id;
        private string nombre,direccion, telefono;

        private string datosReferencia;
        public int Id { get => id; set => id = value; }
        [Required] [StringLength(120)] 
        public string Nombre { get => nombre; set => nombre = value; }
        [Required] [StringLength(120)] 
        public string Direccion { get => direccion; set => direccion = value; }
        [Required] [StringLength(15)] 
        public string Telefono { get => telefono; set => telefono = value; }
        [Required] [StringLength(200)] 
        public string DatosReferencia { get => datosReferencia; set => datosReferencia = value; }

        public void GetCliente(){

            var conection = Mapper.conexion();
            conection.Open();

            var queryString = "Select * From clientes";
            var comando = new SQLiteCommand(queryString,conection);
            List<string> lista = new List<string>();
            using (var rader = comando.ExecuteReader())
            {
                while (rader.Read())
                {
                    lista.Add(rader.GetString(0));
                    Console.WriteLine(rader.GetString(0));
                }
                conection.Close();
            }
        }  

        public Cliente GetClienteById(int id){
            Cliente nuevo;
            var conection = Mapper.conexion();
            conection.Open();

            var queryString = "Select * From clientes Where id_cliente =" +id;
            var comando = new SQLiteCommand(queryString,conection);
            using (var rader = comando.ExecuteReader())
            {
                rader.Read();
                nuevo = new Cliente(rader.GetInt32(0),rader.GetString(1),rader.GetString(2),rader.GetString(3),rader.GetString(4));
                conection.Close();
            }

            return nuevo;
        } 

        public void Update(Cliente nuevo){

            var connection = Mapper.conexion();
            connection.Open();
            var queryString = string.Format("UPDATE clientes SET nombre = '{0}', direccion = '{1}', telefono = '{2}', referencia ='{3}' WHERE id_cadete = {4};", nuevo.Nombre,nuevo.Direccion,nuevo.Telefono,nuevo.DatosReferencia, nuevo.Id);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();

        } 
        public void Delete(int id){
            var connection = Mapper.conexion();
            connection.Open();
            var queryString = string.Format("Delete From clientes Where id_cliente = {0};", id);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();

        } 
        public void Create(Cliente nuevo){
            var connection = Mapper.conexion();
            connection.Open();
            var queryString = string.Format("Insert Into clientes (nombre,direccion,telefono,referencia) Values ('{0}','{1}','{2}','{3}');", nuevo.Nombre,nuevo.Direccion,nuevo.Telefono,nuevo.DatosReferencia);
            var comando = new SQLiteCommand(queryString,connection);
            comando.ExecuteNonQuery();
            connection.Close();

        }

    }

    
    
}