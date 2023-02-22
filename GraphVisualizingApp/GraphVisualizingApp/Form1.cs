using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphVisualizingApp
{
    public partial class Form1 : Form
    {
        int graphSize = 10;

        public Form1()
        {
            InitializeComponent();
            FillTableTextBoxes(graphSize);
        }
        
        public void FillTableTextBoxes(int size)
        {
            for (int i = 1; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    // Filling them with 0s by default so users only have to input 1s
                    TextBox currentTb = new TextBox { Name = $"node_{i}_{j}", Text = "0" };
                    
                    tableLayout.Controls.Add(currentTb, j, i);

                    if (i == j)
                    {
                        DisableTextBox(currentTb);
                    }
                }
            }
        }

        void DisableTextBox(TextBox textBox)
        {
            textBox.Text = "0";
            textBox.Enabled = false;
            textBox.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectedGraph newGraph = new DirectedGraph(tableLayout.Controls.OfType<TextBox>().ToList());
            newGraph.Show();
        }
    }
}
