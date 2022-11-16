using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cadeteria.Models;
using VuiwModels;
using AutoMapper;

namespace cadeteria.Controllers;

public class PedidoController : Controller
{
    private readonly ILogger<PedidoController> _logger;
    IMapper _mapper;
    PedidoViewModel modelPedido = new PedidoViewModel();

    ClienteViewModel modelCliente = new ClienteViewModel();
    List<PedidoViewModel> db = new List<PedidoViewModel>();


    VuiwModels.Mapper PAndC = new VuiwModels.Mapper();

    public PedidoController(ILogger<PedidoController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    
    public IActionResult Index()
    {

        var lista = PAndC.GetPedidoCliente();
        db = _mapper.Map<List<PedidoViewModel>>(lista);

        return View(db);
    }

    [HttpPost]
    public IActionResult Index(string Obs, string nombre,string direccion, string telefono,string referencia)
    {
        
        Cliente nuevoC = new Cliente(0,nombre,direccion,telefono,referencia);
        Pedido nuevoP = new Pedido("0",Obs,"pendiente");
        Console.WriteLine(Obs);
        Console.WriteLine(nombre);
        Console.WriteLine(direccion);
        Console.WriteLine(telefono);
        //modelPedido.Create(nuevoP);
        //modelCliente.Create(nuevoC);

        var lista = PAndC.GetPedidoCliente();
        db = _mapper.Map<List<PedidoViewModel>>(lista);
        return View(db);
    }

    public RedirectToActionResult delete(string Numero)
    {
        //borrar el pedido y la tabla clientePedido con el id del pedido
        modelPedido.Delete(Numero);
        PAndC.deleteClientePedido(Numero);
        return RedirectToAction("Index");
    }

    public IActionResult Edit()
    {
        return View();
    }

    [HttpPost]
    public IActionResult update(string numero, int id, string obj, string estado, string nombre,string direccion, string telefono,string referencia)
    {
        Cliente nuevoC = new Cliente(id,nombre,direccion,telefono,referencia);
        Pedido nuevoP = new Pedido(numero,obj,estado);
        modelPedido.Update(nuevoP);
        modelCliente.Update(nuevoC);
       return RedirectToAction("Index");
    }

    public IActionResult Alta()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
