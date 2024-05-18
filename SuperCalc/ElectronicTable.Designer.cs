namespace SuperCalc
{
    partial class ElectronicTable
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewTable = new DataGridView();
            textBoxOper = new TextBox();
            buttonUse = new Button();
            textBoxResult = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            menuStrip1 = new MenuStrip();
            toolStripMenuItemOpen = new ToolStripMenuItem();
            toolStripMenuItemSave = new ToolStripMenuItem();
            toolStripMenuItemSaveAs = new ToolStripMenuItem();
            ToolStripMenuItemAbout = new ToolStripMenuItem();
            ToolStripMenuItemMethods = new ToolStripMenuItem();
            ToolStripMenuItemInstructions = new ToolStripMenuItem();
            buttonRemoveRow = new Button();
            buttonRemoveColumn = new Button();
            comboBoxMethods = new ComboBox();
            label4 = new Label();
            buttonSelect = new Button();
            buttonClearTable = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewTable
            // 
            dataGridViewTable.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataGridViewTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTable.Location = new Point(14, 55);
            dataGridViewTable.Margin = new Padding(3, 4, 3, 4);
            dataGridViewTable.Name = "dataGridViewTable";
            dataGridViewTable.RowHeadersWidth = 51;
            dataGridViewTable.Size = new Size(1169, 752);
            dataGridViewTable.TabIndex = 0;
            dataGridViewTable.ColumnRemoved += dataGridViewTable_ColumnRemoved;
            dataGridViewTable.RowPrePaint += dgv_RowPrePaint;
            // 
            // textBoxOper
            // 
            textBoxOper.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxOper.Location = new Point(1190, 92);
            textBoxOper.Margin = new Padding(3, 4, 3, 4);
            textBoxOper.Name = "textBoxOper";
            textBoxOper.Size = new Size(187, 39);
            textBoxOper.TabIndex = 2;
            // 
            // buttonUse
            // 
            buttonUse.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            buttonUse.Location = new Point(1190, 143);
            buttonUse.Margin = new Padding(3, 4, 3, 4);
            buttonUse.Name = "buttonUse";
            buttonUse.Size = new Size(405, 96);
            buttonUse.TabIndex = 4;
            buttonUse.Text = "Вычислить";
            buttonUse.UseVisualStyleBackColor = true;
            buttonUse.Click += buttonUse_Click;
            // 
            // textBoxResult
            // 
            textBoxResult.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxResult.Location = new Point(1409, 92);
            textBoxResult.Margin = new Padding(3, 4, 3, 4);
            textBoxResult.Name = "textBoxResult";
            textBoxResult.Size = new Size(185, 39);
            textBoxResult.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(1190, 55);
            label1.Name = "label1";
            label1.Size = new Size(143, 32);
            label1.TabIndex = 6;
            label1.Text = "Выражение";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1409, 55);
            label2.Name = "label2";
            label2.Size = new Size(120, 32);
            label2.TabIndex = 7;
            label2.Text = "Результат";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(1384, 96);
            label3.Name = "label3";
            label3.Size = new Size(24, 32);
            label3.TabIndex = 8;
            label3.Text = "-";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItemOpen, toolStripMenuItemSave, toolStripMenuItemSaveAs, ToolStripMenuItemAbout });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1603, 30);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemOpen
            // 
            toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            toolStripMenuItemOpen.Size = new Size(81, 24);
            toolStripMenuItemOpen.Text = "Открыть";
            toolStripMenuItemOpen.Click += toolStripMenuItemOpen_Click;
            // 
            // toolStripMenuItemSave
            // 
            toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            toolStripMenuItemSave.Size = new Size(97, 24);
            toolStripMenuItemSave.Text = "Сохранить";
            toolStripMenuItemSave.Click += toolStripMenuItemSave_Click;
            // 
            // toolStripMenuItemSaveAs
            // 
            toolStripMenuItemSaveAs.Name = "toolStripMenuItemSaveAs";
            toolStripMenuItemSaveAs.Size = new Size(132, 24);
            toolStripMenuItemSaveAs.Text = "Сохранить как...";
            toolStripMenuItemSaveAs.Click += toolStripMenuItemSaveAs_Click;
            // 
            // ToolStripMenuItemAbout
            // 
            ToolStripMenuItemAbout.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemMethods, ToolStripMenuItemInstructions });
            ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            ToolStripMenuItemAbout.Size = new Size(118, 24);
            ToolStripMenuItemAbout.Text = "О программе";
            // 
            // ToolStripMenuItemMethods
            // 
            ToolStripMenuItemMethods.Name = "ToolStripMenuItemMethods";
            ToolStripMenuItemMethods.Size = new Size(167, 26);
            ToolStripMenuItemMethods.Text = "Методы";
            ToolStripMenuItemMethods.Click += ToolStripMenuItemMethods_Click;
            // 
            // ToolStripMenuItemInstructions
            // 
            ToolStripMenuItemInstructions.Name = "ToolStripMenuItemInstructions";
            ToolStripMenuItemInstructions.Size = new Size(167, 26);
            ToolStripMenuItemInstructions.Text = "Инструция";
            ToolStripMenuItemInstructions.Click += ToolStripMenuItemInstructions_Click;
            // 
            // buttonRemoveRow
            // 
            buttonRemoveRow.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonRemoveRow.Location = new Point(1191, 721);
            buttonRemoveRow.Name = "buttonRemoveRow";
            buttonRemoveRow.Size = new Size(200, 85);
            buttonRemoveRow.TabIndex = 10;
            buttonRemoveRow.Text = "Удалить строку";
            buttonRemoveRow.UseVisualStyleBackColor = true;
            buttonRemoveRow.Click += buttonRemoveRow_Click;
            // 
            // buttonRemoveColumn
            // 
            buttonRemoveColumn.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonRemoveColumn.Location = new Point(1398, 720);
            buttonRemoveColumn.Name = "buttonRemoveColumn";
            buttonRemoveColumn.Size = new Size(199, 85);
            buttonRemoveColumn.TabIndex = 11;
            buttonRemoveColumn.Text = "Удалить столбец";
            buttonRemoveColumn.UseVisualStyleBackColor = true;
            buttonRemoveColumn.Click += buttonRemoveColumn_Click;
            // 
            // comboBoxMethods
            // 
            comboBoxMethods.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMethods.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxMethods.FormattingEnabled = true;
            comboBoxMethods.Items.AddRange(new object[] { "МАКС(Аргумент1,Аргумент2,...)", "МИН(Аргумент1,Аргумент2,...)", "СРЕДНЕЕ(Аргумент1,Аргумент2,...)", "СУММА(Аргумент1,Аргумент2,...)", "РАВНО(Аргумент1,Аргумент2)", "БОЛЬШЕ(Аргумент1,Аргумент2)", "МЕНЬШЕ(Аргумент1,Аргумент2)", "ЗАМЕНИТЬ(Аргумент1,Аргумент2,Аргумент3,Аргумент4)", "ВСТАВИТЬ(Аргумент1,Аргумент2,Аргумент3)" });
            comboBoxMethods.Location = new Point(1191, 280);
            comboBoxMethods.Margin = new Padding(3, 4, 3, 4);
            comboBoxMethods.Name = "comboBoxMethods";
            comboBoxMethods.Size = new Size(404, 31);
            comboBoxMethods.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(1346, 243);
            label4.Name = "label4";
            label4.Size = new Size(103, 32);
            label4.TabIndex = 13;
            label4.Text = "Методы";
            // 
            // buttonSelect
            // 
            buttonSelect.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSelect.Location = new Point(1191, 321);
            buttonSelect.Margin = new Padding(3, 4, 3, 4);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(403, 56);
            buttonSelect.TabIndex = 14;
            buttonSelect.Text = "Выбрать";
            buttonSelect.UseVisualStyleBackColor = true;
            buttonSelect.Click += buttonSelect_Click;
            // 
            // buttonClearTable
            // 
            buttonClearTable.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonClearTable.Location = new Point(1398, 628);
            buttonClearTable.Name = "buttonClearTable";
            buttonClearTable.Size = new Size(199, 86);
            buttonClearTable.TabIndex = 15;
            buttonClearTable.Text = "Отчистить таблицу";
            buttonClearTable.UseVisualStyleBackColor = true;
            buttonClearTable.Click += buttonClearTable_Click;
            // 
            // ElectronicTable
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1603, 823);
            Controls.Add(buttonClearTable);
            Controls.Add(buttonSelect);
            Controls.Add(label4);
            Controls.Add(comboBoxMethods);
            Controls.Add(buttonRemoveColumn);
            Controls.Add(buttonRemoveRow);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxResult);
            Controls.Add(buttonUse);
            Controls.Add(textBoxOper);
            Controls.Add(dataGridViewTable);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ElectronicTable";
            Text = "ElectronicTable";
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewTable;
        private TextBox textBoxOper;
        private Button buttonUse;
        private TextBox textBoxResult;
        private Label label1;
        private Label label2;
        private Label label3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItemSave;
        private ToolStripMenuItem toolStripMenuItemOpen;
        private ToolStripMenuItem toolStripMenuItemSaveAs;
        private Button buttonRemoveRow;
        private Button buttonRemoveColumn;
        private ComboBox comboBoxMethods;
        private Label label4;
        private Button buttonSelect;
        private ToolStripMenuItem ToolStripMenuItemAbout;
        private ToolStripMenuItem ToolStripMenuItemMethods;
        private ToolStripMenuItem ToolStripMenuItemInstructions;
        private Button buttonClearTable;
    }
}
