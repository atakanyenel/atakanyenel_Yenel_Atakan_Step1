namespace ClientSide
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Connect = new System.Windows.Forms.Button();
            this.richtextbox = new System.Windows.Forms.RichTextBox();
            this.tbsend = new System.Windows.Forms.TextBox();
            this.btnsend = new System.Windows.Forms.Button();
            this.tbport = new System.Windows.Forms.TextBox();
            this.tbip = new System.Windows.Forms.TextBox();
            this.tbname = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // Connect
            // 
            this.Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Connect.Location = new System.Drawing.Point(237, 6);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(139, 47);
            this.Connect.TabIndex = 10;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // richtextbox
            // 
            this.richtextbox.ForeColor = System.Drawing.Color.Blue;
            this.richtextbox.Location = new System.Drawing.Point(12, 85);
            this.richtextbox.Name = "richtextbox";
            this.richtextbox.ReadOnly = true;
            this.richtextbox.Size = new System.Drawing.Size(294, 213);
            this.richtextbox.TabIndex = 13;
            this.richtextbox.Text = "";
            // 
            // tbsend
            // 
            this.tbsend.Location = new System.Drawing.Point(12, 59);
            this.tbsend.Name = "tbsend";
            this.tbsend.Size = new System.Drawing.Size(294, 20);
            this.tbsend.TabIndex = 11;
            this.tbsend.TextChanged += new System.EventHandler(this.tbsend_TextChanged);
            // 
            // btnsend
            // 
            this.btnsend.Enabled = false;
            this.btnsend.Location = new System.Drawing.Point(312, 59);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(64, 20);
            this.btnsend.TabIndex = 12;
            this.btnsend.Text = "Send";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // tbport
            // 
            this.tbport.Location = new System.Drawing.Point(44, 6);
            this.tbport.Name = "tbport";
            this.tbport.Size = new System.Drawing.Size(55, 20);
            this.tbport.TabIndex = 7;
            // 
            // tbip
            // 
            this.tbip.Location = new System.Drawing.Point(128, 6);
            this.tbip.Name = "tbip";
            this.tbip.Size = new System.Drawing.Size(103, 20);
            this.tbip.TabIndex = 8;
            // 
            // tbname
            // 
            this.tbname.Location = new System.Drawing.Point(53, 33);
            this.tbname.Name = "tbname";
            this.tbname.Size = new System.Drawing.Size(178, 20);
            this.tbname.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 103);
            this.button1.TabIndex = 14;
            this.button1.Text = "Create Event";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(312, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 61);
            this.button2.TabIndex = 15;
            this.button2.Text = "Events";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(312, 195);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 36);
            this.button3.TabIndex = 16;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.Connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 310);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbname);
            this.Controls.Add(this.tbip);
            this.Controls.Add(this.tbport);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.tbsend);
            this.Controls.Add(this.richtextbox);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(404, 349);
            this.MinimumSize = new System.Drawing.Size(404, 349);
            this.Name = "Form1";
            this.Text = "Client-master";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.RichTextBox richtextbox;
        private System.Windows.Forms.TextBox tbsend;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.TextBox tbport;
        private System.Windows.Forms.TextBox tbip;
        private System.Windows.Forms.TextBox tbname;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

