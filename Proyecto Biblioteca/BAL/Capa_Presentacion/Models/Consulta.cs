using MvcValidationExtensions.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class Consulta
    {
        //El atributo Id no lleva ningun DataAnnotations ya que no se le monstrara al usuario
        public int Id { get; set; }

        //El [Display] le otorga un nombre mas amigable al usuario
        [Display(Name = "Código Consulta")]
        //Atributo CodigoCIIE
        public string CodigoConsulta { get; set; }

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
        public int Telefono { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Asunto { get; set; }

        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        public string Respuesta { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Método de Ingreso")]
        public string MetodoIngreso { get; set; }

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
        public string Estado { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Género del Solicitante")]
        public string GeneroSolicitante { get; set; }
    }
}