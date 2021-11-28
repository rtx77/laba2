using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            dataGridView2.Columns.Add($"Column{numericUpDown1.Value}", $"F");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
       
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Columns.Count > numericUpDown1.Value)
            {
                dataGridView1.Columns.RemoveAt(Convert.ToInt32(numericUpDown1.Value));    
            }
            else
            {
                
                dataGridView1.Columns.Add($"Column{numericUpDown1.Value}", $"X {numericUpDown1.Value}");

                
                for (int i = 0; i < Math.Pow(2,(Convert.ToInt32(dataGridView1.Columns.Count)-1));i++)
                {
                    if(Convert.ToInt32(dataGridView1.Columns.Count) == 1)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows.Add();
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows.Add();
                    }
                    else{
                        dataGridView1.Rows.Add();
                        dataGridView2.Rows.Add();
                       
                    }
                    
                }
                

            }
               
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView1.Columns.Clear();
            numericUpDown1.Value = 1;
        }
    }
}
