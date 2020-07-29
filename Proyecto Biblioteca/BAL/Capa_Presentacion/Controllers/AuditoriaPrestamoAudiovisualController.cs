using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class AuditoriaPrestamoAudiovisualController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<AuditoriaPrestamoAudiovisual> listaAuditoriaPrestamoAudiovisual = new List<AuditoriaPrestamoAudiovisual>();
                clsAuditoriaPrestamoAudiovisual auditoriaPrestamoAudiovisual = new clsAuditoriaPrestamoAudiovisual();
                var data = auditoriaPrestamoAudiovisual.ConsultarAuditoriasPrestamoAudiovisual();
                foreach (var item in data)
                {
                    AuditoriaPrestamoAudiovisual modelo = new AuditoriaPrestamoAudiovisual();
                    modelo.Id = Convert.ToInt32(item.Id);
                    modelo.CodigoPrestamoAudiovisual = item.codigoPrestamoAudiovisual;
                    modelo.Fecha = (DateTime)item.fecha;
                    modelo.Accion = item.accion;
                    modelo.Usuario = item.usuarioBD;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Departamento = item.departamento;
                    modelo.NombreActividad = item.nombreActividad;
                    modelo.Categoria = item.categoria;
                    modelo.EspecificacionCategoria = item.especificacionCategoria;
                    modelo.Ubicacion = item.ubicacion;
                    modelo.HoraInicio = (DateTime)item.horaInicio;
                    modelo.HoraFinal = (DateTime)item.horaFin;
                    modelo.Descripcion = item.descripcion;
                    modelo.EquipoRequerido = item.equipoRequerido;
                    modelo.Aforo = (int)item.aforo;
                    modelo.GeneroSolicitante = item.generoSolicitante;

                    listaAuditoriaPrestamoAudiovisual.Add(modelo);
                }
                return View(listaAuditoriaPrestamoAudiovisual);
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
                clsAuditoriaPrestamoAudiovisual auditoriaPrestamoAudiovisual = new clsAuditoriaPrestamoAudiovisual();
                var dato = auditoriaPrestamoAudiovisual.ConsultarAuditoriaPrestamoAudiovisual(Id);
                AuditoriaPrestamoAudiovisual modelo = new AuditoriaPrestamoAudiovisual();
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoPrestamoAudiovisual = dato[0].codigoPrestamoAudiovisual;
                modelo.Fecha = (DateTime)dato[0].fecha;
                modelo.Accion = dato[0].accion;
                modelo.Usuario = dato[0].usuarioBD;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Departamento = dato[0].departamento;
                modelo.NombreActividad = dato[0].nombreActividad;
                modelo.Categoria = dato[0].categoria;
                modelo.EspecificacionCategoria = dato[0].especificacionCategoria;
                modelo.Ubicacion = dato[0].ubicacion;
                modelo.HoraInicio = (DateTime)dato[0].horaInicio;
                modelo.HoraFinal = (DateTime)dato[0].horaFin;
                modelo.Descripcion = dato[0].descripcion;
                modelo.EquipoRequerido = dato[0].equipoRequerido;
                modelo.Aforo = (int)dato[0].aforo;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;

                return View(modelo);
            }
            catch
            {
                return RedirectToAction("Roles", "Index");
            }
        }
    }
}