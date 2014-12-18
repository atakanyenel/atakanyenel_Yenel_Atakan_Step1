namespace editFriends
{
    partial class editfriends
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.addfriend = new System.Windows.Forms.Button();
            this.removefriend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 290);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(256, 12);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 290);
            this.listBox2.TabIndex = 1;
            // 
            // addfriend
            // 
            this.addfriend.Location = new System.Drawing.Point(139, 93);
            this.addfriend.Name = "addfriend";
            this.addfriend.Size = new System.Drawing.Size(111, 23);
            this.addfriend.TabIndex = 2;
            this.addfriend.Text = "Add-->";
            this.addfriend.UseVisualStyleBackColor = true;
            // 
            // removefriend
            // 
            this.removefriend.Location = new System.Drawing.Point(139, 173);
            this.removefriend.Name = "removefriend";
            this.removefriend.Size = new System.Drawing.Size(111, 23);
            this.removefriend.TabIndex = 3;
            this.removefriend.Text = "<--Remove";
            this.removefriend.UseVisualStyleBackColor = true;
            // 
            // editfriends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 310);
            this.Controls.Add(this.removefriend);
            this.Controls.Add(this.addfriend);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.MaximumSize = new System.Drawing.Size(404, 349);
            this.MinimumSize = new System.Drawing.Size(404, 349);
            this.Name = "editfriends";
            this.Text = "Friends";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button addfriend;
        private System.Windows.Forms.Button removefriend;
    }
}

