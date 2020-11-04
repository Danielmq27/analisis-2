using MvcValidationExtensions.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    //Mapeo de la tabla AuditoriaPrestamoEquipo
    public class AuditoriaPrestamoEquipo
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo CodigoPrestamoEquipo
        [Display(Name = "Código")]
        public string CodigoPrestamoEquipo { get; set; }

        //Atributo Fecha
        public DateTime Fecha { get; set; }

        //Atributo Accion
        [Display(Name = "Acción")]
        public string Accion { get; set; }

        //Atributo Usuario
        public string Usuario { get; set; }

        //Atributo NombreSolicitante
        [Display(Name = "Nombre del solicitante")]
        public string NombreSolicitante { get; set; }

        //Atributo ApellidoSolicitante1
        [Display(Name = "Primer apellido del solicitante")]
        public string ApellidoSolicitante1 { get; set; }

        //Atributo ApellidoSolicitante2
        [Display(Name = "Segundo apellido del solicitante")]
        public string ApellidoSolicitante2 { get; set; }

        //Atributo CedulaSolicitante
        [Display(Name = "Cédula del solicitante")]
        public string CedulaSolicitante { get; set; }

        //Atributo Departamento
        public string Departamento { get; set; }

        //Atributo TipoEquipo
        [Display(Name = "Tipo de equipo")]
        public string TipoEquipo { get; set; }

        //Atributo Implementos
        public string Implementos { get; set; }

        //Atributo EspecificacionImplementos
        [Display(Name = "Especificación de implementos")]
        public string EspecificacionImplementos { get; set; }

        //Atributo GeneroSolicitante
        [Display(Name = "Género del solicitante")]
        public string GeneroSolicitante { get; set; }

        //Atributo FechaIngreso
        [Display(Name = "Fecha Ingreso")]
        public DateTime FechaIngreso { get; set; }

        //Atributo FechaRespuesta
        [Display(Name = "Fecha Respuesta")]
        public DateTime FechaRespuesta { get; set; }

        //Atributo Estado
        public string Estado { get; set; }
    }
}