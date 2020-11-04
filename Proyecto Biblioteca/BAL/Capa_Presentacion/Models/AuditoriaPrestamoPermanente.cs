using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    //Mapeo de la tabla AuditoriaPrestamoPermanente
    public class AuditoriaPrestamoPermanente
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo CodigoPrestamoPermanente
        [Display(Name = "Código")]
        public string CodigoPrestamoPermanente { get; set; }

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

        //Atributo Despacho
        public string Despacho { get; set; }

        //Atributo Telefono
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        //Atributo Extension
        [Display(Name = "Extensión")]
        public string Extension { get; set; }

        //Atributo InformacionAdicional
        [Display(Name = "Información adicional")]
        public string InformacionAdicional { get; set; }

        //Atributo GeneroSolicitante
        [Display(Name = "Género del solicitante")]
        public string GeneroSolicitante { get; set; }

        //Atributo FechaPrestamo
        [Display(Name = "Fecha del préstamo")]
        public DateTime FechaPrestamo { get; set; }

        //Atributo Estado
        public string Estado { get; set; }
    }
}