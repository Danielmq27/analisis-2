using MvcValidationExtensions.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Models
{
    public class PrestamoEquipo
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo CodigoPrestamoEquipo
        [Display(Name = "Código")]
        public string CodigoPrestamoEquipo { get; set; }

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

        //Atributo CedulaSolicitante
        [Required]
        [StringLength(20)]
        [Display(Name = "Cédula del solicitante")]
        public string CedulaSolicitante { get; set; }

        //Atributo Departamento
        [Required]
        [StringLength(40)]
        public string Departamento { get; set; }

        //Atributo TipoEquipo
        [Required]
        [StringLength(20)]
        [Display(Name = "Tipo de equipo")]
        public string TipoEquipo { get; set; }

        //Atributo Implementos
        [StringLength(40)]
        public string Implementos { get; set; }

        //Atributo EspecificacionImplementos
        [StringLength(50)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Especificación de implementos")]
        public string EspecificacionImplementos { get; set; }

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
        [GreaterThanEqualTo("FechaIngreso", ErrorMessage = "La fecha de respuesta no puede ser menor a la fecha de ingreso")]
        [Display(Name = "Fecha de respuesta")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRespuesta { get; set; }

        //Atributo Estado
        [Required]
        [StringLength(20)]
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