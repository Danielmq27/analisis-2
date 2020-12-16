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
    //Controlador PrestamoEquipoController
    [ValidarSesion]
    public class PrestamoEquipoController : Controller
    {
        //Accion para el rol administrador para ver los prestamos de equipo
        [Acceso]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<PrestamoEquipo> listaPrestamoEquipo = new List<PrestamoEquipo>();
                clsPrestamoEquipo prestamoEquipo = new clsPrestamoEquipo();
                var data = prestamoEquipo.ConsultarPrestamosEquipo().ToList();
                foreach (var item in data)
                {
                    PrestamoEquipo modelo = new PrestamoEquipo();
                    modelo.Id = item.Id;
                    modelo.CodigoPrestamoEquipo = item.codigoPrestamoEquipo;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.CodigoPrestamoEquipo = item.codigoPrestamoEquipo;
                    modelo.CedulaSolicitante = item.cedulaSolicitante;
                    modelo.Departamento = item.departamento;
                    modelo.TipoEquipo = item.tipoEquipo;
                    modelo.Implementos = item.implementos;
                    modelo.EspecificacionImplementos = item.especificacionImplementos;
                    modelo.GeneroSolicitante = item.generoSolicictante;
                    modelo.FechaIngreso = item.fechaIngreso;
                    modelo.FechaRespuesta = item.fechaRespuesta;
                    modelo.Estado = item.estado;

                    listaPrestamoEquipo.Add(modelo);
                }

                return View(listaPrestamoEquipo);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("PrestamoEquipo", "Administrador", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar prestamos de equipo
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
                clsDepartamento departamento = new clsDepartamento();
                ViewBag.listaDepartamentos = departamento.ConsultarDepartamentos();
                return View();
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("PrestamoEquipo", "Agregar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar prestamos de equipo
        [Acceso]
        [HttpPost]
        public ActionResult Agregar(PrestamoEquipo prestamoEquipo)
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
                    clsDepartamento departamento = new clsDepartamento();
                    ViewBag.listaDepartamentos = departamento.ConsultarDepartamentos();
                    return View(prestamoEquipo);
                }
                clsPrestamoEquipo objPrestamoEquipo = new clsPrestamoEquipo();
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                bool resultado = objPrestamoEquipo.AgregarPrestamoEquipo(CedulaUsuario, prestamoEquipo.NombreSolicitante, 
                    prestamoEquipo.ApellidoSolicitante1, prestamoEquipo.ApellidoSolicitante2, prestamoEquipo.CedulaSolicitante, 
                    prestamoEquipo.Departamento, prestamoEquipo.TipoEquipo, prestamoEquipo.Implementos, 
                    prestamoEquipo.EspecificacionImplementos, prestamoEquipo.GeneroSolicitante, prestamoEquipo.FechaIngreso, 
                    prestamoEquipo.FechaRespuesta, prestamoEquipo.Estado);
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
                bitacora.AgregarBitacora("PrestamoEquipo", "Agregar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar prestamos de equipo
        [Acceso]
        [HttpGet]
        public ActionResult Actualizar(int Id)
        {
            try
            {
                clsPrestamoEquipo prestamoEquipo = new clsPrestamoEquipo();
                var dato = prestamoEquipo.ConsultarPrestamoEquipo(Id);
                PrestamoEquipo modelo = new PrestamoEquipo();
                modelo.CodigoPrestamoEquipo = dato[0].codigoPrestamoEquipo;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.CedulaSolicitante = dato[0].cedulaSolicitante;
                modelo.Departamento = dato[0].departamento;
                modelo.TipoEquipo = dato[0].tipoEquipo;
                modelo.Implementos = dato[0].implementos;
                modelo.EspecificacionImplementos = dato[0].especificacionImplementos;
                modelo.GeneroSolicitante = dato[0].generoSolicictante;
                modelo.FechaIngreso = dato[0].fechaIngreso;
                modelo.FechaRespuesta = dato[0].fechaRespuesta;
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
                clsDepartamento departamento = new clsDepartamento();
                ViewBag.listaDepartamentos = departamento.ConsultarDepartamentos();
                return View(modelo);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("PrestamoEquipo", "Actualizar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar prestamos de equipo
        [Acceso]
        [HttpPost]
        public ActionResult Actualizar(int Id, PrestamoEquipo prestamoEquipo)
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
                    clsDepartamento departamento = new clsDepartamento();
                    ViewBag.listaDepartamentos = departamento.ConsultarDepartamentos();
                    return View(prestamoEquipo);
                }
                clsPrestamoEquipo objPrestamoEquipo = new clsPrestamoEquipo();
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                bool resultado = objPrestamoEquipo.ActualizarPrestamoEquipo(prestamoEquipo.Id, prestamoEquipo.CodigoPrestamoEquipo, 
                    CedulaUsuario, prestamoEquipo.NombreSolicitante, prestamoEquipo.ApellidoSolicitante1, prestamoEquipo.ApellidoSolicitante2, 
                    prestamoEquipo.CedulaSolicitante, prestamoEquipo.Departamento, prestamoEquipo.TipoEquipo, 
                    prestamoEquipo.Implementos, prestamoEquipo.EspecificacionImplementos, prestamoEquipo.GeneroSolicitante, 
                    prestamoEquipo.FechaIngreso, prestamoEquipo.FechaRespuesta, prestamoEquipo.Estado);
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
                bitacora.AgregarBitacora("PrestamoEquipo", "Actualizar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para datellates de un prestamo de equipo
        [Acceso]
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            try
            {
                clsPrestamoEquipo prestamoEquipo = new clsPrestamoEquipo();
                var dato = prestamoEquipo.ConsultarPrestamoEquipo(id);
                PrestamoEquipo modelo = new PrestamoEquipo();
                modelo.Id = dato[0].Id;
                modelo.CodigoPrestamoEquipo = dato[0].codigoPrestamoEquipo;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.CodigoPrestamoEquipo = dato[0].codigoPrestamoEquipo;
                modelo.CedulaSolicitante = dato[0].cedulaSolicitante;
                modelo.Departamento = dato[0].departamento;
                modelo.TipoEquipo = dato[0].tipoEquipo;
                modelo.Implementos = dato[0].implementos;
                modelo.EspecificacionImplementos = dato[0].especificacionImplementos;
                modelo.GeneroSolicitante = dato[0].generoSolicictante;
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
                bitacora.AgregarBitacora("PrestamoEquipo", "Detalles", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para eliminar prestamos de equipo
        [Acceso]
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                clsPrestamoEquipo prestamoEquipo = new clsPrestamoEquipo();
                bool resultado = prestamoEquipo.EliminarPrestamoEquipo(Id);
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
                bitacora.AgregarBitacora("PrestamoEquipo", "Eliminar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }


        //Accion para eliminar todos prestamos de equipo
        [Acceso]
        [HttpPost]
        public ActionResult EliminarTabla()
        {
            try
            {
                string tabla = "RefConsecutivoPE";
                string tabla1 = "PrestamoEquipo";
                string tabla2 = "AuditoriaPrestamoEquipo";
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
                bitacora.AgregarBitacora("PrestamoEquipo", "EliminarTabla", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}