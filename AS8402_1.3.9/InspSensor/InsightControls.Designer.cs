namespace InspSensor
{
    partial class InsightControls
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cvsInSightDisplay1 = new Cognex.InSight.Controls.Display.CvsInSightDisplay();
            this.SuspendLayout();
            // 
            // cvsInSightDisplay1
            // 
            this.cvsInSightDisplay1.DefaultTextScaleMode = Cognex.InSight.Controls.Display.CvsInSightDisplay.TextScaleModeType.Proportional;
            this.cvsInSightDisplay1.DialogIcon = null;
            this.cvsInSightDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvsInSightDisplay1.Location = new System.Drawing.Point(0, 0);
            this.cvsInSightDisplay1.Name = "cvsInSightDisplay1";
            this.cvsInSightDisplay1.PreferredCropScaleMode = Cognex.InSight.Controls.Display.CvsInSightDisplayCropScaleMode.Default;
            this.cvsInSightDisplay1.Size = new System.Drawing.Size(690, 486);
            this.cvsInSightDisplay1.TabIndex = 0;
            // 
            // InsightControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cvsInSightDisplay1);
            this.Name = "InsightControls";
            this.Size = new System.Drawing.Size(690, 486);
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.InSight.Controls.Display.CvsInSightDisplay cvsInSightDisplay1;
    }
}
