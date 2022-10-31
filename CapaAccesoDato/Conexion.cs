using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaAccesoDato
{
    public class Conexion
    {
        private static readonly Conexion conexion = new Conexion();
        public static Conexion Instancia
        {
            get
            {
                return Conexion.conexion;
            }
        }

        public SqlConnection Conect()
        {
            SqlConnection cn = new SqlConnection
            {
                ConnectionString = "Data Source=DESKTOP-ADDLJ0K\\SQLEXPRESS01; Initial Catalog=matriculasupn2;" + "Integrated Security=true"

            };
            return cn;
        }

    }
}
