using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    //Controlador PrestamoPermanenteController
    public class PrestamoPermanenteController : Controller
    {
        //Accion para el rol administrador para ver todos los prestamos permanentes
        [HttpGet]
        public ActionResult Administrador()
        {
            try
            {
                List<PrestamoPermanente> listaPrestamoPermanente = new List<PrestamoPermanente>();
                clsPrestamoPermanente prestamoPermanente = new clsPrestamoPermanente();
                var data = prestamoPermanente.ConsultarPrestamosPermanente().ToList();
                foreach (var item in data)
                {
                    PrestamoPermanente modelo = new PrestamoPermanente();
                    modelo.Id = item.Id;
                    modelo.CodigoPrestamoPermanente = item.codigoPrestamoPermanente;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Despacho = item.despacho;
                    modelo.Telefono = item.telefono;
                    modelo.Extension = item.extension;
                    modelo.InformacionAdicional = item.informacionAdicional;
                    modelo.GeneroSolicitante = item.generoSolicictante;
                    modelo.FechaPrestamo = item.fechaPrestamo;
                    modelo.Estado = item.estado;

                    listaPrestamoPermanente.Add(modelo);
                }

                return View(listaPrestamoPermanente);
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para el rol editar para ver todos los prestamos permanentes
        [HttpGet]
        public ActionResult Editar()
        {
            try
            {
                List<PrestamoPermanente> listaPrestamoPermanente = new List<PrestamoPermanente>();
                clsPrestamoPermanente prestamoPermanente = new clsPrestamoPermanente();
                var data = prestamoPermanente.ConsultarPrestamosPermanente().ToList();
                foreach (var item in data)
                {
                    PrestamoPermanente modelo = new PrestamoPermanente();
                    modelo.Id = item.Id;
                    modelo.CodigoPrestamoPermanente = item.codigoPrestamoPermanente;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Despacho = item.despacho;
                    modelo.Telefono = item.telefono;
                    modelo.Extension = item.extension;
                    modelo.InformacionAdicional = item.informacionAdicional;
                    modelo.GeneroSolicitante = item.generoSolicictante;
                    modelo.FechaPrestamo = item.fechaPrestamo;
                    modelo.Estado = item.estado;

                    listaPrestamoPermanente.Add(modelo);
                }

                return View(listaPrestamoPermanente);
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para el rol consultar para ver todos los prestamos permanentes
        [HttpGet]
        public ActionResult Consultar()
        {
            try
            {
                List<PrestamoPermanente> listaPrestamoPermanente = new List<PrestamoPermanente>();
                clsPrestamoPermanente prestamoPermanente = new clsPrestamoPermanente();
                var data = prestamoPermanente.ConsultarPrestamosPermanente().ToList();
                foreach (var item in data)
                {
                    PrestamoPermanente modelo = new PrestamoPermanente();
                    modelo.Id = item.Id;
                    modelo.CodigoPrestamoPermanente = item.codigoPrestamoPermanente;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Despacho = item.despacho;
                    modelo.Telefono = item.telefono;
                    modelo.Extension = item.extension;
                    modelo.InformacionAdicional = item.informacionAdicional;
                    modelo.GeneroSolicitante = item.generoSolicictante;
                    modelo.FechaPrestamo = item.fechaPrestamo;
                    modelo.Estado = item.estado;

                    listaPrestamoPermanente.Add(modelo);
                }

                return View(listaPrestamoPermanente);
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar prestamos permanentes
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

        //Accion para agregar prestamos permanentes
        [HttpPost]
        public ActionResult Agregar(PrestamoPermanente prestamoPermanente)
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
                    return View(prestamoPermanente);
                }
                clsPrestamoPermanente objPrestamoPermanente = new clsPrestamoPermanente();
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                string Apellido1Usuario = System.Web.HttpContext.Current.Session["apellido1"] as String;
                string Apellido2Usuario = System.Web.HttpContext.Current.Session["apellido2"] as String;
                bool resultado = objPrestamoPermanente.AgregarPrestamoPermanente(prestamoPermanente.NombreSolicitante, 
                    prestamoPermanente.ApellidoSolicitante1, prestamoPermanente.ApellidoSolicitante2, 
                    prestamoPermanente.Despacho, prestamoPermanente.Telefono, prestamoPermanente.Extension,
                    prestamoPermanente.InformacionAdicional, prestamoPermanente.GeneroSolicitante,
                    prestamoPermanente.FechaPrestamo, prestamoPermanente.Estado, CedulaUsuario, NombreUsuario,
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
            catch (Exception)
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar prestamos permanentes
        [HttpGet]
        public ActionResult Actualizar(int Id)
        {
            try
            {
                clsPrestamoPermanente prestamoPermanente = new clsPrestamoPermanente();
                var dato = prestamoPermanente.ConsultarPrestamoPermanente(Id);
                PrestamoPermanente modelo = new PrestamoPermanente();
                modelo.CodigoPrestamoPermanente = dato[0].codigoPrestamoPermanente;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Despacho = dato[0].despacho;
                modelo.Telefono = dato[0].telefono;
                modelo.Extension = dato[0].extension;
                modelo.InformacionAdicional = dato[0].informacionAdicional;
                modelo.GeneroSolicitante = dato[0].generoSolicictante;
                modelo.FechaPrestamo = dato[0].fechaPrestamo;
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

        //Accion para actualizar prestamos permanentes
        [HttpPost]
        public ActionResult Actualizar(int Id, PrestamoPermanente prestamoPermanente)
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
                    return View(prestamoPermanente);
                }
                clsPrestamoPermanente objPrestamoPermanente = new clsPrestamoPermanente();
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                string Apellido1Usuario = System.Web.HttpContext.Current.Session["apellido1"] as String;
                string Apellido2Usuario = System.Web.HttpContext.Current.Session["apellido2"] as String;
                bool resultado = objPrestamoPermanente.ActualizarPrestamoPermanente(prestamoPermanente.Id, 
                    prestamoPermanente.CodigoPrestamoPermanente, prestamoPermanente.NombreSolicitante, 
                    prestamoPermanente.ApellidoSolicitante1, prestamoPermanente.ApellidoSolicitante2,
                    prestamoPermanente.Despacho, prestamoPermanente.Telefono, prestamoPermanente.Extension,
                    prestamoPermanente.InformacionAdicional, prestamoPermanente.GeneroSolicitante, 
                    prestamoPermanente.FechaPrestamo, prestamoPermanente.Estado, CedulaUsuario, NombreUsuario, 
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

        //Accion para detalles de un prestamo permanente
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            try
            {
                clsPrestamoPermanente prestamoPermanente = new clsPrestamoPermanente();
                var dato = prestamoPermanente.ConsultarPrestamoPermanente(id);
                PrestamoPermanente modelo = new PrestamoPermanente();
                modelo.Id = dato[0].Id;
                modelo.CodigoPrestamoPermanente = dato[0].codigoPrestamoPermanente;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Despacho = dato[0].despacho;
                modelo.Telefono = dato[0].telefono;
                modelo.Extension = dato[0].extension;
                modelo.InformacionAdicional = dato[0].informacionAdicional;
                modelo.GeneroSolicitante = dato[0].generoSolicictante;
                modelo.FechaPrestamo = dato[0].fechaPrestamo;
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

        //Accion para eliminar prestamos permanentes
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                clsPrestamoPermanente prestamoPermanente = new clsPrestamoPermanente();
                bool resultado = prestamoPermanente.EliminarPrestamoPermanente(Id);
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

        //Accion para eliminar todos los prestamos permanentes
        [HttpPost]
        public ActionResult EliminarTabla()
        {
            try
            {
                string tabla = "RefConsecutivoPP";
                string tabla1 = "Usuario_PrestamoPermanente";
                string tabla2 = "PrestamoPermanente";
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