using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImitataCad
{

    [Serializable]
    public class LineShape : BaseShape
    {
        //判断p3点是否在以p1，p2为线段的周围
        public static bool isInLine(Point p1, Point p2, Point p3)
        {
            double iLen1 = Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2);
            double iLen2 = Math.Pow(p1.X - p3.X, 2) + Math.Pow(p1.Y - p3.Y, 2);
            double iLen3 = Math.Pow(p2.X - p3.X, 2) + Math.Pow(p2.Y - p3.Y, 2);
            if (Math.Pow(iLen2, 0.5) + Math.Pow(iLen3, 0.5) - Math.Pow(iLen1, 0.5) < .1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //重写图形的捕捉类
        public override bool catchShape(Point testPoint)
        {
            //测试一个点是否在一个线段的周围
            return isInLine(this.getP1(), this.getP2(), testPoint);
        }
        //重写画方法
        public override void draw(Graphics g, Color c)
        {
            //画线
            g.DrawLine(BaseShape.getPen(c), this.getP1(), this.getP2());
        }
        //重写返回所有热点
        public override Point[] getAllHitPoint()
        {
            Point[] allHitPoint = new Point[2];
            //p1点为热点的第一个点
            allHitPoint[0] = this.getP1();
            allHitPoint[1] = this.getP2();
            return allHitPoint;
        }
        //重写设置热点的方法
        public override void setHitPoint(int hitPointIndex, Point newPoint)
        {
            switch (hitPointIndex)
            {
                case 0:
                    {
                        //索引为相对的坐标
                        Point tempPoint;
                        tempPoint = new Point();
                        tempPoint.X = this.getP1().X + newPoint.X;
                        tempPoint.Y = this.getP1().Y + newPoint.Y;
                        this.setP1(tempPoint);
                        tempPoint = new Point();
                        tempPoint.X = this.getP2().X + newPoint.X;
                        tempPoint.Y = this.getP2().Y + newPoint.Y;
                        this.setP2(tempPoint);
                        break;
                    }
                case 1:
                    {
                        //设置p1的热点
                        this.setP1(newPoint);
                        break;
                    }
                case 2:
                    {
                        //设置p2的热点
                        this.setP2(newPoint);
                        break;
                    }
            }
        }
        //重写复制方法
        public override BaseShape copySelf()
        {
            LineShape copyLineShape = new LineShape();
            //复制起点
            copyLineShape.setP1(this.getP1());
            //复制终点
            copyLineShape.setP2(this.getP2());
            return copyLineShape;
        }
    }
}
