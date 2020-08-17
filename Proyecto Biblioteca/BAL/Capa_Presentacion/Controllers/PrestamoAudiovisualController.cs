using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    //Controlador PrestamoAudiovisualController
    public class PrestamoAudiovisualController : Controller
    {
        //Accion para el rol administrador para ver los prestamos audiovisuales
        [HttpGet]
        public ActionResult Administrador()
        {
            try
            {
                List<PrestamoAudiovisual> listaPrestamoAudiovisual = new List<PrestamoAudiovisual>();
                clsPrestamoAudiovisual prestamoAudiovisual = new clsPrestamoAudiovisual();
                var data = prestamoAudiovisual.ConsultarPrestamosAudioVisual().ToList();
                foreach (var item in data)
                {
                    PrestamoAudiovisual modelo = new PrestamoAudiovisual();
                    modelo.Id = item.Id;
                    modelo.CodigoPrestamoAudiovisual = item.codigoPrestamoAudiovisual;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Telefono = item.telefono;
                    modelo.Departamento = item.departamento;
                    modelo.NombreActividad = item.nombreActividad;
                    modelo.Categoria = item.categoria;
                    modelo.EspecificacionCategoria = item.especificacionCategoria;
                    modelo.Ubicacion = item.ubicacion;
                    modelo.HoraInicio = item.horaInicio;
                    modelo.HoraFinal = item.horaFin;
                    modelo.Descripcion = item.descripcion;
                    modelo.EquipoRequerido = item.equipoRequerido;
                    modelo.Aforo = item.aforo;
                    modelo.GeneroSolicitante = item.generoSolicitante;

                    listaPrestamoAudiovisual.Add(modelo);
                }

                return View(listaPrestamoAudiovisual);
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para  el rol editar para ver los prestamos audiovisuales
        [HttpGet]
        public ActionResult Editar()
        {
            try
            {
                List<PrestamoAudiovisual> listaPrestamoAudiovisual = new List<PrestamoAudiovisual>();
                clsPrestamoAudiovisual prestamoAudiovisual = new clsPrestamoAudiovisual();
                var data = prestamoAudiovisual.ConsultarPrestamosAudioVisual().ToList();
                foreach (var item in data)
                {
                    PrestamoAudiovisual modelo = new PrestamoAudiovisual();
                    modelo.Id = item.Id;
                    modelo.CodigoPrestamoAudiovisual = item.codigoPrestamoAudiovisual;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Telefono = item.telefono;
                    modelo.Departamento = item.departamento;
                    modelo.NombreActividad = item.nombreActividad;
                    modelo.Categoria = item.categoria;
                    modelo.EspecificacionCategoria = item.especificacionCategoria;
                    modelo.Ubicacion = item.ubicacion;
                    modelo.HoraInicio = item.horaInicio;
                    modelo.HoraFinal = item.horaFin;
                    modelo.Descripcion = item.descripcion;
                    modelo.EquipoRequerido = item.equipoRequerido;
                    modelo.Aforo = item.aforo;
                    modelo.GeneroSolicitante = item.generoSolicitante;

                    listaPrestamoAudiovisual.Add(modelo);
                }

                return View(listaPrestamoAudiovisual);
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para el rol consultar para ver los prestamos audiovisuales
        [HttpGet]
        public ActionResult Consultar()
        {
            try
            {
                List<PrestamoAudiovisual> listaPrestamoAudiovisual = new List<PrestamoAudiovisual>();
                clsPrestamoAudiovisual prestamoAudiovisual = new clsPrestamoAudiovisual();
                var data = prestamoAudiovisual.ConsultarPrestamosAudioVisual().ToList();
                foreach (var item in data)
                {
                    PrestamoAudiovisual modelo = new PrestamoAudiovisual();
                    modelo.Id = item.Id;
                    modelo.CodigoPrestamoAudiovisual = item.codigoPrestamoAudiovisual;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Telefono = item.telefono;
                    modelo.Departamento = item.departamento;
                    modelo.NombreActividad = item.nombreActividad;
                    modelo.Categoria = item.categoria;
                    modelo.EspecificacionCategoria = item.especificacionCategoria;
                    modelo.Ubicacion = item.ubicacion;
                    modelo.HoraInicio = item.horaInicio;
                    modelo.HoraFinal = item.horaFin;
                    modelo.Descripcion = item.descripcion;
                    modelo.EquipoRequerido = item.equipoRequerido;
                    modelo.Aforo = item.aforo;
                    modelo.GeneroSolicitante = item.generoSolicitante;

                    listaPrestamoAudiovisual.Add(modelo);
                }

                return View(listaPrestamoAudiovisual);
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar prestamos audiovisuales
        [HttpGet]
        public ActionResult Agregar()
        {
            try
            {
                ViewBag.genero = new SelectList(new[] {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
                return View();
            }
            catch (Exception)
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar prestamos audiovisuales
        [HttpPost]
        public ActionResult Agregar(PrestamoAudiovisual prestamoAudiovisual)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.genero = new SelectList(new[] {
                        new SelectListItem { Value = "Masculino", Text = "Masculino" },
                        new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
                    return View(prestamoAudiovisual);
                }
                clsPrestamoAudiovisual objPrestamoAudiovisual = new clsPrestamoAudiovisual();
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                string Apellido1Usuario = System.Web.HttpContext.Current.Session["apellido1"] as String;
                string Apellido2Usuario = System.Web.HttpContext.Current.Session["apellido2"] as String;
                bool resultado = objPrestamoAudiovisual.AgregarPrestamoAudioVisual(prestamoAudiovisual.NombreSolicitante,
                    prestamoAudiovisual.ApellidoSolicitante1, prestamoAudiovisual.ApellidoSolicitante2, prestamoAudiovisual.Telefono, 
                    prestamoAudiovisual.Departamento, prestamoAudiovisual.NombreActividad, prestamoAudiovisual.Categoria, 
                    prestamoAudiovisual.EspecificacionCategoria, prestamoAudiovisual.Ubicacion, prestamoAudiovisual.HoraInicio,
                    prestamoAudiovisual.HoraFinal, prestamoAudiovisual.Descripcion, prestamoAudiovisual.EquipoRequerido,
                    prestamoAudiovisual.Aforo, prestamoAudiovisual.GeneroSolicitante, CedulaUsuario, NombreUsuario, Apellido1Usuario,
                    Apellido2Usuario);
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

        //Accion para actualizar prestamos audiovisuales
        [HttpGet]
        public ActionResult Actualizar(int Id)
        {
            try
            {
                clsPrestamoAudiovisual prestamoAudiovisual = new clsPrestamoAudiovisual();
                var dato = prestamoAudiovisual.ConsultarPrestamoAudioVisual(Id);
                PrestamoAudiovisual modelo = new PrestamoAudiovisual();
                modelo.CodigoPrestamoAudiovisual = dato[0].codigoPrestamoAudiovisual;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = dato[0].telefono;
                modelo.Departamento = dato[0].departamento;
                modelo.NombreActividad = dato[0].nombreActividad;
                modelo.Categoria = dato[0].categoria;
                modelo.EspecificacionCategoria = dato[0].especificacionCategoria;
                modelo.Ubicacion = dato[0].ubicacion;
                modelo.HoraInicio = dato[0].horaInicio;
                modelo.HoraFinal = dato[0].horaFin;
                modelo.Descripcion = dato[0].descripcion;
                modelo.EquipoRequerido = dato[0].equipoRequerido;
                modelo.Aforo = dato[0].aforo;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                ViewBag.genero = new SelectList(new[] {
                new SelectListItem { Value = "Masculino", Text = "Masculino" },
                new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
                return View(modelo);
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar prestamos audiovisuales
        [HttpPost]
        public ActionResult Actualizar(int Id, PrestamoAudiovisual prestamoAudiovisual)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.genero = new SelectList(new[] {
                        new SelectListItem { Value = "Masculino", Text = "Masculino" },
                        new SelectListItem { Value = "Femenino", Text = "Femenino" }
                                               }, "Value", "Text");
                    return View(prestamoAudiovisual);
                }
                clsPrestamoAudiovisual objPrestamoAudiovisual = new clsPrestamoAudiovisual();
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                string Apellido1Usuario = System.Web.HttpContext.Current.Session["apellido1"] as String;
                string Apellido2Usuario = System.Web.HttpContext.Current.Session["apellido2"] as String;
                bool resultado = objPrestamoAudiovisual.ActualizarPrestamoAudioVisual(prestamoAudiovisual.Id,
                    prestamoAudiovisual.CodigoPrestamoAudiovisual, prestamoAudiovisual.NombreSolicitante, 
                    prestamoAudiovisual.ApellidoSolicitante1, prestamoAudiovisual.ApellidoSolicitante2, 
                    prestamoAudiovisual.Telefono, prestamoAudiovisual.Departamento, prestamoAudiovisual.NombreActividad, 
                    prestamoAudiovisual.Categoria, prestamoAudiovisual.EspecificacionCategoria, prestamoAudiovisual.Ubicacion,
                    prestamoAudiovisual.HoraInicio, prestamoAudiovisual.HoraFinal, prestamoAudiovisual.Descripcion, 
                    prestamoAudiovisual.EquipoRequerido, prestamoAudiovisual.Aforo, prestamoAudiovisual.GeneroSolicitante,
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

        //Accion para detalles de un prestamo audiovisual
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            try
            {
                clsPrestamoAudiovisual prestamoAudiovisual = new clsPrestamoAudiovisual();
                var dato = prestamoAudiovisual.ConsultarPrestamoAudioVisual(id);
                PrestamoAudiovisual modelo = new PrestamoAudiovisual();
                modelo.Id = dato[0].Id;
                modelo.CodigoPrestamoAudiovisual = dato[0].codigoPrestamoAudiovisual;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = dato[0].telefono;
                modelo.Departamento = dato[0].departamento;
                modelo.NombreActividad = dato[0].nombreActividad;
                modelo.Categoria = dato[0].categoria;
                modelo.EspecificacionCategoria = dato[0].especificacionCategoria;
                modelo.Ubicacion = dato[0].ubicacion;
                modelo.HoraInicio = dato[0].horaInicio;
                modelo.HoraFinal = dato[0].horaFin;
                modelo.Descripcion = dato[0].descripcion;
                modelo.EquipoRequerido = dato[0].equipoRequerido;
                modelo.Aforo = dato[0].aforo;
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

        //Accion para actualizar eliminar audiovisuales
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                clsPrestamoAudiovisual prestamoAudiovisual = new clsPrestamoAudiovisual();
                bool resultado = prestamoAudiovisual.EliminarPrestamoAudioVisual(Id);
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

        //Accion para eliminar todos los prestamos audiovisuales
        [HttpPost]
        public ActionResult EliminarTabla()
        {
            try
            {
                string tabla = "RefConsecutivoPA";
                string tabla1 = "Usuario_PrestamoAudiovisual";
                string tabla2 = "PrestamoAudiovisual";
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