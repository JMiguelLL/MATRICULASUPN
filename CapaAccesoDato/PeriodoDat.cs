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
    public class PeriodoDat
    {
        private static readonly PeriodoDat periodoDat = new PeriodoDat();
        public static PeriodoDat Instancia
        {
            get
            {
                return PeriodoDat.periodoDat;
            }
        }

        public List<Periodo> ListaPeriodosActivos()
        {
            List<Periodo> listado = new List<Periodo>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("listaPeriodosActivos", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Periodo periodo = new Periodo
                    {
                        idPeriodo = Convert.ToInt32(dr["idPeriodo"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        status = Convert.ToInt32(dr["status"]),
                    };
                  

                    listado.Add(periodo);
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return listado;
        }

        public Periodo BuscarPeriodo(int idPeriodo)
        {
            Periodo periodo = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("buscarPeriodo", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdPeriodo", idPeriodo);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    periodo = new Periodo
                    {
                        idPeriodo = Convert.ToInt32(dr["idPeriodo"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        status = Convert.ToInt32(dr["status"]),
                    };

                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return periodo;
        }
    }
}
