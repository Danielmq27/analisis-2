using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class AuditoriaFormularioCIIE
    {
        public int Id { get; set; }

        [Display(Name = "Código CIIE")]
        public string CodigoCIIE { get; set; }

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

        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Display(Name = "Tipo de Despacho")]
        public string TipoDespacho { get; set; }

        [Display(Name = "Fracción")]
        public string Fraccion { get; set; }

        [Display(Name = "Especificación del Despacho")]
        public string EspecificacionDespacho { get; set; }

        [Display(Name = "Tipo de Consulta")]
        public string TipoConsulta { get; set; }

        [Display(Name = "Especificación de la Consulta")]
        public string EspecificacionConsulta { get; set; }

        public string Tema { get; set; }

        [Display(Name = "Información Requerida")]
        public string InformacionRequerida { get; set; }

        [Display(Name = "Uso de Información")]
        public string UsoInformacion { get; set; }

        [Display(Name = "Género del Solicitante")]
        public string GeneroSolicitante { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}