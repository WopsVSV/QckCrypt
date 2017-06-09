using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QckCrypt.Library
{
    /// <summary>
    /// This represents an item which will be worked with and used for the list view
    /// </summary>
    [Serializable]
    public class ListItem
    {
        public ListItemType Type { get; set; }

        /// <summary>
        /// Describes the current status of the list item and also disables the spinner if it's done
        /// </summary>
        private CryptStatus status;
        public CryptStatus Status {
            get { return status; }
            set {
                if (value == CryptStatus.Done || value == CryptStatus.Error)
                    Spinner.Visible = false;

                status = value;
            }
        }

        public string Extension { get; set; }
        public string Path { get; private set; }
        public string VirtualPath { get; set; } // This is the drawn path, it's virtual since it's going to be trimmed if it doesn't fit inside the drag list
        public MetroProgressSpinner Spinner { get; set; }

        /// <summary>
        /// Defines the new list item
        /// </summary>
        public ListItem(string extension, string path, ListItemType type, CryptStatus status)
        {
            Extension = extension;
            Path = path;
            VirtualPath = path;
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
}
