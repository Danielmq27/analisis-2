using MvcValidationExtensions.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    /*
     * MODELO DEL FORMULARIO DEL CIIE
     * Se mapean todos los atributos que hay en la tabla FormularioCIIE de la base de datos ARE_Biblioteca_Legislativa
     */
    public class FormularioCIIE
    {
        //El atributo Id no lleva ningun DataAnnotations ya que no se le monstrara al usuario
        public int Id { get; set; }

        //El [Display] le otorga un nombre mas amigable al usuario
        [Display(Name = "Código CIIE")]
        //Atributo CodigoCIIE
        public string CodigoCIIE { get; set; }

        //[Required] nos dice que este atributo es requerido
        [Required]
        //[StringLength] nos permite darle al campo un numero maximo de caracteres
        [StringLength(40)]
        //[RegularExpression("^[a-zA-Z])] nos permite decirle al usuario que este campo solo acepta caracteres de tipo [a-z y A-Z]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Nombre del Solicitante solo acepta letras")]
        //El [Display] le otorga un nombre mas amigable al usuario
        [Display(Name = "Nombre del Solicitante")]
        //Atributo NombreSolicitante
        public string NombreSolicitante { get; set; }

        //[Required] nos dice que este atributo es requerido
        [Required]
        //[StringLength] nos permite darle al campo un numero maximo de caracteres
        [StringLength(20)]
        //[RegularExpression("^[a-zA-Z])] nos permite decirle al usuario que este campo solo acepta caracteres de tipo [a-z y A-Z]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Primer Apellido del Solicitante solo acepta letras")]
        //El [Display] le otorga un nombre mas amigable al usuario
        [Display(Name = "Primer Apellido del Solicitante")]
        //Atributo ApellidoSolicitante1
        public string ApellidoSolicitante1 { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Segundo Apellido del Solicitante solo acepta letras")]
        [Display(Name = "Segundo Apellido del Solicitante")]
        public string ApellidoSolicitante2 { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public int Telefono { get; set; }

        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Tipo de Despacho")]
        public string TipoDespacho { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Fracción")]
        public string Fraccion { get; set; }

        [StringLength(50)]
        [Display(Name = "Especificación del Despacho")]
        public string EspecificacionDespacho { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Tipo de Consulta")]
        public string TipoConsulta { get; set; }

        [StringLength(50)]
        [Display(Name = "Especificación de la Consulta")]
        public string EspecificacionConsulta { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tema")]
        public string Tema { get; set; }

        [Required]
        [Display(Name = "Información Requerida")]
        public string InformacionRequerida { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Uso de Información")]
        public string UsoInformacion { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Género del Solicitante")]
        public string GeneroSolicitante { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //Este atributo define si la fecha de respuesta es despues de la fecha inicial, si no dara un error //Esto no lo HE PROBADO
        [GreaterThanEqualTo("FechaIngreso")]
        [Display(Name = "Fecha de Respuesta")]
        public DateTime FechaRespuesta { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}