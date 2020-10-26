#region .NET Base Class Namespace Imports
using System;
using System.Windows.Forms;
#endregion

#region Compiled Technologies Assemblies
using CompiledTechnologies.Events;
#endregion

#region CTI Assemblies
using CompiledTechnologies.Devices;
using CompiledTechnologies.M280;
#endregion

namespace WinformM280
{
    public partial class Form1 : Form
    {
        #region ******************************** Public Initialize ****************************************
        public Form1()
        {
            InitializeComponent();
            InitializeEvents();
        }
        #endregion

        #region ******************************* Private Form Events ***************************************
        private void Form1_Load(object sender, EventArgs e)
        {
            Static.m280.Start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Static.m280.Stop();
        }
        #endregion

        #region ********************************** Private Events *****************************************
        private void Device_Initialized(object sender, EventArgs e)
        {
            UpdateTools();
        }
        private void Device_Attached(object sender, EventArgs e)
        {
            MessageBox.Show(@"Device Attached");
        }
        private void Device_Detached(object sender, EventArgs e)
        {
            MessageBox.Show(@"Device Detached");
        }
        public void Check_State(object sender, EventArgs e)
        {
            UpdateTools();
        }
        private void Image_Captured(object sender, CapturedEventArgs e)
        {
            picImage.Image = e.Bitmap;
        }
        private void Reader_ReceiveData(object sender, DataReceivedArgs e)
        {
            txtType.Text = e.DL.Record.DocumentType;
            txtNumber.Text = e.DL.Record.LicenseNumber;
            txtIDState.Text = e.DL.Record.JurisdictionCode;
            txtFname.Text = e.DL.Record.FirstName;
            txtMname.Text = e.DL.Record.MiddleName;
            txtLname.Text = e.DL.Record.LastName;
            txtSuffix.Text = e.DL.Record.NameSuffix;
            txtAdd1.Text = e.DL.Record.Address1;
            txtAdd2.Text = e.DL.Record.Address2;
            txtCity.Text = e.DL.Record.City;
            txtState.Text = e.DL.Record.JurisdictionCode;
            txtZip.Text = e.DL.Record.PostalCode;
        }
        private void InitializeEvents()
        {
            Static.m280.Captured += Image_Captured;
            Static.m280.Initialized += Device_Initialized;
            Static.m280.ReceiveData += Reader_ReceiveData;
            Static.m280.DeviceAttached += Device_Attached;
            Static.m280.DeviceDetached += Device_Detached;
            Static.m280.CheckState += Check_State;
        }
        #endregion

        #region ******************************* Private Button Events *************************************
        private void btnCapture_Click(object sender, EventArgs e)
        {
            labButtonImg.Image = global::WinformM280.Properties.Resources.green3;
            Static.m280.Deskew = chkTiltAdj.Checked;
            Static.m280.CaptureImage();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Static.m280.Suspend();
            Form1 form1 = new Form1();
            form1.ShowDialog(this);
            form1.Dispose();
            Static.m280.Resume();
            InitializeEvents();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            picImage.Image = null;
            txtType.Text = string.Empty;
            txtNumber.Text = string.Empty;
            txtIDState.Text = string.Empty;
            txtFname.Text = string.Empty;
            txtMname.Text = string.Empty;
            txtLname.Text = string.Empty;
            txtSuffix.Text = string.Empty;
            txtAdd1.Text = string.Empty;
            txtAdd2.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtZip.Text = string.Empty;
        }
        #endregion

        #region ********************************* Private Methods *****************************************
        private void UpdateTools()
        {
            labUSBConImg.Image = Static.m280.ScannerConnected ? global::WinformM280.Properties.Resources.green3 : global::WinformM280.Properties.Resources.gray3;
            labSysReadyImg.Image = Static.m280.SystemReady ? global::WinformM280.Properties.Resources.green3 : global::WinformM280.Properties.Resources.gray3;
            labSysBusyImg.Image = Static.m280.SystemBusy ? global::WinformM280.Properties.Resources.red3 : global::WinformM280.Properties.Resources.gray3;
            labReadyImg.Image = Static.m280.DeviceReady ? global::WinformM280.Properties.Resources.green3 : global::WinformM280.Properties.Resources.gray3;
            labBusyImg.Image = Static.m280.DeviceBusy ? global::WinformM280.Properties.Resources.red3 : global::WinformM280.Properties.Resources.gray3;
            labButtonImg.Image = global::WinformM280.Properties.Resources.gray3;
        }
        #endregion
    }
}
