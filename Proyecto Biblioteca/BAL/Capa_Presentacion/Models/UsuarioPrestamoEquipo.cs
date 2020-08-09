using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    //Mapeo de la tabla UsuarioPrestamoEquipo
    public class UsuarioPrestamoEquipo
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo CedulaUsuario
        [Display(Name = "Cédula")]
        public string CedulaUsuario { get; set; }

        //Atributo CodigoPrestamoEquipo
        [Display(Name = "Código Prestamo Equipo")]
        public string CodigoPrestamoEquipo { get; set; }

        //Atributo Nombre
        public string Nombre { get; set; }

        //Atributo Apellido1
        public string Apellido1 { get; set; }

        //Atributo Apellido2
        public string Apellido2 { get; set; }
    }
}