using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaSemana2Rethinked.Controllers
{
    public class ControladorUno : Controller
    {
        public IActionResult VistaUno()
        {
            return View();
        }

        public IActionResult VistaDos()
        {
            return View();
        }
    }
}
