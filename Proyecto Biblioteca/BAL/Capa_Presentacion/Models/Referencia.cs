using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    //Mapeo de la tabla Referencia
    public class Referencia
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo Nombre
        [Required]
        [StringLength(40)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Nombre solo acepta letras")]
        public string Nombre { get; set; }

        //Atributo Apellido1
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Primer Apellido solo acepta letras")]
        [Display(Name = "Primer Apellido")]
        public string Apellido1 { get; set; }

        //Atributo Apellido2
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Segundo Apellido solo acepta letras")]
        [Display(Name = "Segundo Apellido")]
        public string Apellido2 { get; set; }

        //Atributo Email
        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        //Atributo Genero
        [Required]
        [StringLength(10)]
        [Display(Name = "Género")]
        public string Genero { get; set; }
    }
}