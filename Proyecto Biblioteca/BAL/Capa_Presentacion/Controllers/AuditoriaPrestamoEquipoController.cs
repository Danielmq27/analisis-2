﻿using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    //Controlador AuditoriaPrestamoEquipoController
    public class AuditoriaPrestamoEquipoController : Controller
    {
        //Accion para ver todas las auditorias de prestamos de equipo
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                //Listado de AuditoriaPrestamoEquipo
                List<AuditoriaPrestamoEquipo> listaAuditoriaPrestamoEquipo = new List<AuditoriaPrestamoEquipo>();
                //Llamado de clsAuditoriaPrestamoEquipo
                clsAuditoriaPrestamoEquipo auditoriaPrestamoEquipo = new clsAuditoriaPrestamoEquipo();
                //Llamado de metodo ConsultarAuditoriasPrestamoEquipo
                var data = auditoriaPrestamoEquipo.ConsultarAuditoriasPrestamoEquipo();
                foreach (var item in data)
                {
                    //Llamado del modelo
                    AuditoriaPrestamoEquipo modelo = new AuditoriaPrestamoEquipo();
                    // Llenamos el modelo con los datos de la BD
                    modelo.Id = Convert.ToInt32(item.Id);
                    modelo.CodigoPrestamoEquipo = item.codigoPrestamoEquipo;
                    modelo.Fecha = (DateTime)item.fecha;
                    modelo.Accion = item.accion;
                    modelo.Usuario = item.usuarioBD;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.CedulaSolicitante = item.cedulaSolicitante;
                    modelo.Departamento = item.departamento;
                    modelo.TipoEquipo = item.tipoEquipo;
                    modelo.Implementos = item.implementos;
                    modelo.EspecificacionImplementos = item.especificacionImplementos;
                    modelo.GeneroSolicitante = item.generoSolicictante;
                    modelo.Estado = item.estado;

                    listaAuditoriaPrestamoEquipo.Add(modelo);
                }
                //Mandamos los datos a la vista
                return View(listaAuditoriaPrestamoEquipo);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("AuditoriaPrestamoEquipo", "Index", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }
        //Accion para ver los detalles de una auditoria
        [HttpGet]
        public ActionResult Detalles(int Id)
        {
            try
            {
                //Llamado de clsAuditoriaPrestamoEquipo 
                clsAuditoriaPrestamoEquipo auditoriaPrestamoEquipo = new clsAuditoriaPrestamoEquipo();
                //Llamado de metodo ConsultarAuditoriaPrestamoEquipo
                var dato = auditoriaPrestamoEquipo.ConsultarAuditoriaPrestamoEquipo(Id);
                //Llamado del modelo
                AuditoriaPrestamoEquipo modelo = new AuditoriaPrestamoEquipo();
                // Llenamos el modelo con los datos de la BD
                modelo.Id = Convert.ToInt32(dato[0].Id);
                modelo.CodigoPrestamoEquipo = dato[0].codigoPrestamoEquipo;
                modelo.Fecha = (DateTime)dato[0].fecha;
                modelo.Accion = dato[0].accion;
                modelo.Usuario = dato[0].usuarioBD;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.CedulaSolicitante = dato[0].cedulaSolicitante;
                modelo.Departamento = dato[0].departamento;
                modelo.TipoEquipo = dato[0].tipoEquipo;
                modelo.Implementos = dato[0].implementos;
                modelo.EspecificacionImplementos = dato[0].especificacionImplementos;
                modelo.GeneroSolicitante = dato[0].generoSolicictante;
                modelo.Estado = dato[0].estado;
                //Mandamos los datos a la vista
                return View(modelo);
            }
            catch (Exception ex)
            {
                //Bitacora
                string NombreUsuario = System.Web.HttpContext.Current.Session["nombre"] as String;
                clsBitacora bitacora = new clsBitacora();
                bitacora.AgregarBitacora("AuditoriaPrestamoEquipo", "Detalles", ex.Message, NombreUsuario, 0);
                //Pagina de error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}