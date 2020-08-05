using Capa_Datos;
using Capa_Logica;
using Capa_Presentacion.Models.ValidacionesExistentes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;

namespace Capa_Presentacion.Models
{
    //Mapeo de tabla Usuario
    public class Usuario
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo cedula
        [CedulaExiste]
        [Required(ErrorMessage = "El campo cédula es obligatorio.")]
        [StringLength(20, ErrorMessage = "El campo nombre debe ser una cadena con una longitud máxima de 20.")]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        //Atributo nombre
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(40, ErrorMessage = "El campo nombre debe ser una cadena con una longitud máxima de 40.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo nombre solo acepta letras.")]
        public string Nombre { get; set; }

        //Atributo apellido1
        [Required(ErrorMessage = "El campo primer apellido es obligatorio.")]
        [StringLength(20, ErrorMessage = "El campo primer apellido debe ser una cadena con una longitud máxima de 20.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo primer apellido solo acepta letras.")]
        [Display(Name = "Primer apellido")]
        public string Apellido1 { get; set; }

        //Atributo apellido2
        [Required(ErrorMessage = "El campo segundo apellido es obligatorio.")]
        [StringLength(20, ErrorMessage = "El campo segundo apellido debe ser una cadena con una longitud máxima de 20.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo segundo apellido solo acepta letras.")]
        [Display(Name = "Segundo apellido")]
        public string Apellido2 { get; set; }

        //Atributo email
        [CorreoExiste]
        [EmailAddress]
        [Required(ErrorMessage = "El campo correo electrónico es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo correo electrónico debe ser una cadena con una longitud máxima de 100.")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        //Atributo clave
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo contraseña es obligatorio.")]
        [StringLength(40, ErrorMessage = "El campo contraseña debe ser una cadena con una longitud máxima de 40.")]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }

        //Atributo IdRol
        [Required(ErrorMessage = "El campo rol es obligatorio.")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }
    }

    //Mapeo de tabla Usuario
    public class UsuarioEditar
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo cedula
        [Required(ErrorMessage = "El campo cédula es obligatorio.")]
        [StringLength(20, ErrorMessage = "El campo nombre debe ser una cadena con una longitud máxima de 20.")]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        //Atributo nombre
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(40, ErrorMessage = "El campo nombre debe ser una cadena con una longitud máxima de 40.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo nombre solo acepta letras.")]
        public string Nombre { get; set; }

        //Atributo apellido1
        [Required(ErrorMessage = "El campo primer apellido es obligatorio.")]
        [StringLength(20, ErrorMessage = "El campo primer apellido debe ser una cadena con una longitud máxima de 20.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo primer apellido solo acepta letras.")]
        [Display(Name = "Primer apellido")]
        public string Apellido1 { get; set; }

        //Atributo apellido2
        [Required(ErrorMessage = "El campo segundo apellido es obligatorio.")]
        [StringLength(20, ErrorMessage = "El campo segundo apellido debe ser una cadena con una longitud máxima de 20.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo segundo apellido solo acepta letras.")]
        [Display(Name = "Segundo apellido")]
        public string Apellido2 { get; set; }

        //Atributo email
        [EmailAddress]
        [Required(ErrorMessage = "El campo correo electrónico es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo correo electrónico debe ser una cadena con una longitud máxima de 100.")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        //Atributo clave
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo contraseña es obligatorio.")]
        [StringLength(40, ErrorMessage = "El campo contraseña debe ser una cadena con una longitud máxima de 40.")]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }

        //Atributo IdRol
        [Required(ErrorMessage = "El campo rol es obligatorio.")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }
    }
}