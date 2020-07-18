using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class AuditoriaPrestamoAudiovisual
    {
        public int Id { get; set; }

        [Display(Name = "Código Préstamo Audiovisual")]
        public string CodigoPrestamoAudiovisual { get; set; }

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

        [StringLength(40)]
        public string Departamento { get; set; }

        [Display(Name = "Nombre de Actividad")]
        public string NombreActividad { get; set; }

        [Display(Name = "Categoría")]
        public string Categoria { get; set; }

        [Display(Name = "Especificación de Categoría")]
        public string EspecificacionCategoria { get; set; }

        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; }

        [Display(Name = "Hora Inicio")]
        public DateTime HoraInicio { get; set; }

        [Display(Name = "Hora Final")]
        public DateTime HoraFinal { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Equipo Requerido")]
        public string EquipoRequerido { get; set; }

        [Required]
        public int Aforo { get; set; }
    }
}