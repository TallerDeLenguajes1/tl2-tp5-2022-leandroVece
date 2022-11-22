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
    private readonly IPedidoRepository _pedidoRepository;

    List<PedidoViewModel> db = new List<PedidoViewModel>();

    VuiwModels.Helpers helpers = new VuiwModels.Helpers();

    public PedidoController(ILogger<PedidoController> logger, IMapper mapper, IPedidoRepository pedidoRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _pedidoRepository = pedidoRepository;
    }

    
    public IActionResult Index()
    {

        var lista = helpers.GetPedidoCliente();
        db = _mapper.Map<List<PedidoViewModel>>(lista);

        return View(db);
    }

    [HttpPost]
    public IActionResult Create(int Id_cliente,string Obs)
    {
        if (!ModelState.IsValid)
        {
            Pedido nuevoP = new Pedido("0",Obs,"pendiente");
            _pedidoRepository.Create(nuevoP,Id_cliente);
            var lista = helpers.GetPedidoCliente();
            db = _mapper.Map<List<PedidoViewModel>>(lista);
            return RedirectToAction("Index");
            
        }
            return RedirectToAction("Index");
    }

    public RedirectToActionResult delete(string Numero)
    {
        //borrar el pedido y la tabla clientePedido con el id del pedido
        _pedidoRepository.Delete(Numero);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(string numero)
    {
        var pedido = _mapper.Map<PedidoViewModel>(_pedidoRepository.GetPedidoById(numero));
        return View(pedido);
    }

    [HttpPost]
    public IActionResult update(string Numero, string Obs, string Estado)
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine(Numero);
            Pedido nuevoP = new Pedido(Numero,Obs,Estado);
            _pedidoRepository.Update(nuevoP);
            return RedirectToAction("Index");
            
        }
            return RedirectToAction("Index");
    }

    public IActionResult Entregar(string Numero,string Obs ){
        var Actualizar = new Pedido(Numero,Obs,"Entregado");
        _pedidoRepository.Update(Actualizar);
        return RedirectToAction("Index");
    }

    public IActionResult Eliminar(string Numero,string Obs ){
        var Actualizar = new Pedido(Numero,Obs,"pendiente");
        _pedidoRepository.Update(Actualizar);
        helpers.DeleteCadetePedido(Numero);
        return RedirectToAction("Index");
    }


    public IActionResult AsignarPedido(int id){
        helpers.Id_cadete = id;
        var lista = helpers.GetPedidoCliente();
        helpers.ListaPedido = _mapper.Map<List<PedidoViewModel>>(lista);
        return View(helpers);
    }
     public IActionResult TomarPedido(string Numero, int Id){
        helpers.CreateCadetePedido(Numero,Id);
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
