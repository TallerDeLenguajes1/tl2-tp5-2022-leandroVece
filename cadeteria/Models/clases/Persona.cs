namespace cadeteria.Models;

public class Persona
{
    private int id;
    private string nombre,direccion,telefono;

    public Persona(int id, string name, string adress, string phone)
    {
        this.id = id;
        this.nombre = name;
        this.direccion = adress;
        this.telefono = phone;
    }

    public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

    
}
