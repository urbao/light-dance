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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.blueTrackBar = new System.Windows.Forms.TrackBar();
            this.greenTrackBar = new System.Windows.Forms.TrackBar();
            this.redTrackBar = new System.Windows.Forms.TrackBar();
            this.R = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.redTextBox = new System.Windows.Forms.TextBox();
            this.greenTextBox = new System.Windows.Forms.TextBox();
            this.blueTextBox = new System.Windows.Forms.TextBox();
            this.importAudioDialog = new System.Windows.Forms.OpenFileDialog();
            this.importBtn = new System.Windows.Forms.Button();
            this.currTimeTextBox = new System.Windows.Forms.TextBox();
            this.totalTimeTextBox = new System.Windows.Forms.TextBox();
            this.playBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBarTimeLine = new System.Windows.Forms.TrackBar();
            this.addBtn = new System.Windows.Forms.Button();
            this.redColorBtn = new System.Windows.Forms.Button();
            this.orangeColorBtn = new System.Windows.Forms.Button();
            this.yellowColorBtn = new System.Windows.Forms.Button();
            this.greenColorBtn = new System.Windows.Forms.Button();
            this.darkGreenColorBtn = new System.Windows.Forms.Button();
            this.cyanColorBtn = new System.Windows.Forms.Button();
            this.blueColorBtn = new System.Windows.Forms.Button();
            this.purpleColorBtn = new System.Windows.Forms.Button();
            this.pinkColorBtn = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.blackColorBtn = new System.Windows.Forms.Button();
            this.saveFileBtn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimeLine)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(7, 7);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(238, 342);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // colorPanel
            // 
            this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorPanel.Location = new System.Drawing.Point(251, 7);
            this.colorPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(76, 71);
            this.colorPanel.TabIndex = 4;
            // 
            // blueTrackBar
            // 
            this.blueTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blueTrackBar.LargeChange = 1;
            this.blueTrackBar.Location = new System.Drawing.Point(393, 330);
            this.blueTrackBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.blueTrackBar.Maximum = 255;
            this.blueTrackBar.Name = "blueTrackBar";
            this.blueTrackBar.Size = new System.Drawing.Size(453, 69);
            this.blueTrackBar.TabIndex = 5;
            this.blueTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.blueTrackBar.Scroll += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // greenTrackBar
            // 
            this.greenTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.greenTrackBar.LargeChange = 1;
            this.greenTrackBar.Location = new System.Drawing.Point(393, 253);
            this.greenTrackBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.greenTrackBar.Maximum = 255;
            this.greenTrackBar.Name = "greenTrackBar";
            this.greenTrackBar.Size = new System.Drawing.Size(453, 69);
            this.greenTrackBar.TabIndex = 6;
            this.greenTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // redTrackBar
            // 
            this.redTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.redTrackBar.LargeChange = 1;
            this.redTrackBar.Location = new System.Drawing.Point(393, 176);
            this.redTrackBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.redTrackBar.Maximum = 255;
            this.redTrackBar.Name = "redTrackBar";
            this.redTrackBar.Size = new System.Drawing.Size(453, 69);
            this.redTrackBar.TabIndex = 7;
            this.redTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // R
            // 
            this.R.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.R.BackColor = System.Drawing.Color.Red;
            this.R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.R.Location = new System.Drawing.Point(286, 176);
            this.R.Name = "R";
            this.R.Size = new System.Drawing.Size(23, 24);
            this.R.TabIndex = 8;
            this.R.Text = "R";
            this.R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.Lime;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(285, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "G";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.BackColor = System.Drawing.Color.Cyan;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(285, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "B";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // redTextBox
            // 
            this.redTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.redTextBox.Location = new System.Drawing.Point(323, 176);
            this.redTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.redTextBox.Name = "redTextBox";
            this.redTextBox.Size = new System.Drawing.Size(64, 29);
            this.redTextBox.TabIndex = 11;
            this.redTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // greenTextBox
            // 
            this.greenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.greenTextBox.Location = new System.Drawing.Point(323, 253);
            this.greenTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.greenTextBox.Name = "greenTextBox";
            this.greenTextBox.Size = new System.Drawing.Size(64, 29);
            this.greenTextBox.TabIndex = 12;
            this.greenTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // blueTextBox
            // 
            this.blueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.blueTextBox.Location = new System.Drawing.Point(323, 330);
            this.blueTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.blueTextBox.Name = "blueTextBox";
            this.blueTextBox.Size = new System.Drawing.Size(64, 29);
            this.blueTextBox.TabIndex = 13;
            this.blueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // importAudioDialog
            // 
            this.importAudioDialog.FileName = "importAudioDialog";
            // 
            // importBtn
            // 
            this.importBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.importBtn.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.Location = new System.Drawing.Point(344, 385);
            this.importBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(134, 35);
            this.importBtn.TabIndex = 14;
            this.importBtn.Text = "Import Audio";
            this.importBtn.UseVisualStyleBackColor = false;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // currTimeTextBox
            // 
            this.currTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currTimeTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.currTimeTextBox.Location = new System.Drawing.Point(25, 391);
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
            this.totalTimeTextBox.Location = new System.Drawing.Point(104, 391);
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
            this.playBtn.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.Location = new System.Drawing.Point(202, 385);
            this.playBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(125, 35);
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
            this.trackBarTimeLine.BackColor = System.Drawing.SystemColors.GrayText;
            this.trackBarTimeLine.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackBarTimeLine.Location = new System.Drawing.Point(-1, 433);
            this.trackBarTimeLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBarTimeLine.Name = "trackBarTimeLine";
            this.trackBarTimeLine.Size = new System.Drawing.Size(865, 69);
            this.trackBarTimeLine.TabIndex = 19;
            this.trackBarTimeLine.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarTimeLine.Scroll += new System.EventHandler(this.trackBarTimeLine_Scroll);
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.addBtn.FlatAppearance.BorderSize = 0;
            this.addBtn.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(541, 385);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(86, 35);
            this.addBtn.TabIndex = 20;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // redColorBtn
            // 
            this.redColorBtn.Location = new System.Drawing.Point(344, 9);
            this.redColorBtn.Name = "redColorBtn";
            this.redColorBtn.Size = new System.Drawing.Size(25, 24);
            this.redColorBtn.TabIndex = 21;
            this.redColorBtn.UseVisualStyleBackColor = true;
            // 
            // orangeColorBtn
            // 
            this.orangeColorBtn.Location = new System.Drawing.Point(375, 9);
            this.orangeColorBtn.Name = "orangeColorBtn";
            this.orangeColorBtn.Size = new System.Drawing.Size(25, 24);
            this.orangeColorBtn.TabIndex = 22;
            this.orangeColorBtn.UseVisualStyleBackColor = true;
            // 
            // yellowColorBtn
            // 
            this.yellowColorBtn.Location = new System.Drawing.Point(406, 9);
            this.yellowColorBtn.Name = "yellowColorBtn";
            this.yellowColorBtn.Size = new System.Drawing.Size(25, 24);
            this.yellowColorBtn.TabIndex = 23;
            this.yellowColorBtn.UseVisualStyleBackColor = true;
            // 
            // greenColorBtn
            // 
            this.greenColorBtn.Location = new System.Drawing.Point(437, 9);
            this.greenColorBtn.Name = "greenColorBtn";
            this.greenColorBtn.Size = new System.Drawing.Size(25, 24);
            this.greenColorBtn.TabIndex = 24;
            this.greenColorBtn.UseVisualStyleBackColor = true;
            // 
            // darkGreenColorBtn
            // 
            this.darkGreenColorBtn.Location = new System.Drawing.Point(468, 9);
            this.darkGreenColorBtn.Name = "darkGreenColorBtn";
            this.darkGreenColorBtn.Size = new System.Drawing.Size(25, 24);
            this.darkGreenColorBtn.TabIndex = 25;
            this.darkGreenColorBtn.UseVisualStyleBackColor = true;
            // 
            // cyanColorBtn
            // 
            this.cyanColorBtn.Location = new System.Drawing.Point(499, 9);
            this.cyanColorBtn.Name = "cyanColorBtn";
            this.cyanColorBtn.Size = new System.Drawing.Size(25, 24);
            this.cyanColorBtn.TabIndex = 26;
            this.cyanColorBtn.UseVisualStyleBackColor = true;
            // 
            // blueColorBtn
            // 
            this.blueColorBtn.Location = new System.Drawing.Point(344, 54);
            this.blueColorBtn.Name = "blueColorBtn";
            this.blueColorBtn.Size = new System.Drawing.Size(25, 24);
            this.blueColorBtn.TabIndex = 27;
            this.blueColorBtn.UseVisualStyleBackColor = true;
            // 
            // purpleColorBtn
            // 
            this.purpleColorBtn.Location = new System.Drawing.Point(375, 54);
            this.purpleColorBtn.Name = "purpleColorBtn";
            this.purpleColorBtn.Size = new System.Drawing.Size(25, 24);
            this.purpleColorBtn.TabIndex = 28;
            this.purpleColorBtn.UseVisualStyleBackColor = true;
            // 
            // pinkColorBtn
            // 
            this.pinkColorBtn.Location = new System.Drawing.Point(406, 54);
            this.pinkColorBtn.Name = "pinkColorBtn";
            this.pinkColorBtn.Size = new System.Drawing.Size(25, 24);
            this.pinkColorBtn.TabIndex = 29;
            this.pinkColorBtn.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(437, 54);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(25, 24);
            this.button8.TabIndex = 30;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(468, 54);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(25, 24);
            this.button9.TabIndex = 31;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // blackColorBtn
            // 
            this.blackColorBtn.Location = new System.Drawing.Point(499, 54);
            this.blackColorBtn.Name = "blackColorBtn";
            this.blackColorBtn.Size = new System.Drawing.Size(25, 24);
            this.blackColorBtn.TabIndex = 32;
            this.blackColorBtn.UseVisualStyleBackColor = true;
            // 
            // saveFileBtn
            // 
            this.saveFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveFileBtn.BackColor = System.Drawing.Color.MediumPurple;
            this.saveFileBtn.Font = new System.Drawing.Font("Consolas", 10F);
            this.saveFileBtn.Location = new System.Drawing.Point(734, 385);
            this.saveFileBtn.Name = "saveFileBtn";
            this.saveFileBtn.Size = new System.Drawing.Size(112, 35);
            this.saveFileBtn.TabIndex = 33;
            this.saveFileBtn.Text = "Save csv";
            this.saveFileBtn.UseVisualStyleBackColor = false;
            this.saveFileBtn.Click += new System.EventHandler(this.saveFileBtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("Consolas", 10F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(564, 7);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(282, 158);
            this.listBox1.TabIndex = 34;
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown_1);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Fuchsia;
            this.button1.Font = new System.Drawing.Font("Consolas", 10F);
            this.button1.Location = new System.Drawing.Point(633, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 35);
            this.button1.TabIndex = 35;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(863, 520);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.saveFileBtn);
            this.Controls.Add(this.blackColorBtn);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.pinkColorBtn);
            this.Controls.Add(this.purpleColorBtn);
            this.Controls.Add(this.blueColorBtn);
            this.Controls.Add(this.cyanColorBtn);
            this.Controls.Add(this.darkGreenColorBtn);
            this.Controls.Add(this.greenColorBtn);
            this.Controls.Add(this.yellowColorBtn);
            this.Controls.Add(this.orangeColorBtn);
            this.Controls.Add(this.redColorBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.trackBarTimeLine);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.totalTimeTextBox);
            this.Controls.Add(this.currTimeTextBox);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.blueTextBox);
            this.Controls.Add(this.greenTextBox);
            this.Controls.Add(this.redTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.R);
            this.Controls.Add(this.redTrackBar);
            this.Controls.Add(this.greenTrackBar);
            this.Controls.Add(this.blueTrackBar);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.checkedListBox1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Light Dance";
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimeLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.TrackBar blueTrackBar;
        private System.Windows.Forms.TrackBar greenTrackBar;
        private System.Windows.Forms.TrackBar redTrackBar;
        private System.Windows.Forms.Label R;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox redTextBox;
        private System.Windows.Forms.TextBox greenTextBox;
        private System.Windows.Forms.TextBox blueTextBox;
        private System.Windows.Forms.OpenFileDialog importAudioDialog;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.TextBox currTimeTextBox;
        private System.Windows.Forms.TextBox totalTimeTextBox;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBarTimeLine;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button redColorBtn;
        private System.Windows.Forms.Button orangeColorBtn;
        private System.Windows.Forms.Button yellowColorBtn;
        private System.Windows.Forms.Button greenColorBtn;
        private System.Windows.Forms.Button darkGreenColorBtn;
        private System.Windows.Forms.Button cyanColorBtn;
        private System.Windows.Forms.Button blueColorBtn;
        private System.Windows.Forms.Button purpleColorBtn;
        private System.Windows.Forms.Button pinkColorBtn;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button blackColorBtn;
        private System.Windows.Forms.Button saveFileBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
    }
}

