using CapaModelos;
using CapaAccesoDato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogsMatriculaDetalleLog
    {
        private static readonly LogsMatriculaDetalleLog logsMatriculaDetalleLog = new LogsMatriculaDetalleLog();
        public static LogsMatriculaDetalleLog Instancia
        {
            get
            {
                return logsMatriculaDetalleLog;
            }
        }

        public Boolean NuevoLogMatriculaDetalle(LogsMatriculaDetalle logMatriculaDetalle)
        {
            return LogsMatriculaDetalleDat.Instancia.NuevoLogMatriculaDetalle(logMatriculaDetalle);
        }

    }
}
