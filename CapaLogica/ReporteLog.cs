using CapaModelos;
using CapaAccesoDato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ReporteLog
    {
        private static readonly ReporteLog reporteLog = new ReporteLog();
        public static ReporteLog Instancia
        {
            get
            {
                return reporteLog;
            }
        }


        public List<Reporte> ReporteMatriculas()
        {
            List<Reporte> lista = ReporteDat.Instancia.ReporteMatriculas();

            return lista;
        }
    }
}
