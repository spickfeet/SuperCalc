namespace SuperCalc
{
    partial class Form1
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
            buttonSave = new Button();
            textBoxCommandLine = new TextBox();
            buttonLoad = new Button();
            buttonUse = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTable
            // 
            dataGridViewTable.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataGridViewTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTable.Location = new Point(12, 41);
            dataGridViewTable.Name = "dataGridViewTable";
            dataGridViewTable.Size = new Size(1023, 564);
            dataGridViewTable.TabIndex = 0;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(12, 12);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // textBoxCommandLine
            // 
            textBoxCommandLine.Font = new Font("Segoe UI", 14F);
            textBoxCommandLine.Location = new Point(1041, 41);
            textBoxCommandLine.Name = "textBoxCommandLine";
            textBoxCommandLine.Size = new Size(113, 32);
            textBoxCommandLine.TabIndex = 2;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(93, 12);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 23);
            buttonLoad.TabIndex = 3;
            buttonLoad.Text = "Загрузить";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonUse
            // 
            buttonUse.Font = new Font("Segoe UI", 14F);
            buttonUse.Location = new Point(1041, 79);
            buttonUse.Name = "buttonUse";
            buttonUse.Size = new Size(250, 32);
            buttonUse.TabIndex = 4;
            buttonUse.Text = "Вычислить";
            buttonUse.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14F);
            textBox1.Location = new Point(1178, 41);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(113, 32);
            textBox1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Segoe UI", 14F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(1041, 13);
            label1.Name = "label1";
            label1.Size = new Size(113, 25);
            label1.TabIndex = 6;
            label1.Text = "Выражение";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1178, 13);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 7;
            label2.Text = "Результат";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(1160, 44);
            label3.Name = "label3";
            label3.Size = new Size(16, 25);
            label3.TabIndex = 8;
            label3.Text = ":";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1296, 617);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(buttonUse);
            Controls.Add(buttonLoad);
            Controls.Add(textBoxCommandLine);
            Controls.Add(buttonSave);
            Controls.Add(dataGridViewTable);
            ForeColor = SystemColors.ControlText;
            KeyPreview = true;
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewTable;
        private Button buttonSave;
        private TextBox textBoxCommandLine;
        private Button buttonLoad;
        private Button buttonUse;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
