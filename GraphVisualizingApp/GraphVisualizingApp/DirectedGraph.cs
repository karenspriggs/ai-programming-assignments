using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphVisualizingApp
{
    public partial class DirectedGraph : Form
    {
        List<TextBox> edges = new List<TextBox>();
        List<Edge> edgeList = new List<Edge>();

        Color[] colorArray = new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Cyan, Color.Blue, Color.Purple, Color.Pink };
        int currentColorIndex = 0;

        Point Origin = new Point(200, 200);
        Point[] vertices;

        int sideCount = 0;
        int circleOffset = 10;
        int edgeLength = 100;

        public DirectedGraph()
        {
            InitializeComponent();
        }

        public DirectedGraph(List<TextBox> _textBoxList)
        {
            InitializeComponent();
            edges = _textBoxList; 
        }

        private void DirectedGraph_Paint(object sender, PaintEventArgs e)
        {
            if (CheckMatrixInput())
            {
                MakeEdgeList();
                CountVertices();
                MakeVertices();
                DrawGraph(e);
            }
            else
            {
                MessageBox.Show("The adjacency matrix you entered is invalid, please close the graph window and enter valid entries.");
            }
        }

        void DrawCircle(Point circlePoint, PaintEventArgs e)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            Rectangle circleRect = new Rectangle(new Point(circlePoint.X- circleOffset, circlePoint.Y - circleOffset), new Size(20, 20));
            e.Graphics.FillEllipse(myBrush, circleRect);
        }

        void DrawArrow(Point point1, Point point2, PaintEventArgs e)
        {
            Pen arrowPen = new Pen(colorArray[SelectColor()], 6);
            arrowPen.EndCap = LineCap.ArrowAnchor;

            int endpointX;
            int endpointY;

            if (point1.X == point2.X)
            {
                endpointX = point2.X;
            } else
            {
                if (point1.X > point2.X)
                {
                    endpointX = point2.X + circleOffset;
                }
                else
                {
                    endpointX = point2.X - circleOffset;
                }
            }

            if (point1.Y == point2.Y)
            {
                endpointY = point2.Y;
            } else
            {
                if (point1.Y > point2.Y)
                {
                    endpointY = point2.Y + circleOffset;
                }
                else
                {
                    endpointY = point2.Y - circleOffset;
                }
            }

            e.Graphics.DrawLine(arrowPen, point1, new Point(endpointX, endpointY));
        }

        int SelectColor() { 
            if (currentColorIndex + 2 > colorArray.Length)
            {
                currentColorIndex = 0;
            } else
            {
                currentColorIndex++;
            }

            return currentColorIndex;
        }

        void MakeVertices()
        {
            vertices = new Point[sideCount];
            vertices[0] = Origin;

            int internalAngleCount = (sideCount - 2) / 180;
            int anglePerSide = internalAngleCount / sideCount;

            int currentdegree = anglePerSide;
            int degreeOffsetPerEdge = 360 / sideCount;

            for (int i = 1; i < vertices.Length; i++)
            {
                double radianPerSide = currentdegree * (Math.PI / 180);
                double sinPerSide = Math.Sin(radianPerSide);
                double cosPerSide = Math.Cos(radianPerSide);

                double yValue = vertices[i - 1].Y - sinPerSide * edgeLength;
                double xValue = vertices[i - 1].X - cosPerSide * edgeLength;

                vertices[i] = new Point((int)xValue, (int)yValue);

                currentdegree -= degreeOffsetPerEdge;
            }
        }

        void DrawGraph(PaintEventArgs e)
        {
            foreach(Point vertexPoint in vertices)
            {
                DrawCircle(vertexPoint, e);
            }

            foreach (Edge edge in edgeList)
            {
                if (edge.isConnected)
                {
                    int startingPointIndex = edge.colNum-1;
                    int endingPointIndex = edge.rowNum-1;
                    DrawArrow(vertices[startingPointIndex], vertices[endingPointIndex], e);
                }
            }
        }

        bool CheckMatrixInput()
        {
            foreach (TextBox textBox in edges)
            {
                if (textBox.Text != "0" && textBox.Text != "1")
                {
                    return false;
                }
            }

            return true;
        }

        void CountVertices()
        {
            foreach(Edge edge in edgeList)
            {
                if (edge.isConnected)
                {
                    if (edge.rowNum > sideCount)
                    {
                        sideCount = edge.rowNum;
                    }

                    if (edge.colNum > sideCount)
                    {
                        sideCount = edge.colNum;
                    }
                }
            }
        }

        void MakeEdgeList()
        {
            foreach(TextBox textBox in edges)
            {
                edgeList.Add(new Edge(textBox.Text, textBox.Name.Substring(5, 1), textBox.Name.Substring(7, 1)));
            }
        }
    }
}
