using MvcValidationExtensions.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class AuditoriaFormularioCEDIL
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo CodigoCIIE
        [Display(Name = "Código")]
        public string CodigoCEDIL { get; set; }

        //Atributo Fecha
        public DateTime Fecha { get; set; }

        //Atributo Accion
        [Display(Name = "Acción")]
        public string Accion { get; set; }

        //Atributo Usuario
        public string Usuario { get; set; }

        //Atributo NombreSolicitante
        [Required]
        [StringLength(40)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Nombre del Solicitante solo acepta letras")]
        [Display(Name = "Nombre del solicitante")]
        public string NombreSolicitante { get; set; }

        //Atributo ApellidoSolicitante1
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Primer Apellido del Solicitante solo acepta letras")]
        [Display(Name = "Primer apellido del solicitante")]
        public string ApellidoSolicitante1 { get; set; }

        //Atributo ApellidoSolicitante2
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Segundo Apellido del Solicitante solo acepta letras")]
        [Display(Name = "Segundo apellido del solicitante")]
        public string ApellidoSolicitante2 { get; set; }

        //Atributo Telefono
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        //Atributo Procedencia
        [StringLength(40)]
        [Display(Name = "Procedencia")]
        public string Procedencia { get; set; }

        //Atributo Ubicacion
        [StringLength(40)]
        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; }

        //Atributo TipoSolicitud
        [StringLength(30)]
        [Display(Name = "Tipo de solicitud")]
        public string TipoSolicitud { get; set; }

        //Atributo InformacionRequerida
        [StringLength(500)]
        [Display(Name = "Información requerida")]
        public string InformacionRequerida { get; set; }

        //Atributo InformacionRequerida
        [Required]
        [StringLength(100)]
        [Display(Name = "Uso información")]
        public string UsoInformacion { get; set; }

        //Atributo GeneroSolicitante
        [Required]
        [StringLength(10)]
        [Display(Name = "Género del Solicitante")]
        public string GeneroSolicitante { get; set; }

        //Atributo FechaIngreso
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        //Atributo FechaRespuesta
        [Required]
        [DataType(DataType.Date)]
        [GreaterThanEqualTo("FechaIngreso")]
        [Display(Name = "Fecha de Respuesta")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRespuesta { get; set; }

        //Atributo Estado
        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}