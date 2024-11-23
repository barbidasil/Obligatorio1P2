using Microsoft.AspNetCore.Mvc;
using Obligatorio2.Models;
using System.Diagnostics;

namespace Obligatorio2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
