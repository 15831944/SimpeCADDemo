using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitataCad
{
    public class StringShape : BaseShape
    {
        public override bool catchShape(Point testPoint)
        {
            throw new NotImplementedException();
        }

        public override BaseShape copySelf()
        {
            throw new NotImplementedException();
        }

        public override void draw(Graphics g, Color c)
        {
            //Graphics g = this.CreateGraphics();
            Font font = new Font("华为宋体", 12);
            //Point一样，只是值是浮点类型
            PointF point = new PointF(50, 50);
            //g.DrawString("我是Kimisme", font, Brushes.Coral, point);
            g.DrawString("nihao ", font, Brushes.Coral, point);
        }

        public override Point[] getAllHitPoint()
        {
            throw new NotImplementedException();
        }

        public override void setHitPoint(int hitPointIndex, Point newPoint)
        {
            throw new NotImplementedException();
        }
    }
}
