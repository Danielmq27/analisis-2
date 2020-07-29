using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class ConsultaController : Controller
    {
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
                return RedirectToAction("505", "Error");
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
                return RedirectToAction("505", "Error");
            }
        }

        [HttpPost]
        public ActionResult Agregar(Consulta consulta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(consulta);
                }
                clsConsulta objConsulta = new clsConsulta();
                bool resultado = objConsulta.AgregarConsulta(consulta.NombreSolicitante, consulta.ApellidoSolicitante1, consulta.ApellidoSolicitante2, consulta.Telefono, consulta.Email, consulta.Asunto, consulta.Descripcion, consulta.Respuesta, consulta.MetodoIngreso, consulta.GeneroSolicitante, consulta.FechaIngreso, consulta.FechaRespuesta, consulta.Estado);
                if (resultado)
                {
                    return RedirectToAction("Index");
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
                return View(modelo);
            }
            catch
            {
                return RedirectToAction("504", "Error");
            }
        }

        [HttpPost]
        public ActionResult Actualizar(int Id, Consulta consulta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(consulta);
                }
                clsConsulta objConsulta = new clsConsulta();
                bool resultado = objConsulta.ActualizarConsulta(consulta.Id, consulta.CodigoConsulta, consulta.NombreSolicitante, consulta.ApellidoSolicitante1, consulta.ApellidoSolicitante2, consulta.Telefono, consulta.Email, consulta.Asunto, consulta.Descripcion, consulta.Respuesta, consulta.MetodoIngreso, consulta.GeneroSolicitante, consulta.FechaIngreso, consulta.FechaRespuesta, consulta.Estado);
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
                clsConsulta consulta = new clsConsulta();
                bool resultado = consulta.EliminarConsulta(Id);
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