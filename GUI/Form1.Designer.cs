﻿namespace GUI
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
            this.importAudioDialog = new System.Windows.Forms.OpenFileDialog();
            this.importBtn = new System.Windows.Forms.Button();
            this.currTimeTextBox = new System.Windows.Forms.TextBox();
            this.totalTimeTextBox = new System.Windows.Forms.TextBox();
            this.playBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBarTimeLine = new System.Windows.Forms.TrackBar();
            this.addBtn = new System.Windows.Forms.Button();
            this.saveFileBtn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.dataSectionListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.resetBtn = new System.Windows.Forms.Button();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.selectAllRadioBtn = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.unselectAllRadioBtn = new System.Windows.Forms.RadioButton();
            this.upperBodyRadioBtn = new System.Windows.Forms.RadioButton();
            this.lowerBodyRadioBtn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimeLine)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.checkedListBox1.Location = new System.Drawing.Point(6, 13);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(238, 208);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
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
            this.importBtn.Location = new System.Drawing.Point(261, 398);
            this.importBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(141, 35);
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
            this.playBtn.Location = new System.Drawing.Point(166, 398);
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
            this.trackBarTimeLine.Location = new System.Drawing.Point(-1, 437);
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
            this.addBtn.Location = new System.Drawing.Point(544, 398);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(86, 35);
            this.addBtn.TabIndex = 20;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
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
            this.dataSectionListBox.Location = new System.Drawing.Point(6, 13);
            this.dataSectionListBox.Name = "dataSectionListBox";
            this.dataSectionListBox.Size = new System.Drawing.Size(439, 293);
            this.dataSectionListBox.TabIndex = 34;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Fuchsia;
            this.button1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(636, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 35);
            this.button1.TabIndex = 35;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.resetBtn.FlatAppearance.BorderSize = 0;
            this.resetBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetBtn.Location = new System.Drawing.Point(737, 398);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(86, 35);
            this.resetBtn.TabIndex = 36;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = false;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(6, 13);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(262, 338);
            this.checkedListBox2.TabIndex = 37;
            this.checkedListBox2.SelectedIndexChanged += new System.EventHandler(this.checkedListBox2_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 236);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Body Parts(Multiple choices)";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.checkedListBox2);
            this.groupBox2.Location = new System.Drawing.Point(264, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 363);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode(Single choice)";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dataSectionListBox);
            this.groupBox3.Location = new System.Drawing.Point(544, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(451, 312);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preview";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.stateTextBox);
            this.groupBox4.Location = new System.Drawing.Point(544, 327);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(451, 45);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "State";
            // 
            // stateTextBox
            // 
            this.stateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stateTextBox.Location = new System.Drawing.Point(6, 16);
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.Size = new System.Drawing.Size(439, 22);
            this.stateTextBox.TabIndex = 38;
            // 
            // selectAllRadioBtn
            // 
            this.selectAllRadioBtn.AutoSize = true;
            this.selectAllRadioBtn.Location = new System.Drawing.Point(6, 19);
            this.selectAllRadioBtn.Name = "selectAllRadioBtn";
            this.selectAllRadioBtn.Size = new System.Drawing.Size(135, 26);
            this.selectAllRadioBtn.TabIndex = 2;
            this.selectAllRadioBtn.TabStop = true;
            this.selectAllRadioBtn.Text = "Select All";
            this.selectAllRadioBtn.UseVisualStyleBackColor = true;
            this.selectAllRadioBtn.CheckedChanged += new System.EventHandler(this.selectAllRadioBtn_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.lowerBodyRadioBtn);
            this.groupBox5.Controls.Add(this.upperBodyRadioBtn);
            this.groupBox5.Controls.Add(this.unselectAllRadioBtn);
            this.groupBox5.Controls.Add(this.selectAllRadioBtn);
            this.groupBox5.Location = new System.Drawing.Point(8, 250);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(250, 122);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Shortcut";
            // 
            // unselectAllRadioBtn
            // 
            this.unselectAllRadioBtn.AutoSize = true;
            this.unselectAllRadioBtn.Location = new System.Drawing.Point(6, 45);
            this.unselectAllRadioBtn.Name = "unselectAllRadioBtn";
            this.unselectAllRadioBtn.Size = new System.Drawing.Size(155, 26);
            this.unselectAllRadioBtn.TabIndex = 3;
            this.unselectAllRadioBtn.TabStop = true;
            this.unselectAllRadioBtn.Text = "Unselect All";
            this.unselectAllRadioBtn.UseVisualStyleBackColor = true;
            this.unselectAllRadioBtn.CheckedChanged += new System.EventHandler(this.unselectAllRadioBtn_CheckedChanged);
            // 
            // upperBodyRadioBtn
            // 
            this.upperBodyRadioBtn.AutoSize = true;
            this.upperBodyRadioBtn.Location = new System.Drawing.Point(6, 71);
            this.upperBodyRadioBtn.Name = "upperBodyRadioBtn";
            this.upperBodyRadioBtn.Size = new System.Drawing.Size(205, 26);
            this.upperBodyRadioBtn.TabIndex = 4;
            this.upperBodyRadioBtn.TabStop = true;
            this.upperBodyRadioBtn.Text = "Select Upper Body";
            this.upperBodyRadioBtn.UseVisualStyleBackColor = true;
            this.upperBodyRadioBtn.CheckedChanged += new System.EventHandler(this.upperBodyRadioBtn_CheckedChanged);
            // 
            // lowerBodyRadioBtn
            // 
            this.lowerBodyRadioBtn.AutoSize = true;
            this.lowerBodyRadioBtn.Location = new System.Drawing.Point(6, 96);
            this.lowerBodyRadioBtn.Name = "lowerBodyRadioBtn";
            this.lowerBodyRadioBtn.Size = new System.Drawing.Size(205, 26);
            this.lowerBodyRadioBtn.TabIndex = 5;
            this.lowerBodyRadioBtn.TabStop = true;
            this.lowerBodyRadioBtn.Text = "Select Lower Body";
            this.lowerBodyRadioBtn.UseVisualStyleBackColor = true;
            this.lowerBodyRadioBtn.CheckedChanged += new System.EventHandler(this.lowerBodyRadioBtn_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1003, 532);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveFileBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.trackBarTimeLine);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.totalTimeTextBox);
            this.Controls.Add(this.currTimeTextBox);
            this.Controls.Add(this.importBtn);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "NCKUEE Light Dance Design GUI";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimeLine)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.OpenFileDialog importAudioDialog;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.TextBox currTimeTextBox;
        private System.Windows.Forms.TextBox totalTimeTextBox;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBarTimeLine;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button saveFileBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ListBox dataSectionListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.RadioButton selectAllRadioBtn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton unselectAllRadioBtn;
        private System.Windows.Forms.RadioButton upperBodyRadioBtn;
        private System.Windows.Forms.RadioButton lowerBodyRadioBtn;
    }
}

