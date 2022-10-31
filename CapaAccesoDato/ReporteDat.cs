using CapaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDato
{
    public class ReporteDat
    {

        private static readonly ReporteDat reporteDat = new ReporteDat();
        public static ReporteDat Instancia
        {
            get
            {
                return ReporteDat.reporteDat;
            }
        }

        public List<Reporte> ReporteMatriculas()
        {
            List<Reporte> listado = new List<Reporte>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("reporteMatriculas", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };


                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Reporte reporte = new Reporte
                    {
                        idMatricula = Convert.ToInt32(dr["idMatricula"]),
                        codigo = Convert.ToString(dr["codigo"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        apellidoPaterno = Convert.ToString(dr["apellidoPaterno"]),
                        apellidoMaterno = Convert.ToString(dr["apellidoMaterno"]),
                        nombrePeriodo = Convert.ToString(dr["nombrePeriodo"]),
                        cursosMatriculados = Convert.ToInt32(dr["cursosMatriculados"]),
                        cantidadAgregados = Convert.ToInt32(dr["cantidadAgregados"]),
                        cantidadEliminados = Convert.ToInt32(dr["cantidadEliminados"]),
                    };

                    listado.Add(reporte);
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return listado;
        }

    }
}
