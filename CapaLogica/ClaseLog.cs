using CapaModelos;
using CapaAccesoDato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClaseLog
    {
        private static readonly ClaseLog claseLog = new ClaseLog();
        public static ClaseLog Instancia
        {
            get
            {
                return claseLog;
            }
        }

        public List<Clase> ListaClasesCurso(int idCurso)
        {
            List<Clase> lista = ClasesDat.Instancia.ListaClasesCurso(idCurso);

            return lista;
        }

        public Clase BuscarClase(int idClase)
        {
            return ClasesDat.Instancia.BuscarClase(idClase);

        }

        public List<Clase> CursosMatriculados(int idMatricula)
        {
            List<Clase> lista = ClasesDat.Instancia.CursosMatriculados(idMatricula);

            return lista;
        }
        
    }
}
