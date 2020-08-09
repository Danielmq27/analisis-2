using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    //Mapeo de la tabla UsuarioPrestamoPermanente
    public class UsuarioPrestamoPermanente
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo CedulaUsuario
        [Display(Name = "Cédula")]
        public string CedulaUsuario { get; set; }

        //Atributo CodigoPrestamoPermanente
        [Display(Name = "Código Prestamo Permanente")]
        public string CodigoPrestamoPermanente { get; set; }

        //Atributo Nombre
        public string Nombre { get; set; }

        //Atributo Apellido1
        public string Apellido1 { get; set; }

        //Atributo Apellido2
        public string Apellido2 { get; set; }
    }
}