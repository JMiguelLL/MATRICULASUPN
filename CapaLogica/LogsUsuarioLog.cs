using CapaModelos;
using CapaAccesoDato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogsUsuarioLog
    {

        private static readonly LogsUsuarioLog logsUsuarioLog = new LogsUsuarioLog();
        public static LogsUsuarioLog Instancia
        {
            get
            {
                return logsUsuarioLog;
            }
        }

        public Boolean NuevoLogUsuario(LogsUsuario logUsuario)
        {
            return LogsUsuarioDat.Instancia.NuevoLogUsuario(logUsuario); 
        }

    }
}
