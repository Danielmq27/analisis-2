using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class AuditoriaPrestamoPermanenteController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<AuditoriaPrestamoPermanente> listaAuditoriaPrestamoPermanente = new List<AuditoriaPrestamoPermanente>();
                clsAuditoriaPrestamoPermanente auditoriaPrestamoPermanente = new clsAuditoriaPrestamoPermanente();
                var data = auditoriaPrestamoPermanente.ConsultarAuditoriasPrestamoPermanente();
                foreach (var item in data)
                {
                    AuditoriaPrestamoPermanente modelo = new AuditoriaPrestamoPermanente();
                    modelo.Id = Convert.ToInt32(item.Id);
                    modelo.CodigoPrestamoPermanente = item.codigoPrestamoPermanente;
                    modelo.Fecha = (DateTime)item.fecha;
                    modelo.Accion = item.accion;
                    modelo.Usuario = item.usuarioBD;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Despacho = item.despacho;
                    modelo.Telefono = (int)item.telefono;
                    modelo.Extension = item.extension;
                    modelo.InformacionAdicional = item.informacionAdicional;
                    modelo.GeneroSolicitante = item.generoSolicictante;
                    modelo.FechaPrestamo = (DateTime)item.fechaPrestamo;
                    modelo.Estado = item.estado;

                    listaAuditoriaPrestamoPermanente.Add(modelo);
                }
                return View(listaAuditoriaPrestamoPermanente);
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
                clsAuditoriaPrestamoPermanente auditoriaPrestamoPermanente = new clsAuditoriaPrestamoPermanente();
                var dato = auditoriaPrestamoPermanente.ConsultarAuditoriaPrestamoPermanente(Id);
                AuditoriaPrestamoPermanente modelo = new AuditoriaPrestamoPermanente();
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoPrestamoPermanente = dato[0].codigoPrestamoPermanente;
                modelo.Fecha = (DateTime)dato[0].fecha;
                modelo.Accion = dato[0].accion;
                modelo.Usuario = dato[0].usuarioBD;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Despacho = dato[0].despacho;
                modelo.Telefono = (int)dato[0].telefono;
                modelo.Extension = dato[0].extension;
                modelo.InformacionAdicional = dato[0].informacionAdicional;
                modelo.GeneroSolicitante = dato[0].generoSolicictante;
                modelo.FechaPrestamo = (DateTime)dato[0].fechaPrestamo;
                modelo.Estado = dato[0].estado;

                return View(modelo);
            }
            catch
            {
                return RedirectToAction("505", "Error");
            }
        }
    }
}