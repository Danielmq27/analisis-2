﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capa_Datos.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.7.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-NRHLOJ2;Initial Catalog=bd_biblioteca;Integrated Security=Tru" +
            "e")]
        public string bd_bibliotecaConnectionString {
            get {
                return ((string)(this["bd_bibliotecaConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-NRHLOJ2;Initial Catalog=ARE_Biblioteca_Legislativa;Integrated" +
            " Security=True")]
        public string ARE_Biblioteca_LegislativaConnectionString {
            get {
                return ((string)(this["ARE_Biblioteca_LegislativaConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ServerFull\\SQLEXPRESS;Initial Catalog=ARE_Biblioteca_Legislativa;Inte" +
            "grated Security=True")]
        public string ARE_Biblioteca_LegislativaConnectionString1 {
            get {
                return ((string)(this["ARE_Biblioteca_LegislativaConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-BAAUC5P\\SQLEXPRESS;Initial Catalog=ARE_Biblioteca_Legislativa" +
            ";Integrated Security=True")]
        public string ARE_Biblioteca_LegislativaConnectionString2 {
            get {
                return ((string)(this["ARE_Biblioteca_LegislativaConnectionString2"]));
            }
        }
    }
}
