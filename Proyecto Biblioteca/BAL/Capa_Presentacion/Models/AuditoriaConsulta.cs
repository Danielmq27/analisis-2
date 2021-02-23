using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    //Mapeo de la tabla AuditoriaConsulta
    public class AuditoriaConsulta
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo CodigoConsulta
        [Display(Name = "Código")]
        public string CodigoConsulta { get; set; }

        //Atributo Fecha
        public DateTime Fecha { get; set; }

        //Atributo Accion
        [Display(Name = "Acción")]
        public string Accion { get; set; }

        //Atributo Usuario
        public string Usuario { get; set; }

        //Atributo NombreSolicitante
        [Display(Name = "Nombre del solicitante")]
        public string NombreSolicitante { get; set; }

        //Atributo ApellidoSolicitante1
        [Display(Name = "Primer apellido del solicitante")]
        public string ApellidoSolicitante1 { get; set; }

        //Atributo ApellidoSolicitante2
        [Display(Name = "Segundo apellido del solicitante")]
        public string ApellidoSolicitante2 { get; set; }

        //Atributo Telefono
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        //Atributo Email
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        //Atributo Asunto
        public string Asunto { get; set; }

        //Atributo Descripcion
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        //Atributo Respuesta
        [Required]
        public string Respuesta { get; set; }

        //Atributo MetodoIngreso
        [Display(Name = "Método de ingreso")]
        public string MetodoIngreso { get; set; }

        //Atributo MetodoIngreso
        [Display(Name = "Fecha de ingreso")]
        public DateTime FechaIngreso { get; set; }

        //Atributo MetodoIngreso
        [Display(Name = "Fecha de respuesta")]
        public DateTime FechaFinal { get; set; }

        //Atributo Estado
        public string Estado { get; set; }

        //Atributo GeneroSolicitante
        [Display(Name = "Género del solicitante")]
        public string GeneroSolicitante { get; set; }

        public string NombreArchivo { get; set; }

        public string TipoArchivo { get; set; }

        public string Extension { get; set; }

        public byte[] ArchivoFile { get; set; }

        public string Referido { get; set; }
    }
}