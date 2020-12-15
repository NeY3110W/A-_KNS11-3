using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_star_KNS11._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dataGridView1.CurrentCell.Style.BackColor = Color.Black;
                ourGrid.cells[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].isWalkable = false;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(!checkBox1.Checked && checkedStart)
            {
                dataGridView1.CurrentCell.Style.BackColor = Color.Green;
                ourGrid.cells[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].isStart = true;
                checkedStart = false;
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!checkBox1.Checked && checkedFinish)
            {
                dataGridView1.CurrentCell.Style.BackColor = Color.Red;
                ourGrid.cells[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].isFinish = true;
                ourGrid.cells[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].isStart = false;
                checkedFinish = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ourGrid.SearchPath();
            for(int i = 0; i < ourGrid.cells.GetLength(0); i++)
            {
                for(int j = 0; j < ourGrid.cells.GetLength(1); j++)
                {
                    if(ourGrid.cells[i,j].isPath == true)
                    {
                        dataGridView1[i, j].Style.BackColor = Color.Yellow;
                        valueString = Convert.ToString(ourGrid.cells[i, j].H) + "(" + Convert.ToString(ourGrid.cells[i, j].F) + "," + Convert.ToString(ourGrid.cells[i, j].G) + ")";
                        dataGridView1[i, j].Value = valueString;
                        
                    }
                }
            }
        }
    }
}
