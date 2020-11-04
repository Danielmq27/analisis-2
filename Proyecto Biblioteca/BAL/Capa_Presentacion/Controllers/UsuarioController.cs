using Capa_Datos;
using Capa_Logica;
using Capa_Presentacion.Filters;
using Capa_Presentacion.Models;
using Capa_Presentacion.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Usuario = Capa_Presentacion.Models.Usuario;

namespace Capa_Presentacion.Controllers
{
    //Controlador UsuarioController
    [ValidarSesion]
    public class UsuarioController : Controller
    {
        //Accion para ver todos los usuarios
        [Acceso]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<Usuario> listaUsuarios = new List<Usuario>();
                clsUsuario usuario = new clsUsuario();
                var data = usuario.ConsultarUsuarios().ToList();
                foreach (var item in data)
                {
                    Usuario modelo = new Usuario();
                    modelo.Id = Convert.ToInt32(item.Id);
                    modelo.Cedula = item.cedula;
                    modelo.Nombre = item.nombre;
                    modelo.Apellido1 = item.apellido1;
                    modelo.Apellido2 = item.apellido2;
                    modelo.Email = Seguridad.Desencriptar(item.email);
                    modelo.Clave = item.clave;
                    modelo.IdRol = item.IdRol;

                    listaUsuarios.Add(modelo);

                }
                return View(listaUsuarios);
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar un usuario
        [Acceso]
        [HttpGet]
        public ActionResult Agregar()
        {
            try
            {
                clsRol rol = new clsRol();
                ViewBag.listaRoles = rol.ConsultarRoles();
                return View();
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar un usuario
        [Acceso]
        [HttpPost]
        public ActionResult Agregar(Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    clsRol rol = new clsRol();
                    ViewBag.listaRoles = rol.ConsultarRoles();
                    return View(usuario);
                }
                clsUsuario objUsuario = new clsUsuario();
                bool resultado = objUsuario.AgregarUsuario(usuario.Cedula, usuario.Nombre, usuario.Apellido1, usuario.Apellido2, Seguridad.Encriptar(usuario.Email), Seguridad.Encriptar(usuario.Clave), usuario.IdRol);
                if (resultado)
                {
                    Correo.enviarCorreo(usuario.Email, "Biblioteca Asamble Legislativa","Bienvenido al sistema, su clave temporal es:" + usuario.Clave, "");
                    return RedirectToAction("Index");
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

        //Accion para actualizar un usuario
        [Acceso]
        [HttpGet]
        public ActionResult Actualizar(int Id)
        {
            try
            {
                clsRol rol = new clsRol();
                clsUsuario usuario = new clsUsuario();
                var dato = usuario.ConsultarUsuario(Id);
                UsuarioEditar modelo = new UsuarioEditar();
                modelo.Cedula = dato[0].cedula;
                modelo.Nombre = dato[0].nombre;
                modelo.Apellido1 = dato[0].apellido1;
                modelo.Apellido2 = dato[0].apellido2;
                modelo.Email = Seguridad.Desencriptar(dato[0].email);
                modelo.Clave = dato[0].clave;
                modelo.IdRol = dato[0].IdRol;


                ViewBag.listaRoles = rol.ConsultarRoles();
                return View(modelo);
            }
            catch
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar un usuario
        [Acceso]
        [HttpPost]
        public ActionResult Actualizar(int Id, UsuarioEditar usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    clsRol rol = new clsRol();
                    ViewBag.listaRoles = rol.ConsultarRoles();
                    return View(usuario);
                }
                clsUsuario objUsuario = new clsUsuario();
                bool resultado = objUsuario.ActualizarUsuario(usuario.Id, usuario.Cedula, usuario.Nombre, usuario.Apellido1, usuario.Apellido2, Seguridad.Encriptar(usuario.Email), usuario.Clave, usuario.IdRol);
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
                bitacora.AgregarBitacora("Usuario", "Actualizar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para eliminar un usuario
        [Acceso]
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                clsUsuario objUsuario = new clsUsuario();
                bool resultado = objUsuario.EliminarUsuario(Id);
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
                bitacora.AgregarBitacora("Usuario", "Eliminar", "INTENTO DE AUTODESTRUCCIÓN" + ex.Message, NombreUsuario, 0);
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}