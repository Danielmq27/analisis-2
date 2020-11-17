﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Capa_Presentacion.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Js").Include(
                "~/Content/plugins/jQuery/jquery-2.2.3.min.js",
                "~/Content/bootstrap/js/bootstrap.min.js",
                "~/Content/plugins/slimScroll/jquery.slimscroll.min.js",
                "~/Content/plugins/fastclick/fastclick.js",
                "~/Content/dist/js/app.min.js",
                "~/Content/dist/js/demo.js",
                "~/Content/plugins/datatables/jquery.dataTables.min.js",
                "~/Content/plugins/datatables/dataTables.bootstrap.min.js",
                "~/Content/plugins/slimScroll/jquery.slimscroll.min.js",
                "~/Content/plugins/fastclick/fastclick.js",
                "~/Content/plugins/iCheck/icheck.min.js",
                "~/Content/plugins/fastclick/fastclick.js",
                "~/Content/alertifyjs/alertify.js",
                "~/Content/alertifyjs/alertify.min.js",
                "~/Content/dist/js/AccionesArchivo.js"));

            bundles.Add(new StyleBundle("~/Css").Include(
                "~/Content/bootstrap/css/bootstrap.min.css",
                "~/Content/dist/css/AdminLTE.min.css",
                "~/Content/dist/css/skins/_all-skins.min.css",
                "~/Content/plugins/datatables/dataTables.bootstrap.css",
                "~/Content/dist/css/AdminLTE.min.css",
                "~/Content/plugins/iCheck/square/blue.css",
                "~/Content/alertifyjs/css/alertify.css",
                "~/Content/alertifyjs/css/alertify.min.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}