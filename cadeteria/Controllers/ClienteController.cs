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
    private readonly IClienteRepository _clienteRepository;
    List<ClienteViewModel> db = new List<ClienteViewModel>();


    VuiwModels.Helpers PAndC = new VuiwModels.Helpers();

    public ClienteController(ILogger<ClienteController> logger, IMapper mapper,IClienteRepository clienteRepository )
    {
        _logger = logger;
        _mapper = mapper;
        _clienteRepository = _clienteRepository;
    }

    
    public IActionResult Index()
    {

        var lista = _clienteRepository.GetCliente();
        db = _mapper.Map<List<ClienteViewModel>>(lista);

        return View(db);
    }

    [HttpPost]
    public IActionResult Create(string nombre,string direccion, string telefono,string datosReferencia)
    {
        if (ModelState.IsValid)
        {
            Cliente nuevoC = new Cliente(0,nombre,direccion,telefono,datosReferencia);
            _clienteRepository.Create(nuevoC);
            return RedirectToAction("Index");
            
        }
            return RedirectToAction("Index");
    }

    public RedirectToActionResult delete(int id)
    {
        //borrar el pedido y la tabla clientePedido con el id del pedido
        _clienteRepository.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var cliente = _mapper.Map<ClienteViewModel>(_clienteRepository.GetClienteById(id));
        return View(cliente);
    }

    [HttpPost]
    public IActionResult update(int id,string nombre,string direccion, string telefono,string referencia)
    {
        if (ModelState.IsValid)
        {
            Cliente nuevoC = new Cliente(id,nombre,direccion,telefono,referencia);
            _clienteRepository.Update(nuevoC);
            return RedirectToAction("Index");
            
        }
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
