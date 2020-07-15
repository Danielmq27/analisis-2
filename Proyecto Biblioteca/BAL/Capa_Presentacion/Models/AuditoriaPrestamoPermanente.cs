using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class AuditoriaPrestamoPermanente
    {
        public int Id { get; set; }

        public string CodigoPrestamoPermanente { get; set; }

        public string NombreSolicitante { get; set; }

        public DateTime Fecha { get; set; }

        public string Accion { get; set; }

        public string Usuario { get; set; }

        public string ApellidoSolicitante1 { get; set; }

        public string ApellidoSolicitante2 { get; set; }

        public string Despacho { get; set; }

        public int Telefono { get; set; }

        public string Extension { get; set; }

        public string InformacionAdicional { get; set; }

        public string GeneroSolicitante { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public string Estado { get; set; }
    }
}