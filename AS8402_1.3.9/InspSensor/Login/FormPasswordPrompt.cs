using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InspSensor.Login
{
    public partial class FormPasswordPrompt : Form
    {
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Label label_Password;
        private Label label1;
        private ComboBox comboBox_Login;
        private Button btnChangePassword;
        private AccessLevel mCurrentAccessLevel = AccessLevel.Operator;
        private PasswordFile mPasswordFile = null;
        public FormPasswordPrompt()
        {
            InitializeComponent();
        }
    }
}
