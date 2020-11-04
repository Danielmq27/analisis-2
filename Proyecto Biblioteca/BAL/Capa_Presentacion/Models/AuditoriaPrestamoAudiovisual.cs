using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models
{
    //Mapeo de la tabla AuditoriaPrestamoAudiovisual
    public class AuditoriaPrestamoAudiovisual
    {
        //Atributo Id
        public int Id { get; set; }

        //Atributo CodigoPrestamoAudiovisual
        [Display(Name = "Código")]
        public string CodigoPrestamoAudiovisual { get; set; }

        //Atributo Fecha
        public DateTime Fecha { get; set; }

        //Atributo Accion
        [Display(Name = "Acción")]
        public string Accion { get; set; }

        //Atributo Usuario
        public string Usuario { get; set; }

        //Atributo NombreSolicitante
        [Display(Name = "Nombre del solicitante")]
        public string NombreSolicitante { get; set; }

        //Atributo ApellidoSolicitante1
        [Display(Name = "Primer apellido del solicitante")]
        public string ApellidoSolicitante1 { get; set; }

        //Atributo ApellidoSolicitante2
        [Display(Name = "Segundo apellido del solicitante")]
        public string ApellidoSolicitante2 { get; set; }

        //Atributo Telefono
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        //Atributo Departamento
        [StringLength(40)]
        public string Departamento { get; set; }

        //Atributo NombreActividad
        [Display(Name = "Nombre de actividad")]
        public string NombreActividad { get; set; }

        //Atributo Categoria
        [Display(Name = "Categoría")]
        public string Categoria { get; set; }

        //Atributo EspecificacionCategoria
        [Display(Name = "Especificación de categoría")]
        public string EspecificacionCategoria { get; set; }

        //Atributo Ubicacion
        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; }

        //Atributo HoraInicio
        [Display(Name = "Hora inicio")]
        public DateTime HoraInicio { get; set; }

        //Atributo HoraFinal
        [Display(Name = "Hora final")]
        public DateTime HoraFinal { get; set; }

        //Atributo Descripcion
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        //Atributo EquipoRequerido
        [Display(Name = "Equipo requerido")]
        public string EquipoRequerido { get; set; }

        //Atributo Aforo
        public int Aforo { get; set; }

        //Atributo GeneroSolicitante
        [Display(Name = "Género del solicitante")]
        public string GeneroSolicitante { get; set; }
    }
}