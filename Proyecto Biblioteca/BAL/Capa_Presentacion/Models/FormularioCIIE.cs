using MvcValidationExtensions.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    //Mapeo de la tabla FormularioCIIE
    public class FormularioCIIE
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo CodigoCIIE
        [Display(Name = "Código")]
        public string CodigoCIIE { get; set; }

        //Atributo NombreSolicitante
        [Required]
        [StringLength(40)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo nombre del solicitante solo acepta letras")]
        [Display(Name = "Nombre del solicitante")]
        public string NombreSolicitante { get; set; }

        //Atributo ApellidoSolicitante1
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo primer apellido del solicitante solo acepta letras")]
        [Display(Name = "Primer apellido del solicitante")]
        public string ApellidoSolicitante1 { get; set; }

        //Atributo ApellidoSolicitante2
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo segundo apellido del solicitante solo acepta letras")]
        [Display(Name = "Segundo apellido del solicitante")]
        public string ApellidoSolicitante2 { get; set; }

        //Atributo Telefono
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        //Atributo Email
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        //Atributo TipoDespacho
        [Required]
        [StringLength(40)]
        [Display(Name = "Tipo de despacho")]
        public string TipoDespacho { get; set; }

        //Atributo Fraccion
        [Required]
        [StringLength(10)]
        [Display(Name = "Fracción")]
        public string Fraccion { get; set; }

        //Atributo EspecificacionDespacho
        [StringLength(50)]
        [Display(Name = "Especificación del despacho")]
        public string EspecificacionDespacho { get; set; }

        //Atributo TipoConsulta
        [Required]
        [StringLength(20)]
        [Display(Name = "Tipo de consulta")]
        public string TipoConsulta { get; set; }

        //Atributo EspecificacionConsulta
        [StringLength(50)]
        [Display(Name = "Especificación de la consulta")]
        public string EspecificacionConsulta { get; set; }

        //Atributo Tema
        [Required]
        [StringLength(50)]
        public string Tema { get; set; }

        //Atributo InformacionRequerida
        [Required]
        [Display(Name = "Información requerida")]
        public string InformacionRequerida { get; set; }

        //Atributo UsoInformacion
        [Required]
        [StringLength(40)]
        [Display(Name = "Uso de información")]
        public string UsoInformacion { get; set; }

        //Atributo GeneroSolicitante
        [Required]
        [StringLength(10)]
        [Display(Name = "Género del solicitante")]
        public string GeneroSolicitante { get; set; }

        //Atributo FechaIngreso
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        //Atributo FechaRespuesta
        [Required]
        [DataType(DataType.Date)]
        [GreaterThanEqualTo("FechaIngreso")]
        [Display(Name = "Fecha de respuesta")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRespuesta { get; set; }

        //Atributo Estado
        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        //*Control*//

        //Atributo CedulaUsuario
        [Display(Name = "Cédula usuario")]
        public string CedulaUsuario { get; set; }

        //Atributo NombreUsuario
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        //Atributo ApellidoUsuario1
        [Display(Name = "Primer apellido")]
        public string Apellido1 { get; set; }

        //Atributo ApellidoUsuario2
        [Display(Name = "Segundo apellido")]
        public string Apellido2 { get; set; }
    }
}