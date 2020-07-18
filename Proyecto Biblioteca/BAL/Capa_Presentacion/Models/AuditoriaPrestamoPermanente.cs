using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class AuditoriaPrestamoPermanente
    {
        public int Id { get; set; }

        [Display(Name = "Código Préstamo Permanente")]
        public string CodigoPrestamoPermanente { get; set; }

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

        public string Despacho { get; set; }

        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        [Display(Name = "Extensión")]
        public string Extension { get; set; }

        [Display(Name = "Información Adicional")]
        public string InformacionAdicional { get; set; }

        [Display(Name = "Género del Solicitante")]
        public string GeneroSolicitante { get; set; }

        [Display(Name = "Fecha del Préstamo")]
        public DateTime FechaPrestamo { get; set; }

        public string Estado { get; set; }
    }
}