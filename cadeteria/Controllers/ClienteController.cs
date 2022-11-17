using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cadeteria.Models;
using VuiwModels;
using AutoMapper;

namespace cadeteria.Controllers;

public class ClienteController : Controller
{
    private readonly ILogger<ClienteController> _logger;
    IMapper _mapper;

    ClienteViewModel temp = new ClienteViewModel();
    List<ClienteViewModel> db = new List<ClienteViewModel>();


    VuiwModels.Mapper PAndC = new VuiwModels.Mapper();

    public ClienteController(ILogger<ClienteController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    
    public IActionResult Index()
    {

        var lista = temp.GetCliente();
        db = _mapper.Map<List<ClienteViewModel>>(lista);

        return View(db);
    }

    [HttpPost]
    public IActionResult Create(string nombre,string direccion, string telefono,string datosReferencia)
    {
        Cliente nuevoC = new Cliente(0,nombre,direccion,telefono,datosReferencia);
        temp.Create(nuevoC);
        return RedirectToAction("Index");
    }

    public RedirectToActionResult delete(int id)
    {
        //borrar el pedido y la tabla clientePedido con el id del pedido
        temp.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var cliente = _mapper.Map<ClienteViewModel>(temp.GetClienteById(id));
        return View(cliente);
    }

    [HttpPost]
    public IActionResult update(int id,string nombre,string direccion, string telefono,string referencia)
    {
        Cliente nuevoC = new Cliente(id,nombre,direccion,telefono,referencia);
        temp.Update(nuevoC);
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
