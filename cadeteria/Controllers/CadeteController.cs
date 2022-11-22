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

    VuiwModels.Helpers helpers = new VuiwModels.Helpers();


    public CadeteController(ILogger<CadeteController> logger, IMapper mapper, ICadeteRepository cadeteRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _cadeteRepository = cadeteRepository;
    }

    
    public IActionResult Index()
    {
        _cadeteRepository.GetCadete();
        var lista = _mapper.Map<List<CadeteUpdateViewModel>>(_cadeteRepository.GetCadete());
        return View(lista);
    }

    public RedirectToActionResult delete(int Id)
    {
        _cadeteRepository.Delete(Id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Create(CadeteViewModel nuevo)
    {
        if (ModelState.IsValid)
        {
            var cadete = _mapper.Map<Cadete>(nuevo);
            _cadeteRepository.Create(cadete);
            var lista = _mapper.Map<List<CadeteViewModel>>(_cadeteRepository.GetCadete());
            return RedirectToAction("Index");
        }
        return RedirectToAction("Alta");
    }
    public IActionResult Alta()
    {
        
        return View();
    }

    public IActionResult Edit(int id)
    {
        
        var cadete = _mapper.Map<CadeteUpdateViewModel>(_cadeteRepository.GetCadeteById(id));
        return View(cadete);
    }

    public IActionResult VerPedidos(int id){

        helpers.ListaPedido = _mapper.Map<List<PedidoViewModel>>(helpers.GetPedidoCadeteById(id));
        return View(helpers.ListaPedido);
    }

    

    

    [HttpPost]
    public RedirectToActionResult update(CadeteUpdateViewModel datosActualizado)
    {
        if (ModelState.IsValid)
        {
            var cadete = _mapper.Map<Cadete>(datosActualizado);
            _cadeteRepository.Update(cadete);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
