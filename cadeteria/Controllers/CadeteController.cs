using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cadeteria.Models;
using VuiwModels;
using AutoMapper;

namespace cadeteria.Controllers;

public class CadeteController : Controller
{
    private readonly ILogger<CadeteController> _logger;
    IMapper _mapper;
    DbModel temp = new DbModel();
    CadeteriaViewModel db = new CadeteriaViewModel();

    CyPViewModel CyP = new CyPViewModel();

    public CadeteController(ILogger<CadeteController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    
    public IActionResult Index()
    {

        var lista = _mapper.Map<List<CadeteViewModel>>(temp.getCadete());
        db.ListaCadete = lista;

        return View(db.ListaCadete);
    }

    public RedirectToActionResult delete(int Id)
    {
        //con el valor que traigo de la vista separo de la lista el elemiento a eliminar y lo borro
        //el metodo de borrar es truncando el viejo archivo csv
        List<Cadete> cadetes = temp.getCadete().FindAll(x => x.Id != Id);
        temp.deleteCadete(cadetes);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Index(string nombre,string direccion, string telefono)
    {
        List<Cadete> listaC = temp.getCadete();
        int id = listaC[listaC.Count -1].Id +1;

        Cadete nuevo = new Cadete(id,nombre,direccion,telefono);
        temp.saveCadete(nuevo);

        var lista = _mapper.Map<List<CadeteViewModel>>(temp.getCadete());
        db.ListaCadete = lista;        

        return View(db);
    }

    [HttpPost]
    public RedirectToActionResult Update(int id, string nombre,string direccion, string telefono)
    {
        //Yo se que no es efectivo, pero es el mejor resultado con menos cambios XD
        
        Cadete actualziarCadete = new Cadete(id,nombre,direccion,telefono);
        List<Cadete> lista = temp.getCadete();

        var elementIndex = lista.FindIndex(i => i.Id == actualziarCadete.Id);
        lista[elementIndex] = actualziarCadete;

        //como en este caso se trunca en la lista, sirve para actualizar
        temp.deleteCadete(lista);     

        return RedirectToAction("Index");
    }

    public IActionResult Alta()
    {
        return View();
    }

    public IActionResult actualizar(int Id)
    {
        var listaPedido = temp.getDatepedidos(temp.getDateCliente()).FindAll(x => x.IdCadete == Id);
        Cadete aux = temp.getCadeteId(Id);

        aux.Listpedido = listaPedido;
        CadeteViewModel cadete = _mapper.Map<CadeteViewModel>(aux);
        cadete.Listpedido = _mapper.Map<List<PedidoViewModel>>(listaPedido);

        return View(cadete);
    }

     public IActionResult AsignarPedido()
    {
        var listaC = _mapper.Map<List<CadeteViewModel>>(temp.getCadete());
        var listaP = _mapper.Map<List<PedidoViewModel>>(temp.getDatepedidos(temp.getDateCliente()));
        
        CyP.ListaCadete = listaC;
        CyP.ListaPedido = listaP;        

        return View(CyP);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
