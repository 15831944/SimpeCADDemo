using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitataCad
{
    /// <summary>
    /// 实现测量坐标系与显示坐标系的坐标转换类
    /// </summary>
    public class Transform
    {
        /// <summary>
        /// 屏幕绘图区域中心点的X坐标值，显示坐标系
        /// </summary>
        public float PaintAreaCenterX { get; set; }
        /// <summary>
        /// 屏幕绘图区域中心点的Y坐标值，显示坐标系
        /// </summary>
        public float PaintAreaCenterY { get; set; }
        /// <summary>
        /// 缩放比例，测量坐标系下的图形乘上本缩放比例，就是显示坐标系下的图形大小
        /// </summary>
        public double Scale { get; set; }
        /// <summary>
        /// 屏幕绘图区域中心点的X坐标值，测量坐标系
        /// </summary>
        public double DisplayCenterX { get; set; }
        /// <summary>
        /// 屏幕绘图区域中心点的Y坐标值，测量坐标系
        /// </summary>
        public double DisplayCenterY { get; set; }
        /// <summary>
        /// 整个图形的最小X坐标
        /// </summary>
        public double minX { get; set; }
        /// <summary>
        /// 整个图形的最小Y坐标
        /// </summary>
        public double minY { get; set; }
        /// <summary>
        /// 整个图形的最大X坐标
        /// </summary>
        public double maxX { get; set; }
        /// <summary>
        /// 整个图形的最大Y坐标
        /// </summary>
        public double maxY { get; set; }
        /// <summary>
        /// 计算测量坐标值在显示坐标系下的坐标
        /// </summary>
        /// <param name="surveyX">测量坐标X的值</param>
        /// <param name="surveyY">测量坐标Y的值</param>
        /// <param name="paintX">显示坐标X的值</param>
        /// <param name="paintY">显示坐标Y的值</param>
        /// <returns></returns>
        public short ToPaintXY(double surveyX, double surveyY, out float paintX, out float paintY)
        {
            // 绘图坐标系正好是测量指标系顺时针旋转90°后的结果
            paintX = (float)(PaintAreaCenterX + Scale * (surveyY - DisplayCenterY));
            paintY = (float)(PaintAreaCenterY - Scale * (surveyX - DisplayCenterX));
            if (paintX < 0 || paintX > 2 * PaintAreaCenterX
                || paintY < 0 || paintY > 2 * PaintAreaCenterY
                )
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        /// <summary>
        /// 计算显示坐标值在测量坐标系下的坐标
        /// </summary>
        /// <param name="paintX">显示坐标X的值</param>
        /// <param name="paintY">显示坐标Y的值</param>
        /// <param name="surveyX">测量坐标X的值</param>
        /// <param name="surveyY">测量坐标Y的值</param>
        public void ToSurveyXY(float paintX, float paintY, out double surveyX, out double surveyY)
        {
            surveyY = DisplayCenterY + (paintX - PaintAreaCenterX) / Scale;
            surveyX = DisplayCenterX - (paintY - PaintAreaCenterY) / Scale;
        }
        double curMinX, curMinY, curMaxX, curMaxY;//表示当前可视区域的测量坐标范围
        /// <summary>
        /// 计算当前缩放比例下，可视区域的测量坐标范围值
        /// </summary>
        /// <returns>true--成功  false--失败</returns>
        public bool DisplayMinMaxXY()
        {
            if (Scale != 0)
            {
                ToSurveyXY(0, 0, out curMaxX, out curMinY);//绘图板左上角
                ToSurveyXY(PaintAreaCenterX * 2, PaintAreaCenterY * 2, out curMinX, out curMaxY);//绘图板右下角
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 测试测量坐标是否在可视区域内
        /// </summary>
        /// <param name="x">测量X坐标</param>
        /// <param name="y">测量Y坐标</param>
        /// <returns>true--内  false--外</returns>
        public bool IsSurveyPointInCurrentDisplayArea(double x, double y)
        {
            if (x < curMinX || x > curMaxX || y < curMinY || y > curMaxY) return false; else return true;
        }
        /// <summary>
        /// 测试测量区域是否与可视区域内有重叠
        /// </summary>
        /// <param name="minX">最小X坐标</param>
        /// <param name="minY">最小Y坐标</param>
        /// <param name="maxX">最大X坐标</param>
        /// <param name="maxY">最大Y坐标</param>
        /// <returns></returns>
        public bool IsSurveyPointInCurrentDisplayArea(double minX, double minY, double maxX, double maxY)
        {
            //平行线  x1 ,x2
            if (((minX >= curMinX && minX <= curMaxX) || (maxX >= curMinX && maxX <= curMaxX))
                && (minY <= curMaxY && maxY >= curMinY))
                return true;
            //垂直线 y1,y2
            if (((minY >= curMinY && minY <= curMaxY) || (maxY >= curMinY && maxY <= curMaxY))
                && (minX <= curMaxX && maxX >= curMinX))
                return true;
            //平行线  curMinX ,curMaxX
            if (((curMinX >= minX && curMinX <= maxX) || (curMaxX >= minX && curMaxX <= maxX))
                && (curMinY <= maxY && curMaxY >= minY))
                return true;
            //垂直线 curMinY,curMaxY
            if (((curMinY >= minY && curMinY <= maxY) || (curMaxY >= minY && curMaxY <= maxY))
                && (curMinX <= maxX && curMaxX >= minX))
                return true;
            return false;
        }
        /// <summary>
        /// 设置能看到全部图形的显示参数
        /// </summary>
        /// <param name="width">显示区域的宽度，单位：像素</param>
        /// <param name="height">显示区域的高度，单位：像素</param>
        public void AllDisplay(float width, float height)
        {
            DisplayCenterX = (minX + maxX) / 2;
            DisplayCenterY = (minY + maxY) / 2;
            PaintAreaCenterX = width / 2;
            PaintAreaCenterY = height / 2;
            Scale = width / (maxX - minX);
            double s1 = height / (maxY - minY);
            if (s1 < Scale) Scale = s1;
        }
        /// <summary>
        /// 设置显示区域的大小
        /// </summary>
        /// <param name="width">显示区域的宽度，单位：像素</param>
        /// <param name="height">显示区域的高度，单位：像素</param>
        public void SetDisplayArea(float width, float height)
        {
            PaintAreaCenterX = width / 2;
            PaintAreaCenterY = height / 2;
        }
        /// <summary>
        /// 测量坐标方位角到显示坐标角度的转换
        /// </summary>
        /// <param name="ang">测量方位角，单位：弧度</param>
        /// <returns>显示坐标角度，单位：度</returns>
        public float AngleSurveyToPaint(double ang)
        {
            ang -= Math.PI / 2;
            if (ang < 0) ang += 2 * Math.PI;
            return (float)(ang * 180.0 / Math.PI);//度为单位
        }
    }
}
