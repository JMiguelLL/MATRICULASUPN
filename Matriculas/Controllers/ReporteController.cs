using CapaLogica;
using CapaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Matriculas.Controllers
{
    public class ReporteController : BaseController
    {
        public ActionResult Reporte()
        {
            List<Reporte> listado = ReporteLog.Instancia.ReporteMatriculas();
            return View(listado);
        }

        public ActionResult ExportarPDF()
        {
            List<Reporte> listado = ReporteLog.Instancia.ReporteMatriculas();

            var output = new MemoryStream();

           
            Document pdfDocument = new Document(PageSize.A4,0f,0f,0f,0f);
            pdfDocument.SetMargins(10f, 10f, 10f, 10f);


            var writer = PdfWriter.GetInstance(pdfDocument, output);
            writer.CloseStream = false;

            PdfPTable tabla = this.CrearTabla(listado);

            Paragraph titulo = new Paragraph("REPORTE DE MATRICULAS");
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 30;

            pdfDocument.Open();

            pdfDocument.Add(titulo);//titulo reporte
            pdfDocument.Add(tabla);//tabla reporte
           
            pdfDocument.Close();

            byte[] archivoPDF = output.ToArray();
            return File(archivoPDF, "application/pdf");
        }

        private PdfPTable CrearTabla(List<Reporte> listado)
        {
            Font font = FontFactory.GetFont("Arial", 9f);
            Font fontCeldas = FontFactory.GetFont("Arial", 8f);

            PdfPTable tabla = new PdfPTable(7);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 15f, 15f, 15f, 15f, 15f, 15f, 15f });

            PdfPCell celda = new PdfPCell();


            celda = new PdfPCell(new Phrase("CÓDIGO DE ESTUDIANTE", font));
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.VerticalAlignment = Element.ALIGN_MIDDLE;
            celda.BackgroundColor = BaseColor.GRAY;
            tabla.AddCell(celda);

            celda = new PdfPCell(new Phrase("APELLIDOS DE ESTUDIANTE", font));
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.VerticalAlignment = Element.ALIGN_MIDDLE;
            celda.BackgroundColor = BaseColor.GRAY;
            tabla.AddCell(celda);

            celda = new PdfPCell(new Phrase("NOMBRES DE ESTUDIANTE", font));
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.VerticalAlignment = Element.ALIGN_MIDDLE;
            celda.BackgroundColor = BaseColor.GRAY;
            tabla.AddCell(celda);

            celda = new PdfPCell(new Phrase("PERIODO", font));
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.VerticalAlignment = Element.ALIGN_MIDDLE;
            celda.BackgroundColor = BaseColor.GRAY;
            tabla.AddCell(celda);

            celda = new PdfPCell(new Phrase("CURSOS MATRICULADOS", font));
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.VerticalAlignment = Element.ALIGN_MIDDLE;
            celda.BackgroundColor = BaseColor.GRAY;
            tabla.AddCell(celda);

            celda = new PdfPCell(new Phrase("ACCIONES DE AÑADIR", font));
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.VerticalAlignment = Element.ALIGN_MIDDLE;
            celda.BackgroundColor = BaseColor.GRAY;
            tabla.AddCell(celda);

            celda = new PdfPCell(new Phrase("ACCIONES DE ELIMINAR", font));
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.VerticalAlignment = Element.ALIGN_MIDDLE;
            celda.BackgroundColor = BaseColor.GRAY;
            tabla.AddCell(celda);

            foreach (Reporte reporte in listado)
            {
                

                celda = new PdfPCell(new Phrase(reporte.codigo, fontCeldas));
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                tabla.AddCell(celda);


                celda = new PdfPCell(new Phrase(reporte.apellidoPaterno + " " + reporte.apellidoMaterno, fontCeldas));
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(reporte.nombre, fontCeldas));
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(reporte.nombrePeriodo, fontCeldas));
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(reporte.cursosMatriculados.ToString(), fontCeldas));
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(reporte.cantidadAgregados.ToString(), fontCeldas));
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(reporte.cantidadEliminados.ToString(), fontCeldas));
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                tabla.AddCell(celda);
            }

            return tabla;
        }
    }
}
