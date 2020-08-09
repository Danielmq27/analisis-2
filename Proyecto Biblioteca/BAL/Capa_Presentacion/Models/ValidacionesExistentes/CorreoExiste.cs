using Capa_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models.ValidacionesExistentes
{
    //Clase donde se valida si el correo ya existe en la base de datos
    public class CorreoExiste : ValidationAttribute
    {
        //Metodo para verificar si el correo ya existe
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (bibliotecaDataContext bd = new bibliotecaDataContext())
            {
                string Correo = (string)value;

                //Comparacion del correo digitado por el usuario con todos los correos de la base de datos
                if (bd.Usuario.Where(d => d.email == Correo).Count() > 0)
                {
                    //el correo si existe
                    return new ValidationResult("Correo electrónico ya registrado en la base de datos");
                }
            }
            return ValidationResult.Success;
        }
    }
}