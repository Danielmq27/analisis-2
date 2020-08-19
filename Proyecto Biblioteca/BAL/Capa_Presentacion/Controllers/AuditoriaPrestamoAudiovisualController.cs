using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    //Controlador AuditoriaPrestamoAudiovisualController
    public class AuditoriaPrestamoAudiovisualController : Controller
    {
        //Accion para ver todas las auditorias de prestamos audiovisuales
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                //Listado de AuditoriaPrestamoAudiovisual
                List<AuditoriaPrestamoAudiovisual> listaAuditoriaPrestamoAudiovisual = new List<AuditoriaPrestamoAudiovisual>();
                //Llamado de clsAuditoriaPrestamoAudiovisual
                clsAuditoriaPrestamoAudiovisual auditoriaPrestamoAudiovisual = new clsAuditoriaPrestamoAudiovisual();
                //Llamado de metodo ConsultarAuditoriasPrestamoAudiovisual
                var data = auditoriaPrestamoAudiovisual.ConsultarAuditoriasPrestamoAudiovisual();
                foreach (var item in data)
                {
                    //Llamado del modelo
                    AuditoriaPrestamoAudiovisual modelo = new AuditoriaPrestamoAudiovisual();
                    // Llenamos el modelo con los datos de la BD
                    modelo.Id = Convert.ToInt32(item.Id);
                    modelo.CodigoPrestamoAudiovisual = item.codigoPrestamoAudiovisual;
                    modelo.Fecha = (DateTime)item.fecha;
                    modelo.Accion = item.accion;
                    modelo.Usuario = item.usuarioBD;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Telefono = (int)item.telefono;
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
                //Mandamos los datos a la vista
                return View(listaAuditoriaPrestamoAudiovisual);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("AuditoriaPrestamoAudiovisual", "Index", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para ver los detalles de una auditoria
        [HttpGet]
        public ActionResult Detalles(int Id)
        {
            try
            {
                //Llamado de clsAuditoriaPrestamoAudiovisual 
                clsAuditoriaPrestamoAudiovisual auditoriaPrestamoAudiovisual = new clsAuditoriaPrestamoAudiovisual();
                //Llamado de metodo ConsultarAuditoriaFormularioCIIE
                var dato = auditoriaPrestamoAudiovisual.ConsultarAuditoriaPrestamoAudiovisual(Id);
                //Llamado del modelo
                AuditoriaPrestamoAudiovisual modelo = new AuditoriaPrestamoAudiovisual();
                // Llenamos el modelo con los datos de la BD
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoPrestamoAudiovisual = dato[0].codigoPrestamoAudiovisual;
                modelo.Fecha = (DateTime)dato[0].fecha;
                modelo.Accion = dato[0].accion;
                modelo.Usuario = dato[0].usuarioBD;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = (int)dato[0].telefono;
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
                //Mandamos los datos a la vista
                return View(modelo);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("AuditoriaPrestamoAudiovisual", "Detalles", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}