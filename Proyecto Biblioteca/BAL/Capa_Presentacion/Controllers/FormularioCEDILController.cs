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
    //Controlador FormularioCEDILController
    public class FormularioCEDILController : Controller
    {
        //Accion del rol administrador para vizualisar los formularios del CEDIL
        [Acceso]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<FormularioCEDIL> listaFormularioCEDIL = new List<FormularioCEDIL>();
                clsFormularioCEDIL formularioCEDIL = new clsFormularioCEDIL();
                var data = formularioCEDIL.ConsultarFormulariosCEDIL().ToList();
                foreach (var item in data)
                {
                    FormularioCEDIL modelo = new FormularioCEDIL();
                    modelo.Id = Convert.ToInt32(item.Id);
                    modelo.CodigoCEDIL = item.codigoCEDIL;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Telefono = item.telefono;
                    modelo.Procedencia = item.procedencia;
                    modelo.Ubicacion = item.ubicacion;
                    modelo.TipoSolicitud = item.tipoSolicitud;
                    modelo.InformacionRequerida = item.informacionRequerida;
                    modelo.UsoInformacion = item.usoInformacion;
                    modelo.InformacionRequerida = item.informacionRequerida;
                    modelo.UsoInformacion = item.usoInformacion;
                    modelo.GeneroSolicitante = item.generoSolicitante;
                    modelo.FechaIngreso = item.fechaIngreso;
                    modelo.FechaRespuesta = item.fechaRespuesta;
                    modelo.Estado = item.estado;
                    modelo.CedulaUsuario = item.cedulaUsuario;
                    modelo.Nombre = item.nombre;
                    modelo.Apellido1 = item.apellido1;
                    modelo.Apellido2 = item.apellido2;

                    listaFormularioCEDIL.Add(modelo);

                }
                return View(listaFormularioCEDIL);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("FormularioCEDIL", "Index", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        [Acceso]
        [HttpGet]
        public ActionResult Agregar()
        {
            try
            {
                ViewBag.genero = new SelectList(new[] {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
                ViewBag.estados = new SelectList(new[] {
                new SelectListItem { Value = "Pendiente", Text = "Pendiente" },
                new SelectListItem { Value = "Finalizado", Text = "Finalizado" }
                                               }, "Value", "Text");
                return View();
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("FormularioCEDIL", "Agregar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar un formularios del CEDIL
        [Acceso]
        [HttpPost]
        public ActionResult Agregar(FormularioCEDIL formularioCEDIL)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.genero = new SelectList(new[] {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
                    ViewBag.estados = new SelectList(new[] {
                new SelectListItem { Value = "Pendiente", Text = "Pendiente" },
                new SelectListItem { Value = "Finalizado", Text = "Finalizado" }
                                               }, "Value", "Text");
                    //Retornamos el modelo
                    return View(formularioCEDIL);
                }
                clsFormularioCEDIL objFormularioCEDIL = new clsFormularioCEDIL();
                //Variables de SESSION
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                string Apellido1Usuario = System.Web.HttpContext.Current.Session["apellido1"] as String;
                string Apellido2Usuario = System.Web.HttpContext.Current.Session["apellido2"] as String;
                bool resultado = objFormularioCEDIL.AgregarFormularioCEDIL(formularioCEDIL.NombreSolicitante,
                    formularioCEDIL.ApellidoSolicitante1, formularioCEDIL.ApellidoSolicitante2, formularioCEDIL.Telefono,
                    formularioCEDIL.Procedencia, formularioCEDIL.Ubicacion, formularioCEDIL.TipoSolicitud, 
                    formularioCEDIL.InformacionRequerida, formularioCEDIL.UsoInformacion, formularioCEDIL.GeneroSolicitante, 
                    formularioCEDIL.FechaIngreso, formularioCEDIL.FechaRespuesta, formularioCEDIL.Estado, 
                    CedulaUsuario, NombreUsuario, Apellido1Usuario, Apellido2Usuario);
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
                bitacora.AgregarBitacora("FormularioCEDIL", "Agregar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar un formularios del CEDIL
        [Acceso]
        [HttpGet]
        public ActionResult Actualizar(int Id)
        {
            try
            {
                clsFormularioCEDIL formulario = new clsFormularioCEDIL();
                var dato = formulario.ConsultarFormularioCEDIL(Id);
                FormularioCEDIL modelo = new FormularioCEDIL();
                modelo.CodigoCEDIL = dato[0].codigoCEDIL;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = dato[0].telefono;
                modelo.Procedencia = dato[0].procedencia;
                modelo.Ubicacion = dato[0].ubicacion;
                modelo.TipoSolicitud = dato[0].tipoSolicitud;
                modelo.InformacionRequerida = dato[0].informacionRequerida;
                modelo.UsoInformacion = dato[0].usoInformacion;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                modelo.FechaIngreso = dato[0].fechaIngreso;
                modelo.FechaRespuesta = dato[0].fechaRespuesta;
                modelo.Estado = dato[0].estado;
                ViewBag.genero = new SelectList(new[] {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
                ViewBag.estados = new SelectList(new[] {
                new SelectListItem { Value = "Pendiente", Text = "Pendiente" },
                new SelectListItem { Value = "Finalizado", Text = "Finalizado" }
                                               }, "Value", "Text");
                return View(modelo);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("FormularioCEDIL", "Actualizar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar un formularios del CEDIL
        [Acceso]
        [HttpPost]
        public ActionResult Actualizar(int Id, FormularioCEDIL formularioCEDIL)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.genero = new SelectList(new[] {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
                    ViewBag.estados = new SelectList(new[] {
                new SelectListItem { Value = "Pendiente", Text = "Pendiente" },
                new SelectListItem { Value = "Finalizado", Text = "Finalizado" }
                                               }, "Value", "Text");
                    //Retornamos el modelo
                    return View(formularioCEDIL);
                }
                clsFormularioCEDIL objFormularioCEDIL = new clsFormularioCEDIL();
                //Variables de SESSION
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                string Apellido1Usuario = System.Web.HttpContext.Current.Session["apellido1"] as String;
                string Apellido2Usuario = System.Web.HttpContext.Current.Session["apellido2"] as String;
                bool resultado = objFormularioCEDIL.ActualizarFormularioCEDIL(formularioCEDIL.Id, formularioCEDIL.CodigoCEDIL, 
                    formularioCEDIL.NombreSolicitante, formularioCEDIL.ApellidoSolicitante1, formularioCEDIL.ApellidoSolicitante2, formularioCEDIL.Telefono,
                    formularioCEDIL.Procedencia, formularioCEDIL.Ubicacion, formularioCEDIL.TipoSolicitud,
                    formularioCEDIL.InformacionRequerida, formularioCEDIL.UsoInformacion, formularioCEDIL.GeneroSolicitante,
                    formularioCEDIL.FechaIngreso, formularioCEDIL.FechaRespuesta, formularioCEDIL.Estado,
                    CedulaUsuario, NombreUsuario, Apellido1Usuario, Apellido2Usuario);
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
                bitacora.AgregarBitacora("FormularioCEDIL", "Actualizar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para ver un formularios del CEDIL
        [Acceso]
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            try
            {
                clsFormularioCEDIL formularioCEDIL = new clsFormularioCEDIL();
                var dato = formularioCEDIL.ConsultarFormularioCEDIL(id);
                FormularioCEDIL modelo = new FormularioCEDIL();
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoCEDIL = dato[0].codigoCEDIL;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = dato[0].telefono;
                modelo.Procedencia = dato[0].procedencia;
                modelo.Ubicacion = dato[0].ubicacion;
                modelo.TipoSolicitud = dato[0].tipoSolicitud;
                modelo.InformacionRequerida = dato[0].informacionRequerida;
                modelo.UsoInformacion = dato[0].usoInformacion;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                modelo.FechaIngreso = dato[0].fechaIngreso;
                modelo.FechaRespuesta = dato[0].fechaRespuesta;
                modelo.Estado = dato[0].estado;
                modelo.CedulaUsuario = dato[0].cedulaUsuario;
                modelo.Nombre = dato[0].nombre;
                modelo.Apellido1 = dato[0].apellido1;
                modelo.Apellido2 = dato[0].apellido2;
                return View(modelo);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("FormularioCEDIL", "Detalles", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para eliminar un formularios del CEDIL
        [Acceso]
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                clsFormularioCEDIL formularioCEDIL = new clsFormularioCEDIL();
                bool resultado = formularioCEDIL.EliminarFormularioCEDIL(Id);
                if (resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //Pagina de Error
                    return RedirectToAction("Error500", "Error");
                }
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("FormularioCEDIL", "Eliminar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para eliminar todos los formularios del CEDIL
        [Acceso]
        [HttpPost]
        public ActionResult EliminarTabla()
        {
            try
            {
                string tabla = "RefConsecutivoCEDIL";
                string tabla1 = "Usuario_FormularioCEDIL";
                string tabla2 = "FormularioCEDIL";
                clsControl control = new clsControl();
                bool resultado = control.Eliminar_Tabla(tabla, tabla1, tabla2);
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
                bitacora.AgregarBitacora("FormularioCEDIL", "EliminarTabla", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}