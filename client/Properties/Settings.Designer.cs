﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocketPlaceClient.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COM2")]
        public string COMPort {
            get {
                return ((string)(this["COMPort"]));
            }
            set {
                this["COMPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string OPOSPrinter {
            get {
                return ((string)(this["OPOSPrinter"]));
            }
            set {
                this["OPOSPrinter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("25")]
        public string store_id {
            get {
                return ((string)(this["store_id"]));
            }
            set {
                this["store_id"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("u3lhullg")]
        public string password {
            get {
                return ((string)(this["password"]));
            }
            set {
                this["password"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("https://docketplace.com.au/Adprovider.asmx")]
        public string DocketPlaceClient_au_com_docketplace_AdProvider {
            get {
                return ((string)(this["DocketPlaceClient_au_com_docketplace_AdProvider"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string RMDBLocation {
            get {
                return ((string)(this["RMDBLocation"]));
            }
            set {
                this["RMDBLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\DocketPlace\\Client\\docketplaceRewards.mdb")]
        public string DPDBLocation {
            get {
                return ((string)(this["DPDBLocation"]));
            }
            set {
                this["DPDBLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool sendSalesData {
            get {
                return ((bool)(this["sendSalesData"]));
            }
            set {
                this["sendSalesData"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool syncCustomersOnStartup {
            get {
                return ((bool)(this["syncCustomersOnStartup"]));
            }
            set {
                this["syncCustomersOnStartup"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("192.168.0.113")]
        public string POSServerLocation {
            get {
                return ((string)(this["POSServerLocation"]));
            }
            set {
                this["POSServerLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sa")]
        public string POSServerUser {
            get {
                return ((string)(this["POSServerUser"]));
            }
            set {
                this["POSServerUser"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Password1")]
        public string POSServerPassword {
            get {
                return ((string)(this["POSServerPassword"]));
            }
            set {
                this["POSServerPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Microsoft")]
        public string POSSoftware {
            get {
                return ((string)(this["POSSoftware"]));
            }
            set {
                this["POSSoftware"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sample1")]
        public string POSServerDBName {
            get {
                return ((string)(this["POSServerDBName"]));
            }
            set {
                this["POSServerDBName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Sales Receipt,Tax Invoice")]
        public string ReceiptIdentifiers {
            get {
                return ((string)(this["ReceiptIdentifiers"]));
            }
            set {
                this["ReceiptIdentifiers"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Transaction #:")]
        public string TransactionCaption {
            get {
                return ((string)(this["TransactionCaption"]));
            }
            set {
                this["TransactionCaption"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\DocketPlace\\Client\\default.png")]
        public string DefaultAd {
            get {
                return ((string)(this["DefaultAd"]));
            }
            set {
                this["DefaultAd"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool CategoriesOnly {
            get {
                return ((bool)(this["CategoriesOnly"]));
            }
            set {
                this["CategoriesOnly"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://testdocketc.web705.discountasp.net/Adprovider.asmx")]
        public string WebService {
            get {
                return ((string)(this["WebService"]));
            }
            set {
                this["WebService"] = value;
            }
        }
    }
}
