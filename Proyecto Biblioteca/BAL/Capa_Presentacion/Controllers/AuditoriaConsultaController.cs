using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class AuditoriaConsultaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<AuditoriaConsulta> listaAuditoriaConsulta = new List<AuditoriaConsulta>();
                clsAuditoriaConsulta auditoriaConsulta = new clsAuditoriaConsulta();
                var data = auditoriaConsulta.ConsultarAuditoriasConsulta();
                foreach (var item in data)
                {
                    AuditoriaConsulta modelo = new AuditoriaConsulta();
                    modelo.Id = Convert.ToInt32(item.Id);
                    modelo.CodigoConsulta = item.codigoConsulta;
                    modelo.Fecha = (DateTime)item.fecha;
                    modelo.Accion = item.accion;
                    modelo.Usuario = item.usuarioBD;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Telefono = (int)item.telefono;
                    modelo.Email = item.email;
                    modelo.Asunto = item.asunto;
                    modelo.Descripcion = item.descripcion;
                    modelo.MetodoIngreso = item.metodoIngreso;
                    modelo.Respuesta = item.respuesta;
                    modelo.GeneroSolicitante = item.generoSolicitante;
                    modelo.Estado = item.estado;

                    listaAuditoriaConsulta.Add(modelo);
                }
                return View(listaAuditoriaConsulta);
            }
            catch
            {
                return RedirectToAction("505", "Error");
            }
        }

        public ActionResult Detalles(int Id)
        {
            try
            {
                clsAuditoriaConsulta auditoriaConsulta = new clsAuditoriaConsulta();
                var dato = auditoriaConsulta.ConsultarAuditoriaConsulta(Id);
                AuditoriaConsulta modelo = new AuditoriaConsulta();
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoConsulta = dato[0].codigoConsulta;
                modelo.Fecha = (DateTime)dato[0].fecha;
                modelo.Accion = dato[0].accion;
                modelo.Usuario = dato[0].usuarioBD;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = (int)dato[0].telefono;
                modelo.Email = dato[0].email;
                modelo.Asunto = dato[0].asunto;
                modelo.Descripcion = dato[0].descripcion;
                modelo.MetodoIngreso = dato[0].metodoIngreso;
                modelo.Respuesta = dato[0].respuesta;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
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