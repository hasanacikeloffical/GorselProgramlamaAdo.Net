namespace WindowsFormsApp1
    {
    partial class ders_5
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
            this.Ulkeler = new System.Windows.Forms.ComboBox();
            this.sehirler = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Ulkeler
            // 
            this.Ulkeler.FormattingEnabled = true;
            this.Ulkeler.Location = new System.Drawing.Point(119, 32);
            this.Ulkeler.Name = "Ulkeler";
            this.Ulkeler.Size = new System.Drawing.Size(217, 21);
            this.Ulkeler.TabIndex = 0;
            this.Ulkeler.SelectedIndexChanged += new System.EventHandler(this.Ulkeler_SelectedIndexChanged);
            // 
            // sehirler
            // 
            this.sehirler.FormattingEnabled = true;
            this.sehirler.Location = new System.Drawing.Point(119, 74);
            this.sehirler.Name = "sehirler";
            this.sehirler.Size = new System.Drawing.Size(217, 21);
            this.sehirler.TabIndex = 1;
            this.sehirler.SelectedIndexChanged += new System.EventHandler(this.sehirler_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(119, 121);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(217, 317);
            this.dataGridView1.TabIndex = 2;
            // 
            // ders_5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.sehirler);
            this.Controls.Add(this.Ulkeler);
            this.Name = "ders_5";
            this.Text = "ders_5";
            this.Load += new System.EventHandler(this.ders_5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.ComboBox Ulkeler;
        private System.Windows.Forms.ComboBox sehirler;
        private System.Windows.Forms.DataGridView dataGridView1;
        }
    }