using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Logica;
using Capa_Entidades;

namespace Capa_Presentacion.Controllers
{
    public class RolController : Controller
    {
        RolL rol = new RolL();
        // GET: Rol
        public ActionResult Index()
        {
            return View(rol.ConsultarRoles());
        }
    }
}