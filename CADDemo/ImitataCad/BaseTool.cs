using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImitataCad
{
  public abstract  class BaseTool
    {
        //关联画板的引用
        private GraphicDisplay refCADPanel = null;
        //鼠标的按下点
        private Point upPoint = new Point();
        //鼠标的弹起点
        private Point downPoint = new Point();
        //新的鼠标移动点
        private Point newMovePoint = new Point();
        //老的鼠标移动点
        private Point oldMovePoint = new Point();
        //新的鼠标拖动点
        private Point newDragPoint = new Point();
        //老的鼠标拖动点
        private Point oldDragPoint = new Point();
        //操作图形的引用
        private BaseShape operShape = null;
        //属性器
        public GraphicDisplay getRefCADPanel()
        {
            return refCADPanel;
        }

        public void setRefCADPanel(GraphicDisplay refCADPanel)
        {
            this.refCADPanel = refCADPanel;
        }
        public Point getUpPoint()
        {
            return upPoint;
        }
        public void setUpPoint(Point upPoint)
        {
            this.upPoint = upPoint;
        }

        public Point getDownPoint()
        {
            return downPoint;
        }
        public void setDownPoint(Point downPoint)
        {
            this.downPoint = downPoint;
        }
        public Point getNewMovePoint()
        {
            return newMovePoint;
        }
        public void setNewMovePoint(Point newMovePoint)
        {
            this.newMovePoint = newMovePoint;
        }
        public Point getOldMovePoint()
        {
            return oldMovePoint;
        }
        public void setOldMovePoint(Point oldMovePoint)
        {
            this.oldMovePoint = oldMovePoint;
        }
        public Point getNewDragPoint()
        {
            return newDragPoint;
        }
        public void setNewDragPoint(Point newDragPoint)
        {
            this.newDragPoint = newDragPoint;
        }
        public Point getOldDragPoint()
        {
            return oldDragPoint;
        }
        public void setOldDragPoint(Point oldDragPoint)
        {
            this.oldDragPoint = oldDragPoint;
        }
        public BaseShape getOperShape()
        {
            return operShape;
        }
        public void setOperShape(BaseShape operShape)
        {
            this.operShape = operShape;
        }
        //定义鼠标按下处理的抽象方法
        public abstract void mouseUp(object sender, MouseEventArgs e);
        //定义鼠标弹起处理的抽象方法
        public abstract void mouseDown(object sender, MouseEventArgs e);
        //定义鼠标移动处理的抽象方法
        public abstract void mouseMove(object sender, MouseEventArgs e);
        //定义鼠标拖动处理的抽象方法
        public abstract void mouseDrag(object sender, MouseEventArgs e);
        //装载抽象方法
        public abstract void set();
        //工具卸载抽象方法
        public abstract void unSet();
        //鼠标释放的方法
        public void superMouseUp(object sender, MouseEventArgs e)
        {
            //鼠标弹起的起始点设置
            this.setUpPoint(new Point(e.X, e.Y));
            //鼠标的弹起处理
            this.mouseUp(sender, e);
            //鼠标弹起点设点
            this.setUpPoint(new Point());
            //鼠标按下点设定
            this.setDownPoint(new Point());
            //老的鼠标移动点设定
            this.setOldMovePoint(new Point());
            //新的鼠标移动点设定
            this.setNewMovePoint(new Point());
            //老的鼠标拖动点设定
            this.setOldDragPoint(new Point());
            //新的鼠标拖动点设定
            this.setNewDragPoint(new Point());
            //快照的保存
            //this.getRefCADPanel().record();//
        }
        //鼠标弹起的方法
        public void superMouseDown(object sender, MouseEventArgs e)
        {
            //鼠标弹起点设定
            this.setUpPoint(new Point(e.X, e.Y));
            //鼠标按下点设定
            this.setDownPoint(new Point(e.X, e.Y));
            //老的鼠标移动点设定
            this.setOldMovePoint(new Point(e.X, e.Y));
            //新的鼠标移动点设定
            this.setNewMovePoint(new Point(e.X, e.Y));
            //老的鼠标拖动点设定
            this.setOldDragPoint(new Point(e.X, e.Y));
            //新的鼠标拖动点设定
            this.setNewDragPoint(new Point(e.X, e.Y));
            //鼠标按下的处理
            this.mouseDown(sender, e);
        }
        //鼠标的移动事件
        public void superMouseMove(object sender, MouseEventArgs e)
        {
            //新的鼠标移动点的设定
            this.setNewMovePoint(new Point(e.X, e.Y));
            //鼠标事件的移动
            this.mouseMove(sender, e);
            //老的鼠标移动的设定
            this.setOldMovePoint(this.getNewMovePoint());
        }
        //鼠标的拖动事件
        public void superMouseDrag(object sender, MouseEventArgs e)
        {
            //新的鼠标拖动点
            this.setNewDragPoint(new Point(e.X, e.Y));
            //鼠标的拖动处理
            this.mouseDrag(sender, e);
            //老的鼠标拖动点
            this.setOldDragPoint(this.getNewDragPoint());
        }
       
    }
}
