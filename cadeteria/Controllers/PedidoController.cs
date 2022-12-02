using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cadeteria.Models;
using VuiwModels;
using AutoMapper;

namespace cadeteria.Controllers;

public class PedidoController : SessionController
{
    private readonly ILogger<PedidoController> _logger;
    IMapper _mapper;
    private readonly DataContext _db;

    List<PedidoViewModel> pedido = new List<PedidoViewModel>();

    VuiwModels.Helpers helpers = new VuiwModels.Helpers();

    public PedidoController(ILogger<PedidoController> logger, IMapper mapper, DataContext db)
    {
        _logger = logger;
        _mapper = mapper;
        _db = db;


    }


    public IActionResult Index()
    {

        var lista = helpers.GetPedidoCliente();
        pedido = _mapper.Map<List<PedidoViewModel>>(lista);

        return View(pedido);
    }

    [HttpPost]
    public IActionResult Create(int Id_cliente, string Obs)
    {
        if (!ModelState.IsValid)
        {
            Pedido nuevoP = new Pedido("0", Obs, "pendiente");
            _db.Pedido.Create(nuevoP, Id_cliente);
            var lista = helpers.GetPedidoCliente();
            pedido = _mapper.Map<List<PedidoViewModel>>(lista);
            return RedirectToAction("Index");

        }
        return RedirectToAction("Index");
    }

    public RedirectToActionResult delete(string Numero)
    {
        //borrar el pedido y la tabla clientePedido con el id del pedido
        _db.Pedido.Delete(Numero);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(string numero)
    {
        var pedido = _mapper.Map<PedidoViewModel>(_db.Pedido.GetPedidoById(numero));
        return View(pedido);
    }

    [HttpPost]
    public IActionResult update(string Numero, string Obs, string Estado)
    {
        if (ModelState.IsValid)
        {
            Pedido nuevoP = new Pedido(Numero, Obs, Estado);
            _db.Pedido.Update(nuevoP);
            return RedirectToAction("Index");

        }
        return RedirectToAction("Index");
    }

    public IActionResult Entregar(string Numero, string Obs)
    {
        var Actualizar = new Pedido(Numero, Obs, "Entregado");
        _db.Pedido.Update(Actualizar);
        return RedirectToAction("Index");
    }

    public IActionResult Eliminar(string Numero, string Obs)
    {
        var Actualizar = new Pedido(Numero, Obs, "pendiente");
        _db.Pedido.Update(Actualizar);
        helpers.DeleteCadetePedido(Numero);
        return RedirectToAction("Index");
    }


    public IActionResult AsignarPedido(int id)
    {
        helpers.Id_cadete = id;
        var lista = helpers.GetPedidoCliente();
        helpers.ListaPedido = _mapper.Map<List<PedidoViewModel>>(lista);
        return View(helpers);
    }
    public IActionResult TomarPedido(string Numero, int Id)
    {
        helpers.CreateCadetePedido(Numero, Id);
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
