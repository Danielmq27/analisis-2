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

namespace Capa_Presentacion.Controllers
{
    //Controlador ReportePrestamoPermanenteController
    public class ReportePrestamoPermanenteController : Controller
    {
        //Accion para el rol Administrador
        [HttpGet]
        public ActionResult Administrador()
        {
            return View();
        }

        //Accion de la cantidad de departamentos por fechas de ingreso
        [HttpPost]
        public ActionResult CantidadDespachoFechaIngresoPP(DateTime Fecha1, DateTime Fecha2)
        {
            clsReportePrestamoPermanente reporte = new clsReportePrestamoPermanente();
            var obj = reporte.CantidadDespachoFechaIngreso(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReportePP> listaReportes = new List<ReportePP>();
                var data = reporte.CantidadDespachoFechaIngreso(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReportePP modelo = new ReportePP();
                    modelo.despacho = item.despacho;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.porcentaje;

                    listaReportes.Add(modelo);
                }
                Session["Reportes"] = listaReportes;
                return View(listaReportes);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Administrador");
            }
        }

        //Metodo para generar un reporte en excel de cantidad de tipos de usuario por fechas de ingreso
        public FileResult ReporteDespachoFechaIngresoPPXLS()
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
                ew.Cells[1, 1].Value = "Despacho";
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
                    range.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                }

                List<ReportePP> lista = (List<ReportePP>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    ew.Cells[i + 2, 1].Value = lista[i].despacho;
                    ew.Cells[i + 2, 2].Value = lista[i].cantidad;
                    ew.Cells[i + 2, 3].Value = lista[i].porcentaje + "%";
                }
                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        //Metodo para generar un reporte en pdf de cantidad de tipos de usuario por fechas de ingreso
        public FileResult ReporteDespachoFechaIngresoPPPDF()
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
                Paragraph titulo = new Paragraph("Reporte por tipos de usuarios por departamento del prestamo permanente");
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);
                Paragraph espacio = new Paragraph(" ");
                doc.Add(espacio);
                //Creamos la tabla en el pdf y damos numero de columnas
                PdfPTable table = new PdfPTable(3);
                //Damos tamaño a las columnas
                float[] values = new float[3] { 25, 15, 15 };
                table.SetWidths(values);
                //Creamos celdas
                PdfPCell celda1 = new PdfPCell(new Phrase("Despacho"));
                celda1.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Cantidad"));
                celda2.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Porcentaje"));
                celda3.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda3);

                List<ReportePP> lista = (List<ReportePP>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    table.AddCell(lista[i].despacho);
                    table.AddCell(lista[i].cantidad.ToString());
                    table.AddCell(lista[i].porcentaje.ToString() + "%");
                }

                doc.Add(table);
                doc.Close();

                buffer = ms.ToArray();
            }
            return File(buffer, "application/pdf");
        }

        //Accion de la cantidad de departamentos por fechas de ingreso
        [HttpPost]
        public ActionResult CantidadGeneroFechaIngresoPP(DateTime Fecha1, DateTime Fecha2)
        {
            clsReportePrestamoPermanente reporte = new clsReportePrestamoPermanente();
            var obj = reporte.CantidadGeneroFechaIngreso(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReportePP> listaReportes = new List<ReportePP>();
                var data = reporte.CantidadGeneroFechaIngreso(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReportePP modelo = new ReportePP();
                    modelo.tipoGenero = item.generoSolicictante;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.porcentaje;

                    listaReportes.Add(modelo);
                }
                Session["Reportes"] = listaReportes;
                return View(listaReportes);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Administrador");
            }
        }

        //Metodo para generar un reporte en excel de cantidad de genero por fechas de ingreso
        public FileResult ReporteGeneroFechaIngresoPPXLS()
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
                ew.Cells[1, 1].Value = "Género";
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
                    range.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                }

                List<ReportePP> lista = (List<ReportePP>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    ew.Cells[i + 2, 1].Value = lista[i].tipoGenero;
                    ew.Cells[i + 2, 2].Value = lista[i].cantidad;
                    ew.Cells[i + 2, 3].Value = lista[i].porcentaje + "%";
                }
                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        //Metodo para generar un reporte en pdf de cantidad de genero por fechas de ingreso
        public FileResult ReporteGeneroFechaIngresoPPPDF()
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
                Paragraph titulo = new Paragraph("Reporte por departamento por fecha de respuesta del prestamo permanente");
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);
                Paragraph espacio = new Paragraph(" ");
                doc.Add(espacio);
                //Creamos la tabla en el pdf y damos numero de columnas
                PdfPTable table = new PdfPTable(3);
                //Damos tamaño a las columnas
                float[] values = new float[3] { 25, 15, 15 };
                table.SetWidths(values);
                //Creamos celdas
                PdfPCell celda1 = new PdfPCell(new Phrase("Género"));
                celda1.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Cantidad"));
                celda2.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Porcentaje"));
                celda3.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda3);

                List<ReportePP> lista = (List<ReportePP>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    table.AddCell(lista[i].tipoGenero);
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