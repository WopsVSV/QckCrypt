using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            dragList.AddItem(new ListItem("PNG", "C:/Pictures/test.png", ListItemType.File, CryptStatus.Unencrypted));
            dragList.AddItem(new ListItem("DIR", "C:/RuneScape/CheatsthisWWWWWlikelywillneverbeinthisapplikewhothefucknamehisdirslikethiasdfdasfass", ListItemType.Folder, CryptStatus.Unencrypted));
            dragList.AddItem(new ListItem("DIR", "C:/RuneScape/Cheats", ListItemType.Folder, CryptStatus.Unencrypted));
            dragList.AddItem(new ListItem("DIR", "C:/RuneScape/CheatsthisWWWWWlikelywillneverbeinthisapplikewhothefucknamehisdirslikethiasdfdasfass", ListItemType.Folder, CryptStatus.Unencrypted));
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            dragList.ItemAt(1).Status = CryptStatus.Encrypted;

        }
    }
}
