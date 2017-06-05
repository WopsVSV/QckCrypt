using MetroFramework.Forms;
using QckCrypt.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QckCrypt.App
{
    public partial class frmMain : MetroForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dragList.DocumentIcon = Properties.Resources.DocumentIcon;
            dragList.FolderIcon = Properties.Resources.FolderIcon;
            dragList.CheckedIcon = Properties.Resources.CheckedIcon; 
        }

        private void dragList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void dragList_DragDrop(object sender, DragEventArgs e)
        {
            List<string> filepaths = new List<string>();
            foreach (var s in (string[])e.Data.GetData(DataFormats.FileDrop, false))
            {
                if (Directory.Exists(s))
                {
                    dragList.AddItem(new ListItem("DIR", s, ListItemType.Folder, CryptStatus.Unencrypted));
                }
                else if (File.Exists(s))
                {
                    dragList.AddItem(new ListItem(GetExtension(s), s, ListItemType.File, CryptStatus.Unencrypted));
                }
                else MessageBox.Show("???");
            }     
        }

        private string GetExtension(string fileName)
        {
            string extension;

            extension = fileName.Split('.')[fileName.Split('.').Length - 1].ToUpper();

            if (extension.Length > 3)
                extension = extension.Substring(0, 3) + "..";

            return extension;
        }
    }
}
