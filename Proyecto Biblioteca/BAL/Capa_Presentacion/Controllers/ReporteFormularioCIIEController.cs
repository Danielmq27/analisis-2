using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class ReporteFormularioCIIEController : Controller
    {
        public ActionResult Administrador()
        {
            return View();
        }

        public ActionResult Editar()
        {
            return View();
        }

        public ActionResult CantidadUsuariosFechaIngreso(DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteFormularioCIIE reporte = new clsReporteFormularioCIIE();
            var obj = reporte.CantidadTipoUsuarioFechaIngreso(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteFormularioCIIE> listaReportesFormularioCIIE = new List<ReporteFormularioCIIE>();
                var data = reporte.CantidadTipoUsuarioFechaIngreso(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReporteFormularioCIIE modelo = new ReporteFormularioCIIE();
                    modelo.tipoDespacho = item.tipoDespacho;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.Porcentaje;

                    listaReportesFormularioCIIE.Add(modelo);
                }
                Session["Reportes"] = listaReportesFormularioCIIE;
                return View(listaReportesFormularioCIIE);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Administrador");
            }
        }

        public ActionResult CantidadUsuariosFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteFormularioCIIE reporte = new clsReporteFormularioCIIE();
            var obj = reporte.CantidadTipoUsuarioFechaIngresoFechaRespuesta(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteFormularioCIIE> listaReportesFormularioCIIE = new List<ReporteFormularioCIIE>();
                var data = reporte.CantidadTipoUsuarioFechaRespuesta(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReporteFormularioCIIE modelo = new ReporteFormularioCIIE();
                    modelo.tipoDespacho = item.tipoDespacho;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.Porcentaje;

                    listaReportesFormularioCIIE.Add(modelo);
                }
                Session["Reportes"] = listaReportesFormularioCIIE;
                return View(listaReportesFormularioCIIE);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Administrador");
            }
        }

        public ActionResult CantidadUsuariosFechaIngresoFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteFormularioCIIE reporte = new clsReporteFormularioCIIE();
            var obj = reporte.CantidadTipoUsuarioFechaIngresoFechaRespuesta(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteFormularioCIIE> listaReportesFormularioCIIE = new List<ReporteFormularioCIIE>();
                var data = reporte.CantidadTipoUsuarioFechaIngresoFechaRespuesta(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReporteFormularioCIIE modelo = new ReporteFormularioCIIE();
                    modelo.tipoDespacho = item.Tipo_Usuario;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.Porcentaje;

                    listaReportesFormularioCIIE.Add(modelo);
                }
                Session["Reportes"] = listaReportesFormularioCIIE;
                return View(listaReportesFormularioCIIE);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Administrador");
            }
        }
    }
}