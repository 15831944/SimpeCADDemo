using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace ImitataCad
{
    public partial class HandTool : BaseTool
    {
       
        //捕捉热点的索引
        public int catchPointIncex = -1;
        //重写鼠标的按下事件
        public override void mouseDown(object sender, MouseEventArgs e)
        {
            //重置捕捉热点的索引
            catchPointIncex = -1;
            //清除前操作对象中选中的状态
            if (this.getOperShape() != null) this.getOperShape().setUnSelected();
            //得到所有的画板上的图形进行判断
            ArrayList allShapes = this.getRefCADPanel().getCurrentShapes();
            //临时处理捕捉的热点
            int catchPoint = -1;
            int i = 0;
            //对每个图形进行捕捉的测试
            for (; i < allShapes.Count; i++)
            {
                //捕捉集合中的一个图形
                catchPoint = ((BaseShape)allShapes[i]).catchShapPoint(this.getNewDragPoint());
                if (catchPoint > -1)
                {
                        break;
                } 
            }
            if (catchPoint > -1)
            {
                //捕获后把临时的热点设置到工具属性中
                catchPointIncex = catchPoint;
                //设置捕捉到的图形为选中状态
                ((BaseShape)allShapes[i]).setSelected();
                //把选中的图形设置到本类的操作图形状态中去
                this.setOperShape(((BaseShape)allShapes[i]));
            }
            //刷新画板
            this.getRefCADPanel().Refresh();
        }
        //重写鼠标的拖动事件
        public override void mouseDrag(object sender, MouseEventArgs e)
        {
            //当又选中的图形时做处理
            if (this.getOperShape() != null)
            {
                Point setPoint = this.getNewDragPoint();
                //捕捉到移动点就进行增量点的计算
                if (catchPointIncex == 0)//>???在捕捉到热点后,CatchPointIndex 属性会设置为0
                {
                    setPoint = new Point();
                    setPoint.X = this.getNewDragPoint().X - this.getOldDragPoint().X;
                    setPoint.Y = this.getNewDragPoint().Y - this.getOldDragPoint().Y;

                }
                //设置热点
                this.getOperShape().setHitPoint(catchPointIncex, setPoint);
                //刷新画板
                this.getRefCADPanel().Refresh();

            }
        }
        //移动的处理的图形
        public BaseShape oldMoveShap = null;
        //重写鼠标的移动事件
        public override void mouseMove(object sender, MouseEventArgs e)
        {
            //清除移动图形选中的状态
            if (oldMoveShap != null) oldMoveShap.setUnSelected();
            //得到画板上的图形集合
            ArrayList allShapes = this.getRefCADPanel().getCurrentShapes();
            //临时处理捕捉的热点
            int catchPoint = -1;
            int i = 0;
            //对每个图形进行捕捉的测试
            for (; i < allShapes.Count; i++)
            {
                //捕捉集合中的一个图形
                catchPoint = ((BaseShape)allShapes[i]).catchShapPoint(this.getNewMovePoint());
                //捕捉到跳出循环
                if (catchPoint > -1) {
                    break;
                }
            }
            //捕获后再设定捕捉的图形为选中状态
            if (catchPoint > -1)
            {
                ((BaseShape)allShapes[i]).setSelected();
                //把选中的图形设置到本类的操作图形状态中去
                oldMoveShap = (BaseShape)allShapes[i];
            }
            //刷新画板
            this.getRefCADPanel().Refresh();

        }
        //重写鼠标释放事件
        public override void mouseUp(object sender, MouseEventArgs e)
        {
            //刷新画板
            this.getRefCADPanel().Refresh();
        }
        //工具的卸载方法
        public override void unSet()
        {
            //得到画板上的图形集合
            ArrayList allShapes = this.getRefCADPanel().getCurrentShapes();
            //清除所有的图形选中的状态
            for (int i = 0; i < allShapes.Count; i++)
            {
                ((BaseShape)allShapes[i]).setUnSelected();

            }
            this.getRefCADPanel().Refresh();
        }
        public override void set()
        {
        }


    }
}
