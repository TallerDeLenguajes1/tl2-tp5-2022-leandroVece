using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cadeteria.Models;
using VuiwModels;
using AutoMapper;
using System.Data.SQLite;

namespace cadeteria.Controllers;

public class CadeteController : Controller
{
    private readonly ILogger<CadeteController> _logger;

    private readonly ICadeteRepository _cadeteRepository;
    IMapper _mapper;
    CadeteViewModel temp = new CadeteViewModel();
    CadeteriaViewModel db = new CadeteriaViewModel();

    VuiwModels.Mapper CyP = new VuiwModels.Mapper();

    public CadeteController(ILogger<CadeteController> logger, IMapper mapper, ICadeteRepository cadeteRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _cadeteRepository = cadeteRepository;
    }

    
    public IActionResult Index()
    {
        _cadeteRepository.GetCadete();
        var lista = _mapper.Map<List<CadeteViewModel>>(_cadeteRepository.GetCadete());
        db.ListaCadete = lista;
        return View(db.ListaCadete);
    }

    public RedirectToActionResult delete(int Id)
    {
        temp.Delete(Id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Index(string Nombre,string Direccion, string Telefono)
    {
        if (ModelState.IsValid)
        {
            temp.Create(new Cadete(0,Nombre,Direccion,Telefono));
            var lista = _mapper.Map<List<CadeteViewModel>>(temp.GetCadete());
            db.ListaCadete = lista;
            return View(db.ListaCadete);
        }
        return View("Index");
    }
    public IActionResult Alta()
    {
        
        return View();
    }

    public IActionResult Edit(int id)
    {
        
        var cadete = _mapper.Map<CadeteViewModel>(temp.getCadeteById(id));
        return View(cadete);
    }



    [HttpPost]
    public RedirectToActionResult update(int id,string nombre,string direccion,string telefono )
    {
        if (ModelState.IsValid)
        {
            temp.Update(new Cadete(id,nombre,direccion,telefono));
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }


     public IActionResult AsignarPedido()
    {
        /*var listaC = _mapper.Map<List<CadeteViewModel>>(temp.GetCadete());
        var listaP = _mapper.Map<List<PedidoViewModel>>(temp.getDatepedidos(temp.getDateCliente()));
        
        CyP.ListaCadete = listaC;
        CyP.ListaPedido = listaP;     */   

        return View(CyP);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
