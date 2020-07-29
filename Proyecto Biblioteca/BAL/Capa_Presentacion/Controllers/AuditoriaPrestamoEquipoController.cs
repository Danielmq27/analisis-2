using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class AuditoriaPrestamoEquipoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<AuditoriaPrestamoEquipo> listaAuditoriaPrestamoEquipo = new List<AuditoriaPrestamoEquipo>();
                clsAuditoriaPrestamoEquipo auditoriaPrestamoEquipo = new clsAuditoriaPrestamoEquipo();
                var data = auditoriaPrestamoEquipo.ConsultarAuditoriasPrestamoEquipo();
                foreach (var item in data)
                {
                    AuditoriaPrestamoEquipo modelo = new AuditoriaPrestamoEquipo();
                    modelo.Id = Convert.ToInt32(item.Id);
                    modelo.CodigoPrestamoEquipo = item.codigoPrestamoEquipo;
                    modelo.Fecha = (DateTime)item.fecha;
                    modelo.Accion = item.accion;
                    modelo.Usuario = item.usuarioBD;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.CedulaSolicitante = item.cedulaSolicitante;
                    modelo.Departamento = item.departamento;
                    modelo.TipoEquipo = item.tipoEquipo;
                    modelo.Implementos = item.implementos;
                    modelo.EspecificacionImplementos = item.especificacionImplementos;
                    modelo.GeneroSolicitante = item.generoSolicictante;
                    modelo.Estado = item.estado;

                    listaAuditoriaPrestamoEquipo.Add(modelo);
                }
                return View(listaAuditoriaPrestamoEquipo);
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
                clsAuditoriaPrestamoEquipo auditoriaPrestamoEquipo = new clsAuditoriaPrestamoEquipo();
                var dato = auditoriaPrestamoEquipo.ConsultarAuditoriaPrestamoEquipo(Id);
                AuditoriaPrestamoEquipo modelo = new AuditoriaPrestamoEquipo();
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoPrestamoEquipo = dato[0].codigoPrestamoEquipo;
                modelo.Fecha = (DateTime)dato[0].fecha;
                modelo.Accion = dato[0].accion;
                modelo.Usuario = dato[0].usuarioBD;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.CedulaSolicitante = dato[0].cedulaSolicitante;
                modelo.Departamento = dato[0].departamento;
                modelo.TipoEquipo = dato[0].tipoEquipo;
                modelo.Implementos = dato[0].implementos;
                modelo.EspecificacionImplementos = dato[0].especificacionImplementos;
                modelo.GeneroSolicitante = dato[0].generoSolicictante;
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