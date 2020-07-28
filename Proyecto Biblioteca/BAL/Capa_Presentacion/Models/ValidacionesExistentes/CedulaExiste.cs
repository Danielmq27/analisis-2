using Capa_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models.ValidacionesExistentes
{
    public class CedulaExiste : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (bibliotecaDataContext bd = new bibliotecaDataContext())
            {
                string Cedula = (string)value;

                if (bd.Usuario.Where(d => d.cedula == Cedula).Count() > 0)
                {
                    return new ValidationResult("Cédula ya registrada en la base de datos");
                }
            }
            return ValidationResult.Success;
        }
    }
}