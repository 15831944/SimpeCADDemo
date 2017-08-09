using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImitataCad;

namespace CADDemo
{
    public partial class CADDemo : Form
    {
        GraphicDisplay pGraphicDisplay;
        //线工具的注册名
        public const string LINETOOL_REGISTERNAME = "LINETOOL_REGISTERNAME";
        //抓取工具的注册名
        public const string HANDTOOL_REGISTERNAME = "HANDTOOL_REGISTERNAME";
        //矩形工具注册名
        public const string RECTANGLETOOL_REGISTERNAME = "RECTANGLETOOL_REGISTERNAME";
        //椭圆工具注册名
        public const string ELLIPESTOOL_REGISTERNAME = "ELLIPESTOOL_REGISTERNAME";
        //圆矩形工具注册名
        public const string CIRCLERECTANGLETOOL_REGISTERNAME = "CIRCLERECTANGLETOOL_REGISTERNAME";
        //曲线工具注册名
        public const string CURVETOOL_REGISTERNAME = "CURVETOOL_REGISTERNAME";
        public CADDemo()
        {
            InitializeComponent();
            pGraphicDisplay = new GraphicDisplay(this.pic);
            pGraphicDisplay.CoordinateDisplay = this.CurveLocation;
           // pGraphicDisplay.Invalidate();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        
        private void tslLine_Click(object sender, EventArgs e)
        {
            //线工具
            pGraphicDisplay.useTool(LINETOOL_REGISTERNAME);
            pic.Invalidate();
        }

        private void tslRectangle_Click(object sender, EventArgs e)
        {
            //矩形工具
            pGraphicDisplay.useTool(RECTANGLETOOL_REGISTERNAME);
            pic.Invalidate();
        }

        private void tslEllipes_Click(object sender, EventArgs e)
        {
            //椭圆工具
            pGraphicDisplay.useTool(ELLIPESTOOL_REGISTERNAME);
            pic.Invalidate();
        }

        private void tslCircleRectangle_Click(object sender, EventArgs e)
        {
            //圆矩形工具
            pGraphicDisplay.useTool(CIRCLERECTANGLETOOL_REGISTERNAME);
            pic.Invalidate();
        }

        private void tslCurve_Click(object sender, EventArgs e)
        {
            //曲线工具
            pGraphicDisplay.useTool(CURVETOOL_REGISTERNAME);
            pic.Invalidate();
        }

        private void tslCatch_Click(object sender, EventArgs e)
        {
            pGraphicDisplay.useTool(HANDTOOL_REGISTERNAME);
            pic.Invalidate();
        }

        private void tsdpCatch_ButtonClick(object sender, EventArgs e)
        {
            pGraphicDisplay.useTool(HANDTOOL_REGISTERNAME);
            pic.Invalidate();
        }

       
    }
}
