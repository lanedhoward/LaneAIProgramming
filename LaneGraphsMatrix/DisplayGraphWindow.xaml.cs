using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LaneGraphsMatrix
{
    /// <summary>
    /// Interaction logic for DisplayGraphWindow.xaml
    /// </summary>
    public partial class DisplayGraphWindow : Window
    {
        public List<MatrixEdgeHelper> helpers;
        PointF[] points;
        private PointF startPoint;
        private float sideLength;
        public DisplayGraphWindow(List<MatrixEdgeHelper> _helpers)
        {
            InitializeComponent();
            helpers = _helpers;
            startPoint = new PointF(350, 150);
            sideLength = 100f;

            CreateNodeGraph();
            DrawPolygon(points);
            DrawEdges();
        }

        public void CreateNodeGraph()
        {
            // first, figure out how many nodes there are gonna be
            int nodes = 0;
            foreach (var helper in helpers)
            {
                if (helper.X == helper.Y) continue; //disregard the automatic 0s
                if (helper.X > nodes) nodes = helper.X;
                if (helper.Y > nodes) nodes = helper.Y;
            }

            points = new PointF[nodes];
            points[0] = startPoint;

            float internalAngleMaxDegrees = (nodes - 2) * 180;
            float eachVertexAngle = internalAngleMaxDegrees / nodes;
            float complementaryAngle = 180 - eachVertexAngle;

            float currentAngle = eachVertexAngle;
            

            // make the points
            for (int i = 1; i < nodes; i++)
            {
                float currentAngleRads = currentAngle * (MathF.PI / 180);

                float x = points[i - 1].X - (MathF.Cos(currentAngleRads) * sideLength);
                float y = points[i - 1].Y - (MathF.Sin(currentAngleRads) * sideLength);

                points[i] = new PointF(x, y);

                currentAngle += complementaryAngle;
            }
        }

        public void DrawPolygon(PointF[] _points)
        {
            for (int i = 0; i < _points.Length; i++)
            {
                var dot = new Ellipse();
                dot.Stroke = Brushes.Black;
                dot.Fill = Brushes.Blue;
                dot.Width = 10;
                dot.Height = 10;
                Canvas.SetLeft(dot, _points[i].X - dot.Width/2);
                Canvas.SetTop(dot, _points[i].Y - dot.Height/2);
                graphCanvas.Children.Add(dot);

                
            }
        }

        public void DrawLine(PointF start, PointF end, Brush brush)
        {
            Line line = new Line();
            line.Stroke = brush;
            line.X1 = start.X;
            line.Y1 = start.Y;
            line.X2 = end.X;
            line.Y2 = end.Y;
            line.StrokeThickness = 2;
            graphCanvas.Children.Add(line);
        }

        public void DrawArrow(PointF start, PointF end, Brush brush, float wingsLength)
        {
            DrawLine(start, end, brush);

            float linedir = PointDirection(start, end);

            PointF wingPoint1 = new PointF(
                end.X - (MathF.Cos(linedir + MathF.PI / 8) * wingsLength),
                end.Y - (MathF.Sin(linedir + MathF.PI / 8) * wingsLength)
                );
            PointF wingPoint2 = new PointF(
                end.X - (MathF.Cos(linedir - MathF.PI / 8) * wingsLength),
                end.Y - (MathF.Sin(linedir - MathF.PI / 8) * wingsLength)
                );

            DrawLine(end, wingPoint1, brush);
            DrawLine(end, wingPoint2, brush);
        }

        public void DrawEdges()
        {
            foreach (MatrixEdgeHelper helper in helpers)
            {
                if (helper.Connection)
                {
                    //need to draw line (arrow) from the x to the y
                    DrawArrow(points[helper.X - 1], points[helper.Y - 1], Brushes.DeepPink, 15);
                }
            }
        }

        public float PointDirection(PointF start, PointF end)
        {
            // adapted from https://stackoverflow.com/questions/12891516/math-calculation-to-retrieve-angle-between-two-points
            float xDiff = end.X - start.X;
            float yDiff = end.Y - start.Y;
            return MathF.Atan2(yDiff, xDiff);

            /*
            //forumla adapted from https://www.cuemath.com/direction-of-a-vector-formula/

            float X = (end.X - start.X);
            float Y = (end.Y - start.Y);
            float alpha = MathF.Atan(Y / X);

            if (X >= 0 && Y <= 0)
            {
                //quadrant 1
                return alpha;
            }
            else if (X < 0 && Y <= 0)
            {
                //quadrant 2
                return MathF.PI - alpha;
            }
            else if (X < 0 && Y > 0)
            {
                //quadrant 3
                return MathF.PI + alpha;
            }
            else
            {
                //quadrant 4
                return MathF.Tau - alpha;
            }
            */
        }
    }
}
