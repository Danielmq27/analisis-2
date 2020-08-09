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
        [Display(Name = "Código Préstamo Permanente")]
        public string CodigoPrestamoPermanente { get; set; }

        //Atributo Fecha
        public DateTime Fecha { get; set; }

        //Atributo Accion
        [Display(Name = "Acción")]
        public string Accion { get; set; }

        //Atributo Usuario
        public string Usuario { get; set; }

        //Atributo NombreSolicitante
        [Display(Name = "Nombre del Solicitante")]
        public string NombreSolicitante { get; set; }

        //Atributo ApellidoSolicitante1
        [Display(Name = "Primer Apellido del Solicitante")]
        public string ApellidoSolicitante1 { get; set; }

        //Atributo ApellidoSolicitante2
        [Display(Name = "Segundo Apellido del Solicitante")]
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
        [Display(Name = "Información Adicional")]
        public string InformacionAdicional { get; set; }

        //Atributo GeneroSolicitante
        [Display(Name = "Género del Solicitante")]
        public string GeneroSolicitante { get; set; }

        //Atributo FechaPrestamo
        [Display(Name = "Fecha del Préstamo")]
        public DateTime FechaPrestamo { get; set; }

        //Atributo Estado
        public string Estado { get; set; }
    }
}