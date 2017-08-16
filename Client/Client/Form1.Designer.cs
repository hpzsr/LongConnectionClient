namespace Client
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
            this.button_lianjie = new System.Windows.Forms.Button();
            this.button_fasong = new System.Windows.Forms.Button();
            this.button_duankai = new System.Windows.Forms.Button();
            this.textBox_send = new System.Windows.Forms.TextBox();
            this.listBox_chat = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button_lianjie
            // 
            this.button_lianjie.Location = new System.Drawing.Point(79, 327);
            this.button_lianjie.Name = "button_lianjie";
            this.button_lianjie.Size = new System.Drawing.Size(75, 23);
            this.button_lianjie.TabIndex = 0;
            this.button_lianjie.Text = "连接";
            this.button_lianjie.UseVisualStyleBackColor = true;
            this.button_lianjie.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_fasong
            // 
            this.button_fasong.Location = new System.Drawing.Point(246, 280);
            this.button_fasong.Name = "button_fasong";
            this.button_fasong.Size = new System.Drawing.Size(75, 23);
            this.button_fasong.TabIndex = 1;
            this.button_fasong.Text = "发送";
            this.button_fasong.UseVisualStyleBackColor = true;
            this.button_fasong.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_duankai
            // 
            this.button_duankai.Location = new System.Drawing.Point(202, 327);
            this.button_duankai.Name = "button_duankai";
            this.button_duankai.Size = new System.Drawing.Size(75, 23);
            this.button_duankai.TabIndex = 2;
            this.button_duankai.Text = "断开";
            this.button_duankai.UseVisualStyleBackColor = true;
            this.button_duankai.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox_send
            // 
            this.textBox_send.Location = new System.Drawing.Point(12, 282);
            this.textBox_send.Name = "textBox_send";
            this.textBox_send.Size = new System.Drawing.Size(223, 21);
            this.textBox_send.TabIndex = 3;
            // 
            // listBox_chat
            // 
            this.listBox_chat.FormattingEnabled = true;
            this.listBox_chat.ItemHeight = 12;
            this.listBox_chat.Location = new System.Drawing.Point(18, 12);
            this.listBox_chat.Name = "listBox_chat";
            this.listBox_chat.Size = new System.Drawing.Size(308, 244);
            this.listBox_chat.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 362);
            this.Controls.Add(this.listBox_chat);
            this.Controls.Add(this.textBox_send);
            this.Controls.Add(this.button_duankai);
            this.Controls.Add(this.button_fasong);
            this.Controls.Add(this.button_lianjie);
            this.Name = "Form1";
            this.Text = "客户端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_lianjie;
        private System.Windows.Forms.Button button_fasong;
        private System.Windows.Forms.Button button_duankai;
        private System.Windows.Forms.TextBox textBox_send;
        private System.Windows.Forms.ListBox listBox_chat;
    }
}

