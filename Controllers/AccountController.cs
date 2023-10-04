using Microsoft.AspNetCore.Mvc;

namespace TP09_LoginMVCyJavaScript.Controllers;

public class AccountController : Controller
{

    public IActionResult Login(){
        ViewBag.ListaUsuarios = BD.LoginUsuario();
        return View();
    }

    public IActionResult Registro(){
        ViewBag.Usuario = BD.ObtenerUsuario();
        return View();
    }

    // public IActionResult Registración(Usuario user){
    //     BD.CrearUsuario(user);
    //     ViewBag.Usuario = BD.ObtenerUsuario();
    //     return View("PaginaBienvenida");
    // }



    public IActionResult GuardarRegistro(Usuario user){
        if (user.id == -1)
        {
            ViewBag.Error = "Error. Nombre no ingresado o Contraseña incorrecta";
            ViewBag.ListaCursos = BD.ObtenerUsuario();
            return View("Registro");
        } else
        {
            BD.CrearUsuario(user);
        }
        return View("PaginaBienvenida");
    }



    public IActionResult Olvide(){

        return View();
    }

    

    public IActionResult PaginaBienvenida(){

        return View();
    }



}