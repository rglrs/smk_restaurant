namespace LKS1
{
    partial class FormChangePass
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
            this.button1 = new System.Windows.Forms.Button();
            this.NewPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ConfirmPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OldPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(220, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Form Change Password";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(347, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 40);
            this.button1.TabIndex = 48;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NewPass
            // 
            this.NewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NewPass.Location = new System.Drawing.Point(347, 181);
            this.NewPass.Name = "NewPass";
            this.NewPass.PasswordChar = '*';
            this.NewPass.Size = new System.Drawing.Size(224, 26);
            this.NewPass.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(191, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 46;
            this.label3.Text = "New Password";
            // 
            // ConfirmPass
            // 
            this.ConfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ConfirmPass.Location = new System.Drawing.Point(347, 223);
            this.ConfirmPass.Name = "ConfirmPass";
            this.ConfirmPass.PasswordChar = '*';
            this.ConfirmPass.Size = new System.Drawing.Size(224, 26);
            this.ConfirmPass.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(191, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "Confirm Password";
            // 
            // OldPass
            // 
            this.OldPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.OldPass.Location = new System.Drawing.Point(347, 145);
            this.OldPass.Name = "OldPass";
            this.OldPass.Size = new System.Drawing.Size(224, 26);
            this.OldPass.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(191, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 42;
            this.label4.Text = "Old Password";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(469, 273);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 40);
            this.button2.TabIndex = 49;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NewPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConfirmPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OldPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "FormChangePass";
            this.Text = "FormChangePass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox NewPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ConfirmPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OldPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}