using Capa_Logica;
using Capa_Presentacion.Models;
using Capa_Presentacion.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class UsuarioController : Controller
    {
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
                return RedirectToAction("Roles", "Index");
            }
        }


        public ActionResult Agregar()
        {
            try
            {
                return View();
            }
            catch
            {
                return RedirectToAction("505", "Error");
            }
        }

        [HttpPost]
        public ActionResult Agregar(Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
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
                    return RedirectToAction("Agregar", "Usuario");
                }
            }
            catch
            {
                return RedirectToAction("Agregar", "Usuario");
            }
        }

        public ActionResult Actualizar(int Id)
        {
            try
            {
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
                return View(modelo);
            }
            catch
            {
                return RedirectToAction("504", "Error");
            }
        }
        [HttpPost]
        public ActionResult Actualizar(int Id, UsuarioEditar usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(usuario);
                }
                clsUsuario objUsuario = new clsUsuario();
                bool resultado = objUsuario.ActualizarUsuario(usuario.Id, usuario.Cedula, usuario.Nombre, usuario.Apellido1, usuario.Apellido2, Seguridad.Encriptar(usuario.Email), Seguridad.Encriptar(usuario.Clave), usuario.IdRol);
                if (resultado)
                {
                    return RedirectToAction("Index");
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
                    return RedirectToAction("404", "Error");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("505", "Error");
            }
        }
    }
}