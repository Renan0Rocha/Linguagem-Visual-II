using Microsoft.AspNetCore.Mvc;
using DataAnnotations.Models;

namespace DataAnnotations.Controllers
{
    public class ClientePremiumController : Controller
    {
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(ClientePremiumViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Sucesso");
            }

            return View(model);
        }

        public IActionResult Sucesso()
        {
            return View();
        }
    }
}
