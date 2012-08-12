using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
using SerialPortSnifferAx;
using Microsoft.CSharp;
using Microsoft.PointOfService;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DocketPlaceClient.au.com.docketplace;
using System.IO;
using System.Drawing.Imaging;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace DocketPlaceClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
        private bool is_realapp = false;
        

		private System.Windows.Forms.Button ClearLogButton;
		private System.Windows.Forms.Button btnExit;


        private System.Windows.Forms.TextBox lbLog;

	   private PosExplorer posExplorer;
        List<DeviceInfo> printerList = new List<DeviceInfo>();
	   private Button TestConnectionButton;
	   private Label TestStoreConnectionErrorLabel;
        private NotifyIcon TraynotifyIcon;
	   private Button DefaultAdPrintButton;
	   private TabControl MainTabControl;
	   private TabPage ConnectionTab;
	   private TabPage PrintTab;
	   private TabPage CustomersTab;
	   private Label ConnectionErrorlabel;
	   private TextBox StoreIDtextBox;
	   private Button SaveConnectionSettingsButton;
	   private Label Storelabel;
	   private Label Passwordlabel;
	   private TextBox PasswordTextBox;
	   private Label COMlabel;
	   private ComboBox OPOSListcomboBox;
	   private ComboBox cbPort;
	   private Button MonitoringButton;
	   private Label OPOSlabel;
	   private Label PrinterErrorLabel;
	   private Button SavePrinterSettingsButton;
	   private Label MonitoringErrorlabel;
	   private CheckBox SendSalesDataCheckBox;
	   private OpenFileDialog RMOpenFileDialog;
	   private TextBox RMDBTextBox;
	   private Label RMLocationLabel;
	   private Label DPLocationLabel;
	   private TextBox DPDBTextBox;
	   private Button FindDPDBButton;
	   private Button ChooseRMDButton;
	   private OpenFileDialog DPOpenFileDialog;
	   private Button SaveRewardsSettingsButton;
        private Label RewardsErrorLabel;
	   private Button SyncOfflineButton;
	   
	   private Label label1;
	   private Button SyncCustomersButton;
	   private CheckBox syncCustomersCheckBox;
	   private GroupBox POSSoftwareGroupBox;
	   private RadioButton MicrosoftRMSRadioButton;
	   private RadioButton MYOBRadioButton;
	   private SplitContainer POSSoftwareSplitContainer;
	   private Label label2;
	   private Label label3;
	   private Label TestMicrosoftConnectionErrorLabel;
	   private Button MicrosoftTestConnectionButton;
	   private Label label6;
	   private TextBox MicrosoftPasswordTextBox;
	   private Label label5;
	   private TextBox MicrosoftUserTextBox;
	   private Label label4;
	   private TextBox MicrosoftLocationTextBox;
	   private TextBox MicrosoftDBTextBox;
	   private Label label7;
        private TextBox TransactionCaptionTextBox;
        private Label TransactionCaptionLabel;
        private TextBox ReceiptIdentifiersTextBox;
        private Label ReceiptIdentifierLabel;
        private TextBox DefaultAdTextBox;
        private Label DefaultAdLabel;
        private OpenFileDialog DefaultAdOpenFileDialog;
        private Button FindDefaultAdButton;
        private Label StockClassificationLabel;
        private RadioButton DepCat1RadioButton;
        private RadioButton Cat1Cat2RadioButton;
        private AxspsnifferLib.AxSerialPortMonitorAx axSerialPortMonitorAx;
        private IContainer components;

		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
               this.components = new System.ComponentModel.Container();
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
               this.ClearLogButton = new System.Windows.Forms.Button();
               this.btnExit = new System.Windows.Forms.Button();
               this.lbLog = new System.Windows.Forms.TextBox();
               this.TestConnectionButton = new System.Windows.Forms.Button();
               this.TestStoreConnectionErrorLabel = new System.Windows.Forms.Label();
               this.TraynotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
               this.DefaultAdPrintButton = new System.Windows.Forms.Button();
               this.MainTabControl = new System.Windows.Forms.TabControl();
               this.PrintTab = new System.Windows.Forms.TabPage();
               this.FindDefaultAdButton = new System.Windows.Forms.Button();
               this.DefaultAdTextBox = new System.Windows.Forms.TextBox();
               this.DefaultAdLabel = new System.Windows.Forms.Label();
               this.label1 = new System.Windows.Forms.Label();
               this.MonitoringErrorlabel = new System.Windows.Forms.Label();
               this.PrinterErrorLabel = new System.Windows.Forms.Label();
               this.SavePrinterSettingsButton = new System.Windows.Forms.Button();
               this.COMlabel = new System.Windows.Forms.Label();
               this.OPOSListcomboBox = new System.Windows.Forms.ComboBox();
               this.MonitoringButton = new System.Windows.Forms.Button();
               this.cbPort = new System.Windows.Forms.ComboBox();
               this.OPOSlabel = new System.Windows.Forms.Label();
               this.ConnectionTab = new System.Windows.Forms.TabPage();
               this.ConnectionErrorlabel = new System.Windows.Forms.Label();
               this.StoreIDtextBox = new System.Windows.Forms.TextBox();
               this.SaveConnectionSettingsButton = new System.Windows.Forms.Button();
               this.Storelabel = new System.Windows.Forms.Label();
               this.Passwordlabel = new System.Windows.Forms.Label();
               this.PasswordTextBox = new System.Windows.Forms.TextBox();
               this.CustomersTab = new System.Windows.Forms.TabPage();
               this.POSSoftwareSplitContainer = new System.Windows.Forms.SplitContainer();
               this.StockClassificationLabel = new System.Windows.Forms.Label();
               this.DepCat1RadioButton = new System.Windows.Forms.RadioButton();
               this.Cat1Cat2RadioButton = new System.Windows.Forms.RadioButton();
               this.label2 = new System.Windows.Forms.Label();
               this.ChooseRMDButton = new System.Windows.Forms.Button();
               this.RMLocationLabel = new System.Windows.Forms.Label();
               this.RMDBTextBox = new System.Windows.Forms.TextBox();
               this.TransactionCaptionTextBox = new System.Windows.Forms.TextBox();
               this.TransactionCaptionLabel = new System.Windows.Forms.Label();
               this.ReceiptIdentifiersTextBox = new System.Windows.Forms.TextBox();
               this.ReceiptIdentifierLabel = new System.Windows.Forms.Label();
               this.MicrosoftDBTextBox = new System.Windows.Forms.TextBox();
               this.label7 = new System.Windows.Forms.Label();
               this.TestMicrosoftConnectionErrorLabel = new System.Windows.Forms.Label();
               this.MicrosoftTestConnectionButton = new System.Windows.Forms.Button();
               this.label6 = new System.Windows.Forms.Label();
               this.MicrosoftPasswordTextBox = new System.Windows.Forms.TextBox();
               this.label5 = new System.Windows.Forms.Label();
               this.MicrosoftUserTextBox = new System.Windows.Forms.TextBox();
               this.label4 = new System.Windows.Forms.Label();
               this.MicrosoftLocationTextBox = new System.Windows.Forms.TextBox();
               this.label3 = new System.Windows.Forms.Label();
               this.POSSoftwareGroupBox = new System.Windows.Forms.GroupBox();
               this.MicrosoftRMSRadioButton = new System.Windows.Forms.RadioButton();
               this.MYOBRadioButton = new System.Windows.Forms.RadioButton();
               this.syncCustomersCheckBox = new System.Windows.Forms.CheckBox();
               this.SyncCustomersButton = new System.Windows.Forms.Button();
               this.SyncOfflineButton = new System.Windows.Forms.Button();
               this.RewardsErrorLabel = new System.Windows.Forms.Label();
               this.SaveRewardsSettingsButton = new System.Windows.Forms.Button();
               this.FindDPDBButton = new System.Windows.Forms.Button();
               this.DPLocationLabel = new System.Windows.Forms.Label();
               this.DPDBTextBox = new System.Windows.Forms.TextBox();
               this.SendSalesDataCheckBox = new System.Windows.Forms.CheckBox();
               this.RMOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
               this.DPOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
               this.DefaultAdOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
               this.axSerialPortMonitorAx = new AxspsnifferLib.AxSerialPortMonitorAx();
               this.MainTabControl.SuspendLayout();
               this.PrintTab.SuspendLayout();
               this.ConnectionTab.SuspendLayout();
               this.CustomersTab.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.POSSoftwareSplitContainer)).BeginInit();
               this.POSSoftwareSplitContainer.Panel1.SuspendLayout();
               this.POSSoftwareSplitContainer.Panel2.SuspendLayout();
               this.POSSoftwareSplitContainer.SuspendLayout();
               this.POSSoftwareGroupBox.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.axSerialPortMonitorAx)).BeginInit();
               this.SuspendLayout();
               // 
               // ClearLogButton
               // 
               this.ClearLogButton.Location = new System.Drawing.Point(479, 624);
               this.ClearLogButton.Name = "ClearLogButton";
               this.ClearLogButton.Size = new System.Drawing.Size(75, 25);
               this.ClearLogButton.TabIndex = 9;
               this.ClearLogButton.Text = "Clear Log";
               this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
               // 
               // btnExit
               // 
               this.btnExit.Location = new System.Drawing.Point(57, 624);
               this.btnExit.Name = "btnExit";
               this.btnExit.Size = new System.Drawing.Size(75, 25);
               this.btnExit.TabIndex = 10;
               this.btnExit.Text = "Exit";
               this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
               // 
               // lbLog
               // 
               this.lbLog.Location = new System.Drawing.Point(593, 26);
               this.lbLog.Multiline = true;
               this.lbLog.Name = "lbLog";
               this.lbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
               this.lbLog.Size = new System.Drawing.Size(519, 576);
               this.lbLog.TabIndex = 22;
               // 
               // TestConnectionButton
               // 
               this.TestConnectionButton.Location = new System.Drawing.Point(25, 208);
               this.TestConnectionButton.Name = "TestConnectionButton";
               this.TestConnectionButton.Size = new System.Drawing.Size(102, 23);
               this.TestConnectionButton.TabIndex = 24;
               this.TestConnectionButton.Text = "Test Connection";
               this.TestConnectionButton.UseVisualStyleBackColor = true;
               this.TestConnectionButton.Click += new System.EventHandler(this.TestConnectionButton_Click);
               // 
               // TestStoreConnectionErrorLabel
               // 
               this.TestStoreConnectionErrorLabel.AutoSize = true;
               this.TestStoreConnectionErrorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.TestStoreConnectionErrorLabel.ForeColor = System.Drawing.Color.Red;
               this.TestStoreConnectionErrorLabel.Location = new System.Drawing.Point(16, 265);
               this.TestStoreConnectionErrorLabel.Name = "TestStoreConnectionErrorLabel";
               this.TestStoreConnectionErrorLabel.Size = new System.Drawing.Size(2, 15);
               this.TestStoreConnectionErrorLabel.TabIndex = 36;
               // 
               // TraynotifyIcon
               // 
               this.TraynotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TraynotifyIcon.Icon")));
               this.TraynotifyIcon.Text = "DocketPlace Client";
               this.TraynotifyIcon.Visible = true;
               this.TraynotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TraynotifyIcon_MouseDoubleClick);
               // 
               // DefaultAdPrintButton
               // 
               this.DefaultAdPrintButton.Location = new System.Drawing.Point(25, 232);
               this.DefaultAdPrintButton.Name = "DefaultAdPrintButton";
               this.DefaultAdPrintButton.Size = new System.Drawing.Size(102, 23);
               this.DefaultAdPrintButton.TabIndex = 37;
               this.DefaultAdPrintButton.Text = "Print Default Ad";
               this.DefaultAdPrintButton.UseVisualStyleBackColor = true;
               this.DefaultAdPrintButton.Click += new System.EventHandler(this.DefaultAdPrintButton_Click);
               // 
               // MainTabControl
               // 
               this.MainTabControl.Controls.Add(this.PrintTab);
               this.MainTabControl.Controls.Add(this.ConnectionTab);
               this.MainTabControl.Controls.Add(this.CustomersTab);
               this.MainTabControl.Location = new System.Drawing.Point(28, 26);
               this.MainTabControl.Name = "MainTabControl";
               this.MainTabControl.SelectedIndex = 0;
               this.MainTabControl.Size = new System.Drawing.Size(546, 576);
               this.MainTabControl.TabIndex = 39;
               // 
               // PrintTab
               // 
               this.PrintTab.Controls.Add(this.FindDefaultAdButton);
               this.PrintTab.Controls.Add(this.DefaultAdTextBox);
               this.PrintTab.Controls.Add(this.DefaultAdLabel);
               this.PrintTab.Controls.Add(this.label1);
               this.PrintTab.Controls.Add(this.MonitoringErrorlabel);
               this.PrintTab.Controls.Add(this.PrinterErrorLabel);
               this.PrintTab.Controls.Add(this.SavePrinterSettingsButton);
               this.PrintTab.Controls.Add(this.COMlabel);
               this.PrintTab.Controls.Add(this.OPOSListcomboBox);
               this.PrintTab.Controls.Add(this.DefaultAdPrintButton);
               this.PrintTab.Controls.Add(this.MonitoringButton);
               this.PrintTab.Controls.Add(this.cbPort);
               this.PrintTab.Controls.Add(this.OPOSlabel);
               this.PrintTab.Location = new System.Drawing.Point(4, 22);
               this.PrintTab.Name = "PrintTab";
               this.PrintTab.Padding = new System.Windows.Forms.Padding(3);
               this.PrintTab.Size = new System.Drawing.Size(538, 550);
               this.PrintTab.TabIndex = 1;
               this.PrintTab.Text = "Print";
               this.PrintTab.UseVisualStyleBackColor = true;
               // 
               // FindDefaultAdButton
               // 
               this.FindDefaultAdButton.Location = new System.Drawing.Point(447, 86);
               this.FindDefaultAdButton.Name = "FindDefaultAdButton";
               this.FindDefaultAdButton.Size = new System.Drawing.Size(75, 23);
               this.FindDefaultAdButton.TabIndex = 44;
               this.FindDefaultAdButton.Text = "Find Ad";
               this.FindDefaultAdButton.UseVisualStyleBackColor = true;
               this.FindDefaultAdButton.Click += new System.EventHandler(this.FindDefaultAdButton_Click);
               // 
               // DefaultAdTextBox
               // 
               this.DefaultAdTextBox.Location = new System.Drawing.Point(169, 86);
               this.DefaultAdTextBox.Name = "DefaultAdTextBox";
               this.DefaultAdTextBox.Size = new System.Drawing.Size(254, 20);
               this.DefaultAdTextBox.TabIndex = 43;
               // 
               // DefaultAdLabel
               // 
               this.DefaultAdLabel.AutoSize = true;
               this.DefaultAdLabel.Location = new System.Drawing.Point(10, 89);
               this.DefaultAdLabel.Name = "DefaultAdLabel";
               this.DefaultAdLabel.Size = new System.Drawing.Size(57, 13);
               this.DefaultAdLabel.TabIndex = 42;
               this.DefaultAdLabel.Text = "Default Ad";
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(10, 82);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(0, 13);
               this.label1.TabIndex = 41;
               // 
               // MonitoringErrorlabel
               // 
               this.MonitoringErrorlabel.AutoSize = true;
               this.MonitoringErrorlabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.MonitoringErrorlabel.ForeColor = System.Drawing.Color.Red;
               this.MonitoringErrorlabel.Location = new System.Drawing.Point(169, 237);
               this.MonitoringErrorlabel.Name = "MonitoringErrorlabel";
               this.MonitoringErrorlabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
               this.MonitoringErrorlabel.Size = new System.Drawing.Size(12, 15);
               this.MonitoringErrorlabel.TabIndex = 40;
               // 
               // PrinterErrorLabel
               // 
               this.PrinterErrorLabel.AutoSize = true;
               this.PrinterErrorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.PrinterErrorLabel.ForeColor = System.Drawing.Color.Red;
               this.PrinterErrorLabel.Location = new System.Drawing.Point(169, 136);
               this.PrinterErrorLabel.Name = "PrinterErrorLabel";
               this.PrinterErrorLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
               this.PrinterErrorLabel.Size = new System.Drawing.Size(12, 15);
               this.PrinterErrorLabel.TabIndex = 39;
               // 
               // SavePrinterSettingsButton
               // 
               this.SavePrinterSettingsButton.Location = new System.Drawing.Point(13, 131);
               this.SavePrinterSettingsButton.Name = "SavePrinterSettingsButton";
               this.SavePrinterSettingsButton.Size = new System.Drawing.Size(81, 23);
               this.SavePrinterSettingsButton.TabIndex = 38;
               this.SavePrinterSettingsButton.Text = "Save Settings";
               this.SavePrinterSettingsButton.UseVisualStyleBackColor = true;
               this.SavePrinterSettingsButton.Click += new System.EventHandler(this.SavePrinterSettingsButton_Click);
               // 
               // COMlabel
               // 
               this.COMlabel.Location = new System.Drawing.Point(9, 22);
               this.COMlabel.Name = "COMlabel";
               this.COMlabel.Size = new System.Drawing.Size(157, 16);
               this.COMlabel.TabIndex = 21;
               this.COMlabel.Text = "Select Printer Port to Monitor:";
               // 
               // OPOSListcomboBox
               // 
               this.OPOSListcomboBox.FormattingEnabled = true;
               this.OPOSListcomboBox.Location = new System.Drawing.Point(169, 55);
               this.OPOSListcomboBox.Name = "OPOSListcomboBox";
               this.OPOSListcomboBox.Size = new System.Drawing.Size(289, 21);
               this.OPOSListcomboBox.TabIndex = 23;
               // 
               // MonitoringButton
               // 
               this.MonitoringButton.Location = new System.Drawing.Point(390, 17);
               this.MonitoringButton.Name = "MonitoringButton";
               this.MonitoringButton.Size = new System.Drawing.Size(132, 23);
               this.MonitoringButton.TabIndex = 1;
               this.MonitoringButton.Text = "Start monitoring";
               this.MonitoringButton.Click += new System.EventHandler(this.MonitorButton_Click);
               // 
               // cbPort
               // 
               this.cbPort.ItemHeight = 13;
               this.cbPort.Location = new System.Drawing.Point(169, 17);
               this.cbPort.Name = "cbPort";
               this.cbPort.Size = new System.Drawing.Size(136, 21);
               this.cbPort.TabIndex = 0;
               // 
               // OPOSlabel
               // 
               this.OPOSlabel.AutoSize = true;
               this.OPOSlabel.Location = new System.Drawing.Point(9, 55);
               this.OPOSlabel.Name = "OPOSlabel";
               this.OPOSlabel.Size = new System.Drawing.Size(70, 13);
               this.OPOSlabel.TabIndex = 24;
               this.OPOSlabel.Text = "OPOSPrinter:";
               // 
               // ConnectionTab
               // 
               this.ConnectionTab.Controls.Add(this.ConnectionErrorlabel);
               this.ConnectionTab.Controls.Add(this.StoreIDtextBox);
               this.ConnectionTab.Controls.Add(this.TestStoreConnectionErrorLabel);
               this.ConnectionTab.Controls.Add(this.SaveConnectionSettingsButton);
               this.ConnectionTab.Controls.Add(this.Storelabel);
               this.ConnectionTab.Controls.Add(this.Passwordlabel);
               this.ConnectionTab.Controls.Add(this.TestConnectionButton);
               this.ConnectionTab.Controls.Add(this.PasswordTextBox);
               this.ConnectionTab.Location = new System.Drawing.Point(4, 22);
               this.ConnectionTab.Name = "ConnectionTab";
               this.ConnectionTab.Padding = new System.Windows.Forms.Padding(3);
               this.ConnectionTab.Size = new System.Drawing.Size(538, 550);
               this.ConnectionTab.TabIndex = 0;
               this.ConnectionTab.Text = "Connection";
               this.ConnectionTab.UseVisualStyleBackColor = true;
               // 
               // ConnectionErrorlabel
               // 
               this.ConnectionErrorlabel.AutoSize = true;
               this.ConnectionErrorlabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.ConnectionErrorlabel.ForeColor = System.Drawing.Color.Red;
               this.ConnectionErrorlabel.Location = new System.Drawing.Point(135, 121);
               this.ConnectionErrorlabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
               this.ConnectionErrorlabel.Name = "ConnectionErrorlabel";
               this.ConnectionErrorlabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
               this.ConnectionErrorlabel.Size = new System.Drawing.Size(12, 15);
               this.ConnectionErrorlabel.TabIndex = 35;
               // 
               // StoreIDtextBox
               // 
               this.StoreIDtextBox.Location = new System.Drawing.Point(108, 16);
               this.StoreIDtextBox.Name = "StoreIDtextBox";
               this.StoreIDtextBox.Size = new System.Drawing.Size(386, 20);
               this.StoreIDtextBox.TabIndex = 26;
               // 
               // SaveConnectionSettingsButton
               // 
               this.SaveConnectionSettingsButton.Location = new System.Drawing.Point(25, 116);
               this.SaveConnectionSettingsButton.Name = "SaveConnectionSettingsButton";
               this.SaveConnectionSettingsButton.Size = new System.Drawing.Size(87, 23);
               this.SaveConnectionSettingsButton.TabIndex = 34;
               this.SaveConnectionSettingsButton.Text = "Save Settings";
               this.SaveConnectionSettingsButton.UseVisualStyleBackColor = true;
               this.SaveConnectionSettingsButton.Click += new System.EventHandler(this.SaveConnectionSettingsButton_Click);
               // 
               // Storelabel
               // 
               this.Storelabel.AutoSize = true;
               this.Storelabel.Location = new System.Drawing.Point(13, 16);
               this.Storelabel.Name = "Storelabel";
               this.Storelabel.Size = new System.Drawing.Size(49, 13);
               this.Storelabel.TabIndex = 25;
               this.Storelabel.Text = "Store ID:";
               // 
               // Passwordlabel
               // 
               this.Passwordlabel.AutoSize = true;
               this.Passwordlabel.Location = new System.Drawing.Point(13, 56);
               this.Passwordlabel.Name = "Passwordlabel";
               this.Passwordlabel.Size = new System.Drawing.Size(56, 13);
               this.Passwordlabel.TabIndex = 27;
               this.Passwordlabel.Text = "Password:";
               // 
               // PasswordTextBox
               // 
               this.PasswordTextBox.Location = new System.Drawing.Point(108, 56);
               this.PasswordTextBox.Name = "PasswordTextBox";
               this.PasswordTextBox.PasswordChar = '*';
               this.PasswordTextBox.Size = new System.Drawing.Size(386, 20);
               this.PasswordTextBox.TabIndex = 28;
               // 
               // CustomersTab
               // 
               this.CustomersTab.Controls.Add(this.POSSoftwareSplitContainer);
               this.CustomersTab.Controls.Add(this.POSSoftwareGroupBox);
               this.CustomersTab.Controls.Add(this.syncCustomersCheckBox);
               this.CustomersTab.Controls.Add(this.SyncCustomersButton);
               this.CustomersTab.Controls.Add(this.SyncOfflineButton);
               this.CustomersTab.Controls.Add(this.RewardsErrorLabel);
               this.CustomersTab.Controls.Add(this.SaveRewardsSettingsButton);
               this.CustomersTab.Controls.Add(this.FindDPDBButton);
               this.CustomersTab.Controls.Add(this.DPLocationLabel);
               this.CustomersTab.Controls.Add(this.DPDBTextBox);
               this.CustomersTab.Controls.Add(this.SendSalesDataCheckBox);
               this.CustomersTab.Location = new System.Drawing.Point(4, 22);
               this.CustomersTab.Name = "CustomersTab";
               this.CustomersTab.Padding = new System.Windows.Forms.Padding(3);
               this.CustomersTab.Size = new System.Drawing.Size(538, 550);
               this.CustomersTab.TabIndex = 2;
               this.CustomersTab.Text = "Customers";
               this.CustomersTab.UseVisualStyleBackColor = true;
               // 
               // POSSoftwareSplitContainer
               // 
               this.POSSoftwareSplitContainer.Location = new System.Drawing.Point(9, 185);
               this.POSSoftwareSplitContainer.Name = "POSSoftwareSplitContainer";
               this.POSSoftwareSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
               // 
               // POSSoftwareSplitContainer.Panel1
               // 
               this.POSSoftwareSplitContainer.Panel1.Controls.Add(this.StockClassificationLabel);
               this.POSSoftwareSplitContainer.Panel1.Controls.Add(this.DepCat1RadioButton);
               this.POSSoftwareSplitContainer.Panel1.Controls.Add(this.Cat1Cat2RadioButton);
               this.POSSoftwareSplitContainer.Panel1.Controls.Add(this.label2);
               this.POSSoftwareSplitContainer.Panel1.Controls.Add(this.ChooseRMDButton);
               this.POSSoftwareSplitContainer.Panel1.Controls.Add(this.RMLocationLabel);
               this.POSSoftwareSplitContainer.Panel1.Controls.Add(this.RMDBTextBox);
               // 
               // POSSoftwareSplitContainer.Panel2
               // 
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.TransactionCaptionTextBox);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.TransactionCaptionLabel);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.ReceiptIdentifiersTextBox);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.ReceiptIdentifierLabel);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.MicrosoftDBTextBox);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.label7);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.TestMicrosoftConnectionErrorLabel);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.MicrosoftTestConnectionButton);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.label6);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.MicrosoftPasswordTextBox);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.label5);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.MicrosoftUserTextBox);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.label4);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.MicrosoftLocationTextBox);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.label3);
               this.POSSoftwareSplitContainer.Size = new System.Drawing.Size(526, 296);
               this.POSSoftwareSplitContainer.SplitterDistance = 99;
               this.POSSoftwareSplitContainer.TabIndex = 47;
               // 
               // StockClassificationLabel
               // 
               this.StockClassificationLabel.AutoSize = true;
               this.StockClassificationLabel.Location = new System.Drawing.Point(13, 76);
               this.StockClassificationLabel.Name = "StockClassificationLabel";
               this.StockClassificationLabel.Size = new System.Drawing.Size(99, 13);
               this.StockClassificationLabel.TabIndex = 37;
               this.StockClassificationLabel.Text = "Stock Classification";
               // 
               // DepCat1RadioButton
               // 
               this.DepCat1RadioButton.AutoSize = true;
               this.DepCat1RadioButton.Location = new System.Drawing.Point(279, 74);
               this.DepCat1RadioButton.Name = "DepCat1RadioButton";
               this.DepCat1RadioButton.Size = new System.Drawing.Size(133, 17);
               this.DepCat1RadioButton.TabIndex = 36;
               this.DepCat1RadioButton.TabStop = true;
               this.DepCat1RadioButton.Text = "Department/Category1";
               this.DepCat1RadioButton.UseVisualStyleBackColor = true;
               this.DepCat1RadioButton.CheckedChanged += new System.EventHandler(this.DepCat1RadioButton_CheckedChanged);
               // 
               // Cat1Cat2RadioButton
               // 
               this.Cat1Cat2RadioButton.AutoSize = true;
               this.Cat1Cat2RadioButton.Location = new System.Drawing.Point(131, 74);
               this.Cat1Cat2RadioButton.Name = "Cat1Cat2RadioButton";
               this.Cat1Cat2RadioButton.Size = new System.Drawing.Size(126, 17);
               this.Cat1Cat2RadioButton.TabIndex = 35;
               this.Cat1Cat2RadioButton.TabStop = true;
               this.Cat1Cat2RadioButton.Text = "Category1/Category2";
               this.Cat1Cat2RadioButton.UseVisualStyleBackColor = true;
               this.Cat1Cat2RadioButton.CheckedChanged += new System.EventHandler(this.Cat1Cat2RadioButton_CheckedChanged);
               // 
               // label2
               // 
               this.label2.AutoSize = true;
               this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label2.Location = new System.Drawing.Point(13, 9);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(132, 13);
               this.label2.TabIndex = 34;
               this.label2.Text = "MYOB Retail Manager";
               // 
               // ChooseRMDButton
               // 
               this.ChooseRMDButton.Location = new System.Drawing.Point(438, 35);
               this.ChooseRMDButton.Name = "ChooseRMDButton";
               this.ChooseRMDButton.Size = new System.Drawing.Size(75, 23);
               this.ChooseRMDButton.TabIndex = 33;
               this.ChooseRMDButton.Text = "Find RMDB";
               this.ChooseRMDButton.UseVisualStyleBackColor = true;
               this.ChooseRMDButton.Click += new System.EventHandler(this.ChooseRMDButton_Click);
               // 
               // RMLocationLabel
               // 
               this.RMLocationLabel.AutoSize = true;
               this.RMLocationLabel.Location = new System.Drawing.Point(13, 38);
               this.RMLocationLabel.Name = "RMLocationLabel";
               this.RMLocationLabel.Size = new System.Drawing.Size(86, 13);
               this.RMLocationLabel.TabIndex = 29;
               this.RMLocationLabel.Text = "RM DB Location";
               // 
               // RMDBTextBox
               // 
               this.RMDBTextBox.Location = new System.Drawing.Point(131, 35);
               this.RMDBTextBox.Name = "RMDBTextBox";
               this.RMDBTextBox.Size = new System.Drawing.Size(268, 20);
               this.RMDBTextBox.TabIndex = 30;
               // 
               // TransactionCaptionTextBox
               // 
               this.TransactionCaptionTextBox.Location = new System.Drawing.Point(131, 139);
               this.TransactionCaptionTextBox.Name = "TransactionCaptionTextBox";
               this.TransactionCaptionTextBox.Size = new System.Drawing.Size(127, 20);
               this.TransactionCaptionTextBox.TabIndex = 49;
               // 
               // TransactionCaptionLabel
               // 
               this.TransactionCaptionLabel.AutoSize = true;
               this.TransactionCaptionLabel.Location = new System.Drawing.Point(13, 143);
               this.TransactionCaptionLabel.Name = "TransactionCaptionLabel";
               this.TransactionCaptionLabel.Size = new System.Drawing.Size(102, 13);
               this.TransactionCaptionLabel.TabIndex = 48;
               this.TransactionCaptionLabel.Text = "Transaction Caption";
               // 
               // ReceiptIdentifiersTextBox
               // 
               this.ReceiptIdentifiersTextBox.Location = new System.Drawing.Point(131, 104);
               this.ReceiptIdentifiersTextBox.Name = "ReceiptIdentifiersTextBox";
               this.ReceiptIdentifiersTextBox.Size = new System.Drawing.Size(382, 20);
               this.ReceiptIdentifiersTextBox.TabIndex = 47;
               // 
               // ReceiptIdentifierLabel
               // 
               this.ReceiptIdentifierLabel.AutoSize = true;
               this.ReceiptIdentifierLabel.Location = new System.Drawing.Point(13, 108);
               this.ReceiptIdentifierLabel.Name = "ReceiptIdentifierLabel";
               this.ReceiptIdentifierLabel.Size = new System.Drawing.Size(92, 13);
               this.ReceiptIdentifierLabel.TabIndex = 46;
               this.ReceiptIdentifierLabel.Text = "Receipt Identifiers";
               // 
               // MicrosoftDBTextBox
               // 
               this.MicrosoftDBTextBox.Location = new System.Drawing.Point(131, 63);
               this.MicrosoftDBTextBox.Name = "MicrosoftDBTextBox";
               this.MicrosoftDBTextBox.Size = new System.Drawing.Size(127, 20);
               this.MicrosoftDBTextBox.TabIndex = 45;
               // 
               // label7
               // 
               this.label7.AutoSize = true;
               this.label7.Location = new System.Drawing.Point(13, 67);
               this.label7.Name = "label7";
               this.label7.Size = new System.Drawing.Size(84, 13);
               this.label7.TabIndex = 44;
               this.label7.Text = "Database Name";
               // 
               // TestMicrosoftConnectionErrorLabel
               // 
               this.TestMicrosoftConnectionErrorLabel.AutoSize = true;
               this.TestMicrosoftConnectionErrorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.TestMicrosoftConnectionErrorLabel.ForeColor = System.Drawing.Color.Red;
               this.TestMicrosoftConnectionErrorLabel.Location = new System.Drawing.Point(129, 172);
               this.TestMicrosoftConnectionErrorLabel.Name = "TestMicrosoftConnectionErrorLabel";
               this.TestMicrosoftConnectionErrorLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
               this.TestMicrosoftConnectionErrorLabel.Size = new System.Drawing.Size(12, 15);
               this.TestMicrosoftConnectionErrorLabel.TabIndex = 43;
               // 
               // MicrosoftTestConnectionButton
               // 
               this.MicrosoftTestConnectionButton.Location = new System.Drawing.Point(14, 167);
               this.MicrosoftTestConnectionButton.Name = "MicrosoftTestConnectionButton";
               this.MicrosoftTestConnectionButton.Size = new System.Drawing.Size(97, 23);
               this.MicrosoftTestConnectionButton.TabIndex = 42;
               this.MicrosoftTestConnectionButton.Text = "Test Connection";
               this.MicrosoftTestConnectionButton.UseVisualStyleBackColor = true;
               this.MicrosoftTestConnectionButton.Click += new System.EventHandler(this.MicrosoftTestConnectionButton_Click);
               // 
               // label6
               // 
               this.label6.AutoSize = true;
               this.label6.Location = new System.Drawing.Point(278, 67);
               this.label6.Name = "label6";
               this.label6.Size = new System.Drawing.Size(53, 13);
               this.label6.TabIndex = 40;
               this.label6.Text = "Password";
               // 
               // MicrosoftPasswordTextBox
               // 
               this.MicrosoftPasswordTextBox.Location = new System.Drawing.Point(356, 64);
               this.MicrosoftPasswordTextBox.Name = "MicrosoftPasswordTextBox";
               this.MicrosoftPasswordTextBox.PasswordChar = '*';
               this.MicrosoftPasswordTextBox.Size = new System.Drawing.Size(157, 20);
               this.MicrosoftPasswordTextBox.TabIndex = 41;
               // 
               // label5
               // 
               this.label5.AutoSize = true;
               this.label5.Location = new System.Drawing.Point(276, 34);
               this.label5.Name = "label5";
               this.label5.Size = new System.Drawing.Size(55, 13);
               this.label5.TabIndex = 38;
               this.label5.Text = "Username";
               // 
               // MicrosoftUserTextBox
               // 
               this.MicrosoftUserTextBox.Location = new System.Drawing.Point(356, 34);
               this.MicrosoftUserTextBox.Name = "MicrosoftUserTextBox";
               this.MicrosoftUserTextBox.Size = new System.Drawing.Size(157, 20);
               this.MicrosoftUserTextBox.TabIndex = 39;
               // 
               // label4
               // 
               this.label4.AutoSize = true;
               this.label4.Location = new System.Drawing.Point(13, 37);
               this.label4.Name = "label4";
               this.label4.Size = new System.Drawing.Size(69, 13);
               this.label4.TabIndex = 36;
               this.label4.Text = "Server Name";
               // 
               // MicrosoftLocationTextBox
               // 
               this.MicrosoftLocationTextBox.Location = new System.Drawing.Point(131, 34);
               this.MicrosoftLocationTextBox.Name = "MicrosoftLocationTextBox";
               this.MicrosoftLocationTextBox.Size = new System.Drawing.Size(127, 20);
               this.MicrosoftLocationTextBox.TabIndex = 37;
               // 
               // label3
               // 
               this.label3.AutoSize = true;
               this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label3.Location = new System.Drawing.Point(11, 13);
               this.label3.Name = "label3";
               this.label3.Size = new System.Drawing.Size(90, 13);
               this.label3.TabIndex = 35;
               this.label3.Text = "Microsoft RMS";
               // 
               // POSSoftwareGroupBox
               // 
               this.POSSoftwareGroupBox.Controls.Add(this.MicrosoftRMSRadioButton);
               this.POSSoftwareGroupBox.Controls.Add(this.MYOBRadioButton);
               this.POSSoftwareGroupBox.Location = new System.Drawing.Point(123, 117);
               this.POSSoftwareGroupBox.Name = "POSSoftwareGroupBox";
               this.POSSoftwareGroupBox.Size = new System.Drawing.Size(285, 62);
               this.POSSoftwareGroupBox.TabIndex = 46;
               this.POSSoftwareGroupBox.TabStop = false;
               this.POSSoftwareGroupBox.Text = "POS Software";
               // 
               // MicrosoftRMSRadioButton
               // 
               this.MicrosoftRMSRadioButton.AutoSize = true;
               this.MicrosoftRMSRadioButton.Location = new System.Drawing.Point(30, 42);
               this.MicrosoftRMSRadioButton.Name = "MicrosoftRMSRadioButton";
               this.MicrosoftRMSRadioButton.Size = new System.Drawing.Size(95, 17);
               this.MicrosoftRMSRadioButton.TabIndex = 1;
               this.MicrosoftRMSRadioButton.TabStop = true;
               this.MicrosoftRMSRadioButton.Text = "Microsoft RMS";
               this.MicrosoftRMSRadioButton.UseVisualStyleBackColor = true;
               this.MicrosoftRMSRadioButton.CheckedChanged += new System.EventHandler(this.MicrosoftRMSRadioButton_CheckedChanged);
               // 
               // MYOBRadioButton
               // 
               this.MYOBRadioButton.AutoSize = true;
               this.MYOBRadioButton.Location = new System.Drawing.Point(30, 19);
               this.MYOBRadioButton.Name = "MYOBRadioButton";
               this.MYOBRadioButton.Size = new System.Drawing.Size(131, 17);
               this.MYOBRadioButton.TabIndex = 0;
               this.MYOBRadioButton.TabStop = true;
               this.MYOBRadioButton.Text = "MYOB Retail Manager";
               this.MYOBRadioButton.UseVisualStyleBackColor = true;
               this.MYOBRadioButton.CheckedChanged += new System.EventHandler(this.MYOBRadioButton_CheckedChanged);
               // 
               // syncCustomersCheckBox
               // 
               this.syncCustomersCheckBox.AutoSize = true;
               this.syncCustomersCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
               this.syncCustomersCheckBox.Location = new System.Drawing.Point(15, 43);
               this.syncCustomersCheckBox.Name = "syncCustomersCheckBox";
               this.syncCustomersCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
               this.syncCustomersCheckBox.Size = new System.Drawing.Size(163, 17);
               this.syncCustomersCheckBox.TabIndex = 45;
               this.syncCustomersCheckBox.Text = "Sync Customers on Startup ?";
               this.syncCustomersCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               this.syncCustomersCheckBox.UseVisualStyleBackColor = true;
               // 
               // SyncCustomersButton
               // 
               this.SyncCustomersButton.Location = new System.Drawing.Point(25, 521);
               this.SyncCustomersButton.Name = "SyncCustomersButton";
               this.SyncCustomersButton.Size = new System.Drawing.Size(125, 23);
               this.SyncCustomersButton.TabIndex = 44;
               this.SyncCustomersButton.Text = "Sync Customers List";
               this.SyncCustomersButton.UseVisualStyleBackColor = true;
               this.SyncCustomersButton.Click += new System.EventHandler(this.SyncCustomersButton_Click);
               // 
               // SyncOfflineButton
               // 
               this.SyncOfflineButton.Location = new System.Drawing.Point(405, 521);
               this.SyncOfflineButton.Name = "SyncOfflineButton";
               this.SyncOfflineButton.Size = new System.Drawing.Size(117, 23);
               this.SyncOfflineButton.TabIndex = 42;
               this.SyncOfflineButton.Text = "Send Offline Dockets";
               this.SyncOfflineButton.UseVisualStyleBackColor = true;
               this.SyncOfflineButton.Click += new System.EventHandler(this.SyncOfflineButton_Click);
               // 
               // RewardsErrorLabel
               // 
               this.RewardsErrorLabel.AutoSize = true;
               this.RewardsErrorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.RewardsErrorLabel.ForeColor = System.Drawing.Color.Red;
               this.RewardsErrorLabel.Location = new System.Drawing.Point(140, 492);
               this.RewardsErrorLabel.Name = "RewardsErrorLabel";
               this.RewardsErrorLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
               this.RewardsErrorLabel.Size = new System.Drawing.Size(12, 15);
               this.RewardsErrorLabel.TabIndex = 41;
               // 
               // SaveRewardsSettingsButton
               // 
               this.SaveRewardsSettingsButton.Location = new System.Drawing.Point(25, 487);
               this.SaveRewardsSettingsButton.Name = "SaveRewardsSettingsButton";
               this.SaveRewardsSettingsButton.Size = new System.Drawing.Size(83, 23);
               this.SaveRewardsSettingsButton.TabIndex = 35;
               this.SaveRewardsSettingsButton.Text = "Save Settings";
               this.SaveRewardsSettingsButton.UseVisualStyleBackColor = true;
               this.SaveRewardsSettingsButton.Click += new System.EventHandler(this.SaveRewardsSettingsButton_Click);
               // 
               // FindDPDBButton
               // 
               this.FindDPDBButton.Location = new System.Drawing.Point(447, 70);
               this.FindDPDBButton.Name = "FindDPDBButton";
               this.FindDPDBButton.Size = new System.Drawing.Size(75, 23);
               this.FindDPDBButton.TabIndex = 34;
               this.FindDPDBButton.Text = "Find DPDB";
               this.FindDPDBButton.UseVisualStyleBackColor = true;
               this.FindDPDBButton.Click += new System.EventHandler(this.FindDPDBButton_Click);
               // 
               // DPLocationLabel
               // 
               this.DPLocationLabel.AutoSize = true;
               this.DPLocationLabel.Location = new System.Drawing.Point(6, 77);
               this.DPLocationLabel.Name = "DPLocationLabel";
               this.DPLocationLabel.Size = new System.Drawing.Size(131, 13);
               this.DPLocationLabel.TabIndex = 31;
               this.DPLocationLabel.Text = "DocketPlace DB Location";
               // 
               // DPDBTextBox
               // 
               this.DPDBTextBox.Location = new System.Drawing.Point(153, 72);
               this.DPDBTextBox.Name = "DPDBTextBox";
               this.DPDBTextBox.Size = new System.Drawing.Size(268, 20);
               this.DPDBTextBox.TabIndex = 32;
               // 
               // SendSalesDataCheckBox
               // 
               this.SendSalesDataCheckBox.AutoSize = true;
               this.SendSalesDataCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
               this.SendSalesDataCheckBox.Location = new System.Drawing.Point(45, 20);
               this.SendSalesDataCheckBox.Name = "SendSalesDataCheckBox";
               this.SendSalesDataCheckBox.Size = new System.Drawing.Size(133, 17);
               this.SendSalesDataCheckBox.TabIndex = 0;
               this.SendSalesDataCheckBox.Text = "Send Customer Data ?";
               this.SendSalesDataCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               this.SendSalesDataCheckBox.UseVisualStyleBackColor = true;
               // 
               // axSerialPortMonitorAx
               // 
               this.axSerialPortMonitorAx.Enabled = true;
               this.axSerialPortMonitorAx.Location = new System.Drawing.Point(593, 617);
               this.axSerialPortMonitorAx.Name = "axSerialPortMonitorAx";
               this.axSerialPortMonitorAx.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSerialPortMonitorAx.OcxState")));
               this.axSerialPortMonitorAx.Size = new System.Drawing.Size(32, 32);
               this.axSerialPortMonitorAx.TabIndex = 40;
               this.axSerialPortMonitorAx.OnOpenClose += new AxspsnifferLib._ISerialPortMonitorAxEvents_OnOpenCloseEventHandler(this.axSerialPortMonitorAx_OnOpenClose);
               this.axSerialPortMonitorAx.OnWrite += new AxspsnifferLib._ISerialPortMonitorAxEvents_OnWriteEventHandler(this.axSerialPortMonitorAx_OnWrite);
               // 
               // FormMain
               // 
               this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
               this.ClientSize = new System.Drawing.Size(1124, 661);
               this.Controls.Add(this.axSerialPortMonitorAx);
               this.Controls.Add(this.MainTabControl);
               this.Controls.Add(this.lbLog);
               this.Controls.Add(this.btnExit);
               this.Controls.Add(this.ClearLogButton);
               this.Name = "FormMain";
               this.Text = "DocketPlace Client";
               this.Closing += new System.ComponentModel.CancelEventHandler(this.FormMain_Closing);
               this.Move += new System.EventHandler(this.FormMain_Move);
               this.MainTabControl.ResumeLayout(false);
               this.PrintTab.ResumeLayout(false);
               this.PrintTab.PerformLayout();
               this.ConnectionTab.ResumeLayout(false);
               this.ConnectionTab.PerformLayout();
               this.CustomersTab.ResumeLayout(false);
               this.CustomersTab.PerformLayout();
               this.POSSoftwareSplitContainer.Panel1.ResumeLayout(false);
               this.POSSoftwareSplitContainer.Panel1.PerformLayout();
               this.POSSoftwareSplitContainer.Panel2.ResumeLayout(false);
               this.POSSoftwareSplitContainer.Panel2.PerformLayout();
               ((System.ComponentModel.ISupportInitialize)(this.POSSoftwareSplitContainer)).EndInit();
               this.POSSoftwareSplitContainer.ResumeLayout(false);
               this.POSSoftwareGroupBox.ResumeLayout(false);
               this.POSSoftwareGroupBox.PerformLayout();
               ((System.ComponentModel.ISupportInitialize)(this.axSerialPortMonitorAx)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		
		[STAThread]
		static void Main() 
		{
            try
            {
                Application.Run(new FormMain());
            }
            catch (Exception ex)
            {
                bool flag = false;
            }
		}

		public void AddLog(string entry, bool writeToFile)
		{
			DateTime dt = DateTime.Now;
			lbLog.AppendText( "[" + dt.ToLongDateString() + " " + dt.ToLongTimeString()  + "] " + entry + "\r\n" );

			if (writeToFile)
			{
				string logentry = dt.ToLongDateString() + " " + dt.ToLongTimeString() + "\t" + entry + "\r\n";

				string path = System.Environment.CurrentDirectory + "\\log.txt";

				if (!File.Exists(path))
				{
					// Create a reference to a file.
					FileInfo fi = new FileInfo(path);
					// Actually create the file.
					FileStream fs = fi.Create();
					// Modify the file as required, and then close the file.
					fs.Close();
				}

				File.AppendAllText(path, logentry);
			}
		}


        /// <summary>
        /// Gets a list of the OPOS printers and loads any saved settings.
        /// </summary>
		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
				
			//Load Connection settings
			StoreIDtextBox.Text = Properties.Settings.Default.store_id;
			PasswordTextBox.Text = Properties.Settings.Default.password;
			



			//Load printer settings.
            RegistryKey rKey = Registry.LocalMachine;
            try
            {
                rKey = rKey.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM");
                string[] values;
                values = rKey.GetValueNames();
                for (int i = 0; i < values.GetLength(0); i++)
                {
                    string comValue = rKey.GetValue(values[i]).ToString();
                    cbPort.Items.Add(comValue);

                    if (comValue == Properties.Settings.Default.COMPort)
                    {
                        cbPort.SelectedItem = comValue;
	
					
                        //Start sniffing as well;


                        SniffSwitch();

                        // Hide the form to the system tray.
                        this.WindowState = FormWindowState.Minimized;

                        this.ShowInTaskbar = false;
                    }
                    else
                    {
                        cbPort.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                posExplorer = new PosExplorer(this);

                DeviceCollection devices = posExplorer.GetDevices(DeviceType.PosPrinter, DeviceCompatibilities.Opos);
                foreach (DeviceInfo deviceInfo in devices)
                {
                    printerList.Add(deviceInfo);
                    OPOSListcomboBox.Items.Add(deviceInfo.ServiceObjectName);
                }

                for (int i = 0; i < OPOSListcomboBox.Items.Count; i++)
                {
                    object o = OPOSListcomboBox.Items[i];
                    string displayText = o.ToString();

                    if (displayText == Properties.Settings.Default.OPOSPrinter)
                    {
                        OPOSListcomboBox.SelectedItem = displayText;
                    }
                    else
                    {
                        OPOSListcomboBox.SelectedIndex = 0;
                    }
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }

               //Default Ad 
                 DefaultAdTextBox.Text = Properties.Settings.Default.DefaultAd;

			//Load Loyalty Settings
			SendSalesDataCheckBox.Checked = Properties.Settings.Default.sendSalesData;
			
			
			DPDBTextBox.Text = Properties.Settings.Default.DPDBLocation;
			syncCustomersCheckBox.Checked = Properties.Settings.Default.syncCustomersOnStartup;

			if (Properties.Settings.Default.POSSoftware == "MYOB")
			{
				MYOBRadioButton.Checked = true;
				MicrosoftRMSRadioButton.Checked = false;
				ToggleSoftwarePanels(true);
                    
				RMDBTextBox.Text = Properties.Settings.Default.RMDBLocation;

				if (!String.IsNullOrEmpty(RMDBTextBox.Text) && !String.IsNullOrEmpty(DPDBTextBox.Text))
				{
					if (syncCustomersCheckBox.Checked)
					{
						SyncCustomers();
					}

					if (SendSalesDataCheckBox.Checked)
					{
						ProcessUnsentDockets();
					}
				}
				else
				{
					RewardsErrorLabel.Text = "Check RetailManager database location";
				}

                    Cat1Cat2RadioButton.Checked = Properties.Settings.Default.CategoriesOnly;
                    DepCat1RadioButton.Checked = !Properties.Settings.Default.CategoriesOnly;
			}
			else if (Properties.Settings.Default.POSSoftware == "Microsoft")
			{
				MYOBRadioButton.Checked = false;
				MicrosoftRMSRadioButton.Checked = true;
				ToggleSoftwarePanels(false);

				MicrosoftLocationTextBox.Text = Properties.Settings.Default.POSServerLocation;
				MicrosoftDBTextBox.Text = Properties.Settings.Default.POSServerDBName;
				MicrosoftUserTextBox.Text = Properties.Settings.Default.POSServerUser;
				MicrosoftPasswordTextBox.Text = Properties.Settings.Default.POSServerPassword;
                    ReceiptIdentifiersTextBox.Text = Properties.Settings.Default.ReceiptIdentifiers;
                    TransactionCaptionTextBox.Text = Properties.Settings.Default.TransactionCaption;


				if (TestSQLConnection(MicrosoftLocationTextBox.Text, MicrosoftDBTextBox.Text ,MicrosoftUserTextBox.Text, MicrosoftPasswordTextBox.Text) && !String.IsNullOrEmpty(DPDBTextBox.Text))
				{
                         if (syncCustomersCheckBox.Checked)
                         {
                              SyncCustomers();
                         }

                         if (SendSalesDataCheckBox.Checked)
                         {
                              ProcessUnsentDockets();
                         }
				}
				else
				{
					RewardsErrorLabel.Text = "Check SQL Server database connection";
				}
			}			
		}

		private bool TestSQLConnection(string location, string DBname, string user, string password)
		{
			string connectionString = MicrosoftRewards.MakeConnectionString(location, DBname, user, password);
			SqlConnection conn = new SqlConnection(connectionString);

			try
			{
				conn.Open();
				return true;
			}
			catch (Exception ex)
			{
				lbLog.AppendText(ex.ToString() + "\r\n");
				return false;
			}
			finally
			{
				conn.Close();
			}
		}

		private void ProcessUnsentDockets()
		{
			try
			{
				List<LocalDocket> unsentDockets = new List<LocalDocket>();

				switch (Properties.Settings.Default.POSSoftware)
				{
					case "MYOB":
						unsentDockets = MYOBRewards.GetUnsentDockets();
						break;
					case "Microsoft":
						if(TestSQLConnection(MicrosoftLocationTextBox.Text, MicrosoftDBTextBox.Text, MicrosoftUserTextBox.Text, MicrosoftPasswordTextBox.Text))
						{
							unsentDockets = MicrosoftRewards.GetUnsentDockets();
						}							
						break;
				}


				AdProvider provider = new AdProvider();
				foreach(LocalDocket item in unsentDockets)
				{
					try
					{
						AdRequest newRequest = HydrateAdRequest();
						newRequest.currentDocket = item;

						AdResponse newResponse = provider.InsertUnsentDocket(newRequest);

						if(newResponse.is_error == false)
						{
							AddLog("Offline Docket #:" + item.local_id.ToString() + "sent to Docketplace successfully",false);
							RewardsHelper.DeleteSentDocket(item.local_id);
						}
						else
						{
							AddLog("Error sending docket:"+item.local_id,true);
						}
						
					}
					catch(System.Net.WebException ex)
					{
						AddLog("No internet",true);
					}
					catch(Exception ex)
					{
						AddLog(ex.ToString(),true);
					}
					finally
					{
						AddLog("Customer sync complete",false);
					}
				}
			}
			catch(Exception ex)
			{
				AddLog(ex.ToString(),true);
			}		
		}


    


		#region Sniffing Events and Functions

		private void MonitorButton_Click(object sender, System.EventArgs e)
		{            
			ClearErrorMessages();	
			SniffSwitch();
		}

        private void SniffSwitch()
        {
            string store_id = StoreIDtextBox.Text;
            string password = PasswordTextBox.Text;
            

            //Check if all fields are filled.
            if ((store_id == "") || (password == ""))
            {
                TestStoreConnectionErrorLabel.Text = "Store ID or password or MAC are empty";
                return;
            }

            //Code to use serial port monitor.
            if (axSerialPortMonitorAx.IsSniffed)
            {
                if (axSerialPortMonitorAx.Stop())
                {
                    cbPort.Enabled = true;
                    MonitoringButton.Text = "Start monitoring";
                }
            }
            else
            {
                string sPort = cbPort.Text;

                if (axSerialPortMonitorAx.Start(sPort))
                {
                    cbPort.Enabled = false;
                    MonitoringButton.Text = "Stop monitoring";
                }
            }           
        }

		private void ClearLogButton_Click(object sender, System.EventArgs e)
		{
			ClearErrorMessages();
			lbLog.Clear();
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			if (axSerialPortMonitorAx.IsSniffed)
			{
				if (axSerialPortMonitorAx.Stop())
				{
				Close();
				}
			}
			else
			{
				Close();
			}            
		}

		private void FormMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (axSerialPortMonitorAx.IsSniffed && !axSerialPortMonitorAx.Stop())
                e.Cancel = true;
		}


        #endregion

        /// <summary>
        /// Method called to request an the ad.
        /// </summary>
		private void printCoupon(bool is_test, string receiptContent, AdRequest new_request)
		{            
            //Get the selected OPOS printer from list.
            var selectedPrinter = from d in printerList
                                  where d.ServiceObjectName == OPOSListcomboBox.SelectedItem.ToString()
                                  select d;
            PosPrinter actualPrinter = (PosPrinter)posExplorer.CreateInstance(selectedPrinter.ElementAt(0));
            string test = actualPrinter.ToString();
            AddLog("Printer found",false);

            try
            {
                if (actualPrinter != null)
                {

				AdProvider provider = new AdProvider();
                    
				actualPrinter.Open();
				
				AddLog("Printer opened",false);

				actualPrinter.Claim(5000);
				actualPrinter.DeviceEnabled = true;
				actualPrinter.RecLetterQuality = true;	

                    AdResponse new_response = new AdResponse();

                    //Call web service
                    if (is_test)
                    {
                         new_response = provider.TestConnection(new_request);
                    }
                    else
                    {
					new_response = provider.RequestAd(new_request);
                    }
                   
                    if (new_response.is_error)
                    {
					AddLog(new_response.status,false);
                         PrintLocalDefaultImage(actualPrinter);
                    }
                    else
                    {
					
					if (new_response.adList.Count() == 0)
					{
						PrintLocalDefaultImage(actualPrinter);
					}
				    else
				    {                        
						int placedad_id = 0;
						
						if (!is_test)
						{
							placedad_id = new_response.placedad_id;						
						}
						
						actualPrinter.PrintNormal(PrinterStation.Receipt, new_response.header);

						foreach (AdImage item in new_response.adList)
						{
							actualPrinter.PrintNormal(PrinterStation.Receipt, "\r\n");
							Bitmap ADimg = Helpers.ConvertPNGDataToBitmap(item.imageData);
                                   string directory = Application.StartupPath;
                                   string fileName = directory + @"/temp.bmp"; 
							ADimg.Save( fileName, ImageFormat.Bmp);

							actualPrinter.PrintBitmap(PrinterStation.Receipt, fileName, PosPrinter.PrinterBitmapAsIs, PosPrinter.PrinterBitmapCenter);
							actualPrinter.PrintNormal(PrinterStation.Receipt, "\r\n");
							actualPrinter.PrintNormal(PrinterStation.Receipt, item.footer);
						}
						
						actualPrinter.PrintNormal(PrinterStation.Receipt, "\r\n\r\nPowered by www.docketplace.com.au");	
						actualPrinter.PrintNormal(PrinterStation.Receipt, "\r\n\r\n\r\n\r\n\r\n\r\n");					   
						actualPrinter.CutPaper(10);

						AddLog("Internet Image printed\t" + placedad_id + "\r\n",false);
                        }
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                //If its a test print  failure display a message otherwise print out the default coupon.
                if (is_test)
                {
                    TestStoreConnectionErrorLabel.Text = "No internet connection";
                }
                else
                {  
				throw ex;
                }
            }
            catch(Exception ex)
            {
                TestStoreConnectionErrorLabel.Text = "Error with printer , check to see if switched on";
                AddLog(ex.ToString(),true);
            }
            finally
            {
                if (actualPrinter.Claimed)
                {
                    actualPrinter.Release();
                }              
                actualPrinter.Close();                
            }
        }
		
		private void PrintLocalDefaultImage(PosPrinter actualPrinter)
		{
               try
               {
                    Image Dummy = Image.FromFile(Properties.Settings.Default.DefaultAd);
                    string directory = Application.StartupPath;
                    string fileName = directory + @"/default.bmp"; 

                    Bitmap ADimg = Helpers.ConvertPNGToBitmap(Dummy);
                   
                    ADimg.Save(fileName, ImageFormat.Bmp);

                    actualPrinter.PrintBitmap(PrinterStation.Receipt, fileName, PosPrinter.PrinterBitmapAsIs, PosPrinter.PrinterBitmapCenter);
               }
               catch (Exception ex)
               {
                    AddLog(ex.ToString(),true);
               }


			actualPrinter.PrintNormal(PrinterStation.Receipt, "\r\n\r\nPowered by www.docketplace.com.au");
			actualPrinter.PrintNormal(PrinterStation.Receipt, "\r\n\r\n\r\n\r\n");
			actualPrinter.CutPaper(10);
			AddLog("Local Image printed",false);
			AddLog("No internet connection",false);
		}

		private AdRequest HydrateAdRequest()
		{
			AdRequest new_request = new AdRequest();
			new_request.store_id = Convert.ToInt32(StoreIDtextBox.Text);            
			new_request.password = PasswordTextBox.Text;


			//Check if all fields are filled.
			if ((StoreIDtextBox.Text == "") || (new_request.password == ""))
			{
				TestStoreConnectionErrorLabel.Text = "Store ID or Password are empty";
				return null;
			}
			else
			{
				return new_request;
			}
		}


		

		#region Button Events
	        
		private void ClearErrorMessages()
		{
			PrinterErrorLabel.Text = "";
			MonitoringErrorlabel.Text = "";
			ConnectionErrorlabel.Text = "";	
			RewardsErrorLabel.Text = "";
			TestStoreConnectionErrorLabel.Text = "";
			TestMicrosoftConnectionErrorLabel.Text = "";					
		}		

		private void SaveConnectionSettingsButton_Click(object sender, EventArgs e)
		   {
			  ClearErrorMessages();
			  string error_message = "";
			  bool is_valid = true;

			  if(StoreIDtextBox.Text == "")
			  {
				 error_message = "Please enter the store ID from the website.";
				 is_valid = false;
			  }
			  else if(PasswordTextBox.Text == "")
			  {
				 error_message = "Please enter the password for the store ID from the website.";
				 is_valid = false;
			  }
	            
			  try
			  {
				 if (is_valid)
				 {
	                    
					Properties.Settings.Default.store_id = StoreIDtextBox.Text;
					Properties.Settings.Default.password = PasswordTextBox.Text;                    
					
	                   
					Properties.Settings.Default.Save();
					ConnectionErrorlabel.Text = "Settings saved successfully";
				 }
				 else
				 {
					ConnectionErrorlabel.Text = error_message;
				 }
			  }
			  catch (Exception ex)
			  {
				 ConnectionErrorlabel.Text = ex.ToString();
			  }
		   }

		private void SavePrinterSettingsButton_Click(object sender, EventArgs e)
			{
				ClearErrorMessages();
				string error_message = "";	
				if(cbPort.Items.Count == 0)
				{
					error_message = "COM ports not detected.";                
				}
				else if(OPOSListcomboBox.Items.Count == 0)
				{
					error_message = "Receipt printer is not detected.";                
				}
                    else if(DefaultAdTextBox.Text == "")
                    {
                         error_message = "Default Ad not selected.";
                    }
                         
				else
				{
					Properties.Settings.Default.COMPort = cbPort.SelectedItem.ToString();
					Properties.Settings.Default.OPOSPrinter = OPOSListcomboBox.SelectedItem.ToString();
                         Properties.Settings.Default.DefaultAd = DefaultAdTextBox.Text;
					error_message = "Settings saved successfully";
					Properties.Settings.Default.Save();
				}
				PrinterErrorLabel.Text = error_message;						
			}

		private void SaveRewardsSettingsButton_Click(object sender, EventArgs e)
		{
			ClearErrorMessages();
			string error_message = "";
			bool is_valid = false;

			if (MYOBRadioButton.Checked)
			{
				if (String.IsNullOrEmpty(RMDBTextBox.Text))
				{
					error_message = "Please enter the location of the Retail Manager database.";
					
				}
				else
				{
					is_valid = true;
					Properties.Settings.Default.POSSoftware = "MYOB";
					Properties.Settings.Default.RMDBLocation = RMDBTextBox.Text;

                         Properties.Settings.Default.CategoriesOnly = Cat1Cat2RadioButton.Checked;
				}
			}
			else if (MicrosoftRMSRadioButton.Checked)
			{
				if(String.IsNullOrEmpty(MicrosoftLocationTextBox.Text))
				{
					error_message = "Please enter the location of the Microsoft RMS server.";				
				}
				else if(String.IsNullOrEmpty(MicrosoftDBTextBox.Text))
				{
					error_message = "Please enter the name of the Microsoft RMS database.";				
				}
				else if (String.IsNullOrEmpty(MicrosoftUserTextBox.Text))
				{
					error_message = "Please enter the user name to connect to the Microsoft RMS database.";				
				}
				else if (String.IsNullOrEmpty(MicrosoftPasswordTextBox.Text))
				{
					error_message = "Please enter the password to connect to the Microsoft RMS database.";				
				}
                    else if (String.IsNullOrEmpty(ReceiptIdentifiersTextBox.Text))
                    {
                         error_message = "Please enter the the identifiers that mark this as a sales receipt or tax invoice.Seperate with commas.";
                    }
                    else if (String.IsNullOrEmpty(TransactionCaptionTextBox.Text))
                    {
                         error_message = "Please enter the caption that identifies the receipt's ID.";
                    }
				else
				{
					is_valid = true;
					Properties.Settings.Default.POSSoftware = "Microsoft";
					Properties.Settings.Default.POSServerLocation = MicrosoftLocationTextBox.Text;
					Properties.Settings.Default.POSServerDBName = MicrosoftDBTextBox.Text;
					Properties.Settings.Default.POSServerUser = MicrosoftUserTextBox.Text;
					Properties.Settings.Default.POSServerPassword = MicrosoftPasswordTextBox.Text;
                         Properties.Settings.Default.ReceiptIdentifiers = ReceiptIdentifiersTextBox.Text;
                         Properties.Settings.Default.TransactionCaption = TransactionCaptionTextBox.Text;
				}
				
			}

			if (DPDBTextBox.Text == "")
			{
				error_message = "Please enter the location of the DocketPlace database.";
				is_valid = false;
			}
			else
			{
				Properties.Settings.Default.DPDBLocation = DPDBTextBox.Text;
			}

			Properties.Settings.Default.sendSalesData = SendSalesDataCheckBox.Checked;
			Properties.Settings.Default.syncCustomersOnStartup = syncCustomersCheckBox.Checked;

			if (is_valid)
			{
				try
				{
					Properties.Settings.Default.Save();
				}
				catch (Exception ex)
				{
					RewardsErrorLabel.Text = ex.ToString();
				}				
				RewardsErrorLabel.Text = "Settings saved successfully";
			}
			else
			{
				RewardsErrorLabel.Text = error_message;
			}
		}

		private void TestConnectionButton_Click(object sender, EventArgs e)
		{
			ClearErrorMessages();

			if (axSerialPortMonitorAx.IsSniffed)
			{
				ConnectionErrorlabel.Text = "Stop monitoring first";
			}
			else
			{
				AdRequest newTestConnectionRequest = HydrateAdRequest();
				printCoupon(true, "", newTestConnectionRequest);    
			}      
		}

		private void DefaultAdPrintButton_Click(object sender, EventArgs e)
		{
			ClearErrorMessages();

			if (axSerialPortMonitorAx.IsSniffed)
			{			
				MonitoringErrorlabel.Text = "Stop monitoring first";
			}
			else
			{
				PrintDefaulltLocalAd();
			}
		}

		private void PrintDefaulltLocalAd()
		{
		   string printer = OPOSListcomboBox.SelectedItem.ToString();

		   var selectedPrinter = from d in printerList
							where d.ServiceObjectName == printer
							select d;
		   PosPrinter actualPrinter = (PosPrinter)posExplorer.CreateInstance(selectedPrinter.ElementAt(0));

		   try
		   {
                  
                    actualPrinter.Open();

                    AddLog("Printer opened", false);

                    actualPrinter.Claim(1000);
                    actualPrinter.DeviceEnabled = true;
                    actualPrinter.RecLetterQuality = true;

                    try
                    {
                         Image Dummy = Image.FromFile(Properties.Settings.Default.DefaultAd);
                         string directory = Application.StartupPath;
                         string fileName = directory + @"/default.bmp";

                         Bitmap ADimg = Helpers.ConvertPNGToBitmap(Dummy);

                         ADimg.Save(fileName, ImageFormat.Bmp);
                         
                      

                         actualPrinter.PrintBitmap(PrinterStation.Receipt, fileName, PosPrinter.PrinterBitmapAsIs, PosPrinter.PrinterBitmapCenter);                       
                    }
                    catch (Exception ex)
                    {
                         AddLog(ex.ToString(), true);
                    }


			   actualPrinter.PrintNormal(PrinterStation.Receipt, "\r\n\r\n\r\n\r\n");
			   actualPrinter.CutPaper(10);
				

			   AddLog("Image printed",false);

		   }
		   catch (Exception ex)
		   {
			   AddLog(ex.ToString(),true);
			   PrinterErrorLabel.Text = "Error with printer , check to see if switched on";
		   }
		   finally
		   {
			   if (actualPrinter.Claimed)
			   {
				   actualPrinter.Release();
			   }
			   actualPrinter.Close();
		   }
		}

		private void ChooseRMDButton_Click(object sender, EventArgs e)
		{
			if (RMOpenFileDialog.ShowDialog() == DialogResult.OK)
			{					
				string fileName = RMOpenFileDialog.FileName;
				RMDBTextBox.Text = fileName;				
			}
		}

		private void FindDPDBButton_Click(object sender, EventArgs e)
		{
			if (DPOpenFileDialog.ShowDialog() == DialogResult.OK)
			{
				string fileName = DPOpenFileDialog.FileName;
				DPDBTextBox.Text = fileName;
			}
		}

          private void FindDefaultAdButton_Click(object sender, EventArgs e)
          {
               if (DefaultAdOpenFileDialog.ShowDialog() == DialogResult.OK)
               {
                    string fileName = DefaultAdOpenFileDialog.FileName;
                    DefaultAdTextBox.Text = fileName;
               }
          }

		private void SyncOfflineButton_Click(object sender, EventArgs e)
		{
			ClearErrorMessages();
			ProcessUnsentDockets();
			AddLog("Offline dockets sent", true);
		}

		private void SyncCustomersButton_Click(object sender, EventArgs e)
		{
			ClearErrorMessages();
			SyncCustomers();				
		}

		private void SyncCustomers()
		{
			try
			{
				//Check if all fields are filled.
				if ((StoreIDtextBox.Text == "") || (PasswordTextBox.Text == ""))
				{
					RewardsErrorLabel.Text = "Store ID or Password are empty";
					return;
				}

				CustomerUpdate newUpdate = new CustomerUpdate();
				newUpdate.store_id = Convert.ToInt32(StoreIDtextBox.Text);
				newUpdate.password = PasswordTextBox.Text;

				switch (Properties.Settings.Default.POSSoftware)
				{
					case "MYOB":
						newUpdate.customerList = MYOBRewards.GetRecentlyModifiedCustomers().ToArray();
						break;
					case "Microsoft":
						if(TestSQLConnection(MicrosoftLocationTextBox.Text, MicrosoftDBTextBox.Text, MicrosoftUserTextBox.Text, MicrosoftPasswordTextBox.Text))
						{
							newUpdate.customerList = MicrosoftRewards.GetRecentlyModifiedCustomers().ToArray();
						}						
						break;
				}				

				if (newUpdate.customerList.Count() == 0)
				{
					lbLog.AppendText("No customers need to be updated");
				}
				else
				{
					AdProvider provider = new AdProvider();

					CustomerUpdateResponse newResponse = provider.UpdateCustomers(newUpdate);

					if (newResponse.is_error)
					{
						AddLog(newResponse.status,true);
						RewardsErrorLabel.Text = newResponse.status;
					}
					else
					{
						RewardsErrorLabel.Text = newResponse.status;
						foreach (string item in newResponse.responses)
						{
							string entry = item;
							lbLog.AppendText(entry + "\r\n");
						}
					}
				}
			}
			catch (Exception ex)
			{
				AddLog(ex.ToString(),true);
				RewardsErrorLabel.Text = "An error has occurred. Please check that you have entered the voucher code correctly.";
			}
		}

          

		#endregion  

		#region MinTray



		   /// <summary>
		   /// Event that control min, max behaviour.
		   /// </summary>
		   /// <param name="sender"></param>
		   /// <param name="e"></param>
		   private void FormMain_Move(object sender, EventArgs e)
		   {
			  //This code causes the form to not show up on the task bar only in the tray.
			  //NOTE there is now a form property that will allow you to keep the application
			  //from ever showing up in the task bar.
			  if (this == null)
			  { //This happen on create.
				 return;
			  }
			  //If we are minimizing the form then hide it so it doesn't show up on the task bar
			  if (this.WindowState == FormWindowState.Minimized)
			  {
				 this.Hide();
	                
			  }
			  else
			  {//any other windows state show it.
				 this.Show();
			  }

		   }

		   /// <summary>
		   /// Restores the window when tray icon is clicked.
		   /// </summary>
		   /// <param name="sender"></param>
		   /// <param name="e"></param>
		   private void TraynotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		   {
			  if (this.WindowState == FormWindowState.Minimized)
			  {
				 this.Show();
				 this.WindowState = FormWindowState.Normal;
			  }

			  // Activate the form.
			  this.Activate();
			  this.Focus();

		   }

		   #endregion  

		#region COM Port Events		

		private void axSerialPortMonitorAx_OnOpenClose(object sender, AxspsnifferLib._ISerialPortMonitorAxEvents_OnOpenCloseEvent e)
			{
			AddLog("====================================",false);
			AddLog("Serial port " + (e.bOpen ? "opened." : "closed"),false);
			AddLog("====================================",false);

			string POSapp = e.szPath;

			if (e.bOpen)
			{
				AddLog("Application: " + e.szPath,false);
				if (POSapp != "" && !POSapp.Contains("DocketPlaceClient"))
				{
					is_realapp = true;
				}
			}
			else
			{
				AddLog("Printing coupon",false);
				if (is_realapp)
				{
					is_realapp = false;
				}
			}  
		}

		private void axSerialPortMonitorAx_OnWrite(object sender, AxspsnifferLib._ISerialPortMonitorAxEvents_OnWriteEvent e)
		{
			ClearErrorMessages();

			string receipt_content = "";
			System.Array buf = e.data as System.Array;

			//Check to see if real receipt data is being sent to the printer. Examples included cash drawer.	
			if ( buf.Length < 100)
			{
				AddLog("Non receipt data",false);
			}
			else			
			{
				receipt_content = System.Text.Encoding.ASCII.GetString(buf as byte[]);
				
				//Stop Sniffing.	
				SniffSwitch();				

				if (SendSalesDataCheckBox.Checked)
				{
					try
					{
						LocalDocket currentDocket = null;

						switch (Properties.Settings.Default.POSSoftware)
						{
							case "MYOB":
								currentDocket = MYOBRewards.GetLastDocket(receipt_content);
								break;
							case "Microsoft":
								if(TestSQLConnection(MicrosoftLocationTextBox.Text, MicrosoftDBTextBox.Text, MicrosoftUserTextBox.Text, MicrosoftPasswordTextBox.Text))
								{
									currentDocket = MicrosoftRewards.GetLastDocket(receipt_content);
								}								
								break;
						}							
						
						if(currentDocket == null)
						{
							PrintDefaulltLocalAd();
						}					
						else
						{
							try
							{
								AdRequest newRewardsRequest = HydrateAdRequest();
								
								currentDocket.receipt_content = Helpers.EncodeToBase64(receipt_content);
								
								newRewardsRequest.currentDocket = currentDocket;
									
								printCoupon(false, receipt_content, newRewardsRequest);
							}
							catch (System.Net.WebException ex)
							{
								RewardsHelper.SaveLastDocket(currentDocket);
								AddLog(ex.Status.ToString(),true);
								PrintDefaulltLocalAd();
							}
						}	
					}
					catch (Exception ex)
					{
						AddLog(ex.ToString(),true);
						PrintDefaulltLocalAd();
					}
				}
				else
				{
					try
					{
						AdRequest newRequest = HydrateAdRequest();
						
						
						LocalDocket nonRewardsDocket = new LocalDocket();
						nonRewardsDocket.creation_datetime = DateTime.Now;
						
						nonRewardsDocket.receipt_content = Helpers.EncodeToBase64(receipt_content);
						
						newRequest.currentDocket = nonRewardsDocket;					
						
					
				
						printCoupon(false, receipt_content, newRequest);
					}				
					catch (System.Net.WebException ex)
					{
						PrintDefaulltLocalAd();
					}						
				}
				//Start Sniffing again.
				SniffSwitch();
				AddLog(receipt_content,false);				
			}
		}

	
		#endregion

		#region POS Software Picker

		private void MYOBRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (MYOBRadioButton.Checked)
			{
				ToggleSoftwarePanels(true);
			}
		}

		private void MicrosoftRMSRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (MicrosoftRMSRadioButton.Checked)
			{
				ToggleSoftwarePanels(false);
			}
		}

		private void ToggleSoftwarePanels(bool MYOBPicked)
		{
			POSSoftwareSplitContainer.Panel1Collapsed = !MYOBPicked;
			POSSoftwareSplitContainer.Panel2Collapsed = MYOBPicked;
		}

		private void MicrosoftTestConnectionButton_Click(object sender, EventArgs e)
		{
			ClearErrorMessages();
			if (TestSQLConnection(MicrosoftLocationTextBox.Text, MicrosoftDBTextBox.Text, MicrosoftUserTextBox.Text, MicrosoftPasswordTextBox.Text))
			{
				TestMicrosoftConnectionErrorLabel.Text = "Connection is solid";
			}
			else
			{
				TestMicrosoftConnectionErrorLabel.Text = "Error connecting to SQL Server.";
			}
		}

		

		

		#endregion

          private void Cat1Cat2RadioButton_CheckedChanged(object sender, EventArgs e)
          {
               if (Cat1Cat2RadioButton.Checked)
               {
                    DepCat1RadioButton.Checked = false;
               }
          }

          private void DepCat1RadioButton_CheckedChanged(object sender, EventArgs e)
          {
               if (DepCat1RadioButton.Checked)
               {
                    Cat1Cat2RadioButton.Checked = false;
               }
          }

       

        

	}	
}		