namespace WindowsFormsApp1
    {
    partial class Form2
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if(disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gorselProgramlamaDataSet = new WindowsFormsApp1.GorselProgramlamaDataSet();
            this.gorselProgramlamaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.ColumnsList = new System.Windows.Forms.ListBox();
            this.RowsList = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gorselProgramlamaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gorselProgramlamaDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Veriyi Getir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(174, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(499, 409);
            this.dataGridView1.TabIndex = 1;
            // 
            // gorselProgramlamaDataSet
            // 
            this.gorselProgramlamaDataSet.DataSetName = "GorselProgramlamaDataSet";
            this.gorselProgramlamaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gorselProgramlamaDataSetBindingSource
            // 
            this.gorselProgramlamaDataSetBindingSource.DataSource = this.gorselProgramlamaDataSet;
            this.gorselProgramlamaDataSetBindingSource.Position = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(45, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Alan Bilgileri";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ColumnsList
            // 
            this.ColumnsList.FormattingEnabled = true;
            this.ColumnsList.Location = new System.Drawing.Point(691, 45);
            this.ColumnsList.Name = "ColumnsList";
            this.ColumnsList.Size = new System.Drawing.Size(260, 368);
            this.ColumnsList.TabIndex = 3;
            // 
            // RowsList
            // 
            this.RowsList.FormattingEnabled = true;
            this.RowsList.Location = new System.Drawing.Point(980, 45);
            this.RowsList.Name = "RowsList";
            this.RowsList.Size = new System.Drawing.Size(260, 368);
            this.RowsList.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(45, 144);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 30);
            this.button3.TabIndex = 5;
            this.button3.Text = "Müþteri Verileri";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 636);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.RowsList);
            this.Controls.Add(this.ColumnsList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gorselProgramlamaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gorselProgramlamaDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private GorselProgramlamaDataSet gorselProgramlamaDataSet;
        private System.Windows.Forms.BindingSource gorselProgramlamaDataSetBindingSource;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox ColumnsList;
        private System.Windows.Forms.ListBox RowsList;
        private System.Windows.Forms.Button button3;
        }
    }