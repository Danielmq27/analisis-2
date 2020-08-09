using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    //Mapeo de la tabla InformacionRol
    public class Rol
    {
        //Atributo Id
        public int IdRol { get; set; }

        //Atributo Nombre
        [Display(Name = "Rol")]
        public string Nombre_Rol { get; set; }

        //Atributo Descripcion
        [Display (Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}