using System.Windows.Forms;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuperCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridViewTable.AllowUserToAddRows = false;
            dataGridViewTable.ColumnCount = 3;
            dataGridViewTable.RowCount = 3;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && dataGridViewTable.CurrentCell.ColumnIndex == dataGridViewTable.ColumnCount - 1)
            {
                dataGridViewTable.Columns.Add("", "");
            }
            if (e.KeyCode == Keys.Enter && dataGridViewTable.CurrentCell.RowIndex == dataGridViewTable.RowCount - 1)
            {
                dataGridViewTable.Rows.Add();
            }
            if (e.KeyCode == Keys.Home)
            {
                dataGridViewTable.CurrentCell = dataGridViewTable[0, 0];
            }
            if (e.KeyCode == Keys.End)
            {
                dataGridViewTable.CurrentCell = dataGridViewTable[dataGridViewTable.ColumnCount - 1, dataGridViewTable.RowCount - 1];
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string[,] data = new string[,]
                {
                { "q","w","e","r" },
                { "qq", "ww", "ee", "rr" },
                { "qqq", "www", "eee", "rrr" },
                {"qqqq","wwww","eeee","rrrr" },
                {"qqqqq","wwwww","eeeee","rrrrr" },
                {"1", "2", "4", "5" }
                };
            if (dataGridViewTable.ColumnCount < data.GetLength(1) && dataGridViewTable.RowCount < data.GetLength(0))
            {
                dataGridViewTable.ColumnCount = data.GetLength(1);
                dataGridViewTable.RowCount = data.GetLength(0);
            }
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    dataGridViewTable.Rows[i].Cells[j].Value = data[i, j];
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string[,] data = new string[dataGridViewTable.RowCount, dataGridViewTable.ColumnCount];
            for (int i = 0; i < dataGridViewTable.RowCount; i++)
            {
                for (int j = 0; dataGridViewTable.ColumnCount > j; j++)
                {
                    string temp = Convert.ToString(dataGridViewTable.Rows[i].Cells[j].Value ?? "");
                    data[i, j] = temp;
                }
            }
        }
    }
}
