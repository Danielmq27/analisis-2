using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class ReportePA
    {
        [Display(Name = "Departamento")]
        public string departamento { get; set; }

        [Display(Name = "Género")]
        public string tipoGenero { get; set; }

        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }

        [Display(Name = "Porcentaje")]
        public int porcentaje { get; set; }
    }
}