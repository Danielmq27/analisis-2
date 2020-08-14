using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class PrestamoEquipoController : Controller
    {
        [HttpGet]
        public ActionResult Administrador()
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
            catch
            {
                return RedirectToAction("Roles", "Index");
            }
        }

        [HttpGet]
        public ActionResult Editar()
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
            catch
            {
                return RedirectToAction("Roles", "Index");
            }
        }

        [HttpGet]
        public ActionResult Consultar()
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
            catch
            {
                return RedirectToAction("Roles", "Index");
            }
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Roles", "Index");
            }
        }

        [HttpPost]
        public ActionResult Agregar(PrestamoEquipo prestamoEquipo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(prestamoEquipo);
                }
                clsPrestamoEquipo objPrestamoEquipo = new clsPrestamoEquipo();
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                string Apellido1Usuario = System.Web.HttpContext.Current.Session["apellido1"] as String;
                string Apellido2Usuario = System.Web.HttpContext.Current.Session["apellido2"] as String;
                bool resultado = objPrestamoEquipo.AgregarPrestamoEquipo(prestamoEquipo.NombreSolicitante, 
                    prestamoEquipo.ApellidoSolicitante1, prestamoEquipo.ApellidoSolicitante2, prestamoEquipo.CedulaSolicitante, 
                    prestamoEquipo.Departamento, prestamoEquipo.TipoEquipo, prestamoEquipo.Implementos, 
                    prestamoEquipo.EspecificacionImplementos, prestamoEquipo.GeneroSolicitante, prestamoEquipo.FechaIngreso, 
                    prestamoEquipo.FechaRespuesta, prestamoEquipo.Estado, CedulaUsuario, NombreUsuario, Apellido1Usuario, 
                    Apellido2Usuario);
                if (resultado)
                {
                    return RedirectToAction("Administrador");
                }
                else
                {
                    //Pagina de ERROR
                    return RedirectToAction("404", "Error");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("505", "Error");
            }
        }

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
                return View(modelo);
            }
            catch
            {
                return RedirectToAction("504", "Error");
            }
        }

        [HttpPost]
        public ActionResult Actualizar(int Id, PrestamoEquipo prestamoEquipo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(prestamoEquipo);
                }
                clsPrestamoEquipo objPrestamoEquipo = new clsPrestamoEquipo();
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                string Apellido1Usuario = System.Web.HttpContext.Current.Session["apellido1"] as String;
                string Apellido2Usuario = System.Web.HttpContext.Current.Session["apellido2"] as String;
                bool resultado = objPrestamoEquipo.ActualizarPrestamoEquipo(prestamoEquipo.Id, prestamoEquipo.CodigoPrestamoEquipo, 
                    prestamoEquipo.NombreSolicitante, prestamoEquipo.ApellidoSolicitante1, prestamoEquipo.ApellidoSolicitante2, 
                    prestamoEquipo.CedulaSolicitante, prestamoEquipo.Departamento, prestamoEquipo.TipoEquipo, 
                    prestamoEquipo.Implementos, prestamoEquipo.EspecificacionImplementos, prestamoEquipo.GeneroSolicitante, 
                    prestamoEquipo.FechaIngreso, prestamoEquipo.FechaRespuesta, prestamoEquipo.Estado, CedulaUsuario, NombreUsuario,
                    Apellido1Usuario, Apellido2Usuario);
                if (resultado)
                {
                    return RedirectToAction("Administrador");
                }
                else
                {
                    return RedirectToAction("404", "Error");
                }
            }
            catch
            {
                return RedirectToAction("504", "Error");
            }
        }

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
                modelo.CedulaUsuario = dato[0].cedulaSolicitante;
                modelo.Nombre = dato[0].nombre;
                modelo.Apellido1 = dato[0].apellido1;
                modelo.Apellido2 = dato[0].apellido2;

                return View(modelo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Eliminar(int Id)
        {
            try
            {
                clsPrestamoEquipo prestamoEquipo = new clsPrestamoEquipo();
                bool resultado = prestamoEquipo.EliminarPrestamoEquipo(Id);
                if (resultado)
                {
                    return RedirectToAction("Administrador");
                }
                else
                {
                    return RedirectToAction("404", "Error");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("505", "Error");
            }
        }

        public ActionResult EliminarTabla()
        {
            try
            {
                string tabla = "RefConsecutivoPE";
                string tabla1 = "Usuario_PrestamoEquipo";
                string tabla2 = "PrestamoEquipo";
                clsControl control = new clsControl();
                bool resultado = control.Eliminar_Tabla(tabla, tabla1, tabla2);
                if (resultado)
                {
                    return RedirectToAction("Administrador");
                }
                else
                {
                    return RedirectToAction("404", "Error");
                }
            }
            catch
            {
                return RedirectToAction("505", "Error");
            }
        }
    }
}