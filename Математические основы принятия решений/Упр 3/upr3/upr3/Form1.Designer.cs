namespace upr3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button1 = new System.Windows.Forms.Button();
            this.ButtonArray = new System.Windows.Forms.Button();
            this.Button_Pareto = new System.Windows.Forms.Button();
            this.dataGridViewPareto = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewPareto1 = new System.Windows.Forms.DataGridView();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button_Suzhenie = new System.Windows.Forms.Button();
            this.Button_Prog = new System.Windows.Forms.Button();
            this.textBox_krit = new System.Windows.Forms.TextBox();
            this.textBox_otv = new System.Windows.Forms.TextBox();
            this.label_Result = new System.Windows.Forms.Label();
            this.label_wi = new System.Windows.Forms.Label();
            this.label_wj = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPareto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPareto1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(832, 251);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Вывод";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ButtonArray
            // 
            this.ButtonArray.Location = new System.Drawing.Point(843, 546);
            this.ButtonArray.Name = "ButtonArray";
            this.ButtonArray.Size = new System.Drawing.Size(75, 23);
            this.ButtonArray.TabIndex = 1;
            this.ButtonArray.Text = "Массив";
            this.ButtonArray.UseVisualStyleBackColor = true;
            this.ButtonArray.Click += new System.EventHandler(this.ButtonArray_Click);
            // 
            // Button_Pareto
            // 
            this.Button_Pareto.Location = new System.Drawing.Point(843, 575);
            this.Button_Pareto.Name = "Button_Pareto";
            this.Button_Pareto.Size = new System.Drawing.Size(75, 23);
            this.Button_Pareto.TabIndex = 2;
            this.Button_Pareto.Text = "Вычислить";
            this.Button_Pareto.UseVisualStyleBackColor = true;
            this.Button_Pareto.Click += new System.EventHandler(this.Button_Pareto_Click);
            // 
            // dataGridViewPareto
            // 
            this.dataGridViewPareto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPareto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridViewPareto.Location = new System.Drawing.Point(8, 2);
            this.dataGridViewPareto.Name = "dataGridViewPareto";
            this.dataGridViewPareto.RowHeadersWidth = 51;
            this.dataGridViewPareto.Size = new System.Drawing.Size(1032, 235);
            this.dataGridViewPareto.TabIndex = 3;
            this.dataGridViewPareto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPareto_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Критерий 1";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Критерий 2";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Критерий 3";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Критерий 4";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Критерий 5";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Критерий 6";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // dataGridViewPareto1
            // 
            this.dataGridViewPareto1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPareto1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column9});
            this.dataGridViewPareto1.Location = new System.Drawing.Point(12, 290);
            this.dataGridViewPareto1.Name = "dataGridViewPareto1";
            this.dataGridViewPareto1.RowHeadersWidth = 51;
            this.dataGridViewPareto1.Size = new System.Drawing.Size(1028, 213);
            this.dataGridViewPareto1.TabIndex = 4;
            this.dataGridViewPareto1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPareto1_CellContentClick);
            // 
            // Column11
            // 
            this.Column11.HeaderText = "";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.Width = 125;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Критерий 1";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.Width = 125;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Критерий 2";
            this.Column13.MinimumWidth = 6;
            this.Column13.Name = "Column13";
            this.Column13.Width = 125;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Критерий 3";
            this.Column14.MinimumWidth = 6;
            this.Column14.Name = "Column14";
            this.Column14.Width = 125;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Критерий 4";
            this.Column15.MinimumWidth = 6;
            this.Column15.Name = "Column15";
            this.Column15.Width = 125;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Критерий 5";
            this.Column16.MinimumWidth = 6;
            this.Column16.Name = "Column16";
            this.Column16.Width = 125;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "Критерий 6";
            this.Column17.MinimumWidth = 6;
            this.Column17.Name = "Column17";
            this.Column17.Width = 125;
            // 
            // Button_Suzhenie
            // 
            this.Button_Suzhenie.Location = new System.Drawing.Point(212, 526);
            this.Button_Suzhenie.Name = "Button_Suzhenie";
            this.Button_Suzhenie.Size = new System.Drawing.Size(89, 23);
            this.Button_Suzhenie.TabIndex = 5;
            this.Button_Suzhenie.Text = "Сужение 5.5";
            this.Button_Suzhenie.UseVisualStyleBackColor = true;
            this.Button_Suzhenie.Click += new System.EventHandler(this.Button_Suzhenie_Click);
            // 
            // Button_Prog
            // 
            this.Button_Prog.Location = new System.Drawing.Point(315, 526);
            this.Button_Prog.Name = "Button_Prog";
            this.Button_Prog.Size = new System.Drawing.Size(81, 23);
            this.Button_Prog.TabIndex = 6;
            this.Button_Prog.Text = "Сужение 5.6";
            this.Button_Prog.UseVisualStyleBackColor = true;
            this.Button_Prog.Click += new System.EventHandler(this.Button_Prog_Click);
            // 
            // textBox_krit
            // 
            this.textBox_krit.Location = new System.Drawing.Point(106, 531);
            this.textBox_krit.Name = "textBox_krit";
            this.textBox_krit.Size = new System.Drawing.Size(100, 20);
            this.textBox_krit.TabIndex = 7;
            // 
            // textBox_otv
            // 
            this.textBox_otv.Location = new System.Drawing.Point(624, 529);
            this.textBox_otv.Name = "textBox_otv";
            this.textBox_otv.Size = new System.Drawing.Size(100, 20);
            this.textBox_otv.TabIndex = 8;
            // 
            // label_Result
            // 
            this.label_Result.AutoSize = true;
            this.label_Result.Location = new System.Drawing.Point(47, 563);
            this.label_Result.Name = "label_Result";
            this.label_Result.Size = new System.Drawing.Size(81, 13);
            this.label_Result.TabIndex = 9;
            this.label_Result.Text = "Нажмите ввод";
            // 
            // label_wi
            // 
            this.label_wi.AutoSize = true;
            this.label_wi.Location = new System.Drawing.Point(31, 588);
            this.label_wi.Name = "label_wi";
            this.label_wi.Size = new System.Drawing.Size(20, 13);
            this.label_wi.TabIndex = 10;
            this.label_wi.Text = "wi:";
            // 
            // label_wj
            // 
            this.label_wj.AutoSize = true;
            this.label_wj.Location = new System.Drawing.Point(106, 588);
            this.label_wj.Name = "label_wj";
            this.label_wj.Size = new System.Drawing.Size(20, 13);
            this.label_wj.TabIndex = 11;
            this.label_wj.Text = "wj:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Массив после обнуления значений";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Важный критерий";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 531);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Коэффициент относительной важности";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 563);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ответ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 588);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "wi:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 588);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "wj:";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Критерий 7";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Критерий 7";
            this.Column9.Name = "Column9";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 660);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_wj);
            this.Controls.Add(this.label_wi);
            this.Controls.Add(this.label_Result);
            this.Controls.Add(this.textBox_otv);
            this.Controls.Add(this.textBox_krit);
            this.Controls.Add(this.Button_Prog);
            this.Controls.Add(this.Button_Suzhenie);
            this.Controls.Add(this.dataGridViewPareto1);
            this.Controls.Add(this.dataGridViewPareto);
            this.Controls.Add(this.Button_Pareto);
            this.Controls.Add(this.ButtonArray);
            this.Controls.Add(this.Button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPareto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPareto1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Button ButtonArray;
        private System.Windows.Forms.Button Button_Pareto;
        private System.Windows.Forms.DataGridView dataGridViewPareto;
        private System.Windows.Forms.DataGridView dataGridViewPareto1;
        private System.Windows.Forms.Button Button_Suzhenie;
        private System.Windows.Forms.Button Button_Prog;
        private System.Windows.Forms.TextBox textBox_krit;
        private System.Windows.Forms.TextBox textBox_otv;
        private System.Windows.Forms.Label label_Result;
        private System.Windows.Forms.Label label_wi;
        private System.Windows.Forms.Label label_wj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}

