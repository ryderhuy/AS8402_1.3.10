namespace InspSensor.Login
{
    partial class FormPasswordPrompt
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
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.comboBox_Login = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChangePassword.Location = new System.Drawing.Point(203, 73);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(84, 27);
            this.btnChangePassword.TabIndex = 50;
            this.btnChangePassword.Text = "Change";
            // 
            // comboBox_Login
            // 
            this.comboBox_Login.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Login.Location = new System.Drawing.Point(112, 12);
            this.comboBox_Login.Name = "comboBox_Login";
            this.comboBox_Login.Size = new System.Drawing.Size(175, 24);
            this.comboBox_Login.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 48;
            this.label1.Text = "User";
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(112, 73);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(84, 27);
            this.button_Cancel.TabIndex = 47;
            this.button_Cancel.Text = "Cancel";
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(21, 73);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(84, 27);
            this.button_OK.TabIndex = 46;
            this.button_OK.Text = "OK";
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(111, 44);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '●';
            this.textBox_Password.Size = new System.Drawing.Size(175, 20);
            this.textBox_Password.TabIndex = 44;
            this.textBox_Password.Text = "1";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Password.Location = new System.Drawing.Point(20, 46);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(68, 16);
            this.label_Password.TabIndex = 45;
            this.label_Password.Text = "Password";
            // 
            // FormPasswordPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 112);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.comboBox_Login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.label_Password);
            this.Name = "FormPasswordPrompt";
            this.Text = "FormPasswordPrompt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.ComboBox comboBox_Login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_Password;
    }
}