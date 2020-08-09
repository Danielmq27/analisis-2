using Capa_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capa_Presentacion.Models.ValidacionesExistentes
{
    //Clase donde se valida si una cedula ya existe en la base de datos
    public class CedulaExiste : ValidationAttribute
    {
        //Metodo para verificar si la cedula ya existe
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (bibliotecaDataContext bd = new bibliotecaDataContext())
            {
                string Cedula = (string)value;

                //Comparacion de la cedula digitada por el usuario con todas las cedulas de la base de datos
                if (bd.Usuario.Where(d => d.cedula == Cedula).Count() > 0)
                {
                    //La cedula si existe
                    return new ValidationResult("Cédula ya registrada en la base de datos");
                }
            }
            return ValidationResult.Success;
        }
    }
}