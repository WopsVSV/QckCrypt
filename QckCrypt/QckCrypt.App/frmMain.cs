using MetroFramework.Forms;
using QckCrypt.Library;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QckCrypt.App
{
    /// <summary>
    /// Main UI form
    /// </summary>
    public partial class frmMain : MetroForm
    {
        // Crypter object used for crypting (lol)
        private Crypter crypter;

        // Constants
        private const string DEFAULT_KEY = "SECUREKEY";
        
        /// <summary>
        /// Initializes all the components
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set the drag list icons
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            dragList.DocumentIcon = Properties.Resources.DocumentIcon;
            dragList.FolderIcon = Properties.Resources.FolderIcon;
            dragList.CheckedIcon = Properties.Resources.CheckedIcon;
            dragList.ErrorIcon = Properties.Resources.ErrorIcon;

            pbUpdateStatus.BackgroundImage = Properties.Resources.CheckedIcon;

            // Creates a new crypter using the default key
            crypter = new Crypter(DEFAULT_KEY);
        }

        /// <summary>
        /// Checks for drag&drop data
        /// </summary>
        private void dragList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Handles dragged&dropped data
        /// </summary>
        private void dragList_DragDrop(object sender, DragEventArgs e)
        {
            // Iterates through every item dropped
            foreach (var item in (string[])e.Data.GetData(DataFormats.FileDrop, false))
            {
                if (Directory.Exists(item))
                {
                    HandleItem(item, ListItemType.Folder);
                }
                else if (File.Exists(item))
                {
                    HandleItem(item, ListItemType.File);
                }
                else MessageBox.Show("???");
            }
        }

        /// <summary>
        /// Modifies the password char of the key textbox based on the checkbox value
        /// </summary>
        private void chkShowKey_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowKey.Checked)
                txtKey.PasswordChar = '\0';
            else
                txtKey.PasswordChar = '*';
        }

        /// <summary>
        /// Updates the settings to the crypter object
        /// </summary>
        private void btnUpdateKey_Click(object sender, EventArgs e)
        {
            string result = CheckSettingsValidity();
            if(!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result);
                return;
            }

            crypter.EncryptedNameLength = int.Parse(txtEncryptedFileLength.Text);
            crypter.Password = txtKey.Text;
            
            new Thread(ShowUpdateSuccess).Start();
        }

        /// <summary>
        /// Attempts encrypting/decrypting an item added to the list
        /// </summary>
        private void HandleItem(string item, ListItemType type)
        {
            // If it's the first item, remove the tip
            if (dragList.Items.Count != 0 && lblHowto.Visible)
                lblHowto.Visible = false;

            if (type == ListItemType.File)
                EncryptFile(item);
            else if(type == ListItemType.Folder)
                EncryptFolder(item);
        }

        /// <summary>
        /// Encrypts the folder by crypting every file separately
        /// </summary>
        private async void EncryptFolder(string item)
        {
            // Create and add the item to the list
            var listItem = new ListItem("DIR", item, ListItemType.Folder, CryptStatus.Unencrypted);
            dragList.AddItem(listItem);

            // Get all files in the folder
            var allFiles = Directory.GetFiles(item, "*", SearchOption.AllDirectories);

            CryptStatus status;
            CryptResult result;
            CryptResult finalResult = CryptResult.Success;

            foreach (var file in allFiles)
            {
                status = Utility.GetCryptStatus(file);
                result = await Crypt(file, status);

                // If the result is not successful, break
                if(result != CryptResult.Success) {
                    finalResult = result;
                    break;
                }
            }

            if (finalResult == CryptResult.Success)
                listItem.Status = CryptStatus.Done;
            else
                listItem.Status = CryptStatus.Error;

        }

        /// <summary>
        /// Encrypts a single file
        /// </summary>
        private async void EncryptFile(string item)
        {
            // Check status
            var status = Utility.GetCryptStatus(item);
            if (status == CryptStatus.Error)
            {
                MessageBox.Show("An error occurred while trying to read the file header.");
                return;
            }

            // Create and add the item to the list
            var listItem = new ListItem(Utility.GetExtension(item), item, ListItemType.File, status);
            listItem.Extension += GetExtensionAddition(status);
            dragList.AddItem(listItem);

            // Crypt
            var result = await Crypt(item, status);

            // Update status (if independent)
            if (result == CryptResult.Success)
                listItem.Status = CryptStatus.Done;
            else
                listItem.Status = CryptStatus.Error;
        }

        /// <summary>
        /// Gets the extension to the extension based on whether the file is encrypted or not
        /// </summary>
        private string GetExtensionAddition(CryptStatus currentStatus)
        {
            if (currentStatus == CryptStatus.Encrypted)
                return "/DEC"; // DEC = decrypt
            else
                return "/ENC"; // ENC = encrypt
        }

        /// <summary>
        /// Encrypts/decrypts a file based on whether or not it is encrypted already
        /// </summary>
        private Task<CryptResult> Crypt(string file, CryptStatus status)
        {
            return Task.Run(() =>
            {
                CryptResult result = CryptResult.UnknownFail;

                if (status == CryptStatus.Unencrypted)
                    result = crypter.EncryptFile(file, true);
                else if (status == CryptStatus.Encrypted)
                    result = crypter.DecryptFile(file);

                return result;
            });
        }

        /// <summary>
        /// Verifies the validity of the settings.
        /// </summary>
        /// <returns>Returns string.Empty if the result ok and the error message otherwise.</returns>
        private string CheckSettingsValidity()
        {
            // Check for valid key length
            if (txtKey.Text.Length < 4 || txtKey.Text.Length > 20)
            {
                return "The key must be between 4-20 characters long!";
            }

            // Check for valid file length
            int length;
            if (chkEncryptFileNames.Checked) {
                if (!int.TryParse(txtEncryptedFileLength.Text, out length))
                    return "The encrypted file name length is invalid!";                  
                if (length < 6 || length > 16)
                    return "The key length should be between 6 and 16 characters!";
            }

            return string.Empty; // Sign that the result is ok
        }

        /// <summary>
        /// Flashes the update status icon for a short period of time
        /// </summary>
        private void ShowUpdateSuccess()
        {
            InvokeUI(() => { pbUpdateStatus.Visible = true; });
            Thread.Sleep(500);
            InvokeUI(() => { pbUpdateStatus.Visible = false; });
        }

        /// <summary>
        /// Used to invoke actions on the UI thread
        /// </summary>
        private void InvokeUI(Action a) => BeginInvoke(new MethodInvoker(a));
    }
}
