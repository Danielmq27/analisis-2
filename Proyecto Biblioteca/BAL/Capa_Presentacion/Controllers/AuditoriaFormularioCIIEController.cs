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
    //Controlador AuditoriaFormularioCIIEController
    [ValidarSesion]
    public class AuditoriaFormularioCIIEController : Controller
    {
        //Accion para ver todas las auditorias de formulario del ciie
        [Acceso]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                //Listado de AuditoriaFormularioCIIE
                List<AuditoriaFormularioCIIE> listaAuditoriaCIIE = new List<AuditoriaFormularioCIIE>();
                //Llamado de clsAuditoriaFormularioCIIE
                clsAuditoriaFormularioCIIE auditoriaFormularioCIIE = new clsAuditoriaFormularioCIIE();
                //Llamado de metodo ConsultarAuditoriasFormularioCIIE
                var data = auditoriaFormularioCIIE.ConsultarAuditoriasFormularioCIIE();
                foreach (var item in data)
                {
                    //Llamado del modelo
                    AuditoriaFormularioCIIE modelo = new AuditoriaFormularioCIIE();
                    // Llenamos el modelo con los datos de la BD
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
                    modelo.Tema = item.tema;
                    modelo.InformacionRequerida = item.informacionRequerida;
                    modelo.UsoInformacion = item.usoInformacion;
                    modelo.GeneroSolicitante = item.generoSolicitante;
                    modelo.Estado = item.estado;
                    modelo.EspecificacionConsulta = item.especificacionConsulta;
                    modelo.TipoConsulta = item.tipoConsulta;

                    listaAuditoriaCIIE.Add(modelo);
                }
                //Mandamos los datos a la vista
                return View(listaAuditoriaCIIE);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("AuditoriaFormularioCIIE", "Index", ex.Message, NombreUsuario, 0);
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
                //Llamado de clsAuditoriaFormularioCIIE 
                clsAuditoriaFormularioCIIE auditoriaFormularioCIIE = new clsAuditoriaFormularioCIIE();
                //Llamado de metodo ConsultarAuditoriaFormularioCIIE
                var dato = auditoriaFormularioCIIE.ConsultarAuditoriaFormularioCIIE(Id);
                //Llamado del modelo
                AuditoriaFormularioCIIE modelo = new AuditoriaFormularioCIIE();
                // Llenamos el modelo con los datos de la BD
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
                modelo.Tema = dato[0].tema;
                modelo.InformacionRequerida = dato[0].informacionRequerida;
                modelo.UsoInformacion = dato[0].usoInformacion;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                modelo.Estado = dato[0].estado;
                modelo.EspecificacionConsulta = dato[0].especificacionConsulta;
                modelo.TipoConsulta = dato[0].tipoConsulta;
                //Mandamos los datos a la vista
                return View(modelo);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("AuditoriaFormularioCIIE", "Detalles", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}