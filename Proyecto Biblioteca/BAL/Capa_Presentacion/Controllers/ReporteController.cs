using Capa_Logica;
using Capa_Presentacion.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Capa_Presentacion.Controllers
{
    public class ReporteController : Controller
    {
        [HttpGet]
        public ActionResult CantidadTipoUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReporteCantidadTipoUsuario(DateTime fechaFrom, DateTime fechaTo)
        {
            clsReporte reporte = new clsReporte();
            var obj = reporte.CantidadTipoUsuarioIngreso(fechaFrom, fechaTo);
            if (obj.Count() > 0)
            {
                List<ReporteFormularioCIIE> listaReportesFormularioCIIE = new List<ReporteFormularioCIIE>();
                var data = reporte.CantidadTipoUsuarioIngreso(fechaFrom, fechaTo).ToList();
                foreach (var item in data)
                {
                    ReporteFormularioCIIE modelo = new ReporteFormularioCIIE();
                    modelo.tipoDespacho = item.tipoDespacho;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.Porcentaje;

                    listaReportesFormularioCIIE.Add(modelo);
                }
                Session["Reportes"] = listaReportesFormularioCIIE;
                return View(listaReportesFormularioCIIE);
            }
            else
            {
                return View();
            }
        }

        //Metodo para generar un Excel
        public FileResult Excel()
        {
            byte[] buffer;

            using (MemoryStream ms = new MemoryStream())
            {
                //Creamos todo el documento Excel
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                ExcelPackage ep = new ExcelPackage();
                ep.Workbook.Worksheets.Add("Reporte");

                ExcelWorksheet ew = ep.Workbook.Worksheets[0];

                //Nombres de las columnas
                ew.Cells[1, 1].Value = "Tipo de usuario";
                ew.Cells[1, 2].Value = "Cantidad";
                ew.Cells[1, 3].Value = "Porcentaje";

                //Damos el tamaño de las columnas
                ew.Column(1).Width = 15;
                ew.Column(2).Width = 25;
                ew.Column(3).Width = 10;

                using (var range = ew.Cells[1, 1, 1, 3])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                }

                List<ReporteFormularioCIIE> lista = (List<ReporteFormularioCIIE>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    ew.Cells[i + 2, 1].Value = lista[i].tipoDespacho;
                    ew.Cells[i + 2, 2].Value = lista[i].cantidad;
                    ew.Cells[i + 2, 3].Value = lista[i].porcentaje + "%";
                }
                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        //Metodo para generar un PDF
        public FileResult Pdf()
        {
            //Se crea documento
            Document doc = new Document();
            byte[] buffer;
            //Se guarda en memoria
            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter.GetInstance(doc, ms);
                doc.Open();
                //Damos titulo al PDF
                Paragraph titulo = new Paragraph("Reporte por tipos de usuarios por fecha de ingreso del formulario del CIIE");
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);
                Paragraph espacio = new Paragraph(" ");
                doc.Add(espacio);
                //Creamos la tabla en el pdf y damos numero de columnas
                PdfPTable table = new PdfPTable(3);
                //Damos tamaño a las columnas
                float[] values = new float[3] { 25, 15, 15};
                table.SetWidths(values);
                //Creamos celdas
                PdfPCell celda1 = new PdfPCell(new Phrase("Tipo de usario"));
                celda1.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Cantidad"));
                celda2.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Porcentaje"));
                celda3.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda3);

                List<ReporteFormularioCIIE> lista = (List<ReporteFormularioCIIE>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    table.AddCell(lista[i].tipoDespacho);
                    table.AddCell(lista[i].cantidad.ToString());
                    table.AddCell(lista[i].porcentaje.ToString() + "%");
                }

                doc.Add(table);
                doc.Close();

                buffer = ms.ToArray();
            }
            return File(buffer, "application/pdf");
        }
    }
}