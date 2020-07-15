﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    public class UsuarioFormularioCIIE
    {
        public int Id { get; set; }

        [Display(Name = "Cédula")]
        public string CedulaUsuario { get; set; }

        [Display(Name = "Código Formulario CIIE")]
        public string CodigoCIIE { get; set; }

        public string Nombre { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }
    }
}