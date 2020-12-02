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
    //Controlador AuditoriaFormularioCEDILController
    [ValidarSesion]
    public class AuditoriaFormularioCEDILController : Controller
    {
        //Accion para ver todas las auditorias de formulario del cedil
        [Acceso]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                //Listado de AuditoriaFormularioCEDIL
                List<AuditoriaFormularioCEDIL> listaAuditoriaCEDIL = new List<AuditoriaFormularioCEDIL>();
                //Llamado de clsAuditoriaFormularioCEDIL
                clsAuditoriaFormularioCEDIL auditoriaFormularioCEDIL = new clsAuditoriaFormularioCEDIL();
                //Llamado de metodo ConsultarAuditoriasFormularioCEDIL
                var data = auditoriaFormularioCEDIL.ConsultarAuditoriasFormularioCEDIL();
                foreach (var item in data)
                {
                    //Llamado del modelo
                    AuditoriaFormularioCEDIL modelo = new AuditoriaFormularioCEDIL();
                    // Llenamos el modelo con los datos de la BD
                    modelo.Id = Convert.ToInt32(item.Id);
                    modelo.CodigoCEDIL = item.codigoCEDIL;
                    modelo.Fecha = (DateTime)item.fecha;
                    modelo.Accion = item.accion;
                    modelo.Usuario = item.cedulaUsuario;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Telefono = (int)item.telefono;
                    modelo.Procedencia = item.procedencia;
                    modelo.Ubicacion = item.ubicacion;
                    modelo.TipoSolicitud = item.tipoSolicitud;
                    modelo.InformacionRequerida = item.informacionRequerida;
                    modelo.UsoInformacion = item.usoInformacion;
                    modelo.GeneroSolicitante = item.generoSolicitante;
                    modelo.Estado = item.estado;

                    listaAuditoriaCEDIL.Add(modelo);
                }
                //Mandamos los datos a la vista
                return View(listaAuditoriaCEDIL);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("AuditoriaFormularioCEDIL", "Index", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para ver los detalles de una auditoria
        [Acceso]
        [HttpGet]
        public ActionResult Detalles(int Id)
        {
            try
            {
                //Llamado de clsAuditoriaFormularioCEDIL
                clsAuditoriaFormularioCEDIL auditoriaFormularioCEDIL = new clsAuditoriaFormularioCEDIL();
                //Llamado de metodo ConsultarAuditoriaFormularioCEDIL
                var dato = auditoriaFormularioCEDIL.ConsultarAuditoriaFormularioCEDIL(Id);
                //Llamado del modelo
                AuditoriaFormularioCEDIL modelo = new AuditoriaFormularioCEDIL();
                // Llenamos el modelo con los datos de la BD
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoCEDIL = dato[0].codigoCEDIL;
                modelo.Fecha = (DateTime)dato[0].fecha;
                modelo.Accion = dato[0].accion;
                modelo.Usuario = dato[0].cedulaUsuario;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = (int)dato[0].telefono;
                modelo.Procedencia = dato[0].procedencia;
                modelo.Ubicacion = dato[0].ubicacion;
                modelo.TipoSolicitud = dato[0].tipoSolicitud;
                modelo.InformacionRequerida = dato[0].informacionRequerida;
                modelo.UsoInformacion = dato[0].usoInformacion;
                modelo.FechaIngreso = (DateTime)dato[0].fechaIngreso;
                modelo.FechaRespuesta = (DateTime)dato[0].fechaRespuesta;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                modelo.Estado = dato[0].estado;
                //Mandamos los datos a la vista
                return View(modelo);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("AuditoriaFormularioCEDIL", "Detalles", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        [Acceso]
        [HttpPost]
        public ActionResult RestaurarCEDIL(int Id)
        {
            try
            {
                clsAuditoriaFormularioCEDIL objFormularioCEDIL = new clsAuditoriaFormularioCEDIL();
                var dato = objFormularioCEDIL.ConsultarAuditoriaFormularioCEDIL(Id);
                //Llamado del modelo
                AuditoriaFormularioCEDIL modelo = new AuditoriaFormularioCEDIL();
                // Llenamos el modelo con los datos de la BD
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoCEDIL = dato[0].codigoCEDIL;
                modelo.Fecha = (DateTime)dato[0].fecha;
                modelo.Accion = dato[0].accion;
                modelo.Usuario = dato[0].cedulaUsuario;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = (int)dato[0].telefono;
                modelo.Procedencia = dato[0].procedencia;
                modelo.Ubicacion = dato[0].ubicacion;
                modelo.TipoSolicitud = dato[0].tipoSolicitud;
                modelo.InformacionRequerida = dato[0].informacionRequerida;
                modelo.UsoInformacion = dato[0].usoInformacion;
                modelo.FechaIngreso = (DateTime)dato[0].fechaIngreso;
                modelo.FechaRespuesta = (DateTime)dato[0].fechaRespuesta;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                modelo.Estado = dato[0].estado;
                //Variables de SESSION
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                bool resultado = objFormularioCEDIL.RestaurarCEDIL(modelo.CodigoCEDIL, CedulaUsuario, modelo.NombreSolicitante,
                    modelo.ApellidoSolicitante1, modelo.ApellidoSolicitante2, modelo.Telefono,
                    modelo.Procedencia, modelo.Ubicacion, modelo.TipoSolicitud, modelo.InformacionRequerida, 
                    modelo.UsoInformacion, modelo.GeneroSolicitante, modelo.FechaIngreso, modelo.FechaRespuesta, 
                    modelo.Estado);
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
                bitacora.AgregarBitacora("AuditoriaFormularioCEDIL", "Recuperar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}