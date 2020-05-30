using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            try
            {
                List<Rol> listaRoles = new List<Rol>();
                clsRoles rol = new clsRoles();
                var data = rol.ConsultarRoles().ToList();

                foreach (var item in data)
                {
                    Rol modelo = new Rol();
                    modelo.IdRol = Convert.ToInt32(item.Id_Rol);
                    modelo.Nombre_Rol = item.Nombre_Rol;
                    modelo.Descripcion = item.Descripcion;

                    listaRoles.Add(modelo);

                }
                return View(listaRoles);
            }
            catch
            {
                return RedirectToAction("NotFound", "Error");
            }
        }
    }
}
