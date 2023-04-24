namespace GUI
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.importAudioDialog = new System.Windows.Forms.OpenFileDialog();
            this.importBtn = new System.Windows.Forms.Button();
            this.currTimeTextBox = new System.Windows.Forms.TextBox();
            this.totalTimeTextBox = new System.Windows.Forms.TextBox();
            this.playBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBarTimeLine = new System.Windows.Forms.TrackBar();
            this.addBtn = new System.Windows.Forms.Button();
            this.colorBtn1 = new System.Windows.Forms.Button();
            this.colorBtn2 = new System.Windows.Forms.Button();
            this.colorBtn3 = new System.Windows.Forms.Button();
            this.colorBtn4 = new System.Windows.Forms.Button();
            this.colorBtn5 = new System.Windows.Forms.Button();
            this.colorBtn6 = new System.Windows.Forms.Button();
            this.colorBtn7 = new System.Windows.Forms.Button();
            this.colorBtn8 = new System.Windows.Forms.Button();
            this.colorBtn9 = new System.Windows.Forms.Button();
            this.colorBtn10 = new System.Windows.Forms.Button();
            this.colorBtn11 = new System.Windows.Forms.Button();
            this.colorBtn12 = new System.Windows.Forms.Button();
            this.saveFileBtn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.dataSectionListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.resetBtn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimeLine)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(18, 7);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(238, 364);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // colorPanel
            // 
            this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorPanel.Location = new System.Drawing.Point(274, 7);
            this.colorPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Padding = new System.Windows.Forms.Padding(12);
            this.colorPanel.Size = new System.Drawing.Size(76, 71);
            this.colorPanel.TabIndex = 4;
            // 
            // importAudioDialog
            // 
            this.importAudioDialog.FileName = "importAudioDialog";
            // 
            // importBtn
            // 
            this.importBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.importBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.Location = new System.Drawing.Point(286, 398);
            this.importBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(137, 35);
            this.importBtn.TabIndex = 14;
            this.importBtn.Text = "Import Audio";
            this.importBtn.UseVisualStyleBackColor = false;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // currTimeTextBox
            // 
            this.currTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currTimeTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.currTimeTextBox.Location = new System.Drawing.Point(8, 403);
            this.currTimeTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.currTimeTextBox.Name = "currTimeTextBox";
            this.currTimeTextBox.Size = new System.Drawing.Size(73, 29);
            this.currTimeTextBox.TabIndex = 15;
            this.currTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // totalTimeTextBox
            // 
            this.totalTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalTimeTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.totalTimeTextBox.Location = new System.Drawing.Point(87, 403);
            this.totalTimeTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.totalTimeTextBox.Name = "totalTimeTextBox";
            this.totalTimeTextBox.Size = new System.Drawing.Size(76, 29);
            this.totalTimeTextBox.TabIndex = 16;
            this.totalTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playBtn
            // 
            this.playBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playBtn.BackColor = System.Drawing.Color.Lime;
            this.playBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.Location = new System.Drawing.Point(183, 398);
            this.playBtn.Margin = new System.Windows.Forms.Padding(0);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(92, 35);
            this.playBtn.TabIndex = 17;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = false;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBarTimeLine
            // 
            this.trackBarTimeLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarTimeLine.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.trackBarTimeLine.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackBarTimeLine.Location = new System.Drawing.Point(-1, 445);
            this.trackBarTimeLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBarTimeLine.Name = "trackBarTimeLine";
            this.trackBarTimeLine.Size = new System.Drawing.Size(1005, 69);
            this.trackBarTimeLine.TabIndex = 19;
            this.trackBarTimeLine.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarTimeLine.Scroll += new System.EventHandler(this.trackBarTimeLine_Scroll);
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.addBtn.FlatAppearance.BorderSize = 0;
            this.addBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(583, 398);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(86, 35);
            this.addBtn.TabIndex = 20;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // colorBtn1
            // 
            this.colorBtn1.Location = new System.Drawing.Point(367, 9);
            this.colorBtn1.Name = "colorBtn1";
            this.colorBtn1.Size = new System.Drawing.Size(25, 24);
            this.colorBtn1.TabIndex = 21;
            this.colorBtn1.UseVisualStyleBackColor = true;
            // 
            // colorBtn2
            // 
            this.colorBtn2.Location = new System.Drawing.Point(398, 9);
            this.colorBtn2.Name = "colorBtn2";
            this.colorBtn2.Size = new System.Drawing.Size(25, 24);
            this.colorBtn2.TabIndex = 22;
            this.colorBtn2.UseVisualStyleBackColor = true;
            // 
            // colorBtn3
            // 
            this.colorBtn3.Location = new System.Drawing.Point(429, 9);
            this.colorBtn3.Name = "colorBtn3";
            this.colorBtn3.Size = new System.Drawing.Size(25, 24);
            this.colorBtn3.TabIndex = 23;
            this.colorBtn3.UseVisualStyleBackColor = true;
            // 
            // colorBtn4
            // 
            this.colorBtn4.Location = new System.Drawing.Point(460, 9);
            this.colorBtn4.Name = "colorBtn4";
            this.colorBtn4.Size = new System.Drawing.Size(25, 24);
            this.colorBtn4.TabIndex = 24;
            this.colorBtn4.UseVisualStyleBackColor = true;
            // 
            // colorBtn5
            // 
            this.colorBtn5.Location = new System.Drawing.Point(491, 9);
            this.colorBtn5.Name = "colorBtn5";
            this.colorBtn5.Size = new System.Drawing.Size(25, 24);
            this.colorBtn5.TabIndex = 25;
            this.colorBtn5.UseVisualStyleBackColor = true;
            // 
            // colorBtn6
            // 
            this.colorBtn6.Location = new System.Drawing.Point(522, 9);
            this.colorBtn6.Name = "colorBtn6";
            this.colorBtn6.Size = new System.Drawing.Size(25, 24);
            this.colorBtn6.TabIndex = 26;
            this.colorBtn6.UseVisualStyleBackColor = true;
            // 
            // colorBtn7
            // 
            this.colorBtn7.Location = new System.Drawing.Point(367, 54);
            this.colorBtn7.Name = "colorBtn7";
            this.colorBtn7.Size = new System.Drawing.Size(25, 24);
            this.colorBtn7.TabIndex = 27;
            this.colorBtn7.UseVisualStyleBackColor = true;
            // 
            // colorBtn8
            // 
            this.colorBtn8.Location = new System.Drawing.Point(398, 54);
            this.colorBtn8.Name = "colorBtn8";
            this.colorBtn8.Size = new System.Drawing.Size(25, 24);
            this.colorBtn8.TabIndex = 28;
            this.colorBtn8.UseVisualStyleBackColor = true;
            // 
            // colorBtn9
            // 
            this.colorBtn9.Location = new System.Drawing.Point(429, 54);
            this.colorBtn9.Name = "colorBtn9";
            this.colorBtn9.Size = new System.Drawing.Size(25, 24);
            this.colorBtn9.TabIndex = 29;
            this.colorBtn9.UseVisualStyleBackColor = true;
            // 
            // colorBtn10
            // 
            this.colorBtn10.Location = new System.Drawing.Point(460, 54);
            this.colorBtn10.Name = "colorBtn10";
            this.colorBtn10.Size = new System.Drawing.Size(25, 24);
            this.colorBtn10.TabIndex = 30;
            this.colorBtn10.UseVisualStyleBackColor = true;
            // 
            // colorBtn11
            // 
            this.colorBtn11.Location = new System.Drawing.Point(491, 54);
            this.colorBtn11.Name = "colorBtn11";
            this.colorBtn11.Size = new System.Drawing.Size(25, 24);
            this.colorBtn11.TabIndex = 31;
            this.colorBtn11.UseVisualStyleBackColor = true;
            // 
            // colorBtn12
            // 
            this.colorBtn12.Location = new System.Drawing.Point(522, 54);
            this.colorBtn12.Name = "colorBtn12";
            this.colorBtn12.Size = new System.Drawing.Size(25, 24);
            this.colorBtn12.TabIndex = 32;
            this.colorBtn12.UseVisualStyleBackColor = true;
            // 
            // saveFileBtn
            // 
            this.saveFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveFileBtn.BackColor = System.Drawing.Color.MediumPurple;
            this.saveFileBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveFileBtn.Location = new System.Drawing.Point(874, 397);
            this.saveFileBtn.Name = "saveFileBtn";
            this.saveFileBtn.Size = new System.Drawing.Size(112, 35);
            this.saveFileBtn.TabIndex = 33;
            this.saveFileBtn.Text = "Save csv";
            this.saveFileBtn.UseVisualStyleBackColor = false;
            this.saveFileBtn.Click += new System.EventHandler(this.saveFileBtn_Click);
            // 
            // dataSectionListBox
            // 
            this.dataSectionListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataSectionListBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dataSectionListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataSectionListBox.Font = new System.Drawing.Font("Consolas", 10F);
            this.dataSectionListBox.FormattingEnabled = true;
            this.dataSectionListBox.IntegralHeight = false;
            this.dataSectionListBox.ItemHeight = 23;
            this.dataSectionListBox.Location = new System.Drawing.Point(583, 7);
            this.dataSectionListBox.Name = "dataSectionListBox";
            this.dataSectionListBox.Size = new System.Drawing.Size(403, 364);
            this.dataSectionListBox.TabIndex = 34;
            this.dataSectionListBox.SelectedIndexChanged += new System.EventHandler(this.dataSectionListBox_SelectedIndexChanged);
            this.dataSectionListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown_1);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Fuchsia;
            this.button1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(675, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 35);
            this.button1.TabIndex = 35;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.resetBtn.FlatAppearance.BorderSize = 0;
            this.resetBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetBtn.Location = new System.Drawing.Point(782, 397);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(86, 35);
            this.resetBtn.TabIndex = 36;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = false;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1003, 532);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataSectionListBox);
            this.Controls.Add(this.saveFileBtn);
            this.Controls.Add(this.colorBtn12);
            this.Controls.Add(this.colorBtn11);
            this.Controls.Add(this.colorBtn10);
            this.Controls.Add(this.colorBtn9);
            this.Controls.Add(this.colorBtn8);
            this.Controls.Add(this.colorBtn7);
            this.Controls.Add(this.colorBtn6);
            this.Controls.Add(this.colorBtn5);
            this.Controls.Add(this.colorBtn4);
            this.Controls.Add(this.colorBtn3);
            this.Controls.Add(this.colorBtn2);
            this.Controls.Add(this.colorBtn1);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.trackBarTimeLine);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.totalTimeTextBox);
            this.Controls.Add(this.currTimeTextBox);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.checkedListBox1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "NCKUEE Light Dance Design GUI";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimeLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.OpenFileDialog importAudioDialog;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.TextBox currTimeTextBox;
        private System.Windows.Forms.TextBox totalTimeTextBox;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBarTimeLine;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button colorBtn1;
        private System.Windows.Forms.Button colorBtn2;
        private System.Windows.Forms.Button colorBtn3;
        private System.Windows.Forms.Button colorBtn4;
        private System.Windows.Forms.Button colorBtn5;
        private System.Windows.Forms.Button colorBtn6;
        private System.Windows.Forms.Button colorBtn7;
        private System.Windows.Forms.Button colorBtn8;
        private System.Windows.Forms.Button colorBtn9;
        private System.Windows.Forms.Button colorBtn10;
        private System.Windows.Forms.Button colorBtn11;
        private System.Windows.Forms.Button colorBtn12;
        private System.Windows.Forms.Button saveFileBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ListBox dataSectionListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button resetBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

