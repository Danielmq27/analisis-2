using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidades;

namespace Capa_Logica
{
    public class RolL
    {
        RolD rol = new RolD();
        public List<RolE> ConsultarRoles()
        {
            return rol.ConsultarRoles();
        }
    }
}
