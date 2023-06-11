namespace Control_GUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statsGroupBox = new System.Windows.Forms.GroupBox();
            this.statsListBox = new System.Windows.Forms.ListBox();
            this.optionGroupBox = new System.Windows.Forms.GroupBox();
            this.serialPortComboBox = new System.Windows.Forms.ComboBox();
            this.serialPortTextBox = new System.Windows.Forms.TextBox();
            this.stageCntTextBox = new System.Windows.Forms.TextBox();
            this.stageComboBox = new System.Windows.Forms.ComboBox();
            this.stageGroupBox = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.functionGroupBox = new System.Windows.Forms.GroupBox();
            this.scanPortBtn = new System.Windows.Forms.Button();
            this.clsBtn = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button7 = new System.Windows.Forms.Button();
            this.statsGroupBox.SuspendLayout();
            this.optionGroupBox.SuspendLayout();
            this.stageGroupBox.SuspendLayout();
            this.functionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // statsGroupBox
            // 
            this.statsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statsGroupBox.AutoSize = true;
            this.statsGroupBox.Controls.Add(this.statsListBox);
            this.statsGroupBox.Location = new System.Drawing.Point(474, 0);
            this.statsGroupBox.Name = "statsGroupBox";
            this.statsGroupBox.Size = new System.Drawing.Size(634, 905);
            this.statsGroupBox.TabIndex = 0;
            this.statsGroupBox.TabStop = false;
            this.statsGroupBox.Text = "States";
            // 
            // statsListBox
            // 
            this.statsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statsListBox.FormattingEnabled = true;
            this.statsListBox.ItemHeight = 18;
            this.statsListBox.Location = new System.Drawing.Point(10, 30);
            this.statsListBox.Name = "statsListBox";
            this.statsListBox.Size = new System.Drawing.Size(618, 846);
            this.statsListBox.TabIndex = 4;
            // 
            // optionGroupBox
            // 
            this.optionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.optionGroupBox.Controls.Add(this.serialPortComboBox);
            this.optionGroupBox.Controls.Add(this.serialPortTextBox);
            this.optionGroupBox.Controls.Add(this.stageCntTextBox);
            this.optionGroupBox.Controls.Add(this.stageComboBox);
            this.optionGroupBox.Location = new System.Drawing.Point(0, 0);
            this.optionGroupBox.Name = "optionGroupBox";
            this.optionGroupBox.Size = new System.Drawing.Size(475, 402);
            this.optionGroupBox.TabIndex = 1;
            this.optionGroupBox.TabStop = false;
            this.optionGroupBox.Text = "Config";
            // 
            // serialPortComboBox
            // 
            this.serialPortComboBox.FormattingEnabled = true;
            this.serialPortComboBox.Location = new System.Drawing.Point(234, 107);
            this.serialPortComboBox.Name = "serialPortComboBox";
            this.serialPortComboBox.Size = new System.Drawing.Size(87, 26);
            this.serialPortComboBox.TabIndex = 5;
            this.serialPortComboBox.SelectedIndexChanged += new System.EventHandler(this.serialPortComboBox_SelectedIndexChanged);
            // 
            // serialPortTextBox
            // 
            this.serialPortTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serialPortTextBox.Location = new System.Drawing.Point(47, 111);
            this.serialPortTextBox.Name = "serialPortTextBox";
            this.serialPortTextBox.ReadOnly = true;
            this.serialPortTextBox.Size = new System.Drawing.Size(181, 22);
            this.serialPortTextBox.TabIndex = 4;
            this.serialPortTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stageCntTextBox
            // 
            this.stageCntTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stageCntTextBox.Location = new System.Drawing.Point(47, 49);
            this.stageCntTextBox.Name = "stageCntTextBox";
            this.stageCntTextBox.ReadOnly = true;
            this.stageCntTextBox.Size = new System.Drawing.Size(181, 22);
            this.stageCntTextBox.TabIndex = 3;
            this.stageCntTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stageComboBox
            // 
            this.stageComboBox.FormattingEnabled = true;
            this.stageComboBox.Location = new System.Drawing.Point(234, 45);
            this.stageComboBox.Name = "stageComboBox";
            this.stageComboBox.Size = new System.Drawing.Size(87, 26);
            this.stageComboBox.TabIndex = 2;
            this.stageComboBox.SelectedIndexChanged += new System.EventHandler(this.stageComboBox_SelectedIndexChanged);
            // 
            // stageGroupBox
            // 
            this.stageGroupBox.Controls.Add(this.button6);
            this.stageGroupBox.Controls.Add(this.button5);
            this.stageGroupBox.Controls.Add(this.button4);
            this.stageGroupBox.Controls.Add(this.button3);
            this.stageGroupBox.Controls.Add(this.button2);
            this.stageGroupBox.Controls.Add(this.button1);
            this.stageGroupBox.Controls.Add(this.testBtn);
            this.stageGroupBox.Location = new System.Drawing.Point(0, 193);
            this.stageGroupBox.Name = "stageGroupBox";
            this.stageGroupBox.Size = new System.Drawing.Size(475, 472);
            this.stageGroupBox.TabIndex = 0;
            this.stageGroupBox.TabStop = false;
            this.stageGroupBox.Text = "Stages Control";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(246, 359);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(165, 85);
            this.button6.TabIndex = 6;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(47, 359);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 85);
            this.button5.TabIndex = 5;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(246, 254);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(165, 85);
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(47, 254);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 85);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(246, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 85);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 85);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(47, 48);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(364, 63);
            this.testBtn.TabIndex = 0;
            this.testBtn.Text = "Send Test Signal";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // functionGroupBox
            // 
            this.functionGroupBox.AutoSize = true;
            this.functionGroupBox.Controls.Add(this.button7);
            this.functionGroupBox.Controls.Add(this.scanPortBtn);
            this.functionGroupBox.Controls.Add(this.clsBtn);
            this.functionGroupBox.Location = new System.Drawing.Point(0, 658);
            this.functionGroupBox.Name = "functionGroupBox";
            this.functionGroupBox.Size = new System.Drawing.Size(475, 246);
            this.functionGroupBox.TabIndex = 2;
            this.functionGroupBox.TabStop = false;
            this.functionGroupBox.Text = "Function";
            // 
            // scanPortBtn
            // 
            this.scanPortBtn.Location = new System.Drawing.Point(29, 56);
            this.scanPortBtn.Name = "scanPortBtn";
            this.scanPortBtn.Size = new System.Drawing.Size(199, 63);
            this.scanPortBtn.TabIndex = 1;
            this.scanPortBtn.Text = "Scan Ports";
            this.scanPortBtn.UseVisualStyleBackColor = true;
            this.scanPortBtn.Click += new System.EventHandler(this.scanPortBtn_Click);
            // 
            // clsBtn
            // 
            this.clsBtn.Location = new System.Drawing.Point(29, 155);
            this.clsBtn.Name = "clsBtn";
            this.clsBtn.Size = new System.Drawing.Size(422, 63);
            this.clsBtn.TabIndex = 0;
            this.clsBtn.Text = "Clear States";
            this.clsBtn.UseVisualStyleBackColor = true;
            this.clsBtn.Click += new System.EventHandler(this.clsBtn_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(252, 56);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(199, 63);
            this.button7.TabIndex = 2;
            this.button7.Text = "Scan Ports";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 1050);
            this.Controls.Add(this.functionGroupBox);
            this.Controls.Add(this.stageGroupBox);
            this.Controls.Add(this.optionGroupBox);
            this.Controls.Add(this.statsGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "NCKUEE Light Dance Control GUI";
            this.statsGroupBox.ResumeLayout(false);
            this.optionGroupBox.ResumeLayout(false);
            this.optionGroupBox.PerformLayout();
            this.stageGroupBox.ResumeLayout(false);
            this.functionGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox statsGroupBox;
        private System.Windows.Forms.GroupBox optionGroupBox;
        private System.Windows.Forms.GroupBox stageGroupBox;
        private System.Windows.Forms.ComboBox stageComboBox;
        private System.Windows.Forms.TextBox stageCntTextBox;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox functionGroupBox;
        private System.Windows.Forms.ListBox statsListBox;
        private System.Windows.Forms.Button clsBtn;
        private System.Windows.Forms.ComboBox serialPortComboBox;
        private System.Windows.Forms.TextBox serialPortTextBox;
        private System.Windows.Forms.Button scanPortBtn;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button7;
    }
}

