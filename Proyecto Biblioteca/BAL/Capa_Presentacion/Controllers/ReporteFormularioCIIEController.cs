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
    //Controlador ReporteFormularioCIIEController
    [ValidarSesion]
    public class ReporteFormularioCIIEController : Controller
    {
        //Accion para el rol Administrador
        [Acceso]
        [HttpGet]
        public ActionResult Administrador()
        {
            return View();
        }

        //Accion de la cantidad de tipos de usuario por fechas de ingreso
        [Acceso]
        [HttpPost]
        public ActionResult CantidadUsuariosFechaIngresoCIIE(DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteFormularioCIIE reporte = new clsReporteFormularioCIIE();
            var obj = reporte.CantidadTipoUsuarioFechaIngreso(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteFormularioCIIE> listaReportesFormularioCIIE = new List<ReporteFormularioCIIE>();
                var data = reporte.CantidadTipoUsuarioFechaIngreso(Fecha1, Fecha2).ToList();
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
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Administrador");
            }
        }

        //Metodo para generar un reporte en excel de cantidad de tipos de usuario por fechas de ingreso
        [Acceso]
        public FileResult ReporteUsuariosFechaIngresoCIIEXLS()
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
                    range.Style.Fill.BackgroundColor.SetColor(Color.Gray);
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

        //Metodo para generar un reporte en pdf de cantidad de tipos de usuario por fechas de ingreso
        [Acceso]
        public FileResult ReporteUsuariosFechaIngresoCIIEPDF()
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

        //Accion de la cantidad de tipos de usuario por fechas de respuesta
        [Acceso]
        [HttpPost]
        public ActionResult CantidadUsuariosFechaRespuestaCIIE(DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteFormularioCIIE reporte = new clsReporteFormularioCIIE();
            var obj = reporte.CantidadTipoUsuarioFechaIngresoFechaRespuesta(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteFormularioCIIE> listaReportesFormularioCIIE = new List<ReporteFormularioCIIE>();
                var data = reporte.CantidadTipoUsuarioFechaRespuesta(Fecha1, Fecha2).ToList();
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
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Administrador");
            }
        }

        //Metodo para generar un reporte en excel de cantidad de tipos de usuario por fechas de respuesta
        [Acceso]
        public FileResult ReporteUsuariosFechaRespuestaCIIEXLS()
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
                    range.Style.Fill.BackgroundColor.SetColor(Color.Gray);
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

        //Metodo para generar un reporte en pdf de cantidad de tipos de usuario por fechas de respuesta
        [Acceso]
        public FileResult ReporteUsuariosFechaRespuestaCIIEPDF()
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
                Paragraph titulo = new Paragraph("Reporte por tipos de usuarios por fecha de respuesta del formulario del CIIE");
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

        //Accion de la cantidad de tipos de usuario por fechas de ingreso y fechas de respuesta
        [Acceso]
        [HttpPost]
        public ActionResult CantidadUsuariosFechaIngresoFechaRespuestaCIIE (DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteFormularioCIIE reporte = new clsReporteFormularioCIIE();
            var obj = reporte.CantidadTipoUsuarioFechaIngresoFechaRespuesta(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteFormularioCIIE> listaReportesFormularioCIIE = new List<ReporteFormularioCIIE>();
                var data = reporte.CantidadTipoUsuarioFechaIngresoFechaRespuesta(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReporteFormularioCIIE modelo = new ReporteFormularioCIIE();
                    modelo.tipoDespacho = item.Tipo_Usuario;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.Porcentaje;

                    listaReportesFormularioCIIE.Add(modelo);
                }
                Session["Reportes"] = listaReportesFormularioCIIE;
                return View(listaReportesFormularioCIIE);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Administrador");
            }
        }

        //Metodo para generar un reporte en excel de cantidad de tipos de usuario por fechas de ingreso y fechas de respuesta
        [Acceso]
        public FileResult ReporteUsuariosFechaIngresoFechaRespuestaCIIEXLS()
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
                    range.Style.Fill.BackgroundColor.SetColor(Color.Gray);
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

        //Metodo para generar un reporte en pdf de cantidad de tipos de usuario por fechas de ingreso y fechas de respuesta
        [Acceso]
        public FileResult ReporteUsuariosFechaIngresoFechaRespuestaCIIEPDF()
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
                Paragraph titulo = new Paragraph("Reporte por tipos de usuarios por fecha de ingreso y fecha de respuesta del formulario del CIIE");
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

        //Accion de la cantidad de genero de usuario por fechas de ingreso
        [Acceso]
        [HttpPost]
        public ActionResult CantidadGeneroFechaIngresoCIIE(DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteFormularioCIIE reporte = new clsReporteFormularioCIIE();
            var obj = reporte.CantidadGeneroFechaIngreso(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteFormularioCIIE> listaReportesFormularioCIIE = new List<ReporteFormularioCIIE>();
                var data = reporte.CantidadGeneroFechaIngreso(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReporteFormularioCIIE modelo = new ReporteFormularioCIIE();
                    modelo.tipoGenero = item.generoSolicitante;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.porcentaje;

                    listaReportesFormularioCIIE.Add(modelo);
                }
                Session["Reportes"] = listaReportesFormularioCIIE;
                return View(listaReportesFormularioCIIE);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Administrador");
            }
        }

        //Metodo para generar un reporte en excel de cantidad de genero de usuario por fechas de ingreso
        [Acceso]
        public FileResult ReporteGeneroFechaIngresoCIIEXLS()
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

                List<ReporteFormularioCIIE> lista = (List<ReporteFormularioCIIE>)Session["Reportes"];
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
        public FileResult ReporteGeneroFechaIngresoCIIEPDF()
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
                Paragraph titulo = new Paragraph("Reporte por genero de usuarios por fecha de ingreso del formulario del CIIE");
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

                List<ReporteFormularioCIIE> lista = (List<ReporteFormularioCIIE>)Session["Reportes"];
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
        public ActionResult CantidadGeneroFechaRespuestaCIIE(DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteFormularioCIIE reporte = new clsReporteFormularioCIIE();
            var obj = reporte.CantidadGeneroFechaRespuesta(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteFormularioCIIE> listaReportesFormularioCIIE = new List<ReporteFormularioCIIE>();
                var data = reporte.CantidadGeneroFechaRespuesta(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReporteFormularioCIIE modelo = new ReporteFormularioCIIE();
                    modelo.tipoGenero = item.generoSolicitante;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.porcentaje;

                    listaReportesFormularioCIIE.Add(modelo);
                }
                Session["Reportes"] = listaReportesFormularioCIIE;
                return View(listaReportesFormularioCIIE);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Administrador");
            }
        }

        //Metodo para generar un reporte en excel de cantidad de genero de usuario por fechas de respuesta
        [Acceso]
        public FileResult ReporteGeneroFechaRespuestaCIIEXLS()
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

                List<ReporteFormularioCIIE> lista = (List<ReporteFormularioCIIE>)Session["Reportes"];
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
        public FileResult ReporteGeneroFechaRespuestaCIIEPDF()
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
                Paragraph titulo = new Paragraph("Reporte por genero de usuarios por fecha de respuesta del formulario del CIIE");
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

                List<ReporteFormularioCIIE> lista = (List<ReporteFormularioCIIE>)Session["Reportes"];
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
        public ActionResult CantidadGeneroFechaIngresoFechaRespuestaCIIE(DateTime Fecha1, DateTime Fecha2)
        {
            clsReporteFormularioCIIE reporte = new clsReporteFormularioCIIE();
            var obj = reporte.CantidadGeneroFechaIngresoFechaRespuesta(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReporteFormularioCIIE> listaReportesFormularioCIIE = new List<ReporteFormularioCIIE>();
                var data = reporte.CantidadGeneroFechaIngresoFechaRespuesta(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReporteFormularioCIIE modelo = new ReporteFormularioCIIE();
                    modelo.tipoGenero = item.generoSolicitante;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.porcentaje;

                    listaReportesFormularioCIIE.Add(modelo);
                }
                Session["Reportes"] = listaReportesFormularioCIIE;
                return View(listaReportesFormularioCIIE);
            }
            else
            {
                TempData["msg"] = "<script>alert('No existen registros con base a los parametros ingresados!');</script>";
                return View("Administrador");
            }
        }

        //Metodo para generar un reporte en excel de cantidad de genero de usuario por fechas de respuesta
        [Acceso]
        public FileResult ReporteGeneroFechaIngresoFechaRespuestaCIIEXLS()
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

                List<ReporteFormularioCIIE> lista = (List<ReporteFormularioCIIE>)Session["Reportes"];
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
        public FileResult ReporteGeneroFechaIngresoFechaRespuestaCIIEPDF()
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
                Paragraph titulo = new Paragraph("Reporte por genero de usuarios por fecha de ingreso y fecha de respuesta del formulario del CIIE");
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

                List<ReporteFormularioCIIE> lista = (List<ReporteFormularioCIIE>)Session["Reportes"];
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