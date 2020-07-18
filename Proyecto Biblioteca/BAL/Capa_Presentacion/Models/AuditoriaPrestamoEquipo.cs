using MvcValidationExtensions.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class AuditoriaPrestamoEquipo
    {
        public int Id { get; set; }

        [Display(Name = "Código Prestamo Equipo")]
        public string CodigoPrestamoEquipo { get; set; }

        public DateTime Fecha { get; set; }

        [Display(Name = "Acción")]
        public string Accion { get; set; }

        public string Usuario { get; set; }

        [Display(Name = "Nombre del Solicitante")]
        public string NombreSolicitante { get; set; }

        [Display(Name = "Primer Apellido del Solicitante")]
        public string ApellidoSolicitante1 { get; set; }

        [Display(Name = "Segundo Apellido del Solicitante")]
        public string ApellidoSolicitante2 { get; set; }

        [Display(Name = "Cédula del Solicitante")]
        public string CedulaSolicitante { get; set; }

        public string Departamento { get; set; }

        [Display(Name = "Tipo de Equipo")]
        public string TipoEquipo { get; set; }

        public string Implementos { get; set; }

        [Display(Name = "Especificación de Implementos")]
        public string EspecificacionImplementos { get; set; }

        [Display(Name = "Género del Solicitante")]
        public string GeneroSolicitante { get; set; }

        public string Estado { get; set; }
    }
}