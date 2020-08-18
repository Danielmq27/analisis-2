using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    //Controlador ConsultaController
    public class ConsultaController : Controller
    {
        //Accion del rol administrador para visualizar las consultas
        [HttpGet]
        public ActionResult Administrador()
        {
            try
            {
                List<Consulta> listaConsulta = new List<Consulta>();
                clsConsulta consulta = new clsConsulta();
                var data = consulta.ConsultarConsultas().ToList();
                foreach (var item in data)
                {
                    Consulta modelo = new Consulta();
                    modelo.Id = item.Id;
                    modelo.CodigoConsulta = item.codigoConsulta;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Telefono = item.telefono;
                    modelo.Email = item.email;
                    modelo.Asunto = item.asunto;
                    modelo.Descripcion = item.descripcion;
                    modelo.Respuesta = item.respuesta;
                    modelo.MetodoIngreso = item.metodoIngreso;
                    modelo.FechaIngreso = item.fechaIngreso;
                    modelo.FechaRespuesta = item.fechaRespuesta;
                    modelo.Estado = item.estado;
                    modelo.GeneroSolicitante = modelo.GeneroSolicitante;

                    listaConsulta.Add(modelo);
                }

                return View(listaConsulta);
            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion del rol editar para visualizar las consultas
        [HttpGet]
        public ActionResult Editar()
        {
            try
            {
                List<Consulta> listaConsulta = new List<Consulta>();
                clsConsulta consulta = new clsConsulta();
                var data = consulta.ConsultarConsultas().ToList();
                foreach (var item in data)
                {
                    Consulta modelo = new Consulta();
                    modelo.Id = item.Id;
                    modelo.CodigoConsulta = item.codigoConsulta;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Telefono = item.telefono;
                    modelo.Email = item.email;
                    modelo.Asunto = item.asunto;
                    modelo.Descripcion = item.descripcion;
                    modelo.Respuesta = item.respuesta;
                    modelo.MetodoIngreso = item.metodoIngreso;
                    modelo.FechaIngreso = item.fechaIngreso;
                    modelo.FechaRespuesta = item.fechaRespuesta;
                    modelo.Estado = item.estado;
                    modelo.GeneroSolicitante = modelo.GeneroSolicitante;

                    listaConsulta.Add(modelo);
                }

                return View(listaConsulta);
            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion del rol consultar para visualizar las consultas
        [HttpGet]
        public ActionResult Consultar()
        {
            try
            {
                List<Consulta> listaConsulta = new List<Consulta>();
                clsConsulta consulta = new clsConsulta();
                var data = consulta.ConsultarConsultas().ToList();
                foreach (var item in data)
                {
                    Consulta modelo = new Consulta();
                    modelo.Id = item.Id;
                    modelo.CodigoConsulta = item.codigoConsulta;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Telefono = item.telefono;
                    modelo.Email = item.email;
                    modelo.Asunto = item.asunto;
                    modelo.Descripcion = item.descripcion;
                    modelo.Respuesta = item.respuesta;
                    modelo.MetodoIngreso = item.metodoIngreso;
                    modelo.FechaIngreso = item.fechaIngreso;
                    modelo.FechaRespuesta = item.fechaRespuesta;
                    modelo.Estado = item.estado;
                    modelo.GeneroSolicitante = modelo.GeneroSolicitante;

                    listaConsulta.Add(modelo);
                }

                return View(listaConsulta);
            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar :GET
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
            catch (Exception)
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar :POST
        [HttpPost]
        public ActionResult Agregar(Consulta consulta)
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
                    return View(consulta);
                }
                clsConsulta objConsulta = new clsConsulta();
                //Variables de SESSION
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                string Apellido1Usuario = System.Web.HttpContext.Current.Session["apellido1"] as String;
                string Apellido2Usuario = System.Web.HttpContext.Current.Session["apellido2"] as String;
                bool resultado = objConsulta.AgregarConsulta(consulta.NombreSolicitante, consulta.ApellidoSolicitante1, 
                    consulta.ApellidoSolicitante2, consulta.Telefono, consulta.Email, consulta.Asunto, consulta.Descripcion, 
                    consulta.Respuesta, consulta.MetodoIngreso, consulta.GeneroSolicitante, consulta.FechaIngreso, 
                    consulta.FechaRespuesta, consulta.Estado, CedulaUsuario, NombreUsuario, Apellido1Usuario, Apellido2Usuario);
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
            catch (Exception)
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar :GET
        [HttpGet]
        public ActionResult Actualizar(int Id)
        {
            try
            {
                clsConsulta consulta = new clsConsulta();
                var dato = consulta.ConsultarConsulta(Id);
                Consulta modelo = new Consulta();
                modelo.CodigoConsulta = dato[0].codigoConsulta;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = dato[0].telefono;
                modelo.Telefono = dato[0].telefono;
                modelo.Email = dato[0].email;
                modelo.Asunto = dato[0].asunto;
                modelo.Descripcion = dato[0].descripcion;
                modelo.Respuesta = dato[0].respuesta;
                modelo.MetodoIngreso = dato[0].metodoIngreso;
                modelo.FechaIngreso = dato[0].fechaIngreso;
                modelo.FechaRespuesta = dato[0].fechaRespuesta;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
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
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar .POST
        [HttpPost]
        public ActionResult Actualizar(int Id, Consulta consulta)
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
                    return View(consulta);
                }
                clsConsulta objConsulta = new clsConsulta();
                //Variables de SESSION
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                string Apellido1Usuario = System.Web.HttpContext.Current.Session["apellido1"] as String;
                string Apellido2Usuario = System.Web.HttpContext.Current.Session["apellido2"] as String;
                bool resultado = objConsulta.ActualizarConsulta(consulta.Id, consulta.CodigoConsulta, consulta.NombreSolicitante, 
                    consulta.ApellidoSolicitante1, consulta.ApellidoSolicitante2, consulta.Telefono, consulta.Email, consulta.Asunto, 
                    consulta.Descripcion, consulta.Respuesta, consulta.MetodoIngreso, consulta.GeneroSolicitante, consulta.FechaIngreso,
                    consulta.FechaRespuesta, consulta.Estado, CedulaUsuario, NombreUsuario, Apellido1Usuario, Apellido2Usuario);
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

        //Accion para detalles :GET
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            try
            {
                clsConsulta consulta = new clsConsulta();
                var dato = consulta.ConsultarConsulta(id);
                Consulta modelo = new Consulta();
                modelo.Id = dato[0].Id;
                modelo.CodigoConsulta = dato[0].codigoConsulta;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = dato[0].telefono;
                modelo.Email = dato[0].email;
                modelo.Asunto = dato[0].asunto;
                modelo.Descripcion = dato[0].descripcion;
                modelo.Respuesta = dato[0].respuesta;
                modelo.MetodoIngreso = dato[0].metodoIngreso;
                modelo.FechaIngreso = dato[0].fechaIngreso;
                modelo.FechaRespuesta = dato[0].fechaRespuesta;
                modelo.Estado = dato[0].estado;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
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

        //Accion para eliminar :POST
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                clsConsulta consulta = new clsConsulta();
                bool resultado = consulta.EliminarConsulta(Id);
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
            catch (Exception)
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para eliminar la tabla :GET
        [HttpPost]
        public ActionResult EliminarTabla()
        {
            try
            {
                string tabla = "RefConsecutivoConsulta";
                string tabla1 = "Usuario_Consulta";
                string tabla2 = "Consulta";
                clsControl control = new clsControl();
                bool resultado = control.Eliminar_Tabla(tabla, tabla1, tabla2);
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
    }
}