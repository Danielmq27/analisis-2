﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    //Mapeo de la tabla PrestamoPermanente
    public class PrestamoPermanente
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo CodigoPrestamoPermanente
        [Display(Name = "Código")]
        public string CodigoPrestamoPermanente { get; set; }

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

        //Atributo Despacho
        [Required]
        [StringLength(40)]
        public string Despacho { get; set; }

        //Atributo Telefono
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        //Atributo Extension
        [StringLength(10)]
        [Display(Name = "Extensión")]
        public string Extension { get; set; }

        //Atributo InformacionAdicional
        [DataType(DataType.MultilineText)]
        [Display(Name = "Información adicional")]
        public string InformacionAdicional { get; set; }

        //Atributo GeneroSolicitante
        [Required]
        [StringLength(10)]
        [Display(Name = "Género del solicitante")]
        public string GeneroSolicitante { get; set; }

        //Atributo FechaPrestamo
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha del Préstamo")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaPrestamo { get; set; }

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