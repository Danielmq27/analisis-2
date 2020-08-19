using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class Bitacora
    {
        public int Id { get; set; }

        public string Controlador { get; set; }

        [Display(Name = "Método")]
        public string Metodo { get; set; }

        public string Mensaje { get; set; }

        public string Usuario { get; set; }

        public DateTime Fecha { get; set; }

        public int Tipo { get; set; }
    }
}