using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace QckCrypt.App
{
    public class MetroDragList : MetroUserControl
    {
        /// <summary>
        /// Constructor for the drag list
        /// </summary>
        public MetroDragList()
        {
            Theme = MetroFramework.MetroThemeStyle.Dark;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(System.Drawing.Pens.Red, new System.Drawing.Rectangle(10, 10, 40, 50));
            base.OnPaint(e);
        }
    }
}
