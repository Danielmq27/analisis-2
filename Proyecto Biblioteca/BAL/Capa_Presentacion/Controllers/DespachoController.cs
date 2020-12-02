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
    public class DespachoController : Controller
    {
        // GET: Despacho
        public ActionResult Index()
        {
            try
            {
                List<Despacho> lista = new List<Despacho>();
                clsDespacho Despacho = new clsDespacho();
                var data = Despacho.ConsultarDespachos().ToList();
                foreach (var item in data)
                {
                    Despacho modelo = new Despacho();
                    modelo.Id = item.Id;
                    modelo.Nombre = item.Nombre;
                    modelo.Descripcion = item.Descripcion;

                    lista.Add(modelo);
                }
                return View(lista);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("Despacho", "Index", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        [HttpPost]
        public ActionResult Agregar(string Nombre, string Descripcion)
        {
            try
            {
                clsDespacho Despacho = new clsDespacho();
                bool resultado = Despacho.AgregarDespacho(Nombre, Descripcion);
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
                bitacora.AgregarBitacora("Despacho", "Agregar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para eliminar Despacho
        [Acceso]
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                clsDespacho Despacho = new clsDespacho();
                bool resultado = Despacho.EliminarDespacho(Id);
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
                bitacora.AgregarBitacora("Despacho", "Eliminar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}