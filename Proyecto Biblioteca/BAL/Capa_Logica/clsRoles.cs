using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class clsRoles
    {
        /*Función para consultar roles*/
        public List<SELECT_ROLESResult> ConsultarRoles()
        {
            try
            {
                /*Atributo de la base de datos*/
                bibliotecaDataContext dc = new bibliotecaDataContext();
                /*Listado de roles con el procedimiento almacenado de la base de datos*/
                List<SELECT_ROLESResult> data = dc.SELECT_ROLES().ToList();
                /*Devuelvame lo que encontro*/
                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /*Función para consultar rol*/
        public List<SELECT_ROLResult> ConsultarRol(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECT_ROLResult> data = dc.SELECT_ROL(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*Función para agregar rol*/
        public bool AgregarRol(string Nombre, string Descripcion)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = Convert.ToInt32(dc.INSERTAR_ROL(Nombre, Descripcion));

                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*Función para actualizar rol*/
        public bool ActualizarRol(int Id, string Nombre, string Descripcion)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.UPDATE_ROL(Id, Nombre, Descripcion);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*Función para eliminar rol*/
        public bool EliminarRol(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.DELETE_ROL(Id);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
        public List<ConsultarRolResult> ConsultaRol(int Codigo)
        {
            try
            {
                bd_bibliotecaDataContext dc = new bd_bibliotecaDataContext();
                List<ConsultarRolResult> data = dc.ConsultarRol(Codigo).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool AgregarRol(string Nombre_Rol, string Descripcion)
        {
            try
            {
                int respuesta = 1;
                bd_bibliotecaDataContext dc = new bd_bibliotecaDataContext();
                respuesta = Convert.ToInt32(dc.AgregarRol(Nombre_Rol, Descripcion));

                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ActualizarRol(int IdRol, string Nombre_Rol, string Descripcion)
        {
            try
            {
                bd_bibliotecaDataContext dc = new bd_bibliotecaDataContext();
                dc.ActualizarRol(IdRol, Nombre_Rol, Descripcion);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarRol(int IdRol)
        {
            try
            {
                bd_bibliotecaDataContext dc = new bd_bibliotecaDataContext();
                dc.EliminarRol(IdRol);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        */
    }
}
