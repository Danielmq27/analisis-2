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
    //Controlador AuditoriaPrestamoPermanenteController
    [ValidarSesion]
    public class AuditoriaPrestamoPermanenteController : Controller
    {
        //Accion para ver todas las auditorias de prestamos permanentes
        [Acceso]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                //Listado de AuditoriaPrestamoPermanente
                List<AuditoriaPrestamoPermanente> listaAuditoriaPrestamoPermanente = new List<AuditoriaPrestamoPermanente>();
                //Llamado de clsAuditoriaPrestamoPermanente
                clsAuditoriaPrestamoPermanente auditoriaPrestamoPermanente = new clsAuditoriaPrestamoPermanente();
                //Llamado de metodo ConsultarAuditoriasPrestamoPermanente
                var data = auditoriaPrestamoPermanente.ConsultarAuditoriasPrestamoPermanente();
                foreach (var item in data)
                {
                    //Llamado del modelo
                    AuditoriaPrestamoPermanente modelo = new AuditoriaPrestamoPermanente();
                    // Llenamos el modelo con los datos de la BD
                    modelo.Id = Convert.ToInt32(item.Id);
                    modelo.CodigoPrestamoPermanente = item.codigoPrestamoPermanente;
                    modelo.Fecha = (DateTime)item.fecha;
                    modelo.Accion = item.accion;
                    modelo.Usuario = item.cedulaUsuario;
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
                //Mandamos los datos a la vista
                return View(listaAuditoriaPrestamoPermanente);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("AuditoriaPrestamoPermanente", "Index", ex.Message, NombreUsuario, 0);
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
                //Llamado de clsAuditoriaPrestamoPermanente 
                clsAuditoriaPrestamoPermanente auditoriaPrestamoPermanente = new clsAuditoriaPrestamoPermanente();
                //Llamado de metodo ConsultarAuditoriaPrestamoPermanente
                var dato = auditoriaPrestamoPermanente.ConsultarAuditoriaPrestamoPermanente(Id);
                //Llamado del modelo
                AuditoriaPrestamoPermanente modelo = new AuditoriaPrestamoPermanente();
                // Llenamos el modelo con los datos de la BD
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoPrestamoPermanente = dato[0].codigoPrestamoPermanente;
                modelo.Fecha = (DateTime)dato[0].fecha;
                modelo.Accion = dato[0].accion;
                modelo.Usuario = dato[0].cedulaUsuario;
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
                //Mandamos los datos a la vista
                return View(modelo);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("AuditoriaPrestamoPermanente", "Detalles", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        [Acceso]
        [HttpPost]
        public ActionResult RestaurarPrestamoPermanente(int Id)
        {
            try
            {
                clsAuditoriaPrestamoPermanente objPrestamoPermanente = new clsAuditoriaPrestamoPermanente();
                var dato = objPrestamoPermanente.ConsultarAuditoriaPrestamoPermanente(Id);
                //Llamado del modelo
                AuditoriaPrestamoPermanente modelo = new AuditoriaPrestamoPermanente();
                // Llenamos el modelo con los datos de la BD
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoPrestamoPermanente = dato[0].codigoPrestamoPermanente;
                modelo.Fecha = (DateTime)dato[0].fecha;
                modelo.Accion = dato[0].accion;
                modelo.Usuario = dato[0].cedulaUsuario;
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
                //Variables de SESSION
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                bool resultado = objPrestamoPermanente.RestaurarPrestamoPermanente(modelo.CodigoPrestamoPermanente, CedulaUsuario, modelo.NombreSolicitante,
                    modelo.ApellidoSolicitante1, modelo.ApellidoSolicitante2, modelo.Despacho,
                    modelo.Telefono, modelo.Extension, modelo.InformacionAdicional, modelo.GeneroSolicitante,
                    modelo.FechaPrestamo, modelo.Estado);
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
                bitacora.AgregarBitacora("AuditoriaFormularioCIIE", "Recuperar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}