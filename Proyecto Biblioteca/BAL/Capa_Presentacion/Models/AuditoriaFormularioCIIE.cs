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
        [Display(Name = "Código CIIE")]
        public string CodigoCIIE { get; set; }

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

        //Atributo Telefono
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        //Atributo Email
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        //Atributo TipoDespacho
        [Display(Name = "Tipo de Despacho")]
        public string TipoDespacho { get; set; }

        //Atributo Fraccion
        [Display(Name = "Fracción")]
        public string Fraccion { get; set; }

        //Atributo EspecificacionDespacho
        [Display(Name = "Especificación del Despacho")]
        public string EspecificacionDespacho { get; set; }

        //Atributo TipoConsulta
        [Display(Name = "Tipo de Consulta")]
        public string TipoConsulta { get; set; }

        //Atributo EspecificacionConsulta
        [Display(Name = "Especificación de la Consulta")]
        public string EspecificacionConsulta { get; set; }

        //Atributo Tema
        public string Tema { get; set; }

        //Atributo InformacionRequerida
        [Display(Name = "Información Requerida")]
        public string InformacionRequerida { get; set; }

        //Atributo UsoInformacion
        [Display(Name = "Uso de Información")]
        public string UsoInformacion { get; set; }

        //Atributo GeneroSolicitante
        [Display(Name = "Género del Solicitante")]
        public string GeneroSolicitante { get; set; }

        //Atributo Estado
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}