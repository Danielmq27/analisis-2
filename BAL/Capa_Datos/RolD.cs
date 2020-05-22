using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Capa_Datos
{
    public class RolD
    {
        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        MySqlCommand cmd = new MySqlCommand();

        public List<RolE> ConsultarRoles()
        {
            List<RolE> listado = new List<RolE>();
            try
            {
                cn.Open();
                cmd = new MySqlCommand("ConsultarRoles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    RolE rol = new RolE();
                    rol.IdRol = Convert.ToInt32(dr["IdRol"]);
                    rol.Rol = dr["Rol"].ToString();

                    listado.Add(rol);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listado;
        }

        public bool AgregarRol(RolE rol)
        {
            bool respuesta = false;
            try
            {
                cn.Open();
                cmd = new MySqlCommand("AgregarRol", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter pRol = new MySqlParameter();
                pRol.ParameterName = "Rol";
                pRol.MySqlDbType = MySqlDbType.VarChar;
                pRol.Size = 50;
                pRol.Value = rol.Rol;

                cmd.Parameters.Add(pRol);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    }
}
