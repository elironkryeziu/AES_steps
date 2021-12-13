namespace AES_steps
{
    partial class AES_steps
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.encryptedtext = new System.Windows.Forms.TextBox();
            this.plaintexttxt = new System.Windows.Forms.TextBox();
            this.encryptkeytxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.encryptbtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.decryptkeytxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.decryptedtext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.decryptbtn = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.plaintextbytes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.plaintextbytes);
            this.tabPage1.Controls.Add(this.encryptedtext);
            this.tabPage1.Controls.Add(this.plaintexttxt);
            this.tabPage1.Controls.Add(this.encryptkeytxt);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.encryptbtn);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(446, 433);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Encrypt";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // encryptedtext
            // 
            this.encryptedtext.Location = new System.Drawing.Point(62, 299);
            this.encryptedtext.Name = "encryptedtext";
            this.encryptedtext.Size = new System.Drawing.Size(301, 20);
            this.encryptedtext.TabIndex = 13;
            // 
            // plaintexttxt
            // 
            this.plaintexttxt.Location = new System.Drawing.Point(62, 83);
            this.plaintexttxt.Name = "plaintexttxt";
            this.plaintexttxt.Size = new System.Drawing.Size(301, 20);
            this.plaintexttxt.TabIndex = 9;
            // 
            // encryptkeytxt
            // 
            this.encryptkeytxt.Location = new System.Drawing.Point(62, 154);
            this.encryptkeytxt.Name = "encryptkeytxt";
            this.encryptkeytxt.Size = new System.Drawing.Size(301, 20);
            this.encryptkeytxt.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Encrypted bytes";
            // 
            // encryptbtn
            // 
            this.encryptbtn.Location = new System.Drawing.Point(288, 180);
            this.encryptbtn.Name = "encryptbtn";
            this.encryptbtn.Size = new System.Drawing.Size(75, 23);
            this.encryptbtn.TabIndex = 7;
            this.encryptbtn.Text = "Encrypt";
            this.encryptbtn.UseVisualStyleBackColor = true;
            this.encryptbtn.Click += new System.EventHandler(this.encryptbtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Plaintext";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Key";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(454, 459);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.decryptkeytxt);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.decryptedtext);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.decryptbtn);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(446, 433);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Decrypt";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // decryptkeytxt
            // 
            this.decryptkeytxt.Location = new System.Drawing.Point(66, 148);
            this.decryptkeytxt.Name = "decryptkeytxt";
            this.decryptkeytxt.Size = new System.Drawing.Size(301, 20);
            this.decryptkeytxt.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Key";
            // 
            // decryptedtext
            // 
            this.decryptedtext.Location = new System.Drawing.Point(66, 257);
            this.decryptedtext.Name = "decryptedtext";
            this.decryptedtext.Size = new System.Drawing.Size(301, 20);
            this.decryptedtext.TabIndex = 26;
            this.decryptedtext.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Plaintext";
            // 
            // decryptbtn
            // 
            this.decryptbtn.Location = new System.Drawing.Point(292, 193);
            this.decryptbtn.Name = "decryptbtn";
            this.decryptbtn.Size = new System.Drawing.Size(75, 23);
            this.decryptbtn.TabIndex = 25;
            this.decryptbtn.Text = "Decrypt";
            this.decryptbtn.UseVisualStyleBackColor = true;
            this.decryptbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(66, 95);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(301, 20);
            this.textBox2.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Encrypted bytes";
            // 
            // plaintextbytes
            // 
            this.plaintextbytes.Location = new System.Drawing.Point(62, 240);
            this.plaintextbytes.Name = "plaintextbytes";
            this.plaintextbytes.Size = new System.Drawing.Size(301, 20);
            this.plaintextbytes.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Plaintext bytes";
            // 
            // AES_steps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 463);
            this.Controls.Add(this.tabControl1);
            this.Name = "AES_steps";
            this.Text = "AES_steps";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox encryptedtext;
        private System.Windows.Forms.TextBox plaintexttxt;
        private System.Windows.Forms.TextBox encryptkeytxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button encryptbtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox decryptkeytxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox decryptedtext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button decryptbtn;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox plaintextbytes;
    }
}

