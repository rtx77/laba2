using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLabaDm
{
    class Vertex
    {
        public int x, y;

        public Vertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Edge
    {
        public int v1, v2;

        public Edge(int v1, int v2)
        {
           this.v1 = v1;
           this.v2 = v2;
        }
    }
    class Graph
    {
        Bitmap bitmap;
        Pen BlackPen;
        Pen RedPen;
        Pen BlackPen2;
        Pen Bluepen;
        Graphics graphics;
        Font font;
        Brush brush;
        PointF point;
        public int R = 25;
        
        public Graph()
        {

        }

        public Graph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
            Picturebox1Clear();
            BlackPen = new Pen(Color.Black);
            BlackPen.Width = 3;
            RedPen = new Pen(Color.Red);
            RedPen.Width = 3;
            BlackPen2 = new Pen(Color.Black);
            BlackPen2.Width = 2;
            font = new Font("Times New Roman", 15);
            Bluepen = new Pen(Color.Blue);
            Bluepen.Width = 5;
            brush = Brushes.Black;
        }
        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void Picturebox1Clear()
        {
            graphics.Clear(Color.White);
        }
        public void DRAWGRAF(List<Vertex> V, List<Edge> E)
        {
            //рёбра
            for (int i = 0; i <E.Count; i++)
            {
                if (E[i].v1 == E[i].v2)
                {

                    graphics.DrawArc(Bluepen, (V[E[i].v1].x - 2 * R), (V[E[i].v1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(V[E[i].v1].x - (int)(2.75 * R), V[E[i].v1].y - (int)(2.75 * R));
                }
                else
                {
                    graphics.DrawLine(Bluepen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x, V[E[i].v2].y);
                    point = new PointF((V[E[i].v1].x + V[E[i].v2].x) / 2, (V[E[i].v1].y + V[E[i].v2].y) / 2);
                }
            }
            //вершины
            for (int i = 0; i < V.Count; i++)
            {
                
                DrawVertex(V[i].x, V[i].y, (i + 1).ToString());
            }
        }

        public void DrawVertex(int x, int y, string number)
        {
            graphics.FillEllipse(Brushes.White, x - R, y - R, 2 * R, 2 * R);
            graphics.DrawEllipse(BlackPen, x - R, y - R, 2 * R, 2 * R);
            point = new PointF(x - 8, y - 10);
            graphics.DrawString(number,font,brush,point);
        }

        public void DrawEdge(Vertex vertex1, Vertex vertex2, Edge E)
        {
            if (E.v1 == E.v2)
            {
                graphics.DrawArc(Bluepen, (vertex1.x - 2 * R), (vertex1.y - 2 * R), 2 * R, 2 * R, 90, 270);
                point = new PointF(vertex1.x - (int)(2.75 * R), vertex1.y - (int)(2.75 * R));
                DrawVertex(vertex1.x, vertex1.y, (E.v1 + 1).ToString());
            }
            else
            {
                graphics.DrawLine(Bluepen, vertex1.x, vertex1.y, vertex2.x, vertex2.y);
                point = new PointF((vertex2.x + vertex1.x) / 2, (vertex1.y + vertex2.y) / 2);
                DrawVertex(vertex1.x, vertex1.y, (E.v1 + 1).ToString());
                DrawVertex(vertex2.x, vertex2.y, (E.v2 + 1).ToString());
            }
        }
        
        public void DrawGraphPart(Vertex v1, Vertex v2, Edge e)
        {

        }

        public void DrawSelectedVertex(int x, int y)
        {
            graphics.DrawEllipse(RedPen, (x - R), (y - R), 2 * R, 2 * R);
        }



    }
}
