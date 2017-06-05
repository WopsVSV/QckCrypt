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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dragList = new QckCrypt.App.MetroDragList();
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
            this.dragList.AllowDrop = true;
            this.dragList.CheckedIcon = ((System.Drawing.Bitmap)(resources.GetObject("dragList.CheckedIcon")));
            this.dragList.DocumentIcon = ((System.Drawing.Bitmap)(resources.GetObject("dragList.DocumentIcon")));
            this.dragList.FolderIcon = ((System.Drawing.Bitmap)(resources.GetObject("dragList.FolderIcon")));
            this.dragList.Location = new System.Drawing.Point(23, 97);
            this.dragList.Name = "dragList";
            this.dragList.Size = new System.Drawing.Size(531, 374);
            this.dragList.TabIndex = 1;
            this.dragList.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.dragList.UseSelectable = true;
            this.dragList.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragList_DragDrop);
            this.dragList.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragList_DragEnter);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 494);
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
    }
}

