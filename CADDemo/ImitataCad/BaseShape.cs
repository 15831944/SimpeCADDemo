using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ImitataCad
{
    [Serializable]
    //图形抽象类 --所有图形继承此类实现抽象方法.
  public abstract  class BaseShape
    {
        //定义选择状态
        private bool isSelected = false;
        //定义起点
        private Point p1;
        //定义终点
        private Point p2;
        //属性器
        private Point[] _P;

        public Point[] P { get => _P; set => _P = value; }

        public void setSelected()
        {
            this.isSelected = true;
        }
        public void setUnSelected()
        {
            this.isSelected = false;
        }
        public Point getP1()
        {
            return p1;
        }
        public void setP1(Point p1)
        {
            this.p1 = p1;
        }
        public Point getP2()
        {
            return p2;
        }
        public void setP2(Point p2)
        {
            this.p2 = p2;
        }

        //画图形的抽象方法
        public abstract void draw(Graphics g, Color c);
        //得到所有图形的抽象方法
        public abstract Point[] getAllHitPoint();
        //设定热点的抽象方法
        public abstract void setHitPoint(int hitPointIndex, Point newPoint);
        //复制的抽象方法
        public abstract BaseShape copySelf();
        //图形捕捉的抽象方法
        public abstract bool catchShape(Point testPoint);

        //测试热点捕捉的方法
        public bool catchHitPoint(Point hitPoint, Point testPoint)
        {
            return this.getHitPointRetangle(hitPoint).Contains(testPoint);
        }

      
        //图形捕捉的方法
        public int catchShapPoint(Point testPoint)
        {
            //定义一个临时的捕捉点索引
            int hitPointIndex = -1;
            //所有的热点进行循环捕捉的判断
            Point[] allHitPoint = this.getAllHitPoint();
            for (int i = 0; i < allHitPoint.Length; i++)
            {
                if (this.catchHitPoint(allHitPoint[i], testPoint))
                {
                    //返回所有热点的索引
                    return i + 1;
                }
            }
            //判断下没有捕捉到热点又捕捉到图形，返回特定的热点
            if (this.catchShape(testPoint))
                return 0;
            //返回捕捉到的热点
            return hitPointIndex;

        }
        //定义一个画热点的方法
        public void drawHitPoint(Point hitPoint, Graphics g, Color c)
        {
            g.DrawRectangle(BaseShape.getPen(c), this.getHitPointRetangle(hitPoint));
        }
        //定义一个画所有热点的方法
        public void drawAllHitPoint(Graphics g, Color c)
        {
            Point[] allHitPoint = this.getAllHitPoint();
            for (int i = 0; i < allHitPoint.Length; i++)
            {
                this.drawHitPoint(allHitPoint[i], g, c);
            }
        }
        //定义一个得到热点矩形的方法（以热点为中心）
        public Rectangle getHitPointRetangle(Point hitPoint)
        {
            Rectangle rect = new Rectangle();
            rect.X = hitPoint.X - 2;
            rect.Y = hitPoint.Y - 2;
            rect.Width = 5;
            rect.Height = 5;
            return rect;
        }

        
        //公共的画法
        public void superDraw(Graphics g, Color c)
        {
            this.draw(g, c);
            if (this.isSelected)
                this.drawAllHitPoint(g, c);
        }
        //得到默认画笔的方法
        public static Pen getPen(Color c)
        {
            return new Pen(c);
        }

    }
}
