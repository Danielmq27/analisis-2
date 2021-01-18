using MvcValidationExtensions.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    //Mapeo de la tabla Consulta
    public class Consulta
    {
        //Atrubuto Id
        public int Id { get; set; }

        //Atributo CodigoCIIE
        [Display(Name = "Código")]
        public string CodigoConsulta { get; set; }

        //Atributo NombreSolicitante
        [Required]
        [StringLength(40)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo nombre del solicitante solo acepta letras")]
        [Display(Name = "Nombre del solicitante")]
        public string NombreSolicitante { get; set; }

        //Atributo ApellidoSolicitante1
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo primer apellido del aolicitante solo acepta letras")]
        [Display(Name = "Primer apellido del aolicitante")]
        public string ApellidoSolicitante1 { get; set; }

        //Atributo ApellidoSolicitante2
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo segundo apellido del solicitante solo acepta letras")]
        [Display(Name = "Segundo apellido del solicitante")]
        public string ApellidoSolicitante2 { get; set; }

        //Atributo Telefono
        [Required]
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        //Atributo Email
        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        //Atributo Asunto
        [Required]
        [StringLength(50)]
        public string Asunto { get; set; }

        //Atributo Descripcion
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        //Atributo Respuesta
        [Required]
        [DataType(DataType.MultilineText)]
        public string Respuesta { get; set; }

        //Atributo MetodoIngreso
        [Required]
        [StringLength(20)]
        [Display(Name = "Método de ingreso")]
        public string MetodoIngreso { get; set; }

        //Atributo FechaIngreso
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        //Atributo FechaRespuesta
        [Required]
        [DataType(DataType.Date)]
        [GreaterThanEqualTo("FechaIngreso", ErrorMessage = "La fecha de respuesta no puede ser menor a la fecha de ingreso")]
        [Display(Name = "Fecha de respuesta")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRespuesta { get; set; }

        //Atributo Estado
        [Required]
        [StringLength(20)]
        public string Estado { get; set; }

        //Atributo GeneroSolicitante
        [Required]
        [StringLength(10)]
        [Display(Name = "Género del solicitante")]
        public string GeneroSolicitante { get; set; }

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

        [Display(Name = "Documento")]
        public HttpPostedFileBase Archivo { get; set; }

        [Display(Name = "Documento")]
        public string NombreArchivo { get; set; }

        public string TipoArchivo { get; set; }

        public string Extension { get; set; }

        public byte[] ArchivoFile { get; set; }

    }
}