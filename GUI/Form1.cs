using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 用來import音樂檔案(允許撥放音樂/讀取音樂長度/顯示現在時間)
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class Form1 : Form
    {
        // Global Variable
        // 有音檔位置, wpm, 預覽畫面的line...
        private string musicFilePath;
        private WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer();
        private List<string> chosedBodyPart=new List<string>();
        private string chosedLedMode = "";
        private int lastChosedLedModeIdx = -1;
        //private string chosedHexColor="";
        bool isPlayingAudio = false;

        /* ----- 以下的global參數可以視情況做調整 -----*/
        // 可以操控的LED燈條部位
        string[] available_body_parts = { "Head", "Body", "Right Hand", "Left Hand", "Right Foot", "Left Foot", "Shoes" };
        // 可以控制LED亮暗的模式
        string[] available_led_modes = { "Both Off", "1 On(2 Off)", "1 Off(2 On)", "Both On" };
        // 預設色塊顏色(用Hex Code表示，共6碼)
        string DEFAULT_COLOR_1 = "#C70039";
        string DEFAULT_COLOR_2 = "#FF5733";
        string DEFAULT_COLOR_3 = "#FFC300";
        string DEFAULT_COLOR_4 = "#00ff67";
        string DEFAULT_COLOR_5 = "#0d9b46";
        string DEFAULT_COLOR_6 = "#00FFFF";
        string DEFAULT_COLOR_7 = "#0d7f9b";
        string DEFAULT_COLOR_8 = "#c007dc";
        string DEFAULT_COLOR_9 = "#f44ae0";
        string DEFAULT_COLOR_10 = "#000000";
        string DEFAULT_COLOR_11 = "#FFB6C1";
        string DEFAULT_COLOR_12 = "#B0C4DE";

        // dark mode的色塊hex code
        string DARKMODE_DARKGREY = "#191E1F";
        string DARKMODE_LIGHTGREY = "#1A282D";
        string DARKMODE_WHITE = "#F2F2F1";
        string DARKMODE_DARKWHITE = "#B0B6B8";
        string DARKMODE_CYAN = "#06D1B5";
        string DARKMODE_PINK = "#F436BC";

        /* ---------------------------------------- */

        public Form1()
        {
            InitializeComponent();
            // 各個區塊的顏色(改掉原本預設的白色(太醜了))
            this.BackColor=System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKGREY);
            dataSectionListBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            dataSectionListBox.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            dataSectionListBox.Font = new System.Drawing.Font("Consolas", 11);
            checkedListBox1.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            checkedListBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            checkedListBox1.Font = new System.Drawing.Font("Consolas", 10);
            checkedListBox2.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            checkedListBox2.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            checkedListBox2.Font = new System.Drawing.Font("Consolas", 10);
            trackBarTimeLine.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            currTimeTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKWHITE);
            totalTimeTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKWHITE);
            playBtn.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_CYAN);
            //colorPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            // 列出所有可以控制的身體部位
            // 可以做彈性調整(目前預設: 頭/右手/右腳/左手/左腳/身體)
            checkedListBox1.Items.AddRange(available_body_parts);
            // 點一下選項就可以成功選取部位
            checkedListBox1.CheckOnClick = true;

            // 列出所有可以選擇的亮暗模式
            checkedListBox2.Items.AddRange(available_led_modes);
            checkedListBox2.CheckOnClick = true;

            // 尚未import music之前，預設總時間為00:00
            totalTimeTextBox.Text = string.Format("{0:00}:{1:00}", 0, 0);


            // 把預設得色塊顏色指定給對應的label
            /*colorBtn1.BackColor = ColorTranslator.FromHtml(DEFAULT_COLOR_1);
            colorBtn2.BackColor = ColorTranslator.FromHtml(DEFAULT_COLOR_2);
            colorBtn3.BackColor = ColorTranslator.FromHtml(DEFAULT_COLOR_3);
            colorBtn4.BackColor=ColorTranslator.FromHtml(DEFAULT_COLOR_4);
            colorBtn5.BackColor = ColorTranslator.FromHtml(DEFAULT_COLOR_5);
            colorBtn6.BackColor = ColorTranslator.FromHtml(DEFAULT_COLOR_6);
            colorBtn7.BackColor=ColorTranslator.FromHtml(DEFAULT_COLOR_7);
            colorBtn8.BackColor = ColorTranslator.FromHtml(DEFAULT_COLOR_8);
            colorBtn9.BackColor=ColorTranslator.FromHtml(DEFAULT_COLOR_9);
            colorBtn12.BackColor = ColorTranslator.FromHtml(DEFAULT_COLOR_10);
            colorBtn10.BackColor = ColorTranslator.FromHtml(DEFAULT_COLOR_11);
            colorBtn11.BackColor = ColorTranslator.FromHtml(DEFAULT_COLOR_12);*/

            // 任何一格預設色塊的button被點擊，更新RGB顏色
            /* colorBtn1.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_COLOR_1));
             colorBtn2.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_COLOR_2));
             colorBtn3.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_COLOR_3));
             colorBtn4.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_COLOR_4));
             colorBtn5.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_COLOR_5));
             colorBtn6.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_COLOR_6));
             colorBtn7.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_COLOR_7));
             colorBtn8.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_COLOR_8));
             colorBtn9.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_COLOR_9));
             colorBtn12.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_COLOR_10));
             colorBtn10.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_COLOR_11));
             colorBtn11.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_COLOR_12));*/
        }


        // trackBar RGB值更新，並更新colorPanel的顏色

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 先reset選擇的bodyPart string(用clear function)
            chosedBodyPart.Clear();
            foreach (string item in checkedListBox1.CheckedItems)
            {
                chosedBodyPart.Add(item.ToString());
            }
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog importMusicFile = new OpenFileDialog();
            importMusicFile.Filter = "Audio files| *.mp3; *.wav; *.wma";
            if(importMusicFile.ShowDialog()== DialogResult.OK )
            {
                // 先用openDialog得到音檔位置，並將其存到wmp.URL
                musicFilePath=importMusicFile.FileName;
                wmp.URL = musicFilePath;
                // 用WMPLib得到音檔的長度和名字，將資訊印在textBox上面
                WMPLib.IWMPMedia media= wmp.newMedia(musicFilePath);
                double durationSeconds = media.duration;
                trackBarTimeLine.Maximum=(int)durationSeconds;
                trackBarTimeLine.Minimum = 0;
                int minute = trackBarTimeLine.Maximum / 60;
                int second = trackBarTimeLine.Maximum % 60;
                totalTimeTextBox.Text = string.Format("{0:00}:{1:00}", minute, second);
                trackBarTimeLine.Value = 0;
                currTimeTextBox.Text = trackBarTimeLine.Value.ToString();
            }
            playBtn.Text = "Pause";
            playBtn.BackColor = Color.LightPink;
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (isPlayingAudio == true)
            {
                wmp.controls.pause();
                timer1.Stop();
                isPlayingAudio = false;
                playBtn.Text = "Play";
                playBtn.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_CYAN);
            }
            else
            {
                wmp.controls.play();
                timer1.Start();
                isPlayingAudio = true;
                playBtn.Text = "Pause";
                playBtn.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_PINK);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBarTimeLine.Value = (int)wmp.controls.currentPosition;
            currTimeTextBox.Text = TimeSpan.FromSeconds(trackBarTimeLine.Value).ToString(@"mm\:ss");
        }

        private void trackBarTimeLine_Scroll(object sender, EventArgs e)
        {
            wmp.controls.currentPosition = trackBarTimeLine.Value;
            currTimeTextBox.Text = TimeSpan.FromSeconds(wmp.controls.currentPosition).ToString(@"mm\:ss");
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // addedText: 寫入檔案的資料(時間(s)+部位+RGB)
            // 有做foolproof: 防止沒有選擇部位: 印出警示提醒
            // 或是RGB沒給值: 預設為(0,0,0)
            int currTime=(int)wmp.controls.currentPosition;
            if (chosedBodyPart.Count == 0)
            {
                MessageBox.Show("The body parts cannot be empty :(", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 不再繼續寫入資料
            }
            if (chosedLedMode == "")
            {
                MessageBox.Show("The LED mode cannot be empty :(", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // 把chosedBodyPart的每個部位都寫成一行獨立command
            string addedText = "";
            foreach(string bodyPart in chosedBodyPart)
            {
                // 把dataSectionListBox的內容印的整齊一點
                int timeMaxLength = 5;
                int bodyPartMaxLength = 11;
                int ledModeMaxLength = 12;
                string prettyCurrTime=(currTime.ToString()).PadLeft(timeMaxLength, ' ');
                string prettyBodyPart = bodyPart.PadLeft(bodyPartMaxLength, ' ');
                string prettyLedMode = chosedLedMode.PadLeft(ledModeMaxLength, ' ');
                addedText=prettyCurrTime+"|"+prettyBodyPart+"|"+prettyLedMode;
                dataSectionListBox.Items.Add(addedText);

            }
            // 把資料加入成功後，依據time重新排序順序(方便使用者觀察和之後存檔)
            // 先把dataSectionListBox的資料存到List<string>，再對其排序
            // 最後，再把資料存回dataSectionListBox
            List<string> allItems=dataSectionListBox.Items.Cast<string>().ToList();
            allItems.Sort((s1, s2) => {
                s1.TrimStart();
                s2.TrimStart();
                int time1 = int.Parse(s1.Split('|')[0]);
                int time2 = int.Parse(s2.Split('|')[0]);
                return time1.CompareTo(time2);
            });
            dataSectionListBox.Items.Clear();
            dataSectionListBox.Items.AddRange(allItems.ToArray());

        }

        // 把RGB更新為點擊的預設色塊button顏色
        /*private void UpdateRGBToDefaultColor(object sender, EventArgs e, string DEFAULT_COLOR)
        {
            Color color = (Color)ColorTranslator.FromHtml(DEFAULT_COLOR);
            chosedHexColor = DEFAULT_COLOR;
            colorPanel.BackColor = color;
        }*/

        private void saveFileBtn_Click(object sender, EventArgs e)
        {
            // 先檢查是否有資料可以存檔，如果沒有，印出警示
            if (dataSectionListBox.Items.Count == 0)
            {
                MessageBox.Show("The data section cannot be empty !\nAdd something via 'Add' button :)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 不再繼續存檔動作
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // 只允許存成csv檔(可以再做調整)
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            // 用今日日期和時間存檔
            DateTime currDateTime = DateTime.Now;
            saveFileDialog.FileName = currDateTime.ToString("yyyyMMdd_HH-mm");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 把所有dataSectionListBox的Items存到csv file
                using (StreamWriter writer=new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (string item in dataSectionListBox.Items)
                    {
                        // 寫檔之前，把item轉成Arduino讀檔看得懂的內容
                        // 用Split()把資料分開判斷
                        string[] data=item.Split('|');
                        // data[]={currTime, bodyPart, Mode}
                        // 先把currTime轉成millisecond
                        int timeSec = Int32.Parse(data[0]);
                        string timeMillis = (timeSec * 1000).ToString();

                        // 再把bodyPart轉成相應0~6代號
                        string code = "-1";
                        // 移除padding用的space
                        data[1] = data[1].TrimStart();
                        if (data[1] == "Head") code = "0";
                        else if (data[1] == "Body") code = "1";
                        else if (data[1] == "Right Hand") code = "2";
                        else if (data[1] == "Left Hand") code = "3";
                        else if (data[1] == "Right Foot") code = "4";
                        else if (data[1] == "Left Foot") code = "5";
                        else if (data[1] == "Shoes") code = "6";
                        else code="-1";

                        // 把chosedLedMode也加入最後寫的內容
                        string mode = "-2";
                        // 移除padding用的space
                        data[2] = data[2].TrimStart();
                        if (data[2] == "Both Off") mode = "0";
                        else if (data[2] == "1 On(2 Off)") mode = "1";
                        else if (data[2] == "1 Off(2 On)") mode = "2";
                        else if (data[2] == "Both On") mode = "3";
                        else mode="-2";
                        string writtenData=timeMillis + "," + code+","+mode+"\n";
                        writer.Write(writtenData);
                    }
                    // 多寫入一行End File方便辨識是否結束
                    writer.Write("End File");
                }
                MessageBox.Show("Successfully save as csv file :)", "Done");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 刪掉在listBox1中選取的line
            string selectedLine=(string)dataSectionListBox.SelectedItem;
            if(selectedLine == null)
            {
                MessageBox.Show("No line is chosed in data section :(", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dataSectionListBox.Items.Remove(selectedLine);
            }
        }

        // 當使用者選取某行資料，並且按下delete鍵，則delete該行
        private void listBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dataSectionListBox.SelectedIndex != -1)
                {
                    dataSectionListBox.Items.RemoveAt(dataSectionListBox.SelectedIndex);
                }
            }
        }

        // 把所有dataSectionListBox的資料清除
        private void resetBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset?\n[Caution] This will earse all data !!!", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dataSectionListBox.Items.Clear();
            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // selectedIndex: 前一個選的mode的index
            int selectedIndex = checkedListBox2.SelectedIndex;
            if (selectedIndex==lastChosedLedModeIdx)
            {
                checkedListBox2.SetItemChecked(selectedIndex, true);
                return;
            }
            else
            {
                lastChosedLedModeIdx=selectedIndex;
            }
            // 把剩下的mode皆設為false，因為只允許一次選一個mode
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                if (i != selectedIndex)
                {
                    checkedListBox2.SetItemChecked(i, false);
                }
            }
            chosedLedMode = checkedListBox2.SelectedItem.ToString();
        }
    }
}
