using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppTempltePattern
{
    internal class MyButton : Button
    {

        int paintCount;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.FillRectangle(Brushes.Aqua, ClientRectangle);
            pevent.Graphics.FillEllipse(Brushes.Orange, ClientRectangle);

            pevent.Graphics.DrawString($"Paint: {paintCount++}", SystemFonts.DefaultFont, Brushes.BlanchedAlmond, ClientRectangle);


        }
    }
}
