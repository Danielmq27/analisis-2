using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class AuditoriaFormularioCIIE
    {
        public int Id { get; set; }

        public string CodigoCIIE { get; set; }

        public DateTime Fecha { get; set; }

        public string Accion { get; set; }

        public string Usuario { get; set; }

        public string NombreSolicitante { get; set; }

        public string ApellidoSolicitante1 { get; set; }

        public string ApellidoSolicitante2 { get; set; }

        public int Telefono { get; set; }

        public string Email { get; set; }

        public string TipoDespacho { get; set; }

        public string Fraccion { get; set; }

        public string EspecificacionDespacho { get; set; }

        public string TipoConsulta { get; set; }

        public string EspecificacionConsulta { get; set; }

        public string Tema { get; set; }

        public string InformacionRequerida { get; set; }

        public string UsoInformacion { get; set; }

        public string GeneroSolicitante { get; set; }

        public string Estado { get; set; }
    }
}