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
    //Controlador FormularioCIIEController
    [ValidarSesion]
    public class FormularioCIIEController : Controller
    {
        //Accion del rol administrador para vizualizar los formularios del CIIE
        [Acceso]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<FormularioCIIE> listaFormularioCIIE = new List<FormularioCIIE>();
                clsFormularioCIIE formularioCIIE = new clsFormularioCIIE();
                var data = formularioCIIE.ConsultarFormulariosCIIE().ToList();
                foreach (var item in data)
                {
                    FormularioCIIE modelo = new FormularioCIIE();
                    modelo.Id = Convert.ToInt32(item.Id);
                    modelo.CodigoCIIE = item.codigoCIIE;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Telefono = (int)item.telefono;
                    modelo.Email = item.email;
                    modelo.TipoDespacho = item.tipoDespacho;
                    modelo.Fraccion = item.fraccion;
                    modelo.EspecificacionDespacho = item.especificacionDespacho;
                    modelo.TipoConsulta = item.tipoConsulta;
                    modelo.EspecificacionConsulta = item.especificacionConsulta;
                    modelo.Tema = item.tema;
                    modelo.InformacionRequerida = item.informacionRequerida;
                    modelo.UsoInformacion = item.usoInformacion;
                    modelo.GeneroSolicitante = item.generoSolicitante;
                    modelo.FechaIngreso = item.fechaIngreso;
                    modelo.FechaRespuesta = (DateTime)item.fechaRespuesta;
                    modelo.Estado = item.estado;
                    modelo.CedulaUsuario = item.cedulaUsuario;
                    modelo.Nombre = item.nombre;
                    modelo.Apellido1 = item.apellido1;
                    modelo.Apellido2 = item.apellido2;

                    listaFormularioCIIE.Add(modelo);

                }
                return View(listaFormularioCIIE);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("FormularioCIIE", "Index", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar un formularios del CIIE
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
                new SelectListItem { Value = "Asignada", Text = "Asignada" },
                new SelectListItem { Value = "Tramite", Text = "Trámite" },
                new SelectListItem { Value = "Realizada", Text = "Realizada"}
                                               }, "Value", "Text");
                clsFraccion fraccion = new clsFraccion();
                ViewBag.listaFracciones = fraccion.ConsultarFracciones();
                clsDespacho despacho = new clsDespacho();
                ViewBag.listaDespachos = despacho.ConsultarDespachos();
                return View();
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("FormularioCIIE", "Agregar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar un formularios del CIIE
        [Acceso]
        [HttpPost]
        public ActionResult Agregar(FormularioCIIE formularioCIIE)
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
                new SelectListItem { Value = "Asignada", Text = "Asignada" },
                new SelectListItem { Value = "Tramite", Text = "Trámite" },
                new SelectListItem { Value = "Realizada", Text = "Realizada"}
                                               }, "Value", "Text");
                    clsFraccion fraccion = new clsFraccion();
                    ViewBag.listaFracciones = fraccion.ConsultarFracciones();
                    clsDespacho despacho = new clsDespacho();
                    ViewBag.listaDespachos = despacho.ConsultarDespachos();
                    //Retornamos el modelo
                    return View(formularioCIIE);
                }
                clsFormularioCIIE objFormularioCIIE = new clsFormularioCIIE();
                //Variables de SESSION
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                bool resultado = objFormularioCIIE.AgregarFormularioCIIE(CedulaUsuario, formularioCIIE.NombreSolicitante, 
                    formularioCIIE.ApellidoSolicitante1, formularioCIIE.ApellidoSolicitante2, formularioCIIE.Telefono, 
                    formularioCIIE.Email, formularioCIIE.TipoDespacho, formularioCIIE.Fraccion, formularioCIIE.EspecificacionDespacho, 
                    formularioCIIE.TipoConsulta, formularioCIIE.EspecificacionConsulta, formularioCIIE.Tema, 
                    formularioCIIE.InformacionRequerida, formularioCIIE.UsoInformacion, formularioCIIE.GeneroSolicitante, 
                    formularioCIIE.FechaIngreso, formularioCIIE.FechaRespuesta, formularioCIIE.Estado);
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
                bitacora.AgregarBitacora("FormularioCIIE", "Agregar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar un formularios del CIIE
        [Acceso]
        [HttpGet]
        public ActionResult Actualizar(int Id)
        {
            try
            {
                clsFormularioCIIE formulario = new clsFormularioCIIE();
                var dato = formulario.ConsultarFormularioCIIE(Id);
                FormularioCIIE modelo = new FormularioCIIE();
                modelo.CodigoCIIE = dato[0].codigoCIIE;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = (int)dato[0].telefono;
                modelo.Email = dato[0].email;
                modelo.TipoDespacho = dato[0].tipoDespacho;
                modelo.Fraccion = dato[0].fraccion;
                modelo.EspecificacionDespacho = dato[0].especificacionDespacho;
                modelo.TipoConsulta = dato[0].tipoConsulta;
                modelo.EspecificacionConsulta = dato[0].especificacionConsulta;
                modelo.Tema = dato[0].tema;
                modelo.InformacionRequerida = dato[0].informacionRequerida;
                modelo.UsoInformacion = dato[0].usoInformacion;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                modelo.FechaIngreso = dato[0].fechaIngreso;
                modelo.FechaRespuesta = (DateTime)dato[0].fechaRespuesta;
                modelo.Estado = dato[0].estado;
                ViewBag.genero = new SelectList(new[] {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
                ViewBag.estados = new SelectList(new[] {
                new SelectListItem { Value = "Asignada", Text = "Asignada" },
                new SelectListItem { Value = "Tramite", Text = "Trámite" },
                new SelectListItem { Value = "Realizada", Text = "Realizada"}
                                               }, "Value", "Text");
                clsFraccion fraccion = new clsFraccion();
                ViewBag.listaFracciones = fraccion.ConsultarFracciones();
                clsDespacho despacho = new clsDespacho();
                ViewBag.listaDespachos = despacho.ConsultarDespachos();
                return View(modelo);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("FormularioCIIE", "Actualizar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar un formularios del CIIE
        [Acceso]
        [HttpPost]
        public ActionResult Actualizar(int Id, FormularioCIIE formularioCIIE)
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
                new SelectListItem { Value = "Asignada", Text = "Asignada" },
                new SelectListItem { Value = "Tramite", Text = "Trámite" },
                new SelectListItem { Value = "Realizada", Text = "Realizada"}
                                               }, "Value", "Text");
                    clsFraccion fraccion = new clsFraccion();
                    ViewBag.listaFracciones = fraccion.ConsultarFracciones();
                    clsDespacho despacho = new clsDespacho();
                    ViewBag.listaDespachos = despacho.ConsultarDespachos();
                    //Retornamos el modelo
                    return View(formularioCIIE);
                }
                clsFormularioCIIE objFormularioCIIE = new clsFormularioCIIE();
                //Variables de SESSION
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                bool resultado = objFormularioCIIE.ActualizarFormularioCIIE(formularioCIIE.Id, formularioCIIE.CodigoCIIE, CedulaUsuario,
                    formularioCIIE.NombreSolicitante, formularioCIIE.ApellidoSolicitante1, formularioCIIE.ApellidoSolicitante2, 
                    formularioCIIE.Telefono, formularioCIIE.Email, formularioCIIE.TipoDespacho, formularioCIIE.Fraccion, 
                    formularioCIIE.EspecificacionDespacho, formularioCIIE.TipoConsulta, formularioCIIE.EspecificacionConsulta, 
                    formularioCIIE.Tema, formularioCIIE.InformacionRequerida, formularioCIIE.UsoInformacion, 
                    formularioCIIE.GeneroSolicitante, formularioCIIE.FechaIngreso, formularioCIIE.FechaRespuesta, formularioCIIE.Estado);
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
                bitacora.AgregarBitacora("FormularioCIIE", "Actualizar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para ver un formularios del CIIE
        [Acceso]
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            try
            {
                clsFormularioCIIE formularioCIIE = new clsFormularioCIIE();
                var dato = formularioCIIE.ConsultarFormularioCIIE(id);
                FormularioCIIE modelo = new FormularioCIIE();
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoCIIE = dato[0].codigoCIIE;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = (int)dato[0].telefono;
                modelo.Email = dato[0].email;
                modelo.TipoDespacho = dato[0].tipoDespacho;
                modelo.Fraccion = dato[0].fraccion;
                modelo.EspecificacionDespacho = dato[0].especificacionDespacho;
                modelo.TipoConsulta = dato[0].tipoConsulta;
                modelo.EspecificacionConsulta = dato[0].especificacionConsulta;
                modelo.Tema = dato[0].tema;
                modelo.InformacionRequerida = dato[0].informacionRequerida;
                modelo.UsoInformacion = dato[0].usoInformacion;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                modelo.FechaIngreso = dato[0].fechaIngreso;
                modelo.FechaRespuesta = (DateTime)dato[0].fechaRespuesta;
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
                bitacora.AgregarBitacora("FormularioCIIE", "Detalles", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para eliminar un formularios del CIIE
        [Acceso]
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                clsFormularioCIIE formularioCIIE = new clsFormularioCIIE();
                bool resultado = formularioCIIE.EliminarFormularioCIIE(Id);
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
                bitacora.AgregarBitacora("FormularioCIIE", "Eliminar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para eliminar todos los formularios del CIIE
        [Acceso]
        [HttpPost]
        public ActionResult EliminarTabla()
        {
            try
            {
                string tabla = "RefConsecutivoCIIE";
                string tabla1 = "FormularioCIIE";
                string tabla2 = "AuditoriaFormularioCIIE";
                clsControl control = new clsControl();
                bool resultado = control.Eliminar_Tabla(tabla, tabla1, tabla2);
                if (resultado)
                {
                    return RedirectToAction("Index");
                } else
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
                bitacora.AgregarBitacora("FormularioCIIE", "EliminarTabla", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}