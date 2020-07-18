using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class AuditoriaConsulta
    {
        public int Id { get; set; }

        [Display(Name = "Código Consulta")]
        public string CodigoConsulta { get; set; }

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

        public string Asunto { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        public string Respuesta { get; set; }

        [Display(Name = "Método de Ingreso")]
        public string MetodoIngreso { get; set; }

        public string Estado { get; set; }

        [Display(Name = "Género del Solicitante")]
        public string GeneroSolicitante { get; set; }
    }
}