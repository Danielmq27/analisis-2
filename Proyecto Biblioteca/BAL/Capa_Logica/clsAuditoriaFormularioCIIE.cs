using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsAuditoriaFormularioCIIE
    {
        //Metodo para consultar todas las auditorias de Formulario CIIE
        public List<SELECCIONAR_TODO_AUDITORIA_CIIEResult> ConsultarAuditoriasFormularioCIIE()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_TODO_AUDITORIA_CIIEResult> data = dc.SELECCIONAR_TODO_AUDITORIA_CIIE().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar una auditoria de Formulario CIIE
        public List<SELECCIONAR_AUDITORIA_CIIEResult> ConsultarAuditoriaFormularioCIIE(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_CIIEResult> data = dc.SELECCIONAR_AUDITORIA_CIIE(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para restaurar un formulario eliminado por medio de la auditoria
        public bool RestaurarCIIE(string Codigo, string Cedula, string Nombre, string Apellido1, string Apellido2, 
            int Telefono, string Email,string TipoDespacho, string Fraccion, string EspecificacionDespacho,
            string TipoConsulta, string EspecificacionConsulta, string Tema, string InformacionRequerida,
            string UsoInformacion, string Genero, DateTime FechaIngreso, DateTime FechaRespuesta,
            string Estado)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.RESTAURAR_INSERTAR_CIIE(Codigo, Cedula, Nombre, Apellido1, Apellido2, Telefono, Email, TipoDespacho, Fraccion,
                    EspecificacionDespacho, TipoConsulta, EspecificacionConsulta, Tema, InformacionRequerida, UsoInformacion,
                    Genero, FechaIngreso, FechaRespuesta, Estado);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
