using Capa_Logica;
using Capa_Presentacion.Models;
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
                    modelo.Email = item.email;
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

        public ActionResult Nuevo()
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
        public ActionResult Nuevo(Usuario usuario)
        {
            try
            {
                clsUsuario objUsuario = new clsUsuario();
                bool resultado = objUsuario.AgregarUsuario(usuario.Cedula, usuario.Nombre, usuario.Apellido1, usuario.Apellido2, usuario.Email, usuario.Clave, usuario.IdRol);
                if (resultado)
                {
                    return RedirectToAction("Index");
                } else
                {
                    return RedirectToAction("Nuevo", "Usuario");
                }
            }
            catch
            {
                return RedirectToAction("Nuevo", "Usuario");
            }
        }

        public ActionResult Actualizar(int Id)
        {
            try
            {
                clsUsuario usuario = new clsUsuario();
                var dato = usuario.ConsultarUsuario(Id);
                Usuario modelo = new Usuario();
                modelo.Cedula = dato[0].cedula;
                modelo.Nombre = dato[0].nombre;
                modelo.Apellido1 = dato[0].apellido1;
                modelo.Apellido2 = dato[0].apellido2;
                modelo.Email = dato[0].email;
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
        public ActionResult Actualizar(int Id, Usuario usuario)
        {
            try
            {
                clsUsuario objUsuario = new clsUsuario();
                bool resultado = objUsuario.ActualizarUsuario(usuario.Id, usuario.Cedula, usuario.Nombre, usuario.Apellido1, usuario.Apellido2, usuario.Email, usuario.Clave, usuario.IdRol);
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