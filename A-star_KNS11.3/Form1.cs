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
            bool countStart = false;
            if(!checkBox1.Checked && !countStart)
            {
                dataGridView1.CurrentCell.Style.BackColor = Color.Green;
                ourGrid.cells[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].isStart = true;
                countStart = true;
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool countFinish = false;
            if (!checkBox1.Checked && !countFinish)
            {
                dataGridView1.CurrentCell.Style.BackColor = Color.Red;
                ourGrid.cells[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].isFinish = true;
                countFinish = true;
            }
        }
    }
}
