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

        public int Telefono { get; set; }

        public string Departamento { get; set; }

        public string NombreActividad { get; set; }

        public string Categoria { get; set; }

        public string EspecificacionCategoria { get; set; }

        public string Ubicacion { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFinal { get; set; }

        public string Descripcion { get; set; }

        public string EquipoRequerido { get; set; }

        public string Aforo { get; set; }
    }
}