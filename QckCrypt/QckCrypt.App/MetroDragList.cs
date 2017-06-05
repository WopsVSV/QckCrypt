using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.Drawing;
using MetroFramework;
using System.ComponentModel;

namespace QckCrypt.App
{
    public enum ListItemType
    {
        Folder,
        File
    }

    public enum CryptStatus
    {
        Encrypted,
        Unencrypted
    }

    /// <summary>
    /// This represents an item which will be worked with and used for the list view
    /// </summary>
    public class ListItem
    {
        public ListItemType Type { get; set; }

        private CryptStatus status;
        public CryptStatus Status {
            get { return status; }
            set {
                if (value == CryptStatus.Encrypted)
                    Spinner.Visible = false;

                status = value;
            }
        }

        public string Extension { get; set; }
        public string Path { get; set; }
        public MetroProgressSpinner Spinner { get; set; }

        public ListItem(string name, string path, ListItemType type, CryptStatus status)
        {
            Extension = name;
            Path = path;
            Type = type;
            Status = status;
            Spinner = new MetroProgressSpinner()
            {
                Style = MetroColorStyle.Green,
                Theme = MetroThemeStyle.Dark,
                Speed = 2f
            };
        }


    }

    public class MetroDragList : MetroUserControl
    {
        private const int ItemHeight = 48;
        private const int Name_X = 54;
        private const int Path_X = 100;

        private Pen BorderPen       = new Pen(Color.FromArgb(60, 60, 60), 0.85f);
        private Pen ItemBorderPen   = new Pen(Color.FromArgb(25, 25, 25), 0.6f);
        private Font ExtensionFont  = new Font("Consolas", 10, FontStyle.Regular);
        private Font PathFont       = new Font("Consolas", 8, FontStyle.Regular);

        /// <summary>
        /// List which contains all items
        /// </summary>
        private List<ListItem> Items { get; set; }
        public List<MetroProgressSpinner> Spinners { get; private set; }

        /// <summary>
        /// Used images
        /// </summary>
        private Bitmap DefaultBitmap = new Bitmap(32, 32);
        public Bitmap FolderIcon { get; set; }
        public Bitmap DocumentIcon { get; set; } 
        public Bitmap CheckedIcon { get; set; }

        /// <summary>
        /// Constructor for the drag list
        /// </summary>
        public MetroDragList()
        {
            Theme = MetroThemeStyle.Dark;

            Items = new List<ListItem>();
            Spinners = new List<MetroProgressSpinner>();

            FolderIcon = DefaultBitmap;
            CheckedIcon = DefaultBitmap;
            DocumentIcon = DefaultBitmap;
        }

        /// <summary>
        /// Draws the items accordingly
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draws the item
            for(int i = 0; i < Items.Count; i++)
            {
                // Border
                e.Graphics.DrawRectangle(ItemBorderPen, 0, i * ItemHeight, Width - 1, ItemHeight);

                // Icon
                if (Items[i].Type == ListItemType.File)
                    e.Graphics.DrawImage(DocumentIcon, 8, (i * ItemHeight) + 8, 32, 32);
                else
                    e.Graphics.DrawImage(FolderIcon, 8, (i * ItemHeight) + 8, 32, 32);

                // Name
                e.Graphics.DrawString(Items[i].Extension, ExtensionFont, Brushes.DarkGray, Name_X, (i * ItemHeight) + 16);

                // Path
                e.Graphics.DrawString(Items[i].Path, PathFont, Brushes.Gray, Path_X, (i * ItemHeight) + 18);

                // Status icon
                if (Items[i].Status == CryptStatus.Encrypted)
                    e.Graphics.DrawImage(CheckedIcon, Width - 48, (i * ItemHeight) + 8, 32,32);
            }

            // Draws the border
            e.Graphics.DrawRectangle(BorderPen, 0, 0, Width - 1, Height - 1);

            base.OnPaint(e);
        }
        
        // Add item to the list
        public void AddItem(ListItem item)
        {
            // Trim length if case
            if (item.Path.Length > (Width - 180) / 6)
                item.Path = item.Path.Substring(0, (Width - 180) / 6) + "...";

            // Add item
            Items.Add(item);

            // Add spinner
            AddSpinner(Items.Count - 1);
            
            Invalidate();
        }

        /// <summary>
        /// Adds a spinner
        /// </summary>
        /// <param name="index"></param>
        private void AddSpinner(int index)
        {
            Items[index].Spinner.Location = new Point(Width - 48, (index * ItemHeight) + 8);
            Items[index].Spinner.Size = new Size(32, 32);
            Spinners.Add(Items[index].Spinner);
            Controls.Add(Spinners.Last());
        }

        /// <summary>
        /// Gets the item at position
        /// </summary>
        public ListItem ItemAt(int index)
        {
            return Items[index];
        }

        /// <summary>
        /// Removes spinner before invalidation
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (!Items[i].Spinner.Visible)
                    Controls.Remove(Spinners[i]);
            }

            base.OnInvalidated(e);
        }

    }
}
