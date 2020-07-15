using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class AuditoriaConsulta
    {
        public int Id { get; set; }

        public string CodigoConsulta { get; set; }

        public DateTime Fecha { get; set; }

        public string Accion { get; set; }

        public string Usuario { get; set; }

        public string NombreSolicitante { get; set; }

        public string ApellidoSolicitante1 { get; set; }

        public string ApellidoSolicitante2 { get; set; }

        public int Telefono { get; set; }

        public string Email { get; set; }

        public string Asunto { get; set; }

        public string Descripcion { get; set; }

        public string MetodoIngreso { get; set; }

        public string Respuesta { get; set; }

        public string GeneroSolicitante { get; set; }

        public string Estado { get; set; }
    }
}