using Microsoft.AspNetCore.Mvc;

namespace TP09_LoginMVCyJavaScript.Controllers;

public class AccountController : Controller
{

    public IActionResult Login(){
        ViewBag.ListaUsuarios = BD.LoginUsuario();
        ViewBag.Usuario = BD.ObtenerUsuario();
        ViewBag.error = "";
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
        return RedirectToAction("Pbienvenida", "Account");
    }

    [HttpPost]
    public IActionResult SesionIniciada(string NombreUsuario, string Contraseña)
    {
        if(BD.ValidacionUsuario(NombreUsuario,Contraseña))
        {
            ViewBag.Usuario = BD.ObtenerUsuario();
            Console.WriteLine("pasobien");
            ViewBag.destacado = "Account";
            return RedirectToAction("Pbienvenida", "Account");
        }
        else
        {
            ViewBag.Usuario = BD.ObtenerUsuario();
            Console.WriteLine("pasomal");
            ViewBag.error = "Nombre de usuario o contraseña no válido. Intentá de nuevo.";
            return View("Login", "Account");
        }  
    }




    public IActionResult Olvide(){
        ViewBag.Usuario = BD.ObtenerUsuario();
        return View();
    }

    public IActionResult OlvideLaContraseña(string mailUser, string contra){
        Usuario usuarioVerificado = BD.VerificacionUsuarioMail(mailUser);
        if(usuarioVerificado == null){
            Console.WriteLine("Entro error verificacion");
            // ViewBag.MensajeError = "Ese nombre de usuario no existe";
            return View("Olvide", "Account");
        }
        else
        {
            Console.WriteLine("NUEVA CONTRASEÑA: " + contra);
            BD.ContraseñaActualizar(mailUser, contra);
            return View("Login", "Account");
        }

        // BD.ActualizarContraseña(mailUser,contra);
        // return View("Login", "Account");
    }

    

    public IActionResult PaginaBienvenida(){

        return View();
    }



}