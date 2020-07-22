using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class RolController : Controller
    {

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
                return RedirectToAction("Index", "IniciarSesion");
            }
        }
    }
}
