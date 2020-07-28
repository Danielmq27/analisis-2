using Capa_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models.ValidacionesExistentes
{
    public class CorreoExiste : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (bibliotecaDataContext bd = new bibliotecaDataContext())
            {
                string Correo = (string)value;

                if (bd.Usuario.Where(d => d.email == Correo).Count() > 0)
                {
                    return new ValidationResult("Correo electrónico ya registrado en la base de datos");
                }
            }
            return ValidationResult.Success;
        }
    }
}