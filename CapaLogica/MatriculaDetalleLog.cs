using CapaModelos;
using CapaAccesoDato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class MatriculaDetalleLog
    {
        private static readonly MatriculaDetalleLog matriculaDetalleLog = new MatriculaDetalleLog();
        public static MatriculaDetalleLog Instancia
        {
            get
            {
                return matriculaDetalleLog;
            }
        }


        public MatriculaDetalle NuevaMatriculaDetalle(MatriculaDetalle matriculaDetalle)
        {
            return MatriculaDetalleDat.Instancia.NuevaMatriculaDetalle(matriculaDetalle);
        }
        public MatriculaDetalle BuscarDetalleCurso(int idMatricula, int idCurso)
        {
            return MatriculaDetalleDat.Instancia.BuscarDetalleCurso(idMatricula,idCurso);
        }
        public MatriculaDetalle BuscarDetalleClase(int idMatricula, int idClase)
        {
            return MatriculaDetalleDat.Instancia.BuscarDetalleClase(idMatricula, idClase);
        }
        public void EliminarCursoMatriculado(int idMatriculaDetalle)
        {
            MatriculaDetalleDat.Instancia.EliminarCursoMatriculado(idMatriculaDetalle);
        }
    }
}
