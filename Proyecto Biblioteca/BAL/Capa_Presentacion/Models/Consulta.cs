using MvcValidationExtensions.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Código Consulta")]
        public string CodigoConsulta { get; set; }

        //Atributo NombreSolicitante
        [Required]
        [StringLength(40)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Nombre del Solicitante solo acepta letras")]
        [Display(Name = "Nombre del Solicitante")]
        public string NombreSolicitante { get; set; }

        //Atributo ApellidoSolicitante1
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Primer Apellido del Solicitante solo acepta letras")]
        [Display(Name = "Primer Apellido del Solicitante")]
        public string ApellidoSolicitante1 { get; set; }

        //Atributo ApellidoSolicitante2
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Segundo Apellido del Solicitante solo acepta letras")]
        [Display(Name = "Segundo Apellido del Solicitante")]
        public string ApellidoSolicitante2 { get; set; }

        //Atributo Telefono
        [Required]
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        //Atributo Email
        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        //Atributo Asunto
        [Required]
        [StringLength(50)]
        public string Asunto { get; set; }

        //Atributo Descripcion
        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        //Atributo Respuesta
        [Required]
        public string Respuesta { get; set; }

        //Atributo MetodoIngreso
        [Required]
        [StringLength(20)]
        [Display(Name = "Método de Ingreso")]
        public string MetodoIngreso { get; set; }

        //Atributo FechaIngreso
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }

        //Atributo FechaRespuesta
        [Required]
        [DataType(DataType.Date)]
        [GreaterThanEqualTo("FechaIngreso", ErrorMessage = "La fecha de respuesta no puede ser menor a la fecha de ingreso")]
        [Display(Name = "Fecha de Respuesta")]
        public DateTime FechaRespuesta { get; set; }

        //Atributo Estado
        [Required]
        [StringLength(20)]
        public string Estado { get; set; }

        //Atributo GeneroSolicitante
        [Required]
        [StringLength(10)]
        [Display(Name = "Género del Solicitante")]
        public string GeneroSolicitante { get; set; }

        //*Control*//

        //Atributo CedulaUsuario
        [Display(Name = "Cédula Usuario")]
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