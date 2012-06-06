﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.269.
// 
#pragma warning disable 1591

namespace DocketPlaceClient.au.com.docketplace {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="AdProviderSoap", Namespace="http://docketplace.com.au/")]
    public partial class AdProvider : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback RequestAdOperationCompleted;
        
        private System.Threading.SendOrPostCallback TestConnectionOperationCompleted;
        
        private System.Threading.SendOrPostCallback InsertUnsentDocketOperationCompleted;
        
        private System.Threading.SendOrPostCallback ValidateVoucherOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateCustomersOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public AdProvider() {
            this.Url = "https://docketplace.com.au/Adprovider.asmx";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event RequestAdCompletedEventHandler RequestAdCompleted;
        
        /// <remarks/>
        public event TestConnectionCompletedEventHandler TestConnectionCompleted;
        
        /// <remarks/>
        public event InsertUnsentDocketCompletedEventHandler InsertUnsentDocketCompleted;
        
        /// <remarks/>
        public event ValidateVoucherCompletedEventHandler ValidateVoucherCompleted;
        
        /// <remarks/>
        public event UpdateCustomersCompletedEventHandler UpdateCustomersCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://docketplace.com.au/HelloWorld", RequestNamespace="http://docketplace.com.au/", ResponseNamespace="http://docketplace.com.au/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://docketplace.com.au/RequestAd", RequestNamespace="http://docketplace.com.au/", ResponseNamespace="http://docketplace.com.au/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public AdResponse RequestAd(AdRequest new_request) {
            object[] results = this.Invoke("RequestAd", new object[] {
                        new_request});
            return ((AdResponse)(results[0]));
        }
        
        /// <remarks/>
        public void RequestAdAsync(AdRequest new_request) {
            this.RequestAdAsync(new_request, null);
        }
        
        /// <remarks/>
        public void RequestAdAsync(AdRequest new_request, object userState) {
            if ((this.RequestAdOperationCompleted == null)) {
                this.RequestAdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRequestAdOperationCompleted);
            }
            this.InvokeAsync("RequestAd", new object[] {
                        new_request}, this.RequestAdOperationCompleted, userState);
        }
        
        private void OnRequestAdOperationCompleted(object arg) {
            if ((this.RequestAdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RequestAdCompleted(this, new RequestAdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://docketplace.com.au/TestConnection", RequestNamespace="http://docketplace.com.au/", ResponseNamespace="http://docketplace.com.au/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public AdResponse TestConnection(AdRequest new_request) {
            object[] results = this.Invoke("TestConnection", new object[] {
                        new_request});
            return ((AdResponse)(results[0]));
        }
        
        /// <remarks/>
        public void TestConnectionAsync(AdRequest new_request) {
            this.TestConnectionAsync(new_request, null);
        }
        
        /// <remarks/>
        public void TestConnectionAsync(AdRequest new_request, object userState) {
            if ((this.TestConnectionOperationCompleted == null)) {
                this.TestConnectionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTestConnectionOperationCompleted);
            }
            this.InvokeAsync("TestConnection", new object[] {
                        new_request}, this.TestConnectionOperationCompleted, userState);
        }
        
        private void OnTestConnectionOperationCompleted(object arg) {
            if ((this.TestConnectionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TestConnectionCompleted(this, new TestConnectionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://docketplace.com.au/InsertUnsentDocket", RequestNamespace="http://docketplace.com.au/", ResponseNamespace="http://docketplace.com.au/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public AdResponse InsertUnsentDocket(AdRequest new_request) {
            object[] results = this.Invoke("InsertUnsentDocket", new object[] {
                        new_request});
            return ((AdResponse)(results[0]));
        }
        
        /// <remarks/>
        public void InsertUnsentDocketAsync(AdRequest new_request) {
            this.InsertUnsentDocketAsync(new_request, null);
        }
        
        /// <remarks/>
        public void InsertUnsentDocketAsync(AdRequest new_request, object userState) {
            if ((this.InsertUnsentDocketOperationCompleted == null)) {
                this.InsertUnsentDocketOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertUnsentDocketOperationCompleted);
            }
            this.InvokeAsync("InsertUnsentDocket", new object[] {
                        new_request}, this.InsertUnsentDocketOperationCompleted, userState);
        }
        
        private void OnInsertUnsentDocketOperationCompleted(object arg) {
            if ((this.InsertUnsentDocketCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertUnsentDocketCompleted(this, new InsertUnsentDocketCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://docketplace.com.au/ValidateVoucher", RequestNamespace="http://docketplace.com.au/", ResponseNamespace="http://docketplace.com.au/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VoucherResponse ValidateVoucher(VoucherCheck new_request) {
            object[] results = this.Invoke("ValidateVoucher", new object[] {
                        new_request});
            return ((VoucherResponse)(results[0]));
        }
        
        /// <remarks/>
        public void ValidateVoucherAsync(VoucherCheck new_request) {
            this.ValidateVoucherAsync(new_request, null);
        }
        
        /// <remarks/>
        public void ValidateVoucherAsync(VoucherCheck new_request, object userState) {
            if ((this.ValidateVoucherOperationCompleted == null)) {
                this.ValidateVoucherOperationCompleted = new System.Threading.SendOrPostCallback(this.OnValidateVoucherOperationCompleted);
            }
            this.InvokeAsync("ValidateVoucher", new object[] {
                        new_request}, this.ValidateVoucherOperationCompleted, userState);
        }
        
        private void OnValidateVoucherOperationCompleted(object arg) {
            if ((this.ValidateVoucherCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ValidateVoucherCompleted(this, new ValidateVoucherCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://docketplace.com.au/UpdateCustomers", RequestNamespace="http://docketplace.com.au/", ResponseNamespace="http://docketplace.com.au/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public CustomerUpdateResponse UpdateCustomers(CustomerUpdate newUpdate) {
            object[] results = this.Invoke("UpdateCustomers", new object[] {
                        newUpdate});
            return ((CustomerUpdateResponse)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateCustomersAsync(CustomerUpdate newUpdate) {
            this.UpdateCustomersAsync(newUpdate, null);
        }
        
        /// <remarks/>
        public void UpdateCustomersAsync(CustomerUpdate newUpdate, object userState) {
            if ((this.UpdateCustomersOperationCompleted == null)) {
                this.UpdateCustomersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateCustomersOperationCompleted);
            }
            this.InvokeAsync("UpdateCustomers", new object[] {
                        newUpdate}, this.UpdateCustomersOperationCompleted, userState);
        }
        
        private void OnUpdateCustomersOperationCompleted(object arg) {
            if ((this.UpdateCustomersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateCustomersCompleted(this, new UpdateCustomersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docketplace.com.au/")]
    public partial class AdRequest {
        
        private int store_idField;
        
        private string passwordField;
        
        private string ipField;
        
        private LocalDocket currentDocketField;
        
        /// <remarks/>
        public int store_id {
            get {
                return this.store_idField;
            }
            set {
                this.store_idField = value;
            }
        }
        
        /// <remarks/>
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        public string IP {
            get {
                return this.ipField;
            }
            set {
                this.ipField = value;
            }
        }
        
        /// <remarks/>
        public LocalDocket currentDocket {
            get {
                return this.currentDocketField;
            }
            set {
                this.currentDocketField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docketplace.com.au/")]
    public partial class LocalDocket {
        
        private int local_idField;
        
        private string receipt_contentField;
        
        private decimal totalField;
        
        private LocalDocketItem[] itemListField;
        
        private LocalCustomer localCustomerField;
        
        private System.DateTime creation_datetimeField;
        
        /// <remarks/>
        public int local_id {
            get {
                return this.local_idField;
            }
            set {
                this.local_idField = value;
            }
        }
        
        /// <remarks/>
        public string receipt_content {
            get {
                return this.receipt_contentField;
            }
            set {
                this.receipt_contentField = value;
            }
        }
        
        /// <remarks/>
        public decimal total {
            get {
                return this.totalField;
            }
            set {
                this.totalField = value;
            }
        }
        
        /// <remarks/>
        public LocalDocketItem[] itemList {
            get {
                return this.itemListField;
            }
            set {
                this.itemListField = value;
            }
        }
        
        /// <remarks/>
        public LocalCustomer localCustomer {
            get {
                return this.localCustomerField;
            }
            set {
                this.localCustomerField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime creation_datetime {
            get {
                return this.creation_datetimeField;
            }
            set {
                this.creation_datetimeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docketplace.com.au/")]
    public partial class LocalDocketItem {
        
        private string product_codeField;
        
        private string product_barcodeField;
        
        private string descriptionField;
        
        private decimal unit_costField;
        
        private double quantityField;
        
        /// <remarks/>
        public string product_code {
            get {
                return this.product_codeField;
            }
            set {
                this.product_codeField = value;
            }
        }
        
        /// <remarks/>
        public string product_barcode {
            get {
                return this.product_barcodeField;
            }
            set {
                this.product_barcodeField = value;
            }
        }
        
        /// <remarks/>
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public decimal unit_cost {
            get {
                return this.unit_costField;
            }
            set {
                this.unit_costField = value;
            }
        }
        
        /// <remarks/>
        public double quantity {
            get {
                return this.quantityField;
            }
            set {
                this.quantityField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docketplace.com.au/")]
    public partial class CustomerUpdateResponse {
        
        private string statusField;
        
        private bool is_errorField;
        
        private string[] responsesField;
        
        /// <remarks/>
        public string status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public bool is_error {
            get {
                return this.is_errorField;
            }
            set {
                this.is_errorField = value;
            }
        }
        
        /// <remarks/>
        public string[] responses {
            get {
                return this.responsesField;
            }
            set {
                this.responsesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docketplace.com.au/")]
    public partial class CustomerUpdate {
        
        private int store_idField;
        
        private string passwordField;
        
        private LocalCustomer[] customerListField;
        
        /// <remarks/>
        public int store_id {
            get {
                return this.store_idField;
            }
            set {
                this.store_idField = value;
            }
        }
        
        /// <remarks/>
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        public LocalCustomer[] customerList {
            get {
                return this.customerListField;
            }
            set {
                this.customerListField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docketplace.com.au/")]
    public partial class LocalCustomer {
        
        private string customer_idField;
        
        private string mobileField;
        
        private string phoneField;
        
        private string emailField;
        
        private string titleField;
        
        private string first_nameField;
        
        private string last_nameField;
        
        private string suburbField;
        
        private string postcodeField;
        
        private string gradeField;
        
        private string barcode_idField;
        
        /// <remarks/>
        public string customer_id {
            get {
                return this.customer_idField;
            }
            set {
                this.customer_idField = value;
            }
        }
        
        /// <remarks/>
        public string mobile {
            get {
                return this.mobileField;
            }
            set {
                this.mobileField = value;
            }
        }
        
        /// <remarks/>
        public string phone {
            get {
                return this.phoneField;
            }
            set {
                this.phoneField = value;
            }
        }
        
        /// <remarks/>
        public string email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        public string first_name {
            get {
                return this.first_nameField;
            }
            set {
                this.first_nameField = value;
            }
        }
        
        /// <remarks/>
        public string last_name {
            get {
                return this.last_nameField;
            }
            set {
                this.last_nameField = value;
            }
        }
        
        /// <remarks/>
        public string suburb {
            get {
                return this.suburbField;
            }
            set {
                this.suburbField = value;
            }
        }
        
        /// <remarks/>
        public string postcode {
            get {
                return this.postcodeField;
            }
            set {
                this.postcodeField = value;
            }
        }
        
        /// <remarks/>
        public string grade {
            get {
                return this.gradeField;
            }
            set {
                this.gradeField = value;
            }
        }
        
        /// <remarks/>
        public string barcode_id {
            get {
                return this.barcode_idField;
            }
            set {
                this.barcode_idField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docketplace.com.au/")]
    public partial class VoucherResponse {
        
        private string statusField;
        
        private bool is_errorField;
        
        private LocalCustomer ownerField;
        
        /// <remarks/>
        public string status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public bool is_error {
            get {
                return this.is_errorField;
            }
            set {
                this.is_errorField = value;
            }
        }
        
        /// <remarks/>
        public LocalCustomer owner {
            get {
                return this.ownerField;
            }
            set {
                this.ownerField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docketplace.com.au/")]
    public partial class VoucherCheck {
        
        private int store_idField;
        
        private string passwordField;
        
        private int voucher_idField;
        
        private string voucher_codeField;
        
        private bool markAsUsedField;
        
        /// <remarks/>
        public int store_id {
            get {
                return this.store_idField;
            }
            set {
                this.store_idField = value;
            }
        }
        
        /// <remarks/>
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        public int voucher_id {
            get {
                return this.voucher_idField;
            }
            set {
                this.voucher_idField = value;
            }
        }
        
        /// <remarks/>
        public string voucher_code {
            get {
                return this.voucher_codeField;
            }
            set {
                this.voucher_codeField = value;
            }
        }
        
        /// <remarks/>
        public bool markAsUsed {
            get {
                return this.markAsUsedField;
            }
            set {
                this.markAsUsedField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docketplace.com.au/")]
    public partial class AdImage {
        
        private string imageDataField;
        
        private string footerField;
        
        /// <remarks/>
        public string imageData {
            get {
                return this.imageDataField;
            }
            set {
                this.imageDataField = value;
            }
        }
        
        /// <remarks/>
        public string footer {
            get {
                return this.footerField;
            }
            set {
                this.footerField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docketplace.com.au/")]
    public partial class AdResponse {
        
        private string statusField;
        
        private bool is_errorField;
        
        private string headerField;
        
        private AdImage[] adListField;
        
        private int placedad_idField;
        
        /// <remarks/>
        public string status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public bool is_error {
            get {
                return this.is_errorField;
            }
            set {
                this.is_errorField = value;
            }
        }
        
        /// <remarks/>
        public string header {
            get {
                return this.headerField;
            }
            set {
                this.headerField = value;
            }
        }
        
        /// <remarks/>
        public AdImage[] adList {
            get {
                return this.adListField;
            }
            set {
                this.adListField = value;
            }
        }
        
        /// <remarks/>
        public int placedad_id {
            get {
                return this.placedad_idField;
            }
            set {
                this.placedad_idField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void RequestAdCompletedEventHandler(object sender, RequestAdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RequestAdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RequestAdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public AdResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((AdResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void TestConnectionCompletedEventHandler(object sender, TestConnectionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TestConnectionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TestConnectionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public AdResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((AdResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void InsertUnsentDocketCompletedEventHandler(object sender, InsertUnsentDocketCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class InsertUnsentDocketCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal InsertUnsentDocketCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public AdResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((AdResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ValidateVoucherCompletedEventHandler(object sender, ValidateVoucherCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ValidateVoucherCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ValidateVoucherCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public VoucherResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((VoucherResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void UpdateCustomersCompletedEventHandler(object sender, UpdateCustomersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateCustomersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateCustomersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public CustomerUpdateResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CustomerUpdateResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591