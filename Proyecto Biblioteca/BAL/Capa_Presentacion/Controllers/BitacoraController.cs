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
    //Controlador BitacoraController
    [ValidarSesion]
    public class BitacoraController : Controller
    {
        //Accion para ver las auditorias
        [Acceso]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<Bitacora> listaBitacora = new List<Bitacora>();
                clsBitacora bitacora = new clsBitacora();
                var data = bitacora.ConsultarBitacora().ToList();
                foreach (var item in data)
                {
                    Bitacora modelo = new Bitacora();
                    modelo.Id = item.Id;
                    modelo.Controlador = item.Controlador;
                    modelo.Metodo = item.Metodo;
                    modelo.Mensaje = item.Mensaje;
                    modelo.Usuario = item.Usuario;
                    modelo.Fecha = (DateTime)item.Fecha;
                    modelo.Tipo = (int)item.Tipo;

                    listaBitacora.Add(modelo);
                }

                return View(listaBitacora);
            }
            catch (Exception ex)
            {
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}