namespace QckCrypt.App
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblHowto = new MetroFramework.Controls.MetroLabel();
            this.dragList = new QckCrypt.Library.MetroDragList();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.txtEncryptedFileLength = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.chkEncryptFileNames = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.pbUpdateStatus = new MetroFramework.Controls.MetroPanel();
            this.btnUpdateKey = new MetroFramework.Controls.MetroButton();
            this.chkShowKey = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtKey = new MetroFramework.Controls.MetroTextBox();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHowto
            // 
            this.lblHowto.AutoSize = true;
            this.lblHowto.Location = new System.Drawing.Point(165, 169);
            this.lblHowto.Name = "lblHowto";
            this.lblHowto.Size = new System.Drawing.Size(198, 19);
            this.lblHowto.TabIndex = 0;
            this.lblHowto.Text = "Drag and drop any file or folder";
            this.lblHowto.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // dragList
            // 
            this.dragList.AllowDrop = true;
            this.dragList.CheckedIcon = ((System.Drawing.Bitmap)(resources.GetObject("dragList.CheckedIcon")));
            this.dragList.DocumentIcon = ((System.Drawing.Bitmap)(resources.GetObject("dragList.DocumentIcon")));
            this.dragList.ErrorIcon = ((System.Drawing.Bitmap)(resources.GetObject("dragList.ErrorIcon")));
            this.dragList.FolderIcon = ((System.Drawing.Bitmap)(resources.GetObject("dragList.FolderIcon")));
            this.dragList.Items = ((System.Collections.Generic.List<QckCrypt.Library.ListItem>)(resources.GetObject("dragList.Items")));
            this.dragList.Location = new System.Drawing.Point(0, 0);
            this.dragList.Name = "dragList";
            this.dragList.Size = new System.Drawing.Size(531, 384);
            this.dragList.TabIndex = 5;
            this.dragList.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.dragList.UseSelectable = true;
            this.dragList.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragList_DragDrop);
            this.dragList.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragList_DragEnter);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Location = new System.Drawing.Point(19, 55);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(540, 426);
            this.metroTabControl1.TabIndex = 3;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.lblHowto);
            this.metroTabPage1.Controls.Add(this.dragList);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(532, 384);
            this.metroTabPage1.TabIndex = 2;
            this.metroTabPage1.Text = "Encrypt/Decrypt";
            this.metroTabPage1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroCheckBox1);
            this.metroTabPage2.Controls.Add(this.metroLabel4);
            this.metroTabPage2.Controls.Add(this.txtEncryptedFileLength);
            this.metroTabPage2.Controls.Add(this.metroLabel2);
            this.metroTabPage2.Controls.Add(this.chkEncryptFileNames);
            this.metroTabPage2.Controls.Add(this.metroLabel3);
            this.metroTabPage2.Controls.Add(this.pbUpdateStatus);
            this.metroTabPage2.Controls.Add(this.btnUpdateKey);
            this.metroTabPage2.Controls.Add(this.chkShowKey);
            this.metroTabPage2.Controls.Add(this.metroLabel1);
            this.metroTabPage2.Controls.Add(this.txtKey);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(532, 384);
            this.metroTabPage2.TabIndex = 3;
            this.metroTabPage2.Text = "Settings";
            this.metroTabPage2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // txtEncryptedFileLength
            // 
            // 
            // 
            // 
            this.txtEncryptedFileLength.CustomButton.Image = null;
            this.txtEncryptedFileLength.CustomButton.Location = new System.Drawing.Point(22, 1);
            this.txtEncryptedFileLength.CustomButton.Name = "";
            this.txtEncryptedFileLength.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtEncryptedFileLength.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEncryptedFileLength.CustomButton.TabIndex = 1;
            this.txtEncryptedFileLength.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEncryptedFileLength.CustomButton.UseSelectable = true;
            this.txtEncryptedFileLength.CustomButton.Visible = false;
            this.txtEncryptedFileLength.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtEncryptedFileLength.Lines = new string[] {
        "8"};
            this.txtEncryptedFileLength.Location = new System.Drawing.Point(73, 112);
            this.txtEncryptedFileLength.MaxLength = 2;
            this.txtEncryptedFileLength.Name = "txtEncryptedFileLength";
            this.txtEncryptedFileLength.PasswordChar = '\0';
            this.txtEncryptedFileLength.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEncryptedFileLength.SelectedText = "";
            this.txtEncryptedFileLength.SelectionLength = 0;
            this.txtEncryptedFileLength.SelectionStart = 0;
            this.txtEncryptedFileLength.ShortcutsEnabled = true;
            this.txtEncryptedFileLength.Size = new System.Drawing.Size(42, 21);
            this.txtEncryptedFileLength.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEncryptedFileLength.TabIndex = 13;
            this.txtEncryptedFileLength.Text = "8";
            this.txtEncryptedFileLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEncryptedFileLength.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtEncryptedFileLength.UseSelectable = true;
            this.txtEncryptedFileLength.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEncryptedFileLength.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(16, 113);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(51, 19);
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "Length:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // chkEncryptFileNames
            // 
            this.chkEncryptFileNames.AutoSize = true;
            this.chkEncryptFileNames.Checked = true;
            this.chkEncryptFileNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEncryptFileNames.Location = new System.Drawing.Point(237, 89);
            this.chkEncryptFileNames.Name = "chkEncryptFileNames";
            this.chkEncryptFileNames.Size = new System.Drawing.Size(26, 15);
            this.chkEncryptFileNames.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkEncryptFileNames.TabIndex = 11;
            this.chkEncryptFileNames.Text = " ";
            this.chkEncryptFileNames.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkEncryptFileNames.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(2, 86);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(232, 19);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "•  Encrypt file names (recommended):";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // pbUpdateStatus
            // 
            this.pbUpdateStatus.BackColor = System.Drawing.Color.Transparent;
            this.pbUpdateStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbUpdateStatus.HorizontalScrollbarBarColor = true;
            this.pbUpdateStatus.HorizontalScrollbarHighlightOnWheel = false;
            this.pbUpdateStatus.HorizontalScrollbarSize = 10;
            this.pbUpdateStatus.Location = new System.Drawing.Point(114, 194);
            this.pbUpdateStatus.Name = "pbUpdateStatus";
            this.pbUpdateStatus.Size = new System.Drawing.Size(24, 24);
            this.pbUpdateStatus.TabIndex = 8;
            this.pbUpdateStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.pbUpdateStatus.VerticalScrollbarBarColor = true;
            this.pbUpdateStatus.VerticalScrollbarHighlightOnWheel = false;
            this.pbUpdateStatus.VerticalScrollbarSize = 10;
            this.pbUpdateStatus.Visible = false;
            // 
            // btnUpdateKey
            // 
            this.btnUpdateKey.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnUpdateKey.Location = new System.Drawing.Point(20, 195);
            this.btnUpdateKey.Name = "btnUpdateKey";
            this.btnUpdateKey.Size = new System.Drawing.Size(88, 22);
            this.btnUpdateKey.TabIndex = 6;
            this.btnUpdateKey.Text = "Update";
            this.btnUpdateKey.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnUpdateKey.UseSelectable = true;
            this.btnUpdateKey.Click += new System.EventHandler(this.btnUpdateKey_Click);
            // 
            // chkShowKey
            // 
            this.chkShowKey.AutoSize = true;
            this.chkShowKey.Checked = true;
            this.chkShowKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowKey.Location = new System.Drawing.Point(20, 43);
            this.chkShowKey.Name = "chkShowKey";
            this.chkShowKey.Size = new System.Drawing.Size(73, 15);
            this.chkShowKey.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkShowKey.TabIndex = 5;
            this.chkShowKey.Text = "Show key";
            this.chkShowKey.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkShowKey.UseSelectable = true;
            this.chkShowKey.CheckedChanged += new System.EventHandler(this.chkShowKey_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 21);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(179, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "•  Encryption/decryption key:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtKey
            // 
            // 
            // 
            // 
            this.txtKey.CustomButton.Image = null;
            this.txtKey.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.txtKey.CustomButton.Name = "";
            this.txtKey.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtKey.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtKey.CustomButton.TabIndex = 1;
            this.txtKey.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtKey.CustomButton.UseSelectable = true;
            this.txtKey.CustomButton.Visible = false;
            this.txtKey.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtKey.Lines = new string[] {
        "SECUREKEY"};
            this.txtKey.Location = new System.Drawing.Point(186, 21);
            this.txtKey.MaxLength = 20;
            this.txtKey.Name = "txtKey";
            this.txtKey.PasswordChar = '\0';
            this.txtKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtKey.SelectedText = "";
            this.txtKey.SelectionLength = 0;
            this.txtKey.SelectionStart = 0;
            this.txtKey.ShortcutsEnabled = true;
            this.txtKey.Size = new System.Drawing.Size(146, 21);
            this.txtKey.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtKey.TabIndex = 4;
            this.txtKey.Text = "SECUREKEY";
            this.txtKey.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtKey.UseSelectable = true;
            this.txtKey.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtKey.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(532, 384);
            this.metroTabPage3.TabIndex = 4;
            this.metroTabPage3.Text = "Storage";
            this.metroTabPage3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Checked = true;
            this.metroCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox1.Location = new System.Drawing.Point(212, 162);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(26, 15);
            this.metroCheckBox1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroCheckBox1.TabIndex = 15;
            this.metroCheckBox1.Text = " ";
            this.metroCheckBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox1.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(2, 159);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(208, 19);
            this.metroLabel4.TabIndex = 14;
            this.metroLabel4.Text = "•  Send encrypted files to storage:";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 498);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "frmMain";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "Quick Crypt";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblHowto;
        private Library.MetroDragList dragList;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtKey;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroCheckBox chkShowKey;
        private MetroFramework.Controls.MetroPanel pbUpdateStatus;
        private MetroFramework.Controls.MetroButton btnUpdateKey;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroCheckBox chkEncryptFileNames;
        private MetroFramework.Controls.MetroTextBox txtEncryptedFileLength;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
    }
}

