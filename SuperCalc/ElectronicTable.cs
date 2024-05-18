using System.Windows.Forms;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualBasic;
using SuperCalc.Poliz;
using SuperCalc.AboutForms;
using SuperCalc.Parsers;
using System.Text;
using System.Linq.Expressions;

namespace SuperCalc
{
    public partial class ElectronicTable : Form
    {
        private JSONRepository _repository;
        public event Action<string> PathChanged;
        private string[,] _data;
        private Calculator _parser = new();

        public ElectronicTable()
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
            dataGridViewTable.Columns.Clear();
            while (true)
            {
                if (dataGridViewTable.ColumnCount < data.GetLength(1)
                && dataGridViewTable.RowCount < data.GetLength(0))
                {
                    dataGridViewTable.Columns.Add($"{dataGridViewTable.ColumnCount + 1}", $"{dataGridViewTable.ColumnCount + 1}");
                    dataGridViewTable.Rows.Add();
                    continue;
                }
                break;
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

            int[] coordinatesOperation = new int[2];
            int[] coordinatesResult = new int[2];

            try
            {
                string[] coordinatesOperationString = textBoxOper.Text.Split(":");
                for (int i = 0; i < 2; i++)
                {
                    coordinatesOperation[i] = int.Parse(coordinatesOperationString[i]);
                }

                string[] coordinatesResultString = textBoxResult.Text.Split(":");
                for (int i = 0; i < 2; i++)
                {
                    coordinatesResult[i] = int.Parse(coordinatesResultString[i]);
                }
                if (coordinatesOperation[0] > dataGridViewTable.RowCount || coordinatesOperation[1] > dataGridViewTable.ColumnCount || coordinatesResult[0] > dataGridViewTable.RowCount || coordinatesResult[1] > dataGridViewTable.ColumnCount)
                {
                    throw new ArgumentException("Клетка с такой координатой не существует");
                }
            }
            catch
            {
                MessageBox.Show("Координаты клеток введены неверно");
                return;
            }
            //try
            //{

                if (dataGridViewTable.Rows[coordinatesOperation[0] - 1].Cells[coordinatesOperation[1] - 1].Value == null)
                {
                    dataGridViewTable.Rows[coordinatesResult[0] - 1].Cells[coordinatesResult[1] - 1].Value = "";
                    return;
                }
                string expression = dataGridViewTable.Rows[coordinatesOperation[0] - 1].Cells[coordinatesOperation[1] - 1].Value.ToString();
                expression = ReplaceCell(expression);
                dataGridViewTable.Rows[coordinatesResult[0] - 1].Cells[coordinatesResult[1] - 1].Value =
                 _parser.Calculate(expression);

            //}
            //catch (ArgumentException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    dataGridViewTable.Rows[coordinatesResult[0] - 1].Cells[coordinatesResult[1] - 1].Value = "#ОШИБКА#";
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Неизвестная ошибка");
            //    dataGridViewTable.Rows[coordinatesResult[0] - 1].Cells[coordinatesResult[1] - 1].Value = "#ОШИБКА#";
            //}
        }

        /// <summary>
        /// Метод возвращает значение ячейки.
        /// В качестве параметра принимает ячейку в формате строка:столбец.
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private string GetValueBuyCell(string cell)
        {
            int[] coordinates = new int[2];
            string[] coordinatesOperationString = cell.Split(":");
            for (int i = 0; i < 2; i++)
            {
                coordinates[i] = int.Parse(coordinatesOperationString[i]);
            }
            string res = dataGridViewTable.Rows[coordinates[0] - 1].Cells[coordinates[1] - 1].Value.ToString();
            return dataGridViewTable.Rows[coordinates[0] - 1].Cells[coordinates[1] - 1].Value.ToString();
        }

        private string ReplaceCell(string expression)
        {
            StringBuilder res = new StringBuilder(expression);
            int indexColon = -1;
            int indexOpenQuotes;
            int indexCloseQuotes = -1;

            string cell;

            int startIndex = 0;
            int endIndex = 0;

            while (true)
            {
                indexColon = res.ToString().IndexOf(":", indexColon + 1);
                if (indexColon == -1) return res.ToString();
                while (true)
                {
                    indexOpenQuotes = res.ToString().IndexOf("\"", indexCloseQuotes + 1);
                    indexCloseQuotes = res.ToString().IndexOf("\"", indexOpenQuotes + 1);
                    if (indexColon > indexOpenQuotes && indexColon < indexCloseQuotes)
                    {
                        break;
                    }
                    if (indexColon < indexOpenQuotes || indexOpenQuotes == -1)
                    {
                        // Поиск индекса начала.

                        for (int i = indexColon - 1; i >= 0; i--)
                        {
                            if (!char.IsDigit(res.ToString()[i]))
                            {
                                break;
                            }
                            startIndex = i;
                        }
                        // Поиск индекса конца.
                        for (int i = indexColon + 1; i < res.ToString().Length; i++)
                        {
                            if (!char.IsDigit(res.ToString()[i]))
                            {
                                break;
                            }
                            endIndex = i;
                        }
                        cell = res.ToString().Substring(startIndex, endIndex - startIndex + 1);
                        res.Replace(cell, GetValueBuyCell(cell), startIndex, endIndex - startIndex + 1);
                        indexColon = -1;
                        indexCloseQuotes = -1;
                        startIndex = 0;
                        endIndex = 0;
                        break;
                    }
                }
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

        private void buttonClearTable_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewTable.RowCount; i++)
            {
                for (int j = 0; dataGridViewTable.ColumnCount > j; j++)
                {
                    dataGridViewTable.Rows[i].Cells[j].Value = "";
                }
            }
        }
    }
}
