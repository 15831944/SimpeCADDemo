using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace ImitataCad
{
    public partial class CurveTool : LineTool
    {

        private ArrayList a = new ArrayList();
        public override void mouseDown(object sender, MouseEventArgs e)
        {
            a.Clear();
            a.Add(new Point(e.X, e.Y));
            this.setOperShape(new CurveShape());
            this.getOperShape().setP1(this.getDownPoint());
            this.getRefCADPanel().getCurrentShapes().Add(this.getOperShape());
        }
        public override void mouseDrag(object sender, MouseEventArgs e)
        {
            a.Add(new Point(e.X, e.Y));
            Graphics gra = this.getRefCADPanel().PictureBox.CreateGraphics();
            this.getOperShape().setP2(new Point(e.X, e.Y));
            gra.DrawLine(BaseShape.getPen((Color)this.getRefCADPanel().c[this.getRefCADPanel().c.Count - 1]), this.getOperShape().getP1(), this.getOperShape().getP2());
            this.getOperShape().setP1(this.getOperShape().getP2());
            gra.Dispose();
        }
        public override void mouseUp(object sender, MouseEventArgs e)
        {
            this.getOperShape().P = new Point[a.Count];
            for (int i = 0; i < a.Count; i++)
            {
                this.getOperShape().P[i] = (Point)a[i];
            }
            this.getRefCADPanel().Refresh();
        }

    }
}
