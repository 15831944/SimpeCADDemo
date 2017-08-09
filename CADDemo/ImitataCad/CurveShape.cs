using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ImitataCad
{
    [Serializable]
    public class CurveShape : LineShape
    {
        public override void draw(Graphics g, Color c)
        {
            try
            {

                g.DrawCurve(BaseShape.getPen(c), P);
            }
            catch (Exception e)
            {
            }

        }
        bool a = false;
        public void isIncurve(Point[] p, Point TestPoint)
        {
            try
            {
                for (int i = 0; i < p.Length; i++)
                {
                    a = isInLine(p[i], p[i + 1], TestPoint);
                    if (a == true)
                        break;
                }

            }
            catch
            {

            }
        }
        public override bool catchShape(Point TestPoint)
        {
            isIncurve(P, TestPoint);
            return a;
        }
        public override Point[] getAllHitPoint()
        {
            return P;
        }
        public override BaseShape copySelf()
        {
            CurveShape CopyAutoLineShape = new CurveShape();

            CopyAutoLineShape.P = this.P;
            return CopyAutoLineShape;
        }
        public override void setHitPoint(int HitPointIndex, Point newPoint)
        {
            try
            {
                if (HitPointIndex == 0)
                {
                    for (int i = 0; i < P.Length; i++)
                    {
                        P[i].X += newPoint.X;
                        P[i].Y += newPoint.Y;
                    }
                }
                if (HitPointIndex > 0)
                {
                    //P[HitPointIndex - 1] = newPoint;
                    switch (HitPointIndex)
                    {
                        case 0:
                            {
                                //索引为相对的坐标
                                Point tempPoint;
                                tempPoint = new Point();
                                tempPoint.X = this.getP1().X + newPoint.X;
                                tempPoint.Y = this.getP1().Y + newPoint.Y;
                                P[0] = tempPoint; ;
                                tempPoint = new Point();
                                tempPoint.X = this.getP2().X + newPoint.X;
                                tempPoint.Y = this.getP2().Y + newPoint.Y;
                                P[1] = tempPoint; ;
                                break;
                            }
                        case 1:
                            {
                                //设置p1的热点
                                P[1] = newPoint;
                                break;
                            }
                        default:
                            {
                                //设置p2的热点
                                P[1] = newPoint;
                                break;
                            }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
