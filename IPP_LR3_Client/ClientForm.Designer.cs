namespace LR3
{
    partial class ClientForm
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
            this.btRight = new System.Windows.Forms.Button();
            this.btLeft = new System.Windows.Forms.Button();
            this.lbServerVoice = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btRight
            // 
            this.btRight.BackColor = System.Drawing.Color.LightGray;
            this.btRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRight.Location = new System.Drawing.Point(205, 74);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(118, 51);
            this.btRight.TabIndex = 0;
            this.btRight.Text = "SecondW";
            this.btRight.UseVisualStyleBackColor = false;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);
            // 
            // btLeft
            // 
            this.btLeft.BackColor = System.Drawing.Color.LightGray;
            this.btLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLeft.Location = new System.Drawing.Point(7, 74);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(118, 51);
            this.btLeft.TabIndex = 1;
            this.btLeft.Text = "FirstW";
            this.btLeft.UseVisualStyleBackColor = false;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
            // 
            // lbServerVoice
            // 
            this.lbServerVoice.AutoSize = true;
            this.lbServerVoice.Location = new System.Drawing.Point(88, 32);
            this.lbServerVoice.Name = "lbServerVoice";
            this.lbServerVoice.Size = new System.Drawing.Size(37, 13);
            this.lbServerVoice.TabIndex = 2;
            this.lbServerVoice.Text = "Result";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbServerVoice);
            this.groupBox1.Controls.Add(this.btLeft);
            this.groupBox1.Controls.Add(this.btRight);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 145);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(340, 162);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClientForm";
            this.Text = "LB3Result";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.Label lbServerVoice;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

