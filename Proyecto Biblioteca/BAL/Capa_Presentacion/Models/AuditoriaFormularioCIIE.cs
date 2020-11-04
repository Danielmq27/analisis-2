using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    //Mapeo de la tabla AuditoriaFormularioCIIE
    public class AuditoriaFormularioCIIE
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo CodigoCIIE
        [Display(Name = "Código")]
        public string CodigoCIIE { get; set; }

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

        //Atributo TipoDespacho
        [Display(Name = "Tipo de despacho")]
        public string TipoDespacho { get; set; }

        //Atributo Fraccion
        [Display(Name = "Fracción")]
        public string Fraccion { get; set; }

        //Atributo EspecificacionDespacho
        [Display(Name = "Especificación del despacho")]
        public string EspecificacionDespacho { get; set; }

        //Atributo TipoConsulta
        [Display(Name = "Tipo de consulta")]
        public string TipoConsulta { get; set; }

        //Atributo EspecificacionConsulta
        [Display(Name = "Especificación de la consulta")]
        public string EspecificacionConsulta { get; set; }

        //Atributo Tema
        public string Tema { get; set; }

        //Atributo InformacionRequerida
        [Display(Name = "Información requerida")]
        public string InformacionRequerida { get; set; }

        //Atributo UsoInformacion
        [Display(Name = "Uso de información")]
        public string UsoInformacion { get; set; }

        //Atributo GeneroSolicitante
        [Display(Name = "Género del solicitante")]
        public string GeneroSolicitante { get; set; }

        [Display(Name = "Fecha Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [Display(Name = "Fecha Respuesta")]
        public DateTime FechaRespuesta { get; set; }

        //Atributo Estado
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}