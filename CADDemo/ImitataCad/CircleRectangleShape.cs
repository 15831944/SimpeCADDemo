using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace ImitataCad
{
    [Serializable]
    public partial class CircleRectangleShape : BaseShape
    {
        Rectangle rec = new Rectangle();
        public void drawRec(Point p1, Point p2)
        {
            Point p = new Point();
            if (p1.X < p2.X && p1.Y < p2.Y)
            {
                rec = new Rectangle(p1, getSize(p1, p2));
            }
            if (p1.X < p2.X && p1.Y > p2.Y)
            {
                p.X = p1.X;
                p.Y = p2.Y;
                rec = new Rectangle(p, getSize(p1, p2));
            }
            if (p1.X > p2.X && p1.Y > p2.Y)
            {
                rec = new Rectangle(p2, getSize(p1, p2));
            }
            if (p1.X > p2.X && p1.Y < p2.Y)
            {
                p.X = p2.X;
                p.Y = p1.Y;
                rec = new Rectangle(p, getSize(p1, p2));
            }

        }

        public Size getSize(Point p1, Point p2)
        {
            int iWidth = Math.Abs(p1.X - p2.X);
            int iHeight = Math.Abs(p1.Y - p2.Y);
            return new Size(iWidth, iHeight);
        }

        public bool isInRectangle(Point p1, Point p2, Point testPoint)
        {
            drawRec(p1, p2);
            return rec.Contains(testPoint);
        }

        public override bool catchShape(Point testPoint)
        {
            return isInRectangle(this.getP1(), this.getP2(), testPoint);
        }
        //绘制圆角矩形 
        public override void draw(Graphics g, Color c)
        {
            drawRec(getP1(), getP2());
            int a = 30;
            Pen p = BaseShape.getPen(c);
            int h = Math.Abs(getP1().Y - getP2().Y);
            int w = Math.Abs(getP1().X - getP2().X);
            int x = getP1().X;
            int y = getP1().Y;
            int x1 = getP2().X;
            int y1 = getP2().Y;
            //移动到原点右下
            if (x > x1 && y > y1)
            {
                g.DrawArc(p, x - a, y - a, a, a, 0, 90);
                g.DrawLine(p, x + a / 2 - w, y, x - a / 2, y);
                g.DrawArc(p, x1, y - a, a, a, 90, 90);
                g.DrawLine(p, x, y - h + a / 2, x, y - a / 2);
                g.DrawLine(p, x1, y - h + a / 2, x1, y - a / 2);
                g.DrawArc(p, x - a, y - h, a, a, 0, -90);
                g.DrawLine(p, x + a / 2 - w, y1, x - a / 2, y1);
                g.DrawArc(p, x1, y1, a, a, 180, 90);

            }
            //移动到原点左下
            if (x > x1 && y < y1)
            {
                g.DrawArc(p, x - a, y, a, a, 0, -90);
                g.DrawLine(p, x1 + a / 2, y, x - a / 2, y);
                g.DrawArc(p, x1, y, a, a, 180, 90);
                g.DrawLine(p, x, y + a / 2, x, y + h - a / 2);
                g.DrawLine(p, x - w, y + a / 2, x - w, y + h - a / 2);
                g.DrawArc(p, x1, y + h - a, a, a, 180, -90);
                g.DrawLine(p, x1 + a / 2, y + h, x - a / 2, y + h);
                g.DrawArc(p, x - a, y + h - a, a, a, 0, 90);

            }
            //移动到原点右上
            if (x < x1 && y > y1)
            {
                g.DrawArc(p, x, y - a, a, a, 90, 90);
                g.DrawLine(p, x + a / 2, y, x - a / 2 + w, y);
                g.DrawArc(p, x + w - a, y - a, a, a, 0, 90);
                g.DrawLine(p, x, y - a / 2, x, y - h + a / 2);
                g.DrawLine(p, x + w, y - a / 2, x + w, y - h + a / 2);
                g.DrawArc(p, x1 - a, y1, a, a, 0, -90);
                g.DrawArc(p, x, y - h, a, a, 180, 90);
                g.DrawLine(p, x + a / 2, y1, x - a / 2 + w, y1);

            }
            //移动到原点左上
            if (x < x1 && y < y1)
            {
                g.DrawArc(p, x, y, a, a, 180, 90);
                g.DrawLine(p, x + a / 2, y, x - a / 2 + w, y);
                g.DrawArc(p, x + w - a, y, a, a, 270, 90);
                g.DrawLine(p, x, y + a / 2, x, y - a / 2 + h);
                g.DrawArc(p, x, y1 - a, a, a, 90, 90);
                g.DrawLine(p, x + a / 2, y1, x + w - a / 2, y1);
                g.DrawArc(p, x1 - a, y1 - a, a, a, 0, 90);
                g.DrawLine(p, x + w, y + a / 2, x + w, y1 - a / 2);

            }


        }
        //获取所有热点  
        public override Point[] getAllHitPoint()
        {
            //4个热点
            Point[] allHitPoint = new Point[4];
            //圆角矩形的4个边点
            allHitPoint[0] = new Point(rec.Left, rec.Top);
            allHitPoint[1] = new Point(rec.Right, rec.Top);
            allHitPoint[2] = new Point(rec.Right, rec.Bottom);
            allHitPoint[3] = new Point(rec.Left, rec.Bottom);
            return allHitPoint;
        }
        //重写 热点的设置
        public override void setHitPoint(int hitPointIndex, Point newPoint)
        {
            int left = rec.Left; int right = rec.Right; int top = rec.Top; int bottom = rec.Bottom;
            switch (hitPointIndex)
            {
                case 0:
                    {
                        left += newPoint.X;
                        right += newPoint.X;
                        top += newPoint.Y;
                        bottom += newPoint.Y;
                        break;
                    }
                case 1:
                    top = newPoint.Y;
                    left = newPoint.X;
                    break;

                case 2:
                    if (newPoint.Y < bottom)
                    {
                        top = newPoint.Y;
                    }
                    else
                    {
                        bottom = newPoint.Y;
                    }
                    break;
                case 3:
                    top = newPoint.Y;
                    right = newPoint.X;
                    break;
                case 4:
                    right = newPoint.X;
                    break;
                case 5:
                    bottom = newPoint.Y;
                    right = newPoint.X;
                    break;
                case 6:
                    int i = top;
                    if (newPoint.Y > top)
                    {
                        bottom = newPoint.Y;
                    }
                    else
                    {
                        top = newPoint.Y;
                    }
                    break;
                case 7:
                    bottom = newPoint.Y;
                    left = newPoint.X;
                    break;
                case 8:
                    left = newPoint.X;
                    break;

            }
            SetRectangle(left, top, right - left, bottom - top);
            Point temp = new Point();
            temp.X = rec.X;
            temp.Y = rec.Y;
            this.setP1(temp);
            temp = getP1() + rec.Size;
            this.setP2(temp);
        }

        protected void SetRectangle(int x, int y, int width, int height)
        {
            rec.X = x;
            rec.Y = y;
            rec.Width = width;
            rec.Height = height;
        }

        //重写复制方法
        public override BaseShape copySelf()
        {
            CircleRectangleShape copyCircleRectangleShape = new CircleRectangleShape();
            //复制起点
            copyCircleRectangleShape.setP1(this.getP1());
            //复制终点
            copyCircleRectangleShape.setP2(this.getP2());
            return copyCircleRectangleShape;
        }
    }
}
