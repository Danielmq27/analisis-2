using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class Rol
    {
        public int IdRol { get; set; }

        [Display(Name = "Rol")]
        public string Nombre_Rol { get; set; }

        [Display (Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}