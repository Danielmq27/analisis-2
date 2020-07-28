using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class AuditoriaFormularioCIIEController : Controller
    {
        // GET: AuditoriaFormularioCIIE
        public ActionResult Index()
        {
            try
            {
                List<AuditoriaFormularioCIIE> listaAuditoriaCIIE = new List<AuditoriaFormularioCIIE>();
                clsAuditoriaFormularioCIIE formularioCIIE = new clsAuditoriaFormularioCIIE();
                var data = formularioCIIE.ConsultarAuditoriasFormularioCIIE();
                foreach (var item in data)
                {
                    AuditoriaFormularioCIIE modelo = new AuditoriaFormularioCIIE();
                    modelo.Id = Convert.ToInt32(item.Id);
                    modelo.CodigoCIIE = item.codigoCIIE;
                    modelo.Fecha = (DateTime)item.fecha;
                    modelo.Accion = item.accion;
                    modelo.Usuario = item.usuarioBD;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Telefono = (int)item.telefono;
                    modelo.Email = item.email;
                    modelo.TipoDespacho = item.tipoDespacho;
                    modelo.Fraccion = item.fraccion;
                    modelo.EspecificacionDespacho = item.especificacionDespacho;
                    modelo.UsoInformacion = item.usoInformacion;
                    modelo.GeneroSolicitante = item.generoSolicitante;
                    modelo.GeneroSolicitante = item.generoSolicitante;
                    modelo.Estado = item.estado;
                    modelo.EspecificacionConsulta = item.especificacionConsulta;
                    modelo.TipoConsulta = item.tipoConsulta;
                    modelo.Estado = item.estado;

                    listaAuditoriaCIIE.Add(modelo);
                }
                return View(listaAuditoriaCIIE);
            }
            catch
            {
                return RedirectToAction("Roles", "Index");
            }
        }

        public ActionResult Detalles(int Id)
        {
            try
            {
                clsAuditoriaFormularioCIIE formularioCIIE = new clsAuditoriaFormularioCIIE();
                var dato = formularioCIIE.ConsultarAuditoriaFormularioCIIE(Id);
                AuditoriaFormularioCIIE modelo = new AuditoriaFormularioCIIE();
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoCIIE = dato[0].codigoCIIE;
                modelo.Fecha = (DateTime)dato[0].fecha;
                modelo.Accion = dato[0].accion;
                modelo.Usuario = dato[0].usuarioBD;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = (int)dato[0].telefono;
                modelo.Email = dato[0].email;
                modelo.TipoDespacho = dato[0].tipoDespacho;
                modelo.Fraccion = dato[0].fraccion;
                modelo.EspecificacionDespacho = dato[0].especificacionDespacho;
                modelo.UsoInformacion = dato[0].usoInformacion;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                modelo.Estado = dato[0].estado;
                modelo.EspecificacionConsulta = dato[0].especificacionConsulta;
                modelo.TipoConsulta = dato[0].tipoConsulta;
                modelo.Estado = dato[0].estado;
                return View(modelo);
            }
            catch
            {
                return RedirectToAction("Roles", "Index");
            }
        }
    }
}