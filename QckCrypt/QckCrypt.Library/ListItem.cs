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

        public ListItem(string extension, string path, ListItemType type, CryptStatus status)
        {
            Extension = extension;
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
}
