
namespace cadeteria.Models;

public class DbModel
    {
        private List<Pedido> ListaPedido;
        private Cadeteria Cadeteria;

        public List<Pedido> ListaPedido1 { get => ListaPedido; set => ListaPedido = value; }
        public Cadeteria Cadeteria1 { get => Cadeteria; set => Cadeteria = value; }

         public DbModel(){
                ListaPedido = new List<Pedido>();
                Cadeteria = new Cadeteria("Eternos","6542112");
        }
        /*

        //////// LOGICA PARA GUARDAR \\\\\\\\\\
        public void savePedido(Pedido obj,int idCliente){

            string path = @"csv\pedido.csv";
                            
            try
            {
                if(!File.Exists(path)){

                    FileStream Archivo = new FileStream(path, FileMode.OpenOrCreate);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            strWrite.WriteLine("{0},{1},{2},{3}",obj.Numero, obj.Obs, obj.Estado, idCliente);
                            strWrite.Close();
                        }              
                }
                else
                {
                    FileStream Archivo = new FileStream(path, FileMode.Append);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            strWrite.WriteLine("{0},{1},{2},{3}",obj.Numero, obj.Obs, obj.Estado, idCliente);
                            strWrite.Close();
                        }
                }
                        
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);            
            }
        }

        public void saveCliente(Cliente obj){

            string path = @"csv\cliente.csv";
                            
            try
            {
                if(!File.Exists(path)){

                    FileStream Archivo = new FileStream(path, FileMode.OpenOrCreate);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            strWrite.WriteLine("{0},{1},{2},{3},{4}",obj.Id, obj.Nombre, obj.Direccion, obj.Telefono, obj.DatosReferencia);
                            strWrite.Close();
                        }              
                }
                else
                {
                    FileStream Archivo = new FileStream(path, FileMode.Append);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            strWrite.WriteLine("{0},{1},{2},{3},{4}",obj.Id, obj.Nombre, obj.Direccion, obj.Telefono, obj.DatosReferencia);
                            strWrite.Close();
                        }
                }
                        
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);            
            }
        }

        public void saveCadete(Cadete obj){

            string path = @"csv\cadete.csv";
                            
            try
            {
                if(!File.Exists(path)){

                    FileStream Archivo = new FileStream(path, FileMode.OpenOrCreate);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            strWrite.WriteLine("{0},{1},{2},{3}",obj.Id, obj.Nombre, obj.Direccion, obj.Telefono);
                            strWrite.Close();
                        }              
                }
                else
                {
                    FileStream Archivo = new FileStream(path, FileMode.Append);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            strWrite.WriteLine("{0},{1},{2},{3}",obj.Id, obj.Nombre, obj.Direccion, obj.Telefono);
                            strWrite.Close();
                        }
                }
                        
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);            
            }
        }

                //////// LOGICA PARA ELIMINAR \\\\\\\\\\
        public void deleteCliente(List<Cliente> clientes){

            string path = @"csv\cliente.csv";
                            
            try
            {
                if(File.Exists(path)){

                    FileStream Archivo = new FileStream(path, FileMode.Truncate);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            foreach (var item in clientes)
                            {
                                strWrite.WriteLine("{0},{1},{2},{3},{4}",item.Id, item.Nombre, item.Direccion, item.Telefono, item.DatosReferencia);  
                            }
                                strWrite.Close();
                        }              
                }
                        
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);            
            }
        }

        public void deleteCadete(List<Cadete> lista){

            string path = @"csv\cadete.csv";
                            
            try
            {
                if(File.Exists(path)){

                    FileStream Archivo = new FileStream(path, FileMode.Truncate);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            foreach (var item in lista)
                            {
                                strWrite.WriteLine("{0},{1},{2},{3}",item.Id, item.Nombre, item.Direccion, item.Telefono);

                            }
                                strWrite.Close();  
                        }              
                }
                        
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);            
            }
        }

        public void deletePedido(List<Pedido> lista){

            string path = @"csv\pedido.csv";
                            
            try
            {
                if(File.Exists(path)){

                    FileStream Archivo = new FileStream(path, FileMode.Truncate);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            foreach (var item in lista)
                            {
                                strWrite.WriteLine("{0},{1},{2},{3},{4},{5}",item.Numero, item.Obs, item.Estado, item.Cliente.Id,item.IdCliente,item.IdCadete);
                            }
                                strWrite.Close();  
                        }              
                }
                        
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);            
            }
        }


        //////// LOGICA PARA OBTENER \\\\\\\\\\
        public List<Cadete> getCadete(){  

            string path = @"csv\cadete.csv";
            List<Cadete> lista = new List<Cadete>();
            try
            {
                if(File.Exists(path)){
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        Cadete aux = new Cadete(0,"","","");
                        string [] array = line.Split(',');
                        aux.Id = Convert.ToInt32(array[0]);
                        aux.Nombre = array[1];
                        aux.Direccion = array[2];
                        aux.Telefono = array[3];
                        lista.Add(aux);                       
                    }
                return lista;
                }
                return lista;
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);
                return lista;
            }
        }

        public List<Pedido> getDatepedidos(List<Cliente>clientes){
            
            string path = @"csv\pedido.csv";
            List<Pedido> lista = new List<Pedido>();
            try
            {
                if(File.Exists(path)){
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        Pedido aux = new Pedido("0","","");
                        string [] array = line.Split(',');
                        aux.Numero = array[0];
                        aux.Obs = array[1];
                        aux.Estado = array[2];
                        aux.Cliente = clientes.Find(x => (x.Id).ToString() == array[3]);
                        aux.IdCadete= int.Parse(array[4]);
                        lista.Add(aux);                       
                    }
                return lista;
                }
                return lista;
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);
                return lista;
            }
        }

        public List<Cliente> getDateCliente(){
            
            string path = @"csv\cliente.csv";
            List<Cliente> lista = new List<Cliente>();
            try
            {
                if(File.Exists(path)){
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        Cliente aux = new Cliente(0,"","","","");
                        string [] array = line.Split(',');
                        aux.Id = Convert.ToInt32(array[0]);
                        aux.Nombre = array[1];
                        aux.Direccion = array[2];
                        aux.Telefono = array[3];
                        aux.DatosReferencia = array[4];
                        lista.Add(aux);                       
                    }
                return lista;
                }
                return lista;
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);
                return lista;
            }
        }

        public Cadete getCadeteId(int id){  

            Cadete aux = new Cadete(0,"","","");
            string path = @"csv\cadete.csv";
            try
            {
                if(File.Exists(path)){
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        string [] array = line.Split(',');
                        
                        if (id == Convert.ToInt32(array[0]))
                        {    
                            
                            aux.Id = Convert.ToInt32(array[0]);
                            aux.Nombre = array[1];
                            aux.Direccion = array[2];
                            aux.Telefono = array[3];   
                            return aux;                 
                        }
                    }
                }
                return aux;
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);
                return aux;
            }
        }

    */
    }

            

    

