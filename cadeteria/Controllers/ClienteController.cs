using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cadeteria.Models;
using VuiwModels;
using AutoMapper;

namespace cadeteria.Controllers;

public class ClienteController : SessionController
{
    private readonly ILogger<ClienteController> _logger;
    IMapper _mapper;
    private readonly DataContext _db;
    List<ClienteViewModel> db = new List<ClienteViewModel>();


    VuiwModels.Helpers PAndC = new VuiwModels.Helpers();

    public ClienteController(ILogger<ClienteController> logger, IMapper mapper, DataContext db)
    {
        _logger = logger;
        _mapper = mapper;
        _db = db;

    }


    public IActionResult Index()
    {

        var lista = _db.Cliente.GetCliente();
        db = _mapper.Map<List<ClienteViewModel>>(lista);

        return View(db);
    }

    [HttpPost]
    public IActionResult Create(string nombre, string direccion, string telefono, string datosReferencia)
    {
        if (ModelState.IsValid)
        {
            Cliente nuevoC = new Cliente(0, nombre, direccion, telefono, datosReferencia);
            _db.Cliente.Create(nuevoC);
            return RedirectToAction("Index");

        }
        return RedirectToAction("Index");
    }

    public RedirectToActionResult delete(int id)
    {
        //borrar el pedido y la tabla clientePedido con el id del pedido
        _db.Cliente.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var cliente = _mapper.Map<ClienteViewModel>(_db.Cliente.GetClienteById(id));
        return View(cliente);
    }

    [HttpPost]
    public IActionResult update(ClienteViewModel cliente)
    {
        if (ModelState.IsValid)
        {
            var nuevoC = _mapper.Map<Cliente>(cliente);
            _db.Cliente.Update(nuevoC);
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
