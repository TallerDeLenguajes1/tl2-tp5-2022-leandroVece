using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cadeteria.Models;
using VuiwModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace cadeteria.Controllers;

public class HomeController : SessionController
{
    private readonly ILogger<HomeController> _logger;

    IMapper _mapper;
    private readonly DataContext _db;

    public HomeController(ILogger<HomeController> logger, IMapper Mapper)
    {
        _logger = logger;
        _mapper = Mapper;

    }


    public IActionResult Index()
    {
        if (!IsSesionIniciada())
            return RedirectToAction("Login", "User");
        return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
