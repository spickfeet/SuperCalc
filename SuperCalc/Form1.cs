using System.Windows.Forms;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualBasic;
using SuperCalc.Poliz;
using SuperCalc.AboutForms;

namespace SuperCalc
{
    public partial class Form1 : Form
    {
        private JSONRepository _repository;
        public event Action<string> PathChanged;
        private string[,] _data;

        public Form1()
        {
            InitializeComponent();
            dataGridViewTable.AllowUserToAddRows = false;

            for (int i = 1; i <= 4; i++)
            {
                dataGridViewTable.Columns.Add($"{i}", $"{i}");
                dataGridViewTable.Rows.Add();
            }

            _repository = new JSONRepository();
            PathChanged += _repository.OnPathChanged;
        }

        private void ColumnRecount()
        {
            for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
            {
                dataGridViewTable.Columns[i].HeaderText = (i + 1).ToString();

            }
        }
        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object head = this.dataGridViewTable.Rows[e.RowIndex].HeaderCell.Value;
            if (head == null || !head.Equals((e.RowIndex + 1).ToString()))
                this.dataGridViewTable.Rows[e.RowIndex].HeaderCell.Value =
                (e.RowIndex + 1).ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && dataGridViewTable.CurrentCell.ColumnIndex == dataGridViewTable.ColumnCount - 1)
            {
                dataGridViewTable.Columns.Add($"{dataGridViewTable.ColumnCount + 1}", $"{dataGridViewTable.ColumnCount + 1}");
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
        private void ReadData()
        {
            _data = new string[dataGridViewTable.RowCount, dataGridViewTable.ColumnCount];

            for (int i = 0; i < dataGridViewTable.RowCount; i++)
            {
                for (int j = 0; dataGridViewTable.ColumnCount > j; j++)
                {
                    string temp = Convert.ToString(dataGridViewTable.Rows[i].Cells[j].Value ?? "");
                    _data[i, j] = temp;
                }
            }
        }
        private void toolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            ReadData();

            if (string.IsNullOrEmpty(_repository.PathName))
                if (TryChoosePath() == false) return;

            _repository.Save(_data);
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            if (TryOpen() == false) return;

            string[,] data = _repository.GetData();

            dataGridViewTable.ColumnCount = data.GetLength(1);
            dataGridViewTable.RowCount = data.GetLength(0);

            DisplayTable(data);
        }

        private void toolStripMenuItemSaveAs_Click(object sender, EventArgs e)
        {
            if (TryChoosePath() == false) return;

            ReadData();
            _repository.Save(_data);
        }

        private void DisplayTable(string[,] data)
        {
            if (dataGridViewTable.ColumnCount < data.GetLength(1)
                && dataGridViewTable.RowCount < data.GetLength(0))
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

        private bool TryChoosePath()
        {
            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                AddExtension = true,
                Filter = "JSON | *.json",
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string pathName = fileDialog.FileName;
                PathChanged?.Invoke(pathName);

                if (!File.Exists(pathName))
                    File.Create(pathName).Close();

                return true;
            }
            else { return false; }
        }

        private bool TryOpen()
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                AddExtension = true,
                Filter = "JSON | *.json",
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string pathName = fileDialog.FileName;
                PathChanged?.Invoke(pathName);

                return true;
            }
            else { return false; }
        }

        private void buttonRemoveRow_Click(object sender, EventArgs e)
        {
            if (dataGridViewTable.RowCount > 1)
            {
                dataGridViewTable.Rows.RemoveAt(dataGridViewTable.CurrentCell.RowIndex);
            }
        }

        private void buttonRemoveColumn_Click(object sender, EventArgs e)
        {
            if (dataGridViewTable.ColumnCount > 1)
            {
                dataGridViewTable.Columns.RemoveAt(dataGridViewTable.CurrentCell.ColumnIndex);
            }
        }

        private void dataGridViewTable_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            ColumnRecount();
        }

        private void buttonUse_Click(object sender, EventArgs e)
        {
            try
            {
                string[] coordinatesOperation = textBoxOper.Text.Split(":");
                string[] coordinatesResult = textBoxResult.Text.Split(":");
                dataGridViewTable.Rows[int.Parse(coordinatesResult[0]) - 1].Cells[int.Parse(coordinatesResult[1]) - 1].Value =
                    RPN.Calculate(dataGridViewTable.Rows[int.Parse(coordinatesOperation[0]) - 1].Cells[int.Parse(coordinatesOperation[1]) - 1].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Координаты клеток введены неверно");
            }

        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            dataGridViewTable.CurrentCell.Value += comboBoxMethods.Text;
        }

        private void ToolStripMenuItemMethods_Click(object sender, EventArgs e)
        {
            AboutMethods aboutMethods = new AboutMethods();
            aboutMethods.Show();
        }

        private void ToolStripMenuItemInstructions_Click(object sender, EventArgs e)
        {
            AboutInstructions aboutInstructions = new AboutInstructions();
            aboutInstructions.Show();
        }
    }
}
