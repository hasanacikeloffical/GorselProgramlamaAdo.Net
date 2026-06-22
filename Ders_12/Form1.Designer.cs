namespace Ders_12
    {
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CategoryFiltre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Arama = new System.Windows.Forms.TextBox();
            this.BtnAra = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FiyatAzalan = new System.Windows.Forms.RadioButton();
            this.FiyatArtan = new System.Windows.Forms.RadioButton();
            this.StokDurum = new System.Windows.Forms.CheckBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(235, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(553, 342);
            this.dataGridView1.TabIndex = 0;
            // 
            // CategoryFiltre
            // 
            this.CategoryFiltre.FormattingEnabled = true;
            this.CategoryFiltre.Location = new System.Drawing.Point(108, 96);
            this.CategoryFiltre.Name = "CategoryFiltre";
            this.CategoryFiltre.Size = new System.Drawing.Size(121, 21);
            this.CategoryFiltre.TabIndex = 1;
            this.CategoryFiltre.SelectedIndexChanged += new System.EventHandler(this.CategoryFiltre_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kategori";
            // 
            // Arama
            // 
            this.Arama.Location = new System.Drawing.Point(235, 70);
            this.Arama.Name = "Arama";
            this.Arama.Size = new System.Drawing.Size(100, 20);
            this.Arama.TabIndex = 3;
            this.Arama.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Arama_KeyPress);
            // 
            // BtnAra
            // 
            this.BtnAra.Location = new System.Drawing.Point(341, 70);
            this.BtnAra.Name = "BtnAra";
            this.BtnAra.Size = new System.Drawing.Size(48, 21);
            this.BtnAra.TabIndex = 4;
            this.BtnAra.Text = "Ara";
            this.BtnAra.UseVisualStyleBackColor = true;
            this.BtnAra.Click += new System.EventHandler(this.BtnAra_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FiyatAzalan);
            this.groupBox1.Controls.Add(this.FiyatArtan);
            this.groupBox1.Location = new System.Drawing.Point(508, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 34);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sýrala";
            // 
            // FiyatAzalan
            // 
            this.FiyatAzalan.AutoSize = true;
            this.FiyatAzalan.Location = new System.Drawing.Point(192, 11);
            this.FiyatAzalan.Name = "FiyatAzalan";
            this.FiyatAzalan.Size = new System.Drawing.Size(82, 17);
            this.FiyatAzalan.TabIndex = 1;
            this.FiyatAzalan.TabStop = true;
            this.FiyatAzalan.Text = "Fiyat Azalan";
            this.FiyatAzalan.UseVisualStyleBackColor = true;
            this.FiyatAzalan.CheckedChanged += new System.EventHandler(this.FiyatAzalan_CheckedChanged);
            // 
            // FiyatArtan
            // 
            this.FiyatArtan.AutoSize = true;
            this.FiyatArtan.Location = new System.Drawing.Point(6, 11);
            this.FiyatArtan.Name = "FiyatArtan";
            this.FiyatArtan.Size = new System.Drawing.Size(75, 17);
            this.FiyatArtan.TabIndex = 0;
            this.FiyatArtan.TabStop = true;
            this.FiyatArtan.Text = "Fiyat Artan";
            this.FiyatArtan.UseVisualStyleBackColor = true;
            this.FiyatArtan.CheckedChanged += new System.EventHandler(this.FiyatArtan_CheckedChanged);
            // 
            // StokDurum
            // 
            this.StokDurum.AutoSize = true;
            this.StokDurum.Location = new System.Drawing.Point(108, 70);
            this.StokDurum.Name = "StokDurum";
            this.StokDurum.Size = new System.Drawing.Size(122, 17);
            this.StokDurum.TabIndex = 6;
            this.StokDurum.Text = "Sadece Stokta Olan";
            this.StokDurum.UseVisualStyleBackColor = true;
            this.StokDurum.CheckedChanged += new System.EventHandler(this.StokDurum_CheckedChanged);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(395, 72);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(55, 19);
            this.BtnDelete.TabIndex = 7;
            this.BtnDelete.Text = "Temizle";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 516);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.StokDurum);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnAra);
            this.Controls.Add(this.Arama);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CategoryFiltre);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox CategoryFiltre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Arama;
        private System.Windows.Forms.Button BtnAra;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton FiyatAzalan;
        private System.Windows.Forms.RadioButton FiyatArtan;
        private System.Windows.Forms.CheckBox StokDurum;
        private System.Windows.Forms.Button BtnDelete;
        }
    }

