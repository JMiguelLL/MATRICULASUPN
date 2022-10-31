using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class LogsUsuario
    {
        public int idLogsUsuario { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaIngreso { get; set; }

        public Usuario usuario { get; set; }
        public LogsUsuario()
        {
        }
        public LogsUsuario( int idUsuario, DateTime fecha)
        {
            this.idUsuario = idUsuario;
            this.fechaIngreso = fecha;
        }
    }
}
