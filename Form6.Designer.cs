namespace Sql_Proje
{
    partial class FormGeriBildirim
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
            if (disposing && (components != null))
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGeriBildirim));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxÜrünID = new System.Windows.Forms.TextBox();
            this.textBoxKullanıcıID = new System.Windows.Forms.TextBox();
            this.textBoxYorum = new System.Windows.Forms.TextBox();
            this.comboBoxPuan = new System.Windows.Forms.ComboBox();
            this.musteriBildirimiDataSet = new Sql_Proje.MusteriBildirimiDataSet();
            this.geriBildirimlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.geriBildirimlerTableAdapter = new Sql_Proje.MusteriBildirimiDataSetTableAdapters.GeriBildirimlerTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musteriBildirimiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.geriBildirimlerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(430, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(910, 632);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(7, 592);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 65);
            this.button1.TabIndex = 1;
            this.button1.Text = "GERİ BİLDİRİM EKLE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(145, 592);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 65);
            this.button2.TabIndex = 2;
            this.button2.Text = "GERİ BİLDİRİM SİL";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.Location = new System.Drawing.Point(283, 592);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 65);
            this.button3.TabIndex = 3;
            this.button3.Text = "GERİ BİLDİRİM GÜNCELLE";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(4, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ürün ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(4, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kullanıcı ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(4, 439);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Puan:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(4, 491);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Yorum:";
            // 
            // textBoxÜrünID
            // 
            this.textBoxÜrünID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxÜrünID.Location = new System.Drawing.Point(110, 323);
            this.textBoxÜrünID.Name = "textBoxÜrünID";
            this.textBoxÜrünID.Size = new System.Drawing.Size(305, 24);
            this.textBoxÜrünID.TabIndex = 9;
            // 
            // textBoxKullanıcıID
            // 
            this.textBoxKullanıcıID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxKullanıcıID.Location = new System.Drawing.Point(110, 377);
            this.textBoxKullanıcıID.Name = "textBoxKullanıcıID";
            this.textBoxKullanıcıID.Size = new System.Drawing.Size(305, 24);
            this.textBoxKullanıcıID.TabIndex = 10;
            // 
            // textBoxYorum
            // 
            this.textBoxYorum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxYorum.Location = new System.Drawing.Point(110, 488);
            this.textBoxYorum.Name = "textBoxYorum";
            this.textBoxYorum.Size = new System.Drawing.Size(305, 24);
            this.textBoxYorum.TabIndex = 11;
            this.textBoxYorum.TextChanged += new System.EventHandler(this.textBoxYorum_TextChanged);
            // 
            // comboBoxPuan
            // 
            this.comboBoxPuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxPuan.FormattingEnabled = true;
            this.comboBoxPuan.Location = new System.Drawing.Point(110, 431);
            this.comboBoxPuan.Name = "comboBoxPuan";
            this.comboBoxPuan.Size = new System.Drawing.Size(305, 26);
            this.comboBoxPuan.TabIndex = 12;
            // 
            // musteriBildirimiDataSet
            // 
            this.musteriBildirimiDataSet.DataSetName = "MusteriBildirimiDataSet";
            this.musteriBildirimiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // geriBildirimlerBindingSource
            // 
            this.geriBildirimlerBindingSource.DataMember = "GeriBildirimler";
            this.geriBildirimlerBindingSource.DataSource = this.musteriBildirimiDataSet;
            // 
            // geriBildirimlerTableAdapter
            // 
            this.geriBildirimlerTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 269);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // FormGeriBildirim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(1364, 683);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBoxPuan);
            this.Controls.Add(this.textBoxYorum);
            this.Controls.Add(this.textBoxKullanıcıID);
            this.Controls.Add(this.textBoxÜrünID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGeriBildirim";
            this.Text = "Geri Bildirimler Sayfası";
            this.Load += new System.EventHandler(this.FormGeriBildirim_Load);
            this.MouseEnter += new System.EventHandler(this.FormGeriBildirim_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musteriBildirimiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.geriBildirimlerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxÜrünID;
        private System.Windows.Forms.TextBox textBoxKullanıcıID;
        private System.Windows.Forms.TextBox textBoxYorum;
        private System.Windows.Forms.ComboBox comboBoxPuan;
        private MusteriBildirimiDataSet musteriBildirimiDataSet;
        private System.Windows.Forms.BindingSource geriBildirimlerBindingSource;
        private MusteriBildirimiDataSetTableAdapters.GeriBildirimlerTableAdapter geriBildirimlerTableAdapter;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}