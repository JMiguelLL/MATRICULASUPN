using CapaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaAccesoDato
{
    public class LogsUsuarioDat
    {
        private static readonly LogsUsuarioDat logsUsuarioDat = new LogsUsuarioDat();
        public static LogsUsuarioDat Instancia
        {
            get
            {
                return logsUsuarioDat;
            }
        }

        public Boolean NuevoLogUsuario(LogsUsuario logUsuario)
        {
            Boolean created = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("nuevoLogUsuario", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdUsuario", logUsuario.idUsuario);
                cmd.Parameters.AddWithValue("@paramFechaIngreso", logUsuario.fechaIngreso);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    created = true;
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return created;
        }
    }
}
