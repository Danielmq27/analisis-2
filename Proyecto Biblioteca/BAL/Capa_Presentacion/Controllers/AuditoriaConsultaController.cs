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
    //Controlador AuditoriaConsultaController
    [ValidarSesion]
    public class AuditoriaConsultaController : Controller
    {
        //Accion para ver todas las auditorias de consultas
        [Acceso]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                //Listado de AuditoriaConsulta
                List<AuditoriaConsulta> listaAuditoriaConsulta = new List<AuditoriaConsulta>();
                //Llamado de clsAuditoriaConsulta
                clsAuditoriaConsulta auditoriaConsulta = new clsAuditoriaConsulta();
                //Llamado de metodo ConsultarAuditoriasConsulta
                var data = auditoriaConsulta.ConsultarAuditoriasConsulta();
                foreach (var item in data)
                {
                    //Llamado del modelo
                    AuditoriaConsulta modelo = new AuditoriaConsulta();
                    // Llenamos el modelo con los datos de la BD
                    modelo.Id = Convert.ToInt32(item.Id);
                    modelo.CodigoConsulta = item.codigoConsulta;
                    modelo.Fecha = (DateTime)item.fecha;
                    modelo.Accion = item.accion;
                    modelo.Usuario = item.cedulaUsuario;
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
                //Mandamos los datos a la vista
                return View(listaAuditoriaConsulta);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("AuditoriaConsulta", "Index", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("500", "Error");
            }
        }

        //Accion para ver los detalles de una auditoria
        [Acceso]
        [HttpGet]
        public ActionResult Detalles(int Id)
        {
            try
            {
                //Llamado de clsAuditoriaConsulta 
                clsAuditoriaConsulta auditoriaConsulta = new clsAuditoriaConsulta();
                //Llamado de metodo ConsultarAuditoriaConsulta
                var dato = auditoriaConsulta.ConsultarAuditoriaConsulta(Id);
                //Llamado del modelo
                AuditoriaConsulta modelo = new AuditoriaConsulta();
                // Llenamos el modelo con los datos de la BD
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoConsulta = dato[0].codigoConsulta;
                modelo.Fecha = (DateTime)dato[0].fecha;
                modelo.Accion = dato[0].accion;
                modelo.Usuario = dato[0].cedulaUsuario;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = (int)dato[0].telefono;
                modelo.Email = dato[0].email;
                modelo.Asunto = dato[0].asunto;
                modelo.Descripcion = dato[0].descripcion;
                modelo.MetodoIngreso = dato[0].metodoIngreso;
                modelo.FechaIngreso = (DateTime)dato[0].fechaIngreso;
                modelo.FechaFinal = (DateTime)dato[0].fechaRespuesta;
                modelo.Respuesta = dato[0].respuesta;
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
                bitacora.AgregarBitacora("AuditoriaConsulta", "Detalles", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        [Acceso]
        [HttpPost]
        public ActionResult RestaurarConsulta(int Id)
        {
            try
            {
                clsAuditoriaConsulta objConsulta = new clsAuditoriaConsulta();
                var dato = objConsulta.ConsultarAuditoriaConsulta(Id);
                //Llamado del modelo
                AuditoriaConsulta modelo = new AuditoriaConsulta();
                // Llenamos el modelo con los datos de la BD
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoConsulta = dato[0].codigoConsulta;
                modelo.Fecha = (DateTime)dato[0].fecha;
                modelo.Accion = dato[0].accion;
                modelo.Usuario = dato[0].cedulaUsuario;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = (int)dato[0].telefono;
                modelo.Email = dato[0].email;
                modelo.Asunto = dato[0].asunto;
                modelo.Descripcion = dato[0].descripcion;
                modelo.MetodoIngreso = dato[0].metodoIngreso;
                modelo.FechaIngreso = (DateTime)dato[0].fechaIngreso;
                modelo.FechaFinal = (DateTime)dato[0].fechaRespuesta;
                modelo.Respuesta = dato[0].respuesta;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                modelo.Estado = dato[0].estado;
                //Variables de SESSION
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                bool resultado = objConsulta.RestaurarConsulta(modelo.CodigoConsulta, CedulaUsuario, modelo.NombreSolicitante,
                    modelo.ApellidoSolicitante1, modelo.ApellidoSolicitante2, modelo.Telefono,
                    modelo.Email, modelo.Asunto, modelo.Descripcion, modelo.Respuesta, modelo.MetodoIngreso,
                    modelo.GeneroSolicitante, modelo.FechaIngreso, modelo.FechaFinal, modelo.Estado, modelo.NombreArchivo,
                    modelo.TipoArchivo, modelo.Extension, modelo.ArchivoFile);
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
                bitacora.AgregarBitacora("AuditoriaConsulta", "Recuperar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}