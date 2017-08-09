using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace ImitataCad
{
    /// <summary>
    /// 在屏幕上显示图形
    /// </summary>
   public   class GraphicDisplay
    {
        //关联画板对象
        public PictureBox PictureBox;
        //显示光标位置的控件
        public ToolStripStatusLabel CoordinateDisplay { get; set; }
        //坐标转换
        public Transform Transforms { get; set; }//用于显示坐标与测量坐标的转换
        //当前的应用工具
        private BaseTool currentTool = null;
        //当前显示的图形集合
        private ArrayList currentShapes = null;
        //注册的工具集合
        private Hashtable registerToolMap = null;
        //历史图形的快照集合
        private ArrayList historyShapes = null;

        public ArrayList c = new ArrayList();
        public const string LINETOOL_REGISTERNAME = "LINETOOL_REGISTERNAME";
        //抓取工具的注册名
        public const string HANDTOOL_REGISTERNAME = "HANDTOOL_REGISTERNAME";

        public const string RECTANGLETOOL_REGISTERNAME = "RECTANGLETOOL_REGISTERNAME";

        public const string ELLIPESTOOL_REGISTERNAME = "ELLIPESTOOL_REGISTERNAME";

        public const string CIRCLERECTANGLETOOL_REGISTERNAME = "CIRCLERECTANGLETOOL_REGISTERNAME";

        public const string CURVETOOL_REGISTERNAME = "CURVETOOL_REGISTERNAME";

        public GraphicDisplay(PictureBox pictureBox) {
            this.PictureBox = pictureBox;
            Transforms = new Transform();
            Transforms.Scale = 1;
            //实例化当前显示的图形集合对象
            currentShapes = new ArrayList();
            //实例化注册工具的集合对象
            registerToolMap = new Hashtable();
            //实例化历史图形的快照集合对象
            historyShapes = new ArrayList();
            pictureBox.Paint += pictureBox1_Paint;//图形重绘制事件
            pictureBox.MouseDown += pictureBox1_MouseDown;//鼠标按下事件
            pictureBox.MouseMove += pictureBox1_MouseMove;//鼠标移动事件
            pictureBox.MouseUp += pictureBox1_MouseUp;//鼠标释放事件
                                                      //实例化当前显示的
            //注册线工具
            this.registerTool(LINETOOL_REGISTERNAME, new LineTool());
            //注册矩形工具
            this.registerTool(RECTANGLETOOL_REGISTERNAME, new RectangleTool());
            //注册椭圆工具
            this.registerTool(ELLIPESTOOL_REGISTERNAME, new EllipesTool());
            //注册圆矩形工具
            this.registerTool(CIRCLERECTANGLETOOL_REGISTERNAME, new CircleRectangleTool());
            //注册曲线工具
            this.registerTool(CURVETOOL_REGISTERNAME, new CurveTool());
            //注册抓取工具
            this.registerTool(HANDTOOL_REGISTERNAME, new HandTool());

            this.record();
            c.Add(Color.Black);

        }

        //更新图形的方法 --选择之一 初始化图形 用
        public void Invalidate()
        {
            PictureBox.Invalidate();//使控件的特定区域无效并向控件发送绘制消息。
        }
        //更新图形的方法-- 图形改变后 使用
        public void Refresh()
        {
            PictureBox.Refresh();//强制控件使其工作区无效并立即重绘自己和任何子控件。
        }

       

        /// <summary>
        /// 得到当前绘图图形
        /// </summary>
        /// <returns></returns>
        public ArrayList getCurrentShapes()
        {
            return currentShapes;
        }
        /// <summary>
        /// 设置当前绘图图形
        /// </summary>
        /// <param name="currentShapes">绘图图形</param>
        public void setCurrentShapes(ArrayList currentShapes)
        {
            this.currentShapes = currentShapes;
        }
        /// <summary>
        /// 得到当前绘图工具
        /// </summary>
        /// <returns>绘图工具基类</returns>
        public BaseTool getCurrentTool()
        {
            return currentTool;
        }
        /// <summary>
        /// 设置绘图绘图工具
        /// </summary>
        /// <param name="currentTool">绘图工具</param>
        public void setCurrentTool(BaseTool currentTool)
        {
            this.currentTool = currentTool;
        }
        /// <summary>
        /// 得到注册绘图工具
        /// </summary>
        /// <returns></returns>
        public Hashtable getRegisterToolMap()
        {
            return registerToolMap;
        }
        /// <summary>
        /// 设置绘图工具
        /// </summary>
        /// <param name="registerToolMap"></param>
        public void setRegisterToolMap(Hashtable registerToolMap)
        {
            this.registerToolMap = registerToolMap;
        }

        /// <summary>
        ///  得到历史快照
        /// </summary>
        /// <returns></returns>
        public ArrayList getHistoryShapes()
        {
            return historyShapes;
        }
        /// <summary>
        /// 设置历史快照
        /// </summary>
        /// <param name="historyShape"></param>
        public void setHistoryShapes(ArrayList historyShape)
        {
            this.historyShapes = historyShape;
        }
        
        /// <summary>
        /// 注册工具的方法
        /// </summary>
        /// <param name="registerName">工具名</param>
        /// <param name="registerTool">工具</param>
        public void registerTool(string registerName, BaseTool registerTool)
        {
            this.getRegisterToolMap().Add(registerName, registerTool);
            registerTool.setRefCADPanel(this);
        }

        //运用工具的方法
        public void useTool(string registerName)
        {
            //卸载之前用的工具
            if (this.getCurrentTool() != null)
                this.getCurrentTool().unSet();
            //得到要加载的工具
            BaseTool setTool = (BaseTool)this.getRegisterToolMap()[registerName];
            //工具装载处理
            if (setTool != null)
            {
                setTool.set();
                //装载工具
                this.setCurrentTool(setTool);
            }
        }
        //回退的索引
        int undoIndex = 0;
        //快照保存的方法
        public void record()
        {
            //当有回退时清空会退或者快照
            if (undoIndex > 0)
            {
                while (undoIndex != 0)
                {
                    this.getHistoryShapes().RemoveAt(this.getHistoryShapes().Count - 1);
                    undoIndex--;
                }
            }
            //保存快照
            this.getHistoryShapes().Add(this.cloneShapArray(this.getCurrentShapes()));
        }
        //重做的方法
        public void redo()
        {
            //回退时才可以重做
            if (undoIndex > 0)
            {
                undoIndex--;
                //把历史的快照取回到当前的图形中
                this.setCurrentShapes(this.cloneShapArray((ArrayList)this.getHistoryShapes()[this.getHistoryShapes().Count - 1 - undoIndex]));
            }
            //刷新画板
            this.Refresh();
        }
        //回退的方法
        public void undo()
        {
            //历史集合中有历史的话才可以回退
            if ((this.getHistoryShapes().Count - 1 - undoIndex) > 0)
            {
                undoIndex++;
                //把历史的快照取回到当前的图形中
                this.setCurrentShapes((this.cloneShapArray((ArrayList)this.getHistoryShapes()[this.getHistoryShapes().Count - 1 - undoIndex])));
            }
            this.Refresh();
        }
        
        /// <summary>
        /// 图形集合深复制的方法
        /// </summary>
        /// <param name="shapeArrayList"></param>
        /// <returns>图形集合</returns>
        public ArrayList cloneShapArray(ArrayList shapeArrayList)
        {
            ArrayList returnShapeArrayList = new ArrayList();
            for (int i = 0; i < shapeArrayList.Count; i++)
            {
                returnShapeArrayList.Add(((BaseShape)shapeArrayList[i]).copySelf());
            }
            return returnShapeArrayList;
        }

        public string GetCursorLocation()
        {
            Point p = new Point();//光标位置
            string Txt = "";
            //当前工具不为空,表示有工具在使用
            if (currentTool != null)
            {
                //获取移动点坐标
                p = currentTool.getNewMovePoint();
                Txt = "X坐标:" + p.X + "Y坐标:" + p.Y;
                return Txt;
            }
            return "X坐标:" + p.X + "Y坐标:" + p.Y;

        }

        //清空图片区
        public void clear()
        {
            //重置回退的索引
            undoIndex = 0;
            //初始化历史快照
            this.setHistoryShapes(new ArrayList());
            //初始化当前图形的集合
            this.setCurrentShapes(new ArrayList());
            //记录这个过程
            c.Clear();
            c.Add(Color.Black);
            this.record();
            PictureBox.Refresh();
        }
        //重绘
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < currentShapes.Count; i++)
            {
                if (i < c.Count)
                {
                    ((BaseShape)currentShapes[i]).superDraw(g, (Color)c[i]);
                }
                else
                {
                    c.Add(c[i - 1]);
                    ((BaseShape)currentShapes[i]).superDraw(g, (Color)c[i]);
                }
            }
        }
        //鼠标是否按下
        bool isMouseDown = false;
        //鼠标的按下
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //鼠标按下的标示
            isMouseDown = true;
            //记录鼠标按下的状态
            if (this.getCurrentTool() != null)
            {
                this.getCurrentTool().superMouseDown(sender, e);
                double  x, y;
                Transforms.ToSurveyXY(e.X, e.Y, out x, out y);
                CoordinateDisplay.Text = x.ToString("F3") + "," + y.ToString("F3");
            }
        }
        //鼠标的移动
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                //拖动
                if (this.getCurrentTool() != null)
                {
                    this.getCurrentTool().superMouseDrag(sender, e);
                    double x, y;
                    Transforms.ToSurveyXY(e.X, e.Y, out x, out y);
                    CoordinateDisplay.Text = x.ToString("F3") + "," + y.ToString("F3");
                }
            }
            else
            {
                //移动
                if (this.getCurrentTool() != null)
                {
                    this.getCurrentTool().superMouseMove(sender, e);
                    double x, y;
                    Transforms.ToSurveyXY(e.X, e.Y, out x, out y);
                    CoordinateDisplay.Text = x.ToString("F3") + "," + y.ToString("F3");
                }
            }
        }
        //鼠标的释放
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            //鼠标释放的状态
            if (this.getCurrentTool() != null)
            {
                this.getCurrentTool().superMouseUp(sender, e);
                double x, y;
                Transforms.ToSurveyXY(e.X, e.Y, out x, out y);
                CoordinateDisplay.Text = x.ToString("F3") + "," + y.ToString("F3");
            }
        }
    }
}
