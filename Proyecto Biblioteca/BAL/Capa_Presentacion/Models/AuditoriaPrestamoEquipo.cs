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

        public string CodigoPrestamoEquipo { get; set; }

        public DateTime Fecha { get; set; }

        public string Accion { get; set; }

        public string Usuario { get; set; }

        public string NombreSolicitante { get; set; }

        public string ApellidoSolicitante1 { get; set; }

        public string ApellidoSolicitante2 { get; set; }

        public string CedulaSolicitante { get; set; }

        public string Departamento { get; set; }

        public string TipoEquipo { get; set; }

        public string Implementos { get; set; }

        public string EspecificacionImplementos { get; set; }

        public string GeneroSolicitante { get; set; }

        public string Estado { get; set; }
    }
}