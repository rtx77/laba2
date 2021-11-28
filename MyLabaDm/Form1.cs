using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;


namespace MyLabaDm
{
    public partial class Form1 : Form 
    {
        Graph GRAPH;
        List<Vertex> V;
        List<Edge> E;
        public int sumEdge = 0;
        public int a = 0;
        public int sw = 0;
        public int nesw = 0;

        public List<int> list = new List<int>();

        public int pln_edge, pln_vertex = 0;

        public int chosen1, chosen2;

        public Form1()
        {
            InitializeComponent();
            GRAPH = new Graph(pictureBox1.Width, pictureBox1.Height);
            V = new List<Vertex>();
            E = new List<Edge>();
            pictureBox1.Image = GRAPH.GetBitmap();
           
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void VertexButton_Click(object sender, EventArgs e)
        {
            VertexDraw.Enabled = false;
            EdgeDraw.Enabled = true;
            GRAPH.Picturebox1Clear();
            GRAPH.DRAWGRAF(V, E);
            pictureBox1.Image = GRAPH.GetBitmap();
            
        }

        private void EdgeButton_Click(object sender, EventArgs e)
        {
            EdgeDraw.Enabled = false;
            VertexDraw.Enabled = true;
            GRAPH.Picturebox1Clear();
            GRAPH.DRAWGRAF(V, E);
            pictureBox1.Image = GRAPH.GetBitmap();
            chosen1 = -1;
            chosen2 = -1;

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateGraph_Click(object sender, EventArgs e)
        {
            //List<Vertex> vershini = new List<Vertex>();
            //List<Edge> rebra = new List<Edge>();
            //button1.Enabled = false;
            //VertexDraw.Enabled = true;
            //EdgeDraw.Enabled = true;
            //GRAPH.Picturebox1Clear();
            //GRAPH.DRAWGRAF(vershini, rebra);
            //pictureBox1.Image = GRAPH.GetBitmap();

        }

        private void SumEdge_Click(object sender, EventArgs e)
        {
            int b = 0;
            for (int i = 0; i < sumEdge; i++)
            {
                b = b + 1;
                a = a + 1;

            }
            
            label2.Text ="Сумма всех степеней вершин графа " +b.ToString();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Sviaznii_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if((pln_vertex*(pln_vertex-1)/2 == pln_edge) && pln_edge != 0)
            {
                label2.Text = "Полный граф";
            }
            else{
                label2.Text = "Не полный граф";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] array = list.ToArray();

            for (int j = 0; j < V.Count; j++)
            {
                if (!array.Contains(j))
                {
                    label1.Text = "Не связанный граф";
                    goto indicator;
                }
            }
            label1.Text = "связанный граф";
        indicator: array[0] = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int [] array = list.ToArray();


            int m = 0;
            for (int j = 0;j< V.Count; j++)
            {
                m = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == j)
                    {
                        m++;
                    }
                }
                if(m % 2 == 0)
                {
                    sw++;
                }
                else
                {
                    nesw++;
                }
            }


            label1.Text = "Четные " + sw + "  Нечетные " + nesw;
            sw = 0;
            nesw = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < (int)numericUpDown1.Value; i++)
            {
                Random rnd = new Random();
                int month = rnd.Next(10, pictureBox1.Size.Width);
                int dice = rnd.Next(10, pictureBox1.Size.Height);
                V.Add(new Vertex(pictureBox1.Location.X - month, pictureBox1.Location.Y - dice));
                GRAPH.DrawVertex(pictureBox1.Location.X - month, pictureBox1.Location.Y - dice, V.Count.ToString());
                pictureBox1.Image = GRAPH.GetBitmap();
                pln_vertex += 1;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (VertexDraw.Enabled==false)
            {
                label1.Text = "draw";
                V.Add(new Vertex(e.X,e.Y));
                GRAPH.DrawVertex(e.X, e.Y, V.Count.ToString());
                pictureBox1.Image = GRAPH.GetBitmap();
                pln_vertex += 1;

            }
            if (EdgeDraw.Enabled==false)
            {
               
                if (e.Button==MouseButtons.Left)
                {         
                    for (int i = 0; i < V.Count; i++)
                    {             
                        if (Math.Pow(V[i].x - e.X, 2) + Math.Pow(V[i].y - e.Y, 2) <= GRAPH.R * GRAPH.R)
                        { 
                            if (chosen1 == -1)
                            {
                                label1.Text = (i + 1).ToString();
                                list.Add(i);
                                list.Sort();
                                //GRAPH.DrawSelectedVertex(V[i].x, V[i].y);

                                chosen1 = i;
                                pictureBox1.Image = GRAPH.GetBitmap();
                                sumEdge += 1;
                                break;
                            }                   
                            if (chosen2 == -1)
                            {
                                label1.Text = (i + 1).ToString();
                                list.Add(i);
                                list.Sort();
                                //GRAPH.DrawSelectedVertex(V[i].x, V[i].y);
                                chosen2 = i;
                                E.Add(new Edge(chosen1, chosen2));
                                GRAPH.DrawEdge(V[chosen1], V[chosen2], E[E.Count - 1]);
                                
                                chosen1 = -1;
                                chosen2 = -1;
                                pictureBox1.Image = GRAPH.GetBitmap();
                                sumEdge += 1;
                                pln_edge += 1;
                                label1.Text = "-";
                                break;
                            }
                           
                        }
      
                    }
                }
            }

        }
    }
}
