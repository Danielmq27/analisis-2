using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    //Controlador FormularioCIIEController
    public class FormularioCIIEController : Controller
    {
        //Accion del rol administrador para vizualisar los formularios del CIIE
        [HttpGet]
        public ActionResult Administrador()
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
                    modelo.Telefono = item.telefono;
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
                    modelo.FechaRespuesta = item.fechaRespuesta;
                    modelo.Estado = item.estado;
                    modelo.CedulaUsuario = item.cedulaUsuario;
                    modelo.Nombre = item.nombre;
                    modelo.Apellido1 = item.apellido1;
                    modelo.Apellido2 = item.apellido2;

                    listaFormularioCIIE.Add(modelo);

                }
                return View(listaFormularioCIIE);
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion del rol editar para vizualisar los formularios del CIIE
        [HttpGet]
        public ActionResult Editar()
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
                    modelo.Telefono = item.telefono;
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
                    modelo.FechaRespuesta = item.fechaRespuesta;
                    modelo.Estado = item.estado;

                    listaFormularioCIIE.Add(modelo);

                }
                return View(listaFormularioCIIE);
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion del rol consultar para vizualisar los formularios del CIIE
        [HttpGet]
        public ActionResult Consultar()
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
                    modelo.Telefono = item.telefono;
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
                    modelo.FechaRespuesta = item.fechaRespuesta;
                    modelo.Estado = item.estado;

                    listaFormularioCIIE.Add(modelo);

                }
                return View(listaFormularioCIIE);
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar un formularios del CIIE
        [HttpGet]
        public ActionResult Agregar()
        {
            try
            {
                ViewBag.genero = new SelectList(new[] {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
                ViewBag.estado = new SelectList(new[] {
                new SelectListItem { Value = "Pendiente", Text = "Pendiente" },
                new SelectListItem { Value = "Finalizado", Text = "Finalizado" }
                                               }, "Value", "Text");
                return View();
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar un formularios del CIIE
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
                    ViewBag.estado = new SelectList(new[] {
                new SelectListItem { Value = "Pendiente", Text = "Pendiente" },
                new SelectListItem { Value = "Finalizado", Text = "Finalizado" }
                                               }, "Value", "Text");
                    //Retornamos el modelo
                    return View(formularioCIIE);
                }
                clsFormularioCIIE objFormularioCIIE = new clsFormularioCIIE();
                //Variables de SESSION
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                string Apellido1Usuario = System.Web.HttpContext.Current.Session["apellido1"] as String;
                string Apellido2Usuario = System.Web.HttpContext.Current.Session["apellido2"] as String;
                bool resultado = objFormularioCIIE.AgregarFormularioCIIE(formularioCIIE.NombreSolicitante, 
                    formularioCIIE.ApellidoSolicitante1, formularioCIIE.ApellidoSolicitante2, formularioCIIE.Telefono, 
                    formularioCIIE.Email, formularioCIIE.TipoDespacho, formularioCIIE.Fraccion, formularioCIIE.EspecificacionDespacho, 
                    formularioCIIE.TipoConsulta, formularioCIIE.EspecificacionConsulta, formularioCIIE.Tema, 
                    formularioCIIE.InformacionRequerida, formularioCIIE.UsoInformacion, formularioCIIE.GeneroSolicitante, 
                    formularioCIIE.FechaIngreso, formularioCIIE.FechaRespuesta, formularioCIIE.Estado, CedulaUsuario, NombreUsuario, 
                    Apellido1Usuario, Apellido2Usuario);
                if (resultado)
                {
                    return RedirectToAction("Administrador");
                }
                else
                {
                    //Pagina de Error
                    return RedirectToAction("Error404", "Error");
                }
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar un formularios del CIIE
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
                modelo.Telefono = dato[0].telefono;
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
                modelo.FechaRespuesta = dato[0].fechaRespuesta;
                modelo.Estado = dato[0].estado;
                ViewBag.genero = new SelectList(new[] {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
                ViewBag.estado = new SelectList(new[] {
                new SelectListItem { Value = "Pendiente", Text = "Pendiente" },
                new SelectListItem { Value = "Finalizado", Text = "Finalizado" }
                                               }, "Value", "Text");
                return View(modelo);
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar un formularios del CIIE
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
                    ViewBag.estado = new SelectList(new[] {
                new SelectListItem { Value = "Pendiente", Text = "Pendiente" },
                new SelectListItem { Value = "Finalizado", Text = "Finalizado" }
                                               }, "Value", "Text");
                    //Retornamos el modelo
                    return View(formularioCIIE);
                }
                clsFormularioCIIE objFormularioCIIE = new clsFormularioCIIE();
                //Variables de SESSION
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                string Apellido1Usuario = System.Web.HttpContext.Current.Session["apellido1"] as String;
                string Apellido2Usuario = System.Web.HttpContext.Current.Session["apellido2"] as String;
                bool resultado = objFormularioCIIE.ActualizarFormularioCIIE(formularioCIIE.Id, formularioCIIE.CodigoCIIE, 
                    formularioCIIE.NombreSolicitante, formularioCIIE.ApellidoSolicitante1, formularioCIIE.ApellidoSolicitante2, 
                    formularioCIIE.Telefono, formularioCIIE.Email, formularioCIIE.TipoDespacho, formularioCIIE.Fraccion, 
                    formularioCIIE.EspecificacionDespacho, formularioCIIE.TipoConsulta, formularioCIIE.EspecificacionConsulta, 
                    formularioCIIE.Tema, formularioCIIE.InformacionRequerida, formularioCIIE.UsoInformacion, 
                    formularioCIIE.GeneroSolicitante, formularioCIIE.FechaIngreso, formularioCIIE.FechaRespuesta, formularioCIIE.Estado,
                    CedulaUsuario, NombreUsuario, Apellido1Usuario, Apellido2Usuario);
                if (resultado)
                {
                    return RedirectToAction("Administrador");
                }
                else
                {
                    //Pagina de Error
                    return RedirectToAction("Error404", "Error");
                }
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para ver un formularios del CIIE
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
                modelo.Telefono = dato[0].telefono;
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
                modelo.FechaRespuesta = dato[0].fechaRespuesta;
                modelo.Estado = dato[0].estado;
                modelo.CedulaUsuario = dato[0].cedulaUsuario;
                modelo.Nombre = dato[0].nombre;
                modelo.Apellido1 = dato[0].apellido1;
                modelo.Apellido2 = dato[0].apellido2;
                return View(modelo);
            }
            catch (Exception)
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para eliminar un formularios del CIIE
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                clsFormularioCIIE formularioCIIE = new clsFormularioCIIE();
                bool resultado = formularioCIIE.EliminarFormularioCIIE(Id);
                if (resultado)
                {
                    return RedirectToAction("Administrador");
                }
                else
                {
                    //Pagina de Error
                    return RedirectToAction("Error500", "Error");
                }
            }
            catch (Exception)
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para eliminar todos los formularios del CIIE
        [HttpPost]
        public ActionResult EliminarTabla()
        {
            try
            {
                string tabla = "RefConsecutivoCIIE";
                string tabla1 = "Usuario_FormularioCIIE";
                string tabla2 = "FormularioCIIE";
                clsControl control = new clsControl();
                bool resultado = control.Eliminar_Tabla(tabla, tabla1, tabla2);
                if (resultado)
                {
                    return RedirectToAction("Administrador");
                } else
                {
                    //Pagina de Error
                    return RedirectToAction("Error404", "Error");
                }
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}