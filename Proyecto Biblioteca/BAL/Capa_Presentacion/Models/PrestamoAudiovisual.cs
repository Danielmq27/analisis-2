using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    //Mapeo de la tabla PrestamoAudiovisual
    public class PrestamoAudiovisual
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo CodigoPrestamoAudiovisual
        [Display(Name = "Código Préstamo Audiovisual")]
        public string CodigoPrestamoAudiovisual { get; set; }

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

        //Atributo Telefono
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        //Atributo Departamento
        [StringLength(40)]
        public string Departamento { get; set; }

        //Atributo NombreActividad
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre de Actividad")]
        public string NombreActividad { get; set; }

        //Atributo Categoria
        [Required]
        [StringLength(40)]
        [Display(Name = "Categoría")]
        public string Categoria { get; set; }

        //Atributo EspecificacionCategoria
        [Required]
        [StringLength(100)]
        [Display(Name = "Especificación de Categoría")]
        public string EspecificacionCategoria { get; set; }

        //Atributo Ubicacion
        [StringLength(100)]
        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; }

        //Atributo HoraInicio
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hora Inicio")]
        public DateTime HoraInicio { get; set; }

        //Atributo HoraFinal
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hora Final")]
        public DateTime HoraFinal { get; set; }

        //Atributo Descripcion
        [Required]
        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        //Atributo EquipoRequerido
        [Required]
        [StringLength(40)]
        [Display(Name = "Equipo Requerido")]
        public string EquipoRequerido { get; set; }

        //Atributo Aforo
        [Required]
        public int Aforo { get; set; }

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