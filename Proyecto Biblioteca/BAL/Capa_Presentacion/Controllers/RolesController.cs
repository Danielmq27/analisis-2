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

        public ActionResult Nuevo()
        {
            try
            {
                return View();
            }
            catch
            {
                return RedirectToAction("NotFound", "Error");
            }

        }

        [HttpPost]
        public ActionResult Nuevo(Rol rol)
        {
            try
            {
                clsRoles objRol = new clsRoles();
                bool resultado = objRol.AgregarRol(rol.Nombre_Rol, rol.Descripcion);
                if (resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Nuevo", "Roles");
                }
            }
            catch
            {
                return RedirectToAction("Nuevo", "Roles");
            }
        }

        public ActionResult Actualizar(int Id)
        {
            try
            {
                clsRoles rol = new clsRoles();
                var dato = rol.ConsultarRol(Id);
                Rol modelo = new Rol();
                modelo.IdRol = dato[0].Id;
                modelo.Nombre_Rol = dato[0].nombre;
                modelo.Descripcion = dato[0].descripcion;
                return View(modelo);
            }
            catch
            {
                return RedirectToAction("504", "Error");
            }
        }

        [HttpPost]
        public ActionResult Actualizar(int Id, Rol rol)
        {
            try
            {
                clsRoles objRol = new clsRoles();
                bool resultado = objRol.ActualizarRol(rol.IdRol, rol.Nombre_Rol, rol.Descripcion);
                if (resultado)
                {
                    return RedirectToAction("Index");
                } else
                {
                    return RedirectToAction("404", "Error");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("504", "Error");
            }
        }

        public ActionResult Eliminar(int Id)
        {
            try
            {
                clsRoles objRol = new clsRoles();
                bool resultado = objRol.EliminarRol(Id);
                if (resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("404", "Error");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("505", "Error");
            }
        }
    }
}
