namespace cadeteria.Models;

public class Pedido
{
    private string numero ,obs;
    private string estado;
    int idCliente;
    
    //siguiendo la teoria de composicion si creo clientes desde la clase pedido este se eliminara cuando elimine el pedido
    Cliente cliente;

    public Pedido(string numero, string obs, string estado){
        this.Numero = numero;
        this.Obs = obs;
        this.Estado = estado;
        cliente = new Cliente();;
    }


    public string Numero { get => numero; set => numero = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public string Estado { get => estado; set => estado = value; }

}
