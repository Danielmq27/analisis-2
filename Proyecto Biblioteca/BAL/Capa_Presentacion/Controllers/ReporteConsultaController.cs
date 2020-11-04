using Capa_Logica;
using Capa_Presentacion.Filters;
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
    //Controlador ReporteConsultaController
    [ValidarSesion]
    public class ReporteConsultaController : Controller
    {
        //Accion para el rol Index
        [Acceso]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //Accion de la cantidad de metodos de ingreso por fechas de ingreso
        [Acceso]
        [HttpPost]
        public ActionResult CantidadMetodoIngresoFechaIngresoConsulta(DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteConsulta reporte = new clsReporteConsulta();
            var obj = reporte.CantidadMetodoIngresoFechaIngreso(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteConsulta> listaReportesConsulta = new List<ReporteConsulta>();
                var data = reporte.CantidadMetodoIngresoFechaIngreso(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReporteConsulta modelo = new ReporteConsulta();
                    modelo.tipoMetodo = item.metodoIngreso;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.porcentaje;

                    listaReportesConsulta.Add(modelo);
                }
                Session["Reportes"] = listaReportesConsulta;
                return View(listaReportesConsulta);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Index");
            }
        }

        //Metodo para generar un reporte en excel de cantidad de metodos de ingreso por fechas de ingreso
        [Acceso]
        public FileResult ReporteMetodoIngresoFechaIngresoConsultaXLS()
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
                ew.Cells[1, 1].Value = "Metodo de ingreso";
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

                List<ReporteConsulta> lista = (List<ReporteConsulta>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    ew.Cells[i + 2, 1].Value = lista[i].tipoMetodo;
                    ew.Cells[i + 2, 2].Value = lista[i].cantidad;
                    ew.Cells[i + 2, 3].Value = lista[i].porcentaje + "%";
                }
                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        //Metodo para generar un reporte en pdf de cantidad de metodos de ingreso por fechas de ingreso
        [Acceso]
        public FileResult ReporteMetodoIngresoFechaIngresoConsultaPDF()
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
                Paragraph titulo = new Paragraph("Reporte por metodos de ingreso por fecha de ingreso de las consultas");
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
                PdfPCell celda1 = new PdfPCell(new Phrase("Metodo de ingreso"));
                celda1.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Cantidad"));
                celda2.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Porcentaje"));
                celda3.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda3);

                List<ReporteConsulta> lista = (List<ReporteConsulta>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    table.AddCell(lista[i].tipoMetodo);
                    table.AddCell(lista[i].cantidad.ToString());
                    table.AddCell(lista[i].porcentaje.ToString() + "%");
                }

                doc.Add(table);
                doc.Close();

                buffer = ms.ToArray();
            }
            return File(buffer, "application/pdf");
        }

        //Accion de la cantidad de metodos de ingreso por fechas de respuesta
        [Acceso]
        [HttpPost]
        public ActionResult CantidadMetodoIngresoFechaRespuestaConsulta(DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteConsulta reporte = new clsReporteConsulta();
            var obj = reporte.CantidadMetodoIngresoFechaRespuesta(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteConsulta> listaReportesConsulta = new List<ReporteConsulta>();
                var data = reporte.CantidadMetodoIngresoFechaRespuesta(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReporteConsulta modelo = new ReporteConsulta();
                    modelo.tipoMetodo = item.metodoIngreso;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.porcentaje;

                    listaReportesConsulta.Add(modelo);
                }
                Session["Reportes"] = listaReportesConsulta;
                return View(listaReportesConsulta);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Index");
            }
        }

        //Metodo para generar un reporte en excel de cantidad de metodos de ingreso por fechas de respuesta
        [Acceso]
        public FileResult ReporteReporteConsultaFechaRespuestaConsultaXLS()
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
                ew.Cells[1, 1].Value = "Metodo de ingreso";
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

                List<ReporteConsulta> lista = (List<ReporteConsulta>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    ew.Cells[i + 2, 1].Value = lista[i].tipoMetodo;
                    ew.Cells[i + 2, 2].Value = lista[i].cantidad;
                    ew.Cells[i + 2, 3].Value = lista[i].porcentaje + "%";
                }
                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        //Metodo para generar un reporte en pdf de cantidad de metodos de ingreso por fechas de respuesta
        [Acceso]
        public FileResult ReporteMetodoIngresoFechaRespuestaConsultaPDF()
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
                Paragraph titulo = new Paragraph("Reporte por metodos de ingreso por fecha de respuesta de consultas");
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
                PdfPCell celda1 = new PdfPCell(new Phrase("Tipo de usario"));
                celda1.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Cantidad"));
                celda2.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Porcentaje"));
                celda3.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda3);

                List<ReporteConsulta> lista = (List<ReporteConsulta>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    table.AddCell(lista[i].tipoMetodo);
                    table.AddCell(lista[i].cantidad.ToString());
                    table.AddCell(lista[i].porcentaje.ToString() + "%");
                }

                doc.Add(table);
                doc.Close();

                buffer = ms.ToArray();
            }
            return File(buffer, "application/pdf");
        }

        //Accion de la cantidad de metodos de ingreso por fechas de ingreso y fechas de respuesta
        [Acceso]
        [HttpPost]
        public ActionResult CantidadMetodoIngresoFechaIngresoFechaRespuestaConsulta(DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteConsulta reporte = new clsReporteConsulta();
            var obj = reporte.CantidadMetodoIngresoFechaIngresoFechaRespuesta(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteConsulta> listaReportesConsulta = new List<ReporteConsulta>();
                var data = reporte.CantidadMetodoIngresoFechaIngresoFechaRespuesta(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReporteConsulta modelo = new ReporteConsulta();
                    modelo.tipoMetodo = item.MetodoIngreso;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.Porcentaje;

                    listaReportesConsulta.Add(modelo);
                }
                Session["Reportes"] = listaReportesConsulta;
                return View(listaReportesConsulta);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Index");
            }
        }

        //Metodo para generar un reporte en excel de cantidad de metodos de ingreso por fechas de ingreso y fechas de respuesta
        [Acceso]
        public FileResult ReporteMetodoIngresoFechaIngresoFechaRespuestaConcultaXLS()
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
                ew.Cells[1, 1].Value = "Metodo de ingreso";
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

                List<ReporteConsulta> lista = (List<ReporteConsulta>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    ew.Cells[i + 2, 1].Value = lista[i].tipoMetodo;
                    ew.Cells[i + 2, 2].Value = lista[i].cantidad;
                    ew.Cells[i + 2, 3].Value = lista[i].porcentaje + "%";
                }
                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        //Metodo para generar un reporte en pdf de cantidad de metodos de ingreso por fechas de ingreso y fechas de respuesta
        [Acceso]
        public FileResult ReporteMetodoIngresoFechaIngresoFechaRespuestaCIIEPDF()
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
                Paragraph titulo = new Paragraph("Reporte por metodos de ingreso por fecha de ingreso y fecha de respuesta de consultas");
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
                PdfPCell celda1 = new PdfPCell(new Phrase("Metodo de ingreso"));
                celda1.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Cantidad"));
                celda2.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Porcentaje"));
                celda3.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda3);

                List<ReporteConsulta> lista = (List<ReporteConsulta>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    table.AddCell(lista[i].tipoMetodo);
                    table.AddCell(lista[i].cantidad.ToString());
                    table.AddCell(lista[i].porcentaje.ToString() + "%");
                }

                doc.Add(table);
                doc.Close();

                buffer = ms.ToArray();
            }
            return File(buffer, "application/pdf");
        }

        //Accion de la cantidad de genero de usuario por fechas de ingreso
        [Acceso]
        [HttpPost]
        public ActionResult CantidadGeneroFechaIngresoConsulta(DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteConsulta reporte = new clsReporteConsulta();
            var obj = reporte.CantidadGeneroFechaIngreso(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteConsulta> listaReportesConsulta= new List<ReporteConsulta>();
                var data = reporte.CantidadGeneroFechaIngreso(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReporteConsulta modelo = new ReporteConsulta();
                    modelo.tipoGenero = item.generoSolicitante;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.porcentaje;

                    listaReportesConsulta.Add(modelo);
                }
                Session["Reportes"] = listaReportesConsulta;
                return View(listaReportesConsulta);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Index");
            }
        }

        //Metodo para generar un reporte en excel de cantidad de genero de usuario por fechas de ingreso
        [Acceso]
        public FileResult ReporteGeneroFechaIngresoConsultaXLS()
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

                List<ReporteConsulta> lista = (List<ReporteConsulta>)Session["Reportes"];
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

        //Metodo para generar un reporte en pdf de cantidad de tipos de usuario por fechas de ingreso
        [Acceso]
        public FileResult ReporteGeneroFechaIngresoConsultaPDF()
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
                Paragraph titulo = new Paragraph("Reporte por genero de usuarios por fecha de ingreso de consultas");
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

                List<ReporteConsulta> lista = (List<ReporteConsulta>)Session["Reportes"];
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

        //Accion de la cantidad de genero de usuario por fechas de respuesta
        [Acceso]
        [HttpPost]
        public ActionResult CantidadGeneroFechaRespuestaConsulta(DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteConsulta reporte = new clsReporteConsulta();
            var obj = reporte.CantidadGeneroFechaRespuesta(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteConsulta> listaReportesConsulta = new List<ReporteConsulta>();
                var data = reporte.CantidadGeneroFechaRespuesta(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReporteConsulta modelo = new ReporteConsulta();
                    modelo.tipoGenero = item.generoSolicitante;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.porcentaje;

                    listaReportesConsulta.Add(modelo);
                }
                Session["Reportes"] = listaReportesConsulta;
                return View(listaReportesConsulta);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Index");
            }
        }

        //Metodo para generar un reporte en excel de cantidad de genero de usuario por fechas de respuesta
        [Acceso]
        public FileResult ReporteGeneroFechaRespuestaConsultaXLS()
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

                List<ReporteConsulta> lista = (List<ReporteConsulta>)Session["Reportes"];
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

        //Metodo para generar un reporte en pdf de cantidad de genero de usuario por fechas de respuesta
        [Acceso]
        public FileResult ReporteGeneroFechaRespuestaConsultaPDF()
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
                Paragraph titulo = new Paragraph("Reporte por genero de usuarios por fecha de respuesta de consultas");
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

                List<ReporteConsulta> lista = (List<ReporteConsulta>)Session["Reportes"];
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

        //Accion de la cantidad de genero de usuario por fechas de ingreso
        [Acceso]
        [HttpPost]
        public ActionResult CantidadGeneroFechaIngresoFechaRespuestaConsulta(DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteConsulta reporte = new clsReporteConsulta();
            var obj = reporte.CantidadGeneroFechaIngresoFechaRespuesta(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteConsulta> listaReportesConsulta = new List<ReporteConsulta>();
                var data = reporte.CantidadGeneroFechaIngresoFechaRespuesta(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReporteConsulta modelo = new ReporteConsulta();
                    modelo.tipoGenero = item.generoSolicitante;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.porcentaje;

                    listaReportesConsulta.Add(modelo);
                }
                Session["Reportes"] = listaReportesConsulta;
                return View(listaReportesConsulta);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Index");
            }
        }

        //Metodo para generar un reporte en excel de cantidad de genero de usuario por fechas de respuesta
        [Acceso]
        public FileResult ReporteGeneroFechaIngresoFechaRespuestaConsultaXLS()
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

                List<ReporteConsulta> lista = (List<ReporteConsulta>)Session["Reportes"];
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

        //Metodo para generar un reporte en pdf de cantidad de tipos de usuario por fechas de ingreso y fecha de respuesta
        [Acceso]
        public FileResult ReporteGeneroFechaIngresoFechaRespuestaConsultaPDF()
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
                Paragraph titulo = new Paragraph("Reporte por genero de usuarios por fecha de ingreso y fecha de respuesta de consultas");
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

                List<ReporteConsulta> lista = (List<ReporteConsulta>)Session["Reportes"];
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