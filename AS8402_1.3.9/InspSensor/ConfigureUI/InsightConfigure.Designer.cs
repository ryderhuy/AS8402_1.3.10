namespace InspSensor.ConfigureUI
{
    partial class InsightConfigure
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
            this.mBtnOK = new System.Windows.Forms.Button();
            this.mBtnCancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Sorting = new System.Windows.Forms.GroupBox();
            this.cbPatmaxSorting = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudTrayInspThreshold = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTrayTrainRegion = new System.Windows.Forms.Button();
            this.btnTrayTrainButton = new System.Windows.Forms.Button();
            this.btnTraySearchRegion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudPanelInspShowGraphic = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPanelInspThreshold = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbNumPanel = new System.Windows.Forms.ComboBox();
            this.btnSearchPanel = new System.Windows.Forms.Button();
            this.btnPanelTrainRegion = new System.Windows.Forms.Button();
            this.btnPanelTrain = new System.Windows.Forms.Button();
            this.btnPanelSearchRegion = new System.Windows.Forms.Button();
            this.mBtnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Sorting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTrayInspThreshold)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPanelInspShowGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPanelInspThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // mBtnOK
            // 
            this.mBtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.mBtnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.mBtnOK.Location = new System.Drawing.Point(605, 0);
            this.mBtnOK.Margin = new System.Windows.Forms.Padding(2);
            this.mBtnOK.Name = "mBtnOK";
            this.mBtnOK.Size = new System.Drawing.Size(65, 31);
            this.mBtnOK.TabIndex = 2;
            this.mBtnOK.Text = "OK";
            this.mBtnOK.UseVisualStyleBackColor = true;
            // 
            // mBtnCancel
            // 
            this.mBtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mBtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.mBtnCancel.Location = new System.Drawing.Point(735, 0);
            this.mBtnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.mBtnCancel.Name = "mBtnCancel";
            this.mBtnCancel.Size = new System.Drawing.Size(65, 31);
            this.mBtnCancel.TabIndex = 0;
            this.mBtnCancel.Text = "Cancel";
            this.mBtnCancel.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mBtnOK);
            this.splitContainer1.Panel2.Controls.Add(this.mBtnReset);
            this.splitContainer1.Panel2.Controls.Add(this.mBtnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(800, 413);
            this.splitContainer1.SplitterDistance = 379;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Sorting);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 379);
            this.panel1.TabIndex = 0;
            // 
            // Sorting
            // 
            this.Sorting.Controls.Add(this.cbPatmaxSorting);
            this.Sorting.Controls.Add(this.label4);
            this.Sorting.Location = new System.Drawing.Point(8, 214);
            this.Sorting.Margin = new System.Windows.Forms.Padding(2);
            this.Sorting.Name = "Sorting";
            this.Sorting.Padding = new System.Windows.Forms.Padding(2);
            this.Sorting.Size = new System.Drawing.Size(322, 196);
            this.Sorting.TabIndex = 7;
            this.Sorting.TabStop = false;
            this.Sorting.Text = "Panel Sorting";
            // 
            // cbPatmaxSorting
            // 
            this.cbPatmaxSorting.FormattingEnabled = true;
            this.cbPatmaxSorting.Items.AddRange(new object[] {
            "1 - X inc",
            "2 - X dec",
            "3 - Y inc",
            "4 - Y dec"});
            this.cbPatmaxSorting.Location = new System.Drawing.Point(44, 27);
            this.cbPatmaxSorting.Margin = new System.Windows.Forms.Padding(2);
            this.cbPatmaxSorting.Name = "cbPatmaxSorting";
            this.cbPatmaxSorting.Size = new System.Drawing.Size(92, 21);
            this.cbPatmaxSorting.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Sort";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudTrayInspThreshold);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnTrayTrainRegion);
            this.groupBox2.Controls.Add(this.btnTrayTrainButton);
            this.groupBox2.Controls.Add(this.btnTraySearchRegion);
            this.groupBox2.Location = new System.Drawing.Point(334, 20);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(258, 188);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TrayDirection";
            // 
            // nudTrayInspThreshold
            // 
            this.nudTrayInspThreshold.Location = new System.Drawing.Point(190, 28);
            this.nudTrayInspThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.nudTrayInspThreshold.Name = "nudTrayInspThreshold";
            this.nudTrayInspThreshold.Size = new System.Drawing.Size(52, 20);
            this.nudTrayInspThreshold.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Threshold";
            // 
            // btnTrayTrainRegion
            // 
            this.btnTrayTrainRegion.Location = new System.Drawing.Point(4, 24);
            this.btnTrayTrainRegion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTrayTrainRegion.Name = "btnTrayTrainRegion";
            this.btnTrayTrainRegion.Size = new System.Drawing.Size(98, 27);
            this.btnTrayTrainRegion.TabIndex = 3;
            this.btnTrayTrainRegion.Text = "Train Region";
            this.btnTrayTrainRegion.UseVisualStyleBackColor = true;
            // 
            // btnTrayTrainButton
            // 
            this.btnTrayTrainButton.Location = new System.Drawing.Point(4, 90);
            this.btnTrayTrainButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTrayTrainButton.Name = "btnTrayTrainButton";
            this.btnTrayTrainButton.Size = new System.Drawing.Size(98, 27);
            this.btnTrayTrainButton.TabIndex = 4;
            this.btnTrayTrainButton.Text = "Train Patmax";
            this.btnTrayTrainButton.UseVisualStyleBackColor = true;
            // 
            // btnTraySearchRegion
            // 
            this.btnTraySearchRegion.Location = new System.Drawing.Point(4, 57);
            this.btnTraySearchRegion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTraySearchRegion.Name = "btnTraySearchRegion";
            this.btnTraySearchRegion.Size = new System.Drawing.Size(98, 27);
            this.btnTraySearchRegion.TabIndex = 5;
            this.btnTraySearchRegion.Text = "Search Region";
            this.btnTraySearchRegion.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudPanelInspShowGraphic);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudPanelInspThreshold);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbNumPanel);
            this.groupBox1.Controls.Add(this.btnSearchPanel);
            this.groupBox1.Controls.Add(this.btnPanelTrainRegion);
            this.groupBox1.Controls.Add(this.btnPanelTrain);
            this.groupBox1.Controls.Add(this.btnPanelSearchRegion);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(322, 188);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PanelInspection";
            // 
            // nudPanelInspShowGraphic
            // 
            this.nudPanelInspShowGraphic.Location = new System.Drawing.Point(255, 53);
            this.nudPanelInspShowGraphic.Margin = new System.Windows.Forms.Padding(2);
            this.nudPanelInspShowGraphic.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudPanelInspShowGraphic.Name = "nudPanelInspShowGraphic";
            this.nudPanelInspShowGraphic.Size = new System.Drawing.Size(52, 21);
            this.nudPanelInspShowGraphic.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Show graphic";
            // 
            // nudPanelInspThreshold
            // 
            this.nudPanelInspThreshold.Location = new System.Drawing.Point(255, 28);
            this.nudPanelInspThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.nudPanelInspThreshold.Name = "nudPanelInspThreshold";
            this.nudPanelInspThreshold.Size = new System.Drawing.Size(52, 21);
            this.nudPanelInspThreshold.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Threshold";
            // 
            // cbNumPanel
            // 
            this.cbNumPanel.FormattingEnabled = true;
            this.cbNumPanel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbNumPanel.Location = new System.Drawing.Point(116, 152);
            this.cbNumPanel.Margin = new System.Windows.Forms.Padding(2);
            this.cbNumPanel.Name = "cbNumPanel";
            this.cbNumPanel.Size = new System.Drawing.Size(50, 23);
            this.cbNumPanel.TabIndex = 6;
            // 
            // btnSearchPanel
            // 
            this.btnSearchPanel.Location = new System.Drawing.Point(13, 149);
            this.btnSearchPanel.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchPanel.Name = "btnSearchPanel";
            this.btnSearchPanel.Size = new System.Drawing.Size(98, 27);
            this.btnSearchPanel.TabIndex = 5;
            this.btnSearchPanel.Text = "Search Panel";
            this.btnSearchPanel.UseVisualStyleBackColor = true;
            // 
            // btnPanelTrainRegion
            // 
            this.btnPanelTrainRegion.Location = new System.Drawing.Point(12, 28);
            this.btnPanelTrainRegion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPanelTrainRegion.Name = "btnPanelTrainRegion";
            this.btnPanelTrainRegion.Size = new System.Drawing.Size(98, 27);
            this.btnPanelTrainRegion.TabIndex = 0;
            this.btnPanelTrainRegion.Text = "Train Region";
            this.btnPanelTrainRegion.UseVisualStyleBackColor = true;
            // 
            // btnPanelTrain
            // 
            this.btnPanelTrain.Location = new System.Drawing.Point(12, 94);
            this.btnPanelTrain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPanelTrain.Name = "btnPanelTrain";
            this.btnPanelTrain.Size = new System.Drawing.Size(98, 27);
            this.btnPanelTrain.TabIndex = 1;
            this.btnPanelTrain.Text = "Train Patmax";
            this.btnPanelTrain.UseVisualStyleBackColor = true;
            // 
            // btnPanelSearchRegion
            // 
            this.btnPanelSearchRegion.Location = new System.Drawing.Point(12, 61);
            this.btnPanelSearchRegion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPanelSearchRegion.Name = "btnPanelSearchRegion";
            this.btnPanelSearchRegion.Size = new System.Drawing.Size(98, 27);
            this.btnPanelSearchRegion.TabIndex = 2;
            this.btnPanelSearchRegion.Text = "Search Region";
            this.btnPanelSearchRegion.UseVisualStyleBackColor = true;
            // 
            // mBtnReset
            // 
            this.mBtnReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.mBtnReset.Location = new System.Drawing.Point(670, 0);
            this.mBtnReset.Margin = new System.Windows.Forms.Padding(2);
            this.mBtnReset.Name = "mBtnReset";
            this.mBtnReset.Size = new System.Drawing.Size(65, 31);
            this.mBtnReset.TabIndex = 1;
            this.mBtnReset.Text = "Reset";
            this.mBtnReset.UseVisualStyleBackColor = true;
            // 
            // InsightConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "InsightConfigure";
            this.Size = new System.Drawing.Size(800, 413);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.Sorting.ResumeLayout(false);
            this.Sorting.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTrayInspThreshold)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPanelInspShowGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPanelInspThreshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button mBtnOK;
        protected System.Windows.Forms.Button mBtnCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        protected System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox Sorting;
        private System.Windows.Forms.ComboBox cbPatmaxSorting;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudTrayInspThreshold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTrayTrainRegion;
        private System.Windows.Forms.Button btnTrayTrainButton;
        private System.Windows.Forms.Button btnTraySearchRegion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudPanelInspShowGraphic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudPanelInspThreshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNumPanel;
        private System.Windows.Forms.Button btnSearchPanel;
        private System.Windows.Forms.Button btnPanelTrainRegion;
        private System.Windows.Forms.Button btnPanelTrain;
        private System.Windows.Forms.Button btnPanelSearchRegion;
        protected System.Windows.Forms.Button mBtnReset;


    }
}
