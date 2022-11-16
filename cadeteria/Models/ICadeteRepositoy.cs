using Microsoft.AspNetCore.Mvc.RazorPages;
using cadeteria.Models;

namespace DependencyInjectionNET6Demo.Pages;

public interface ICadeteRepositoy
{
    string update();
    string delete();
    string create();

    



}