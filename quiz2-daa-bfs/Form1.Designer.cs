using System.Text;

namespace quiz2_daa_bfs
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            comboAsal = new ComboBox();
            comboTujuan = new ComboBox();
            btnCari = new Button();
            txtHasil = new TextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // comboAsal
            // 
            comboAsal.FormattingEnabled = true;
            comboAsal.Location = new Point(24, 161);
            comboAsal.Name = "comboAsal";
            comboAsal.Size = new Size(151, 28);
            comboAsal.TabIndex = 1;
            comboAsal.Text = "From";
            comboAsal.SelectedIndexChanged += comboAsal_SelectedIndexChanged;
            // 
            // comboTujuan
            // 
            comboTujuan.FormattingEnabled = true;
            comboTujuan.Location = new Point(24, 210);
            comboTujuan.Name = "comboTujuan";
            comboTujuan.Size = new Size(151, 28);
            comboTujuan.TabIndex = 2;
            comboTujuan.Text = "Destination";
            // 
            // btnCari
            // 
            btnCari.Location = new Point(47, 261);
            btnCari.Name = "btnCari";
            btnCari.Size = new Size(94, 29);
            btnCari.TabIndex = 3;
            btnCari.Text = "Find";
            btnCari.UseVisualStyleBackColor = true;
            btnCari.Click += btnCari_Click;
            // 
            // txtHasil
            // 
            txtHasil.Location = new Point(223, 12);
            txtHasil.Multiline = true;
            txtHasil.Name = "txtHasil";
            txtHasil.Size = new Size(565, 426);
            txtHasil.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(24, 97);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 27);
            textBox1.TabIndex = 5;
            textBox1.Text = "Flight Route Finder";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(txtHasil);
            Controls.Add(btnCari);
            Controls.Add(comboTujuan);
            Controls.Add(comboAsal);
            HelpButton = true;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboAsal;
        private ComboBox comboTujuan;
        private Button btnCari;
        private TextBox txtHasil;
        private TextBox textBox1;
    }
}
