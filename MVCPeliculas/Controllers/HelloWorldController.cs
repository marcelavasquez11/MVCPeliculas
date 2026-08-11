using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MVCPeliculas.Controllers;

public class HelloWorldController : Controller
{
    public string Index()
    {
        return "Esta es mi acción <b> predeterminada </b>";
    }
    public string Welcome()
    {
        return "Esta es el método de acción Bienvenida...";
    }
    public string Greeting(string nombre, int id = 1)
    {
        return HtmlEncoder.Default.Encode($"Hola {nombre}, ID: {id}");
    }
}