using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QckCrypt.Library
{
    /// <summary>
    /// The very hardcoded drag list
    /// </summary>
    public class MetroBorderPanel : MetroUserControl
    {
        private Pen BorderPen = new Pen(Color.FromArgb(60, 60, 60), 0.85f);

        /// <summary>
        /// Constructor for the drag list
        /// </summary>
        public MetroBorderPanel()
        {
            Theme = MetroThemeStyle.Dark;
        }

        /// <summary>
        /// Draws the items accordingly
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draws the border
            e.Graphics.DrawRectangle(BorderPen, 0, 0, Width-1, Height-1);
            base.OnPaint(e);
        }
    }
}
