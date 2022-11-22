namespace cadeteria.Models;

public class Cadeteria
{
    //relacion de compossicion con la clase cadete
        private string nombre;
        private string telefono;

        public string Nombre { get => nombre; set => nombre = value; }

        public string Telefono { get => telefono; set => telefono = value; }
         public List<Cadete> ListaCadete { get => listaCadete; set => listaCadete = value; }

        List<Cadete> listaCadete = new List<Cadete>(); 

        public Cadeteria(){
             
        }
}
