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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dragList = new QckCrypt.App.MetroDragList();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(198, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Drag and drop any file or folder";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // dragList
            // 
            this.dragList.Location = new System.Drawing.Point(23, 103);
            this.dragList.Name = "dragList";
            this.dragList.Size = new System.Drawing.Size(531, 368);
            this.dragList.TabIndex = 1;
            this.dragList.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.dragList.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(327, 40);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(213, 28);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "This happens when it gets encrypted";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 494);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.dragList);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frmMain";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "Quick Crypt";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroDragList dragList;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}

