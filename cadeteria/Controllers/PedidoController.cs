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
    DbModel temp = new DbModel();
    List<PedidoViewModel> db = new List<PedidoViewModel>();

    public PedidoController(ILogger<PedidoController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    
    public IActionResult Index()
    {

        var lista = temp.getDatepedidos(temp.getDateCliente());
        db = _mapper.Map<List<PedidoViewModel>>(lista);

        return View(db);
    }

    public RedirectToActionResult delete(string Numero,int Id)
    {
        //con el valor que traigo de la vista separo de la lista el elemiento a eliminar y lo borro
        //el metodo de borrar es truncando el viejo archivo csv

        List<Cliente> clientes = temp.getDateCliente().FindAll(x => x.Id != Id);
        List<Pedido> pedidos = temp.getDatepedidos(clientes).FindAll(x=> x.Numero != Numero);

        temp.deletePedido(pedidos);
        temp.deleteCliente(clientes);

        return RedirectToAction("Index");
    }

    public IActionResult actualizar(string Numero)
    {
        //con el valor que traigo de la vista separo de la lista el elemiento a eliminar y lo borro
        //el metodo de borrar es truncando el viejo archivo csv

        var lista = temp.getDatepedidos(temp.getDateCliente());
        db = _mapper.Map<List<PedidoViewModel>>(lista);
        PedidoViewModel pedido = db.Find(x=> x.Numero == Numero);
        return View(pedido);
    }

    [HttpPost]
    public IActionResult Index(string obj, string nombre,string direccion, string telefono,string referencia)
    {
        List<Cliente> listaC = temp.getDateCliente();
        int idCliente = listaC[listaC.Count -1].Id +1;

        List<Pedido> listaP = temp.getDatepedidos(temp.getDateCliente());
        int idpedido = Convert.ToInt32(listaP[listaP.Count - 1].Numero) + 1;

        Pedido newPedido = new Pedido(idpedido.ToString(),obj,"pendiente");
        Cliente newCliente = new Cliente(idCliente,nombre,direccion,telefono,referencia);

        temp.savePedido(newPedido,idCliente);
        temp.saveCliente(newCliente);

        var lista = temp.getDatepedidos(temp.getDateCliente());
        db = _mapper.Map<List<PedidoViewModel>>(lista);
        return View(db);
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
