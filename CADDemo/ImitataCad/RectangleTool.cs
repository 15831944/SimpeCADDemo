using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ImitataCad
{
    public partial class RectangleTool : BaseTool
    {
        //重写先的鼠标按下事件
        public override void mouseDown(object sender, MouseEventArgs e)
        {
            this.setOperShape(new RectangleShape());
            this.getOperShape().setP1(this.getDownPoint());
            this.getRefCADPanel().getCurrentShapes().Add(this.getOperShape());
        }
        //重写鼠标的拖动处理事件
        public override void mouseDrag(object sender, MouseEventArgs e)
        {
            this.getOperShape().setP2(this.getNewDragPoint());
            this.getRefCADPanel().Refresh();
        }
        public override void mouseMove(object sender, MouseEventArgs e)
        {
        }
        public override void mouseUp(object sender, MouseEventArgs e)
        {
            if (this.getOperShape().getP2() == Point.Empty)
            {
                this.getOperShape().setP1(new Point());
                this.getOperShape().setP2(new Point());
            }
            this.getRefCADPanel().Refresh();
        }
        public override void unSet()
        {
        }
        public override void set()
        {
        }
    }
}
