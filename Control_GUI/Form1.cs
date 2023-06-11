using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;

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
        string SCAN_PORT_BTN = "#CF7FFF";

        int BAUD_RATE = 115200;
        int MAX_STAGE_CNT = 6;
        int STAGE_CNT = 0;

        string[] PORTS_LIST;
        string SEL_PORT="";

        // used to let the Event_Handler can also accessed to statsListBox
        private static Form1 instance;

        public Form1()
        {
            InitializeComponent();
            instance = this;
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
            stageCntTextBox.Text = "[Scenes Count]";
            serialPortTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            serialPortTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            serialPortTextBox.Font = new System.Drawing.Font("Consolas", 11);
            serialPortTextBox.Text = "[Serial Ports]";
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
            scanPortBtn.BackColor = System.Drawing.ColorTranslator.FromHtml(SCAN_PORT_BTN);
            scanPortBtn.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKGREY);
            scanPortBtn.Font = new System.Drawing.Font("Consolas", 13);

            // Set the Baud-rate of serial port
            serialPort1.BaudRate = BAUD_RATE;

            // detect valid serial_port
            PORTS_LIST =SerialPort.GetPortNames();
            // no serial port is detected
            if (PORTS_LIST.Length == 0)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "no serial port is detected! (Try to re-connect & scan again)");
            }
            else
            {
                serialPortComboBox.Items.AddRange(PORTS_LIST);
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "total "+PORTS_LIST.Length.ToString()+" serial port is found");
            }

            // add valid stage count to comboBox
            for (int i=1;i<=MAX_STAGE_CNT;i++)
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
                    button.Text = "Scene " + i.ToString();
                    button.BackColor= System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_DISABLE);
                    button.ForeColor= System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKGREY);
                }
            }

            // subscribe the serialPort1 to DataReceived event
            serialPort1.DataReceived += SerialPort_DataReceived;

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
            statsListBox.Items.Add(currTime+"update scenes count to "+STAGE_CNT.ToString());
            statsListBox.TopIndex = statsListBox.Items.Count - 1;
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
            DialogResult result = MessageBox.Show("Do you really want to clear all states?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
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
                statsListBox.Items.Add(currTime + "need to select scenes count to continue");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            else if(STAGE_CNT < 1)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "this scene is disabled");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            // check if port is specified
            else if(SEL_PORT=="")
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "serial port is either unspecified or invalid");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            else
            {
                // refresh color of all stage button
                refresh_stageBtn_color();
                // change the backcolor to click
                button1.BackColor= System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_CLICK);
                // send signal via serialPort
                serialPort1.WriteLine("1");
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "send the scene 1 signal");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // check if the button is allowed to click
            // must <= STAGE_CNT
            if (STAGE_CNT == 0)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "need to select scenes count to continue");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            else if (STAGE_CNT < 2)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "this scene is disabled");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            // check if port is specified
            else if (SEL_PORT == "")
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "serial port is either unspecified or invalid");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            else
            {
                // refresh color of all stage button
                refresh_stageBtn_color();
                // change the backcolor to click
                button2.BackColor = System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_CLICK);
                // send signal via serialPort
                serialPort1.WriteLine("2");
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "send the scene 2 signal");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // check if the button is allowed to click
            // must <= STAGE_CNT
            if (STAGE_CNT == 0)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "need to select scenes count to continue");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            else if (STAGE_CNT < 3)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "this scene is disabled");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            // check if port is specified
            else if (SEL_PORT == "")
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "serial port is either unspecified or invalid");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            else
            {
                // refresh color of all stage button
                refresh_stageBtn_color();
                // change the backcolor to click
                button3.BackColor = System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_CLICK);
                // send signal via serialPort
                serialPort1.WriteLine("3");
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "send the scene 3 signal");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // check if the button is allowed to click
            // must <= STAGE_CNT
            if (STAGE_CNT == 0)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "need to select scenes count to continue");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            else if (STAGE_CNT < 4)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "this scene is disabled");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            // check if port is specified
            else if (SEL_PORT == "")
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "serial port is either unspecified or invalid");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            else
            {
                // refresh color of all stage button
                refresh_stageBtn_color();
                button4.BackColor = System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_CLICK);
                // send signal via serialPort
                serialPort1.WriteLine("4");
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "send the scene 4 signal");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // check if the button is allowed to click
            // must <= STAGE_CNT
            if (STAGE_CNT == 0)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "need to select scenes count to continue");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            else if (STAGE_CNT < 5)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "this scene is disabled");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            // check if port is specified
            else if (SEL_PORT == "")
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "serial port is either unspecified or invalid");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            else
            {
                // refresh color of all stage button
                refresh_stageBtn_color();
                button5.BackColor = System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_CLICK);
                // send signal via serialPort
                serialPort1.WriteLine("5");
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "send the scene 5 signal");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // check if the button is allowed to click
            // must <= STAGE_CNT
            if (STAGE_CNT == 0)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "need to select scenes count to continue");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            else if (STAGE_CNT < 6)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "this scene is disabled");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            // check if port is specified
            else if (SEL_PORT == "")
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "serial port is either unspecified or invalid");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
                return;
            }
            else
            {
                // refresh color of all stage button
                refresh_stageBtn_color();
                button6.BackColor = System.Drawing.ColorTranslator.FromHtml(STAGE_BTN_CLICK);
                // send signal via serialPort
                serialPort1.WriteLine("6");
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "send the scene 6 signal");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
            }
        }

        private void scanPortBtn_Click(object sender, EventArgs e)
        {
            // detect valid serial_port
            PORTS_LIST = SerialPort.GetPortNames();
            // no serial port is detected
            if (PORTS_LIST.Length == 0)
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "no serial port is detected! (Try to re-connect & scan again)");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
            }
            else
            {
                serialPortComboBox.Items.AddRange(PORTS_LIST);
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "total " + PORTS_LIST.Length.ToString() + " serial port is found");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
            }
            return;
        }

        private void serialPortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // close the current open port
            serialPort1.Close();
            // read the selected port in ComboBox, and update the name to serialPort1
            SEL_PORT = serialPortComboBox.SelectedItem.ToString();
            serialPort1.PortName = SEL_PORT;
            string currTime = get_curr_time();
            statsListBox.Items.Add(currTime + "select serial port [" + SEL_PORT.ToString()+"]");
            statsListBox.TopIndex = statsListBox.Items.Count - 1;
            // try to open the port
            try
            {
                serialPort1.Open();
                currTime= get_curr_time();
                statsListBox.Items.Add(currTime + "successfully open [" + serialPort1.PortName.ToString() + "] serial port (Try to send test signal)");
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
            }
            catch (Exception ex)
            {
                currTime = get_curr_time();
                statsListBox.Items.Add(currTime+"error occurs when try to open port {" + ex.Message+"}");
                // if port cannot be opened, reset SEL_PORT to empty string
                SEL_PORT = "";
                statsListBox.TopIndex = statsListBox.Items.Count - 1;
            }
            return;
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            // check if the port is selected, no need to select STAGE_CNT
            if (SEL_PORT == "")
            {
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "serial port is either unspecified or invalid");
                statsListBox.TopIndex = statsListBox.Items.Count-1;
                return;
            }
            else
            {
                serialPort1.WriteLine("0");
                string currTime = get_curr_time();
                statsListBox.Items.Add(currTime + "send the '0' character as test signal");
                statsListBox.TopIndex = statsListBox.Items.Count-1;
            }
            return;
        }

        // Event handler for the DataReceived event
        private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // first cast the sender to an Serial Port for reading data out
            SerialPort sp = sender as SerialPort;
            if(sp != null)
            {
                // read all existing buffer data at once
                string receivedData = sp.ReadExisting();
                // Split the received data into lines
                string[] lines = receivedData.Split('\n');
                foreach (string line in lines)
                {
                    DateTime currentTime = DateTime.Now;
                    string currTime = "[" + currentTime.ToString("HH:mm:ss") + "] -> ";
                    // make sure no extra unwanted spaces existed
                    string trimmedLine = line.Trim();
                    instance.statsListBox.Items.Add(currTime+trimmedLine);
                    instance.statsListBox.TopIndex = instance.statsListBox.Items.Count - 1;
                }
            }
        }
    }
}
