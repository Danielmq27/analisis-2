using Capa_Logica;
using Capa_Presentacion.Filters;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    //Controlador ConsultaController
    [ValidarSesion]
    public class ConsultaController : Controller
    {
        //Accion del rol administrador para visualizar las consultas
        [Acceso]
        [HttpGet]
        public ActionResult Index()
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
                    modelo.Telefono = (int)item.telefono;
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
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("Consulta", "Index", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar :GET
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
                new SelectListItem { Value = "Pendiente", Text = "Pendiente" },
                new SelectListItem { Value = "Finalizado", Text = "Finalizado" }
                                               }, "Value", "Text");
                return View();
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("Consulta", "Agregar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para agregar :POST
        [Acceso]
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
                new SelectListItem { Value = "Asignada", Text = "Asignada" },
                new SelectListItem { Value = "Tramite", Text = "Trámite" },
                new SelectListItem { Value = "Realizada", Text = "Realizada"}
                                               }, "Value", "Text");
                    //Retornamos el modelo
                    return View(consulta);
                }

                string NombreArchivo = consulta.Archivo.FileName;
                Stream strmStream = consulta.Archivo.InputStream;

                Int32 Tamaño = (Int32)strmStream.Length;
                byte[] BitesArchivo = new byte[Tamaño + 1];
                strmStream.Read(BitesArchivo, 0, Tamaño);
                strmStream.Close();

                string TipoArchivo = consulta.Archivo.ContentType;
                string Extension = Path.GetExtension(NombreArchivo);

                clsConsulta objConsulta = new clsConsulta();
                //Variables de SESSION
                string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                bool resultado = objConsulta.AgregarConsulta(CedulaUsuario, consulta.NombreSolicitante, consulta.ApellidoSolicitante1,
                    consulta.ApellidoSolicitante2, consulta.Telefono, consulta.Email, consulta.Asunto, consulta.Descripcion,
                    consulta.Respuesta, consulta.MetodoIngreso, consulta.GeneroSolicitante, consulta.FechaIngreso,
                    consulta.FechaRespuesta, consulta.Estado, NombreArchivo, TipoArchivo, Extension, BitesArchivo);
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
                bitacora.AgregarBitacora("Consulta", "Agregar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar :GET
        [Acceso]
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
                modelo.Telefono = (int)dato[0].telefono;
                modelo.Email = dato[0].email;
                modelo.Asunto = dato[0].asunto;
                modelo.Descripcion = dato[0].descripcion;
                modelo.Respuesta = dato[0].respuesta;
                modelo.MetodoIngreso = dato[0].metodoIngreso;
                modelo.FechaIngreso = dato[0].fechaIngreso;
                modelo.FechaRespuesta = dato[0].fechaRespuesta;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                modelo.Estado = dato[0].estado;
                modelo.NombreArchivo = dato[0].nombreArchivo;
                modelo.TipoArchivo = dato[0].tipoArchivo;
                modelo.Extension = dato[0].extension;
                modelo.ArchivoFile = dato[0].archivo.ToArray();
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
            catch(Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("Consulta", "Actualizar", ex.Message, NombreUsuario, 0);
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para actualizar :POST
        [Acceso]
        [HttpPost]
        public ActionResult Actualizar(Consulta consulta)
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
                else if (consulta.Archivo != null)
                {
                    string NombreArchivo = consulta.Archivo.FileName;
                    Stream strmStream = consulta.Archivo.InputStream;

                    Int32 Tamaño = (Int32)strmStream.Length;
                    byte[] BitesArchivo = new byte[Tamaño + 1];
                    strmStream.Read(BitesArchivo, 0, Tamaño);
                    strmStream.Close();

                    string TipoArchivo = consulta.Archivo.ContentType;
                    string Extension = Path.GetExtension(NombreArchivo);
                    clsConsulta objConsulta = new clsConsulta();
                    //Variables de SESSION
                    string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                    bool resultado = objConsulta.ActualizarConsulta(consulta.Id, consulta.CodigoConsulta, CedulaUsuario, consulta.NombreSolicitante,
                        consulta.ApellidoSolicitante1, consulta.ApellidoSolicitante2, consulta.Telefono, consulta.Email, consulta.Asunto,
                        consulta.Descripcion, consulta.Respuesta, consulta.MetodoIngreso, consulta.GeneroSolicitante, consulta.FechaIngreso,
                        consulta.FechaRespuesta, consulta.Estado, NombreArchivo, TipoArchivo, Extension, BitesArchivo);
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
                else
                {
                    clsConsulta objConsulta = new clsConsulta();
                    //Variables de SESSION
                    string CedulaUsuario = System.Web.HttpContext.Current.Session["cedula"] as String;
                    bool resultado = objConsulta.ActualizarConsulta(consulta.Id, consulta.CodigoConsulta, CedulaUsuario, consulta.NombreSolicitante,
                        consulta.ApellidoSolicitante1, consulta.ApellidoSolicitante2, consulta.Telefono, consulta.Email, consulta.Asunto,
                        consulta.Descripcion, consulta.Respuesta, consulta.MetodoIngreso, consulta.GeneroSolicitante, consulta.FechaIngreso,
                        consulta.FechaRespuesta, consulta.Estado, consulta.NombreArchivo, consulta.TipoArchivo, consulta.Extension, consulta.ArchivoFile);
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
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("Consulta", "Actualizar", ex.Message, NombreUsuario, 0);
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        public ActionResult Descargar(Consulta consulta)
        {
            try
            {
                clsConsulta obj = new clsConsulta();
                var x = obj.ConsultarConsulta(consulta.Id);

                Response.Clear();
                MemoryStream ms = new MemoryStream(x[0].archivo.ToArray());
                Response.ContentType = x[0].tipoArchivo;
                Response.AddHeader("content-disposition", "attachment;filename= " + x[0].nombreArchivo);
                Response.Buffer = true;
                ms.WriteTo(Response.OutputStream);
                Response.End();

                return RedirectToAction("Detalles", "Consulta");
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("Consulta", "Agregar", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para detalles :GET
        [Acceso]
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
                modelo.Telefono = (int)dato[0].telefono;
                modelo.Email = dato[0].email;
                modelo.Asunto = dato[0].asunto;
                modelo.Descripcion = dato[0].descripcion;
                modelo.Respuesta = dato[0].respuesta;
                modelo.MetodoIngreso = dato[0].metodoIngreso;
                modelo.FechaIngreso = dato[0].fechaIngreso;
                modelo.FechaRespuesta = dato[0].fechaRespuesta;
                modelo.Estado = dato[0].estado;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                modelo.NombreArchivo = dato[0].nombreArchivo;
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
                bitacora.AgregarBitacora("Consulta", "Detalles", ex.Message, NombreUsuario, 0);
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para eliminar :POST
        [Acceso]
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                clsConsulta consulta = new clsConsulta();
                bool resultado = consulta.EliminarConsulta(Id);
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
                bitacora.AgregarBitacora("Consulta", "Eliminar", ex.Message, NombreUsuario, 0);
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para eliminar la tabla :GET
        [Acceso]
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
                bitacora.AgregarBitacora("Consulta", "EliminarTabla", ex.Message, NombreUsuario, 0);
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}