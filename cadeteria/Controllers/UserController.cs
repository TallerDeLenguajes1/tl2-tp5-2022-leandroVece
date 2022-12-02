using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cadeteria.Models;
using VuiwModels;
using AutoMapper;

namespace cadeteria.Controllers;

public class UserController : SessionController
{
    private readonly ILogger<UserController> _logger;
    private readonly IDataContext _db;

    IMapper _mapper;
    //CadeteriaViewModel db = new CadeteriaViewModel();

    public UserController(ILogger<UserController> logger, IMapper Mapper, IDataContext db)
    {
        _logger = logger;
        _mapper = Mapper;
        _db = db;

    }
    public IActionResult Login(UserLoginViewModel user = null)
    {
        // solo pueden entrar al login quienes no estan en sesion
        if (user == null)
        {
            user.Message = "";
            return View(user);
        }
        return View(user);

        return RedirectToAction("Index");
    }



    public IActionResult Validar(UserLoginViewModel user)
    {
        var getUser = _db.User.GetUsuarioByLogin(user.Nombre, user.Password);
        if (getUser != null)
        {
            var sesion = _mapper.Map<UserLoginViewModel>(getUser);
            SetSesion(getUser); // iniciar sesion
            //_logger.LogInformation($"LOGUEO DE USUARIO - ID:{getUser.Id}, Nombre:{getUser.Nombre}");

            return RedirectToAction("Index", "Home");
        }
        else
        {
            user.Message = "Contraseña o Usuarios incorrectos";

            return RedirectToAction("Login", user);
        }
        return RedirectToAction("Login");

    }
    public IActionResult Alta()
    {

        return View();
    }


    [HttpPost]
    public IActionResult Create(UserViewModel usuario)
    {
        if (!ModelState.IsValid)
        {
            _db.User.Create(new Usuario(usuario.Nombre, usuario.Password, "cliente"));
            return RedirectToAction("Login");
        }
        return RedirectToAction("Alta");
    }

    public IActionResult Edit(int id)
    {
        var user = _mapper.Map<UserUpdateViewModel>(_db.User.GetUsuarioById(id));
        return View(user);
    }

    public IActionResult Perfil(Usuario user)
    {
        /*switch (user.Rol)
        {
            case "cliente":


            case "cadete":

            default
        }*/
        return View();
    }


    public IActionResult CerrarSesion()
    {

        if (IsSesionIniciada())
            Logout();

        return RedirectToAction("Login");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
