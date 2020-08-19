using Capa_Logica;
using Capa_Presentacion.Filters;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    [ValidarSesion]
    //Controlador RolController
    public class RolController : Controller
    {
        //Accion para ver lo roles
        [Acceso]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<Rol> listaRoles = new List<Rol>();
                clsRol rol = new clsRol();
                var data = rol.ConsultarRoles().ToList();

                foreach (var item in data)
                {
                    Rol modelo = new Rol();
                    modelo.IdRol = Convert.ToInt32(item.Id);
                    modelo.Nombre_Rol = item.nombre;
                    modelo.Descripcion = item.descripcion;

                    listaRoles.Add(modelo);

                }
                return View(listaRoles);
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}
