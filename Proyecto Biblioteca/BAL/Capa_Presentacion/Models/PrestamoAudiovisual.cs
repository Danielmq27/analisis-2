using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class PrestamoAudiovisual
    {
        //El atributo Id no lleva ningun DataAnnotations ya que no se le monstrara al usuario
        public int Id { get; set; }

        //El [Display] le otorga un nombre mas amigable al usuario
        [Display(Name = "Código Préstamo Audiovisual")]
        //Atributo CodigoCIIE
        public string CodigoPrestamoAudiovisual { get; set; }

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
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        [StringLength(40)]
        public string Departamento { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre de Actividad")]
        public string NombreActividad { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Categoría")]
        public string Categoria { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Especificación de Categoría")]
        public string EspecificacionCategoria { get; set; }

        [StringLength(100)]
        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hora Inicio")]
        public DateTime HoraInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hora Final")]
        public DateTime HoraFinal { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Equipo Requerido")]
        public string EquipoRequerido { get; set; }

        [Required]
        public int Aforo { get; set; }
    }
}