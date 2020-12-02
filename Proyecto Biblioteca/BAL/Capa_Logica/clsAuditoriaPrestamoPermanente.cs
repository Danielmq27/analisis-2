using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsAuditoriaPrestamoPermanente
    {
        //Metodo para consultar todas las auditorias de Prestamo Permanente
        public List<SELECCIONAR_TODO_AUDITORIA_PPResult> ConsultarAuditoriasPrestamoPermanente()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_TODO_AUDITORIA_PPResult> data = dc.SELECCIONAR_TODO_AUDITORIA_PP().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar una auditoria de Prestamo Permanente
        public List<SELECCIONAR_AUDITORIA_PPResult> ConsultarAuditoriaPrestamoPermanente(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_PPResult> data = dc.SELECCIONAR_AUDITORIA_PP(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para restaurar un formulario eliminado por medio de la auditoria
        public bool RestaurarPrestamoPermanente(string Codigo, string Cedula, string Nombre, string Apellido1, string Apellido2,
            string Despacho, int Telefono, string Extension, string InformacionAdicional, string Genero, 
            DateTime FechaPrestamo, string Estado)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.RESTAURAR_PrestamoPermanente(Codigo, Cedula, Nombre, Apellido1, Apellido2, Despacho, Telefono, Extension,
                    InformacionAdicional, Genero, FechaPrestamo, Estado);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
