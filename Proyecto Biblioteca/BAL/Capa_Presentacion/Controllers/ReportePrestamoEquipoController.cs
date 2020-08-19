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
    //Controlaor ReportePrestamoEquipoController
    [ValidarSesion]
    public class ReportePrestamoEquipoController : Controller
    {
        //Accion para el rol Administrador
        [Acceso]
        [HttpGet]
        public ActionResult Administrador()
        {
            return View();
        }

        //Accion de la cantidad de departamentos por fechas de ingreso
        [Acceso]
        [HttpPost]
        public ActionResult CantidadDepartamentoFechaIngresoPE(DateTime Fecha1, DateTime Fecha2)
        {
            clsReportePrestamoEquipo reporte = new clsReportePrestamoEquipo();
            var obj = reporte.CantidadDepartamentoFechaIngreso(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReportePE> listaReportes = new List<ReportePE>();
                var data = reporte.CantidadDepartamentoFechaIngreso(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReportePE modelo = new ReportePE();
                    modelo.departamento = item.departamento;
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
        [Acceso]
        public FileResult ReporteDepartamentoFechaIngresoPEXLS()
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
                ew.Cells[1, 1].Value = "Departamento";
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

                List<ReportePE> lista = (List<ReportePE>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    ew.Cells[i + 2, 1].Value = lista[i].departamento;
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
        public FileResult ReporteDepartamentoFechaIngresoPEPDF()
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
                Paragraph titulo = new Paragraph("Reporte por tipos de usuarios por departamento del prestamo de equipo");
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
                PdfPCell celda1 = new PdfPCell(new Phrase("Departamento"));
                celda1.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Cantidad"));
                celda2.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Porcentaje"));
                celda3.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda3);

                List<ReportePE> lista = (List<ReportePE>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    table.AddCell(lista[i].departamento);
                    table.AddCell(lista[i].cantidad.ToString());
                    table.AddCell(lista[i].porcentaje.ToString() + "%");
                }

                doc.Add(table);
                doc.Close();

                buffer = ms.ToArray();
            }
            return File(buffer, "application/pdf");
        }

        //Accion de la cantidad de departamentos por fechas de respuesta
        [Acceso]
        [HttpPost]
        public ActionResult CantidadDepartamentoFechaRespuestaPE(DateTime Fecha1, DateTime Fecha2)
        {
            clsReportePrestamoEquipo reporte = new clsReportePrestamoEquipo();
            var obj = reporte.CantidadDepartamentooFechaRespuesta(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReportePE> listaReportes = new List<ReportePE>();
                var data = reporte.CantidadDepartamentooFechaRespuesta(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReportePE modelo = new ReportePE();
                    modelo.departamento = item.departamento;
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

        //Metodo para generar un reporte en excel de cantidad de tipos de usuario por fechas de respuesta
        [Acceso]
        public FileResult ReporteDepartamentoFechaRespuestaPEXLS()
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
                ew.Cells[1, 1].Value = "Departamento";
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

                List<ReportePE> lista = (List<ReportePE>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    ew.Cells[i + 2, 1].Value = lista[i].departamento;
                    ew.Cells[i + 2, 2].Value = lista[i].cantidad;
                    ew.Cells[i + 2, 3].Value = lista[i].porcentaje + "%";
                }
                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        //Metodo para generar un reporte en pdf de cantidad de departamentos por fechas de respuesta
        [Acceso]
        public FileResult ReporteDepartamentoFechaRespuestaPEPDF()
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
                Paragraph titulo = new Paragraph("Reporte por departamento por fecha de respuesta del prestamo audiovisual");
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
                PdfPCell celda1 = new PdfPCell(new Phrase("Departamento"));
                celda1.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Cantidad"));
                celda2.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Porcentaje"));
                celda3.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda3);

                List<ReportePE> lista = (List<ReportePE>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    table.AddCell(lista[i].departamento);
                    table.AddCell(lista[i].cantidad.ToString());
                    table.AddCell(lista[i].porcentaje.ToString() + "%");
                }

                doc.Add(table);
                doc.Close();

                buffer = ms.ToArray();
            }
            return File(buffer, "application/pdf");
        }

        //Accion de la cantidad de departamentos por fechas de ingreso y fechas de respuesta
        [Acceso]
        [HttpPost]
        public ActionResult CantidadDepartamentoFechaIngresoFechaRespuestaPE(DateTime Fecha1, DateTime Fecha2)
        {
            clsReportePrestamoEquipo reporte = new clsReportePrestamoEquipo();
            var obj = reporte.CantidadDepartamentoFechaIngresoFechaRespuesta(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReportePE> listaReportes = new List<ReportePE>();
                var data = reporte.CantidadDepartamentoFechaIngresoFechaRespuesta(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReportePE modelo = new ReportePE();
                    modelo.departamento = item.Departamento;
                    modelo.cantidad = (int)item.Cantidad;
                    modelo.porcentaje = (int)item.Porcentaje;

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

        //Metodo para generar un reporte en excel de cantidad de tipos de usuario por fechas de ingreso y fechas de respuesta
        [Acceso]
        public FileResult ReporteDepartamentoFechaIngresoFechaRespuestaPEXLS()
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
                ew.Cells[1, 1].Value = "Departamento";
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

                List<ReportePE> lista = (List<ReportePE>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    ew.Cells[i + 2, 1].Value = lista[i].departamento;
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
        public FileResult ReporteDepartamentoFechaIngresoFechaRespuestaPEPDF()
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
                Paragraph titulo = new Paragraph("Reporte por departamento por fecha de ingreso y fecha de respuesta de prestamo de equipo");
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
                PdfPCell celda1 = new PdfPCell(new Phrase("Departamento"));
                celda1.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Cantidad"));
                celda2.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Porcentaje"));
                celda3.BackgroundColor = new BaseColor(82, 197, 211);
                table.AddCell(celda3);

                List<ReportePE> lista = (List<ReportePE>)Session["Reportes"];
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    table.AddCell(lista[i].departamento);
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
        public ActionResult CantidadGeneroFechaIngresoPE(DateTime Fecha1, DateTime Fecha2)
        {
            clsReportePrestamoEquipo reporte = new clsReportePrestamoEquipo();
            var obj = reporte.CantidadGeneroFechaIngreso(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReportePE> listaReportes = new List<ReportePE>();
                var data = reporte.CantidadGeneroFechaIngreso(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReportePE modelo = new ReportePE();
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

        //Metodo para generar un reporte en excel de cantidad de genero de usuario por fechas de ingreso
        [Acceso]
        public FileResult ReporteGeneroFechaIngresoPEXLS()
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

                List<ReportePE> lista = (List<ReportePE>)Session["Reportes"];
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
        public FileResult ReporteGeneroFechaIngresoPEPDF()
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
                Paragraph titulo = new Paragraph("Reporte por genero de usuarios por fecha de ingreso de prestamos de equipo");
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

                List<ReportePE> lista = (List<ReportePE>)Session["Reportes"];
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
        public ActionResult CantidadGeneroFechaRespuestaPE(DateTime Fecha1, DateTime Fecha2)
        {
            clsReportePrestamoEquipo reporte = new clsReportePrestamoEquipo();
            var obj = reporte.CantidadGeneroFechaRespuesta(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReportePE> listaReportes = new List<ReportePE>();
                var data = reporte.CantidadGeneroFechaRespuesta(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReportePE modelo = new ReportePE();
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

        //Metodo para generar un reporte en excel de cantidad de genero de usuario por fechas de respuesta
        [Acceso]
        public FileResult ReporteGeneroFechaRespuestaPEXLS()
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

                List<ReportePE> lista = (List<ReportePE>)Session["Reportes"];
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
        public FileResult ReporteGeneroFechaRespuestaPEPDF()
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
                Paragraph titulo = new Paragraph("Reporte por genero de usuarios por fecha de respuesta de prestamos de equipo");
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

                List<ReportePE> lista = (List<ReportePE>)Session["Reportes"];
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
        public ActionResult CantidadGeneroFechaIngresoFechaRespuestaPE(DateTime Fecha1, DateTime Fecha2)
        {
            clsReportePrestamoEquipo reporte = new clsReportePrestamoEquipo();
            var obj = reporte.CantidadGeneroFechaIngresoFechaRespuesta(Fecha1, Fecha2);
            if (obj.Count() > 0)
            {
                List<ReportePE> listaReportes = new List<ReportePE>();
                var data = reporte.CantidadGeneroFechaIngresoFechaRespuesta(Fecha1, Fecha2).ToList();
                foreach (var item in data)
                {
                    ReportePE modelo = new ReportePE();
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

        //Metodo para generar un reporte en excel de cantidad de genero de usuario por fechas de respuesta
        [Acceso]
        public FileResult ReporteGeneroFechaIngresoFechaRespuestaPEXLS()
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

                List<ReportePE> lista = (List<ReportePE>)Session["Reportes"];
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
        public FileResult ReporteGeneroFechaIngresoFechaRespuestaPEPDF()
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
                Paragraph titulo = new Paragraph("Reporte por genero de usuarios por fecha de ingreso y fecha de respuesta del prestamo de equipo");
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

                List<ReportePE> lista = (List<ReportePE>)Session["Reportes"];
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