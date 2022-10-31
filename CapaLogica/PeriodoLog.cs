using CapaModelos;
using CapaAccesoDato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class PeriodoLog
    {
        private static readonly PeriodoLog periodoLog = new PeriodoLog();
        public static PeriodoLog Instancia
        {
            get
            {
                return PeriodoLog.periodoLog;
            }
        }

        public List<Periodo> ListaPeriodosActivos()
        {
            List<Periodo> lista = PeriodoDat.Instancia.ListaPeriodosActivos();

            return lista;
        }
        
        public Periodo BuscarPeriodo(int idPeriodo)
        {
            return PeriodoDat.Instancia.BuscarPeriodo(idPeriodo);

        }

    }
}
