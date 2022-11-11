using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cadeteria.Models;
using VuiwModels;
using AutoMapper;

namespace cadeteria.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    DbModel db = new DbModel();
    IMapper _mapper;

    public HomeController(ILogger<HomeController> logger, IMapper Mapper)
    {
        _logger = logger;
        _mapper = Mapper;

    }

    
    public IActionResult Index()
    {

        db.Cadeteria1.ListaCadete = db.getCadete();
        db.ListaPedido1 = db.getDatepedidos(db.getDateCliente());
        return View(db);
    }

    public RedirectToActionResult delete(string Numero,int Id)
    {
        //con el valor que traigo de la vista separo de la lista el elemiento a eliminar y lo borro
        //el metodo de borrar es truncando el viejo archivo csv

        List<Cliente> clientes = db.getDateCliente().FindAll(x => x.Id != Id);
        List<Pedido> pedidos = db.getDatepedidos(clientes).FindAll(x=> x.Numero != Numero);

        db.deletePedido(pedidos);
        db.deleteCliente(clientes);

        Console.WriteLine(pedidos.Count);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Index(string obj, string nombre,string direccion, string telefono,string referencia)
    {
        List<Cliente> listaC = db.getDateCliente();
        int idCliente = listaC[listaC.Count -1].Id +1;

        List<Pedido> listaP = db.getDatepedidos(db.getDateCliente());
        int idpedido = Convert.ToInt32(listaP[listaP.Count - 1].Numero) + 1;

        Pedido newPedido = new Pedido(idpedido.ToString(),obj,"pendiente");
        Cliente newCliente = new Cliente(idCliente,nombre,direccion,telefono,referencia);

        db.savePedido(newPedido,idCliente);
        db.saveCliente(newCliente);

        db.Cadeteria1.ListaCadete = db.getCadete();
        db.ListaPedido1 = db.getDatepedidos(db.getDateCliente());
        return View(db);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
