using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsUsuario
    {
        //Metodo para acceso al sistema [LOGIN]
        public List<LOGIN_USUARIOResult> Login(string Correo, string Clave)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<LOGIN_USUARIOResult> data = dc.LOGIN_USUARIO(Correo, Clave).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Metodo para consultar todos los usuarios
        public List<SELECCIONAR_USUARIO_TODOResult> ConsultarUsuarios()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_USUARIO_TODOResult> data = dc.SELECCIONAR_USUARIO_TODO().ToList();
                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar un usuario
        public List<SELECCIONAR_USUARIOResult> ConsultarUsuario(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_USUARIOResult> data = dc.SELECCIONAR_USUARIO(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para agregar un usuario
        public bool AgregarUsuario(string Cedula, string Nombre, string Apellido1, string Apellido2, string Email, string Clave, string Estado, int IdRol)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = dc.INSERTAR_USUARIO(Cedula, Nombre, Apellido1, Apellido2, Email, Clave, Estado, IdRol);

                if (respuesta == 0)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para actualizar un usuario
        public bool ActualizarUsuario(int Id, string Cedula, string Nombre, string Apellido1, string Apellido2, string Email, string Clave, string Estado, int IdRol)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = dc.ACTUALIZAR_USUARIO(Id, Cedula, Nombre, Apellido1, Apellido2, Email, Clave, Estado, IdRol);
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
    }
}
