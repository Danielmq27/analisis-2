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
    public class FraccionController : Controller
    {
        // GET: Fraccion
        public ActionResult Index()
        {
            try
            {
                List<Fraccion> listaFracciones = new List<Fraccion>();
                clsFraccion fraccion = new clsFraccion();
                var data = fraccion.ConsultarFracciones().ToList();
                foreach (var item in data)
                {
                    Fraccion modelo = new Fraccion();
                    modelo.Id = item.Id;
                    modelo.Nombre = item.Nombre;
                    modelo.Descripcion = item.Descripcion;

                    listaFracciones.Add(modelo);
                }
                return View(listaFracciones);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("Fraccion", "Index", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        [HttpPost]
        public ActionResult Agregar(string Nombre, string Descripcion)
        {
            try
            {
                clsFraccion fraccion = new clsFraccion();
                bool resultado = fraccion.AgregarFraccion(Nombre, Descripcion);
                if (resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //Pagina de Error
                    return RedirectToAction("Error404", "Error");
                }
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("Fraccion", "Agregar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para eliminar un formularios del CIIE
        [Acceso]
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                clsFraccion fraccion = new clsFraccion();
                bool resultado = fraccion.EliminarFraccion(Id);
                if (resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //Pagina de Error
                    return RedirectToAction("Error500", "Error");
                }
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("Fraccion", "Eliminar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}