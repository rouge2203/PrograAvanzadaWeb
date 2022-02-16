using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaSemana2Rethinked.Controllers
{
    public class ControladorDos : Controller
    {
        public IActionResult VistaTres()
        {
            return View();
        }

        public IActionResult VistaCuatro()
        {
            return View();
        }
    }
}
