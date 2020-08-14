using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class PrestamoPermanenteController : Controller
    {
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
                return RedirectToAction("505", "Error");
            }
        }

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
                return RedirectToAction("505", "Error");
            }
        }

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
        public ActionResult Agregar(PrestamoPermanente prestamoPermanente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(prestamoPermanente);
                }
                clsPrestamoPermanente objPrestamoPermanente = new clsPrestamoPermanente();
                bool resultado = objPrestamoPermanente.AgregarPrestamoPermanente(prestamoPermanente.NombreSolicitante, prestamoPermanente.ApellidoSolicitante1, prestamoPermanente.ApellidoSolicitante2, prestamoPermanente.Despacho, prestamoPermanente.Telefono, prestamoPermanente.Extension, prestamoPermanente.InformacionAdicional, prestamoPermanente.GeneroSolicitante, prestamoPermanente.FechaPrestamo, prestamoPermanente.Estado);
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
                return View(modelo);
            }
            catch
            {
                return RedirectToAction("504", "Error");
            }
        }

        [HttpPost]
        public ActionResult Actualizar(int Id, PrestamoPermanente prestamoPermanente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(prestamoPermanente);
                }
                clsPrestamoPermanente objPrestamoPermanente = new clsPrestamoPermanente();
                bool resultado = objPrestamoPermanente.ActualizarPrestamoPermanente(prestamoPermanente.Id, prestamoPermanente.CodigoPrestamoPermanente, prestamoPermanente.NombreSolicitante, prestamoPermanente.ApellidoSolicitante1, prestamoPermanente.ApellidoSolicitante2, prestamoPermanente.Despacho, prestamoPermanente.Telefono, prestamoPermanente.Extension, prestamoPermanente.InformacionAdicional, prestamoPermanente.GeneroSolicitante, prestamoPermanente.FechaPrestamo, prestamoPermanente.Estado);
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
                clsPrestamoPermanente prestamoPermanente = new clsPrestamoPermanente();
                bool resultado = prestamoPermanente.EliminarPrestamoPermanente(Id);
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
    }
}