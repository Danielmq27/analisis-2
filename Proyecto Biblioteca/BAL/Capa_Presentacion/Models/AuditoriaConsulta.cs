using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    //Mapeo de la tabla AuditoriaConsulta
    public class AuditoriaConsulta
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo CodigoConsulta
        [Display(Name = "Código Consulta")]
        public string CodigoConsulta { get; set; }

        //Atributo Fecha
        public DateTime Fecha { get; set; }

        //Atributo Accion
        [Display(Name = "Acción")]
        public string Accion { get; set; }

        //Atributo Usuario
        public string Usuario { get; set; }

        //Atributo NombreSolicitante
        [Display(Name = "Nombre del Solicitante")]
        public string NombreSolicitante { get; set; }

        //Atributo ApellidoSolicitante1
        [Display(Name = "Primer Apellido del Solicitante")]
        public string ApellidoSolicitante1 { get; set; }

        //Atributo ApellidoSolicitante2
        [Display(Name = "Segundo Apellido del Solicitante")]
        public string ApellidoSolicitante2 { get; set; }

        //Atributo Telefono
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        //Atributo Email
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        //Atributo Asunto
        public string Asunto { get; set; }

        //Atributo Descripcion
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        //Atributo Respuesta
        [Required]
        public string Respuesta { get; set; }

        //Atributo MetodoIngreso
        [Display(Name = "Método de Ingreso")]
        public string MetodoIngreso { get; set; }

        //Atributo Estado
        public string Estado { get; set; }

        //Atributo GeneroSolicitante
        [Display(Name = "Género del Solicitante")]
        public string GeneroSolicitante { get; set; }
    }
}