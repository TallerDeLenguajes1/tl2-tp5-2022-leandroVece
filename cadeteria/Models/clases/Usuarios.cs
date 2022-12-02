namespace cadeteria.Models;  

    public class Usuario
    {
        private int id;
        private string nombre;
        private string contra;
        private string rol;
        

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Contra { get => contra; set => contra = value; }
        public string Rol { get => rol; set => rol = value; }

        public Usuario()
        {
            
        }

        public Usuario(string nombre, string password, string rol)
        {
            Id = id;
            this.Nombre = nombre;
            this.Contra = password;
            this.Rol = rol;

        }

        public Usuario(int id, string nombre, string password, string rol)
        {
            Id = id;
            this.Nombre = nombre;
            this.Contra = password;
            this.Rol = rol;

        }

    }