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
    public IActionResult Create(int Id_cliente,string Obs)
    {
        
        Pedido nuevoP = new Pedido("0",Obs,"pendiente");
        nuevoP.Cliente.Id = Id_cliente;
        modelPedido.Create(nuevoP,Id_cliente);
        var lista = PAndC.GetPedidoCliente();
        db = _mapper.Map<List<PedidoViewModel>>(lista);
        return RedirectToAction("Index");
    }

    public RedirectToActionResult delete(string Numero)
    {
        //borrar el pedido y la tabla clientePedido con el id del pedido
        modelPedido.Delete(Numero);
        return RedirectToAction("Index");
    }

    public IActionResult Edit()
    {
        return View();
    }

    [HttpPost]
    public IActionResult update(string numero, string obj, string estado)
    {

        Pedido nuevoP = new Pedido(numero,obj,estado);
        modelPedido.Update(nuevoP);
       return RedirectToAction("Index");
    }

    public IActionResult Alta(int id)
    {
        ViewBag.id = id;
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
