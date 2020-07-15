using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class AuditoriaPrestamoAudiovisual
    {
        public int Id { get; set; }

        public string CodigoPrestamoAudiovisual { get; set; }

        public DateTime Fecha { get; set; }

        public string Accion { get; set; }

        public string Usuario { get; set; }

        public string NombreSolicitante { get; set; }

        public string ApellidoSolicitante1 { get; set; }

        public string ApellidoSolicitante2 { get; set; }

        public int Telefono { get; set; }

        public string Departamento { get; set; }

        public string NombreActividad { get; set; }

        public string Categoria { get; set; }

        public string EspecificacionCategoria { get; set; }

        public string Ubicacion { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFinal { get; set; }

        public string Descripcion { get; set; }

        public string EquipoRequerido { get; set; }

        public string Aforo { get; set; }
    }
}