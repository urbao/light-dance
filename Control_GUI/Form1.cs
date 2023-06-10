using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_GUI
{
    public partial class Form1 : Form
    {
        // Global variables
        string DARKMODE_DARKGREY = "#191E1F";
        string DARKMODE_LIGHTGREY = "#1A282D";
        string DARKMODE_WHITE = "#F2F2F1";
        string TEST_BTN_COLOR = "#7A96EA";
        string CLS_BTN_COLOR = "#F50291";
        string STAGE_BTN_DISABLE = "#4B5A6B";
        string STAGE_BTN_ENABLE = "#66B2B2";
        string STAGE_BTN_CLICK = "#FCC642";

        int BAUD_RATE = 115200;
        int MAX_STAGE_CNT = 6;
        int STAGE_CNT = 0;
        int CLICK_STAGE = 0;

        public Form1()
        {
            InitializeComponent();
            // enable automatically startup in MAX size
            WindowState = FormWindowState.Maximized;

            // change the color of GUI
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKGREY);
            statsGroupBox.Font= new System.Drawing.Font("Consolas", 10);
            statsGroupBox.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            statsGroupBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            optionGroupBox.Font = new System.Drawing.Font("Consolas", 10);
            optionGroupBox.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            optionGroupBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            stageGroupBox.Font = new System.Drawing.Font("Consolas", 10);
            stageGroupBox.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            stageGroupBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            stageCntTextBox.BackColor= System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            stageCntTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            stageCntTextBox.Font = new System.Drawing.Font("Consolas", 11);
            stageCntTextBox.Text = "[Stages Count]";
            testBtn.BackColor= System.Drawing.ColorTranslator.FromHtml(TEST_BTN_COLOR);
            testBtn.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKGREY);
            testBtn.Font = new System.Drawing.Font("Consolas", 13);
            statsListBox.BackColor= System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            statsListBox.ForeColor= System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            statsListBox.Font= new System.Drawing.Font("Consolas", 11);
            clsBtn.BackColor = System.Drawing.ColorTranslator.FromHtml(CLS_BTN_COLOR);
            clsBtn.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKGREY);
            clsBtn.Font = new System.Drawing.Font("Consolas", 13);
            functionGroupBox.Font = new System.Drawing.Font("Consolas", 10);
            functionGroupBox.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            functionGroupBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);

            // Set the Baud-rate of serial port
            serialPort1.BaudRate = BAUD_RATE;

            // add valid stage count to comboBox
            for(int i=1;i<=MAX_STAGE_CNT;i++)
            {
                stageComboBox.Items.Add(i.ToString());
            }

            // set default config of stageBtn
            for(int i=1;i<=MAX_STAGE_CNT;i++)
            {
                string buttonName = "button" + i.ToString();
                // Find the button by name
                Button button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Font = new System.Drawing.Font("Consolas", 13);
                    button.Text = "Stage " + i.ToString();
                    button.BackColor= System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_DISABLE);
                    button.ForeColor= System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKGREY);
                }
            }

        }
        // used for update current time and print in statsListBox
        private string get_curr_time()
        {
            DateTime currentTime = DateTime.Now;
            string formattedTime = "["+currentTime.ToString("HH:mm:ss")+"] -> ";
            return formattedTime;
        }

        private void stageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            STAGE_CNT = stageComboBox.SelectedIndex+1;
            string currTime=get_curr_time();
            statsListBox.Items.Add(currTime+"update stages count to "+STAGE_CNT.ToString());
            // make the button light up
            for (int i = 1; i <= MAX_STAGE_CNT; i++)
            {
                string buttonName = "button" + i.ToString();
                // Find the button by name
                Button button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null&&i<=STAGE_CNT)
                {
                    button.Font = new System.Drawing.Font("Consolas", 13, FontStyle.Bold);
                    button.BackColor = System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_ENABLE);
                }
                else
                {
                    button.Font = new System.Drawing.Font("Consolas", 13);
                    button.BackColor = System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_DISABLE);
                }
            }
            return;
        }

        private void clsBtn_Click(object sender, EventArgs e)
        {
            statsListBox.Items.Clear();
            string currTime = get_curr_time();
            statsListBox.Items.Add(currTime + "successfully clear all states");
            return;
        }

        private void refresh_stageBtn_color()
        {
            // make the button light up
            for (int i = 1; i <= MAX_STAGE_CNT; i++)
            {
                string buttonName = "button" + i.ToString();
                // Find the button by name
                Button button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null && i <= STAGE_CNT)
                {
                    button.Font = new System.Drawing.Font("Consolas", 13, FontStyle.Bold);
                    button.BackColor = System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_ENABLE);
                }
                else
                {
                    button.Font = new System.Drawing.Font("Consolas", 13);
                    button.BackColor = System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_DISABLE);
                }
            }
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // check if the button is allowed to click
            // must <= STAGE_CNT
            if (STAGE_CNT == 0)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "need to select stages count to continue");
                return;
            }
            else if(STAGE_CNT < 1)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "this stage is disabled");
                return;
            }
            else
            {
                // refresh color of all stage button
                refresh_stageBtn_color();
                // change the backcolor to click
                button1.BackColor= System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_CLICK);
                // send signal via serialPort

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // check if the button is allowed to click
            // must <= STAGE_CNT
            if (STAGE_CNT == 0)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "need to select stages count to continue");
                return;
            }
            else if (STAGE_CNT < 2)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "this stage is disabled");
                return;
            }
            else
            {
                // refresh color of all stage button
                refresh_stageBtn_color();
                // change the backcolor to click
                button2.BackColor = System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_CLICK);
                // send signal via serialPort

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // check if the button is allowed to click
            // must <= STAGE_CNT
            if (STAGE_CNT == 0)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "need to select stages count to continue");
                return;
            }
            else if (STAGE_CNT < 3)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "this stage is disabled");
                return;
            }
            else
            {
                // refresh color of all stage button
                refresh_stageBtn_color();
                // change the backcolor to click
                button3.BackColor = System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_CLICK);
                // send signal via serialPort

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // check if the button is allowed to click
            // must <= STAGE_CNT
            if (STAGE_CNT == 0)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "need to select stages count to continue");
                return;
            }
            else if (STAGE_CNT < 4)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "this stage is disabled");
                return;
            }
            else
            {
                // refresh color of all stage button
                refresh_stageBtn_color();
                button4.BackColor = System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_CLICK);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // check if the button is allowed to click
            // must <= STAGE_CNT
            if (STAGE_CNT == 0)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "need to select stages count to continue");
                return;
            }
            else if (STAGE_CNT < 5)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "this stage is disabled");
                return;
            }
            else
            {
                // refresh color of all stage button
                refresh_stageBtn_color();
                button5.BackColor = System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_CLICK);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // check if the button is allowed to click
            // must <= STAGE_CNT
            if (STAGE_CNT == 0)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "need to select stages count to continue");
                return;
            }
            else if (STAGE_CNT < 6)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "this stage is disabled");
                return;
            }
            else
            {
                // refresh color of all stage button
                refresh_stageBtn_color();
                button6.BackColor = System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_CLICK);
            }
        }
    }
}
