using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public IActionResult Logout()
    {
        HttpContext.Session.Clear(); // borra todo lo de la sesión
        return RedirectToAction("Login", "Persona");
    }

    public IActionResult Login()
    {
        return View();
    }
}
