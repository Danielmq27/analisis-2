using MvcValidationExtensions.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class PrestamoEquipo
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo CodigoPrestamoEquipo
        [Display(Name = "Código Prestamo Equipo")]
        public string CodigoPrestamoEquipo { get; set; }

        //Atributo NombreSolicitante
        [Required]
        [StringLength(40)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo nombre del solicitante solo acepta letras")]
        [Display(Name = "Nombre del Solicitante")]
        public string NombreSolicitante { get; set; }

        //Atributo ApellidoSolicitante1
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo primer apellido del solicitante solo acepta letras")]
        [Display(Name = "Primer Apellido del Solicitante")]
        public string ApellidoSolicitante1 { get; set; }

        //Atributo ApellidoSolicitante2
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo segundo apellido del solicitante solo acepta letras")]
        [Display(Name = "Segundo Apellido del Solicitante")]
        public string ApellidoSolicitante2 { get; set; }

        //Atributo CedulaSolicitante
        [Required]
        [StringLength(20)]
        [Display(Name = "Cédula del Solicitante")]
        public string CedulaSolicitante { get; set; }

        //Atributo Departamento
        [Required]
        [StringLength(40)]
        public string Departamento { get; set; }

        //Atributo TipoEquipo
        [Required]
        [StringLength(20)]
        [Display(Name = "Tipo de Equipo")]
        public string TipoEquipo { get; set; }

        //Atributo Implementos
        [StringLength(40)]
        public string Implementos { get; set; }

        //Atributo EspecificacionImplementos
        [StringLength(50)]
        [Display(Name = "Especificación de Implementos")]
        public string EspecificacionImplementos { get; set; }

        //Atributo GeneroSolicitante
        [Required]
        [StringLength(10)]
        [Display(Name = "Género del Solicitante")]
        public string GeneroSolicitante { get; set; }

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
    }
}