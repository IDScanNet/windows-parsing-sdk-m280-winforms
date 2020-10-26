namespace WinformM280
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkTiltAdj = new System.Windows.Forms.CheckBox();
            this.picESEEK = new System.Windows.Forms.PictureBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.timCheckStatus = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labSysBusyImg = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labSysReadyImg = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labUSBConImg = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labBusyImg = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labButtonImg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labReadyImg = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtIDState = new System.Windows.Forms.TextBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.txtMname = new System.Windows.Forms.TextBox();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.txtAdd1 = new System.Windows.Forms.TextBox();
            this.txtAdd2 = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblFname = new System.Windows.Forms.Label();
            this.lblMname = new System.Windows.Forms.Label();
            this.lblLname = new System.Windows.Forms.Label();
            this.lblSuffix = new System.Windows.Forms.Label();
            this.lblAdd1 = new System.Windows.Forms.Label();
            this.lblAdd2 = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picESEEK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkTiltAdj);
            this.groupBox3.Location = new System.Drawing.Point(493, 267);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 60);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Option";
            // 
            // chkTiltAdj
            // 
            this.chkTiltAdj.AutoSize = true;
            this.chkTiltAdj.Location = new System.Drawing.Point(30, 19);
            this.chkTiltAdj.Name = "chkTiltAdj";
            this.chkTiltAdj.Size = new System.Drawing.Size(120, 17);
            this.chkTiltAdj.TabIndex = 0;
            this.chkTiltAdj.Text = "Auto Tilt Adjustment";
            this.chkTiltAdj.UseVisualStyleBackColor = true;
            // 
            // picESEEK
            // 
            this.picESEEK.Image = global::WinformM280.Properties.Resources.e_seek_top_logo;
            this.picESEEK.InitialImage = null;
            this.picESEEK.Location = new System.Drawing.Point(493, 361);
            this.picESEEK.Name = "picESEEK";
            this.picESEEK.Size = new System.Drawing.Size(193, 74);
            this.picESEEK.TabIndex = 10;
            this.picESEEK.TabStop = false;
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.Black;
            this.picImage.Location = new System.Drawing.Point(12, 12);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(475, 270);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 6;
            this.picImage.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labSysBusyImg);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.labSysReadyImg);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.labUSBConImg);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(493, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 113);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System Status";
            // 
            // labSysBusyImg
            // 
            this.labSysBusyImg.AutoSize = true;
            this.labSysBusyImg.Image = global::WinformM280.Properties.Resources.gray3;
            this.labSysBusyImg.Location = new System.Drawing.Point(149, 80);
            this.labSysBusyImg.Name = "labSysBusyImg";
            this.labSysBusyImg.Size = new System.Drawing.Size(22, 13);
            this.labSysBusyImg.TabIndex = 5;
            this.labSysBusyImg.Text = "     ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "System Busy";
            // 
            // labSysReadyImg
            // 
            this.labSysReadyImg.AutoSize = true;
            this.labSysReadyImg.Image = global::WinformM280.Properties.Resources.gray3;
            this.labSysReadyImg.Location = new System.Drawing.Point(149, 55);
            this.labSysReadyImg.Name = "labSysReadyImg";
            this.labSysReadyImg.Size = new System.Drawing.Size(22, 13);
            this.labSysReadyImg.TabIndex = 3;
            this.labSysReadyImg.Text = "     ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "System Ready";
            // 
            // labUSBConImg
            // 
            this.labUSBConImg.AutoSize = true;
            this.labUSBConImg.Image = global::WinformM280.Properties.Resources.gray3;
            this.labUSBConImg.Location = new System.Drawing.Point(149, 29);
            this.labUSBConImg.Name = "labUSBConImg";
            this.labUSBConImg.Size = new System.Drawing.Size(22, 13);
            this.labUSBConImg.TabIndex = 1;
            this.labUSBConImg.Text = "     ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "USB Connect";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ready LED";
            // 
            // labBusyImg
            // 
            this.labBusyImg.AutoSize = true;
            this.labBusyImg.Image = global::WinformM280.Properties.Resources.gray3;
            this.labBusyImg.Location = new System.Drawing.Point(149, 55);
            this.labBusyImg.Name = "labBusyImg";
            this.labBusyImg.Size = new System.Drawing.Size(22, 13);
            this.labBusyImg.TabIndex = 3;
            this.labBusyImg.Text = "     ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Busy LED";
            // 
            // labButtonImg
            // 
            this.labButtonImg.AutoSize = true;
            this.labButtonImg.Image = global::WinformM280.Properties.Resources.gray3;
            this.labButtonImg.Location = new System.Drawing.Point(149, 84);
            this.labButtonImg.Name = "labButtonImg";
            this.labButtonImg.Size = new System.Drawing.Size(22, 13);
            this.labButtonImg.TabIndex = 5;
            this.labButtonImg.Text = "     ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Capture Button";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labButtonImg);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labBusyImg);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labReadyImg);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(493, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 120);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Indicator";
            // 
            // labReadyImg
            // 
            this.labReadyImg.AutoSize = true;
            this.labReadyImg.Image = global::WinformM280.Properties.Resources.gray3;
            this.labReadyImg.Location = new System.Drawing.Point(149, 29);
            this.labReadyImg.Name = "labReadyImg";
            this.labReadyImg.Size = new System.Drawing.Size(22, 13);
            this.labReadyImg.TabIndex = 1;
            this.labReadyImg.Text = "     ";
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(493, 446);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(193, 69);
            this.btnCapture.TabIndex = 7;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(127, 288);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(250, 20);
            this.txtType.TabIndex = 0;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(127, 314);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(195, 20);
            this.txtNumber.TabIndex = 1;
            // 
            // txtIDState
            // 
            this.txtIDState.Location = new System.Drawing.Point(328, 314);
            this.txtIDState.Name = "txtIDState";
            this.txtIDState.Size = new System.Drawing.Size(49, 20);
            this.txtIDState.TabIndex = 2;
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(127, 340);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(250, 20);
            this.txtFname.TabIndex = 3;
            // 
            // txtMname
            // 
            this.txtMname.Location = new System.Drawing.Point(127, 366);
            this.txtMname.Name = "txtMname";
            this.txtMname.Size = new System.Drawing.Size(250, 20);
            this.txtMname.TabIndex = 4;
            // 
            // txtLname
            // 
            this.txtLname.Location = new System.Drawing.Point(127, 392);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(250, 20);
            this.txtLname.TabIndex = 5;
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(127, 418);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(250, 20);
            this.txtSuffix.TabIndex = 6;
            // 
            // txtAdd1
            // 
            this.txtAdd1.Location = new System.Drawing.Point(127, 443);
            this.txtAdd1.Name = "txtAdd1";
            this.txtAdd1.Size = new System.Drawing.Size(250, 20);
            this.txtAdd1.TabIndex = 7;
            // 
            // txtAdd2
            // 
            this.txtAdd2.Location = new System.Drawing.Point(127, 469);
            this.txtAdd2.Name = "txtAdd2";
            this.txtAdd2.Size = new System.Drawing.Size(250, 20);
            this.txtAdd2.TabIndex = 8;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(127, 495);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(126, 20);
            this.txtCity.TabIndex = 9;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(259, 495);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(34, 20);
            this.txtState.TabIndex = 10;
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(299, 495);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(78, 20);
            this.txtZip.TabIndex = 11;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(12, 288);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(109, 20);
            this.lblType.TabIndex = 24;
            this.lblType.Text = "ID Type";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNumber
            // 
            this.lblNumber.Location = new System.Drawing.Point(12, 313);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(109, 20);
            this.lblNumber.TabIndex = 25;
            this.lblNumber.Text = "ID Number - State";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFname
            // 
            this.lblFname.Location = new System.Drawing.Point(12, 340);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(109, 20);
            this.lblFname.TabIndex = 26;
            this.lblFname.Text = "First Name";
            this.lblFname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMname
            // 
            this.lblMname.Location = new System.Drawing.Point(12, 365);
            this.lblMname.Name = "lblMname";
            this.lblMname.Size = new System.Drawing.Size(109, 20);
            this.lblMname.TabIndex = 27;
            this.lblMname.Text = "Middle Name";
            this.lblMname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLname
            // 
            this.lblLname.Location = new System.Drawing.Point(12, 392);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(109, 20);
            this.lblLname.TabIndex = 28;
            this.lblLname.Text = "Last Name";
            this.lblLname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSuffix
            // 
            this.lblSuffix.Location = new System.Drawing.Point(12, 418);
            this.lblSuffix.Name = "lblSuffix";
            this.lblSuffix.Size = new System.Drawing.Size(109, 20);
            this.lblSuffix.TabIndex = 29;
            this.lblSuffix.Text = "Suffix";
            this.lblSuffix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAdd1
            // 
            this.lblAdd1.Location = new System.Drawing.Point(12, 443);
            this.lblAdd1.Name = "lblAdd1";
            this.lblAdd1.Size = new System.Drawing.Size(109, 20);
            this.lblAdd1.TabIndex = 30;
            this.lblAdd1.Text = "Address 1";
            this.lblAdd1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAdd2
            // 
            this.lblAdd2.Location = new System.Drawing.Point(12, 469);
            this.lblAdd2.Name = "lblAdd2";
            this.lblAdd2.Size = new System.Drawing.Size(109, 20);
            this.lblAdd2.TabIndex = 31;
            this.lblAdd2.Text = "Address 2";
            this.lblAdd2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCity
            // 
            this.lblCity.Location = new System.Drawing.Point(12, 494);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(109, 20);
            this.lblCity.TabIndex = 32;
            this.lblCity.Text = "City - State - Zip";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(493, 334);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(611, 332);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 34;
            this.btnNew.Text = "New Form";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 523);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblAdd2);
            this.Controls.Add(this.lblAdd1);
            this.Controls.Add(this.lblSuffix);
            this.Controls.Add(this.lblLname);
            this.Controls.Add(this.lblMname);
            this.Controls.Add(this.lblFname);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtAdd2);
            this.Controls.Add(this.txtAdd1);
            this.Controls.Add(this.txtSuffix);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(this.txtMname);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.txtIDState);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.picESEEK);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCapture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M280 Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picESEEK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkTiltAdj;
        private System.Windows.Forms.PictureBox picESEEK;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Timer timCheckStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labSysBusyImg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labSysReadyImg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labUSBConImg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labBusyImg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labButtonImg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labReadyImg;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtIDState;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.TextBox txtMname;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.TextBox txtAdd1;
        private System.Windows.Forms.TextBox txtAdd2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.Label lblMname;
        private System.Windows.Forms.Label lblLname;
        private System.Windows.Forms.Label lblSuffix;
        private System.Windows.Forms.Label lblAdd1;
        private System.Windows.Forms.Label lblAdd2;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNew;
    }
}

