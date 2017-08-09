namespace CADDemo
{
    partial class CADDemo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslLine = new System.Windows.Forms.ToolStripLabel();
            this.tslRectangle = new System.Windows.Forms.ToolStripLabel();
            this.tslEllipes = new System.Windows.Forms.ToolStripLabel();
            this.tslCircleRectangle = new System.Windows.Forms.ToolStripLabel();
            this.tslCurve = new System.Windows.Forms.ToolStripLabel();
            this.tslCatch = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tspScaleName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.CurveLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsdpCatch = new System.Windows.Forms.ToolStripSplitButton();
            this.pic = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslLine,
            this.tslRectangle,
            this.tslEllipes,
            this.tslCircleRectangle,
            this.tslCurve,
            this.tslCatch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(918, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslLine
            // 
            this.tslLine.Name = "tslLine";
            this.tslLine.Size = new System.Drawing.Size(56, 22);
            this.tslLine.Text = "绘制直线";
            this.tslLine.Click += new System.EventHandler(this.tslLine_Click);
            // 
            // tslRectangle
            // 
            this.tslRectangle.Name = "tslRectangle";
            this.tslRectangle.Size = new System.Drawing.Size(56, 22);
            this.tslRectangle.Text = "绘制矩形";
            this.tslRectangle.Click += new System.EventHandler(this.tslRectangle_Click);
            // 
            // tslEllipes
            // 
            this.tslEllipes.Name = "tslEllipes";
            this.tslEllipes.Size = new System.Drawing.Size(56, 22);
            this.tslEllipes.Text = "绘制椭圆";
            this.tslEllipes.Click += new System.EventHandler(this.tslEllipes_Click);
            // 
            // tslCircleRectangle
            // 
            this.tslCircleRectangle.Name = "tslCircleRectangle";
            this.tslCircleRectangle.Size = new System.Drawing.Size(68, 22);
            this.tslCircleRectangle.Text = "绘制圆矩形";
            this.tslCircleRectangle.Click += new System.EventHandler(this.tslCircleRectangle_Click);
            // 
            // tslCurve
            // 
            this.tslCurve.Name = "tslCurve";
            this.tslCurve.Size = new System.Drawing.Size(56, 22);
            this.tslCurve.Text = "绘制曲线";
            this.tslCurve.Click += new System.EventHandler(this.tslCurve_Click);
            // 
            // tslCatch
            // 
            this.tslCatch.Name = "tslCatch";
            this.tslCatch.Size = new System.Drawing.Size(32, 22);
            this.tslCatch.Text = "捕捉";
            this.tslCatch.Click += new System.EventHandler(this.tslCatch_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspScaleName,
            this.tspScale,
            this.toolStripStatusLabel1,
            this.CurveLocation,
            this.tsdpCatch});
            this.statusStrip1.Location = new System.Drawing.Point(0, 362);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(918, 23);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tspScaleName
            // 
            this.tspScaleName.Name = "tspScaleName";
            this.tspScaleName.Size = new System.Drawing.Size(44, 18);
            this.tspScaleName.Text = "比例尺";
            // 
            // tspScale
            // 
            this.tspScale.Name = "tspScale";
            this.tspScale.Size = new System.Drawing.Size(37, 18);
            this.tspScale.Text = " 1:1  ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 18);
            this.toolStripStatusLabel1.Text = "坐标";
            // 
            // CurveLocation
            // 
            this.CurveLocation.Name = "CurveLocation";
            this.CurveLocation.Size = new System.Drawing.Size(28, 18);
            this.CurveLocation.Text = "     ";
            // 
            // tsdpCatch
            // 
            this.tsdpCatch.Image = global::CADDemo.Properties.Resources.hand;
            this.tsdpCatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdpCatch.Name = "tsdpCatch";
            this.tsdpCatch.Size = new System.Drawing.Size(64, 21);
            this.tsdpCatch.Text = "捕捉";
            this.tsdpCatch.ButtonClick += new System.EventHandler(this.tsdpCatch_ButtonClick);
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic.Location = new System.Drawing.Point(0, 25);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(918, 337);
            this.pic.TabIndex = 2;
            this.pic.TabStop = false;
            // 
            // CADDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 385);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CADDemo";
            this.Text = "CADDemo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslLine;
        private System.Windows.Forms.ToolStripLabel tslRectangle;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.ToolStripLabel tslEllipes;
        private System.Windows.Forms.ToolStripLabel tslCircleRectangle;
        private System.Windows.Forms.ToolStripLabel tslCurve;
        private System.Windows.Forms.ToolStripLabel tslCatch;
        private System.Windows.Forms.ToolStripStatusLabel tspScaleName;
        private System.Windows.Forms.ToolStripStatusLabel tspScale;
        private System.Windows.Forms.ToolStripStatusLabel CurveLocation;
        private System.Windows.Forms.ToolStripSplitButton tsdpCatch;
    }
}

