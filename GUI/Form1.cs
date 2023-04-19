using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private string chosedHexColor="";
        bool isPlayingAudio = false;

        /* ----- 以下的global參數可以視情況做調整 -----*/
        // 可以操控的LED燈條部位
        string[] available_body_parts = { "Head", "Right Hand", "Right Foot", "Left Hand", "Left Foot", "Body" };
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
            trackBarTimeLine.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            currTimeTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKWHITE);
            totalTimeTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKWHITE);
            playBtn.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_CYAN);
            colorPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            // 列出所有可以控制的身體部位
            // 可以做彈性調整(目前預設: 頭/右手/右腳/左手/左腳/身體)
            checkedListBox1.Items.AddRange(available_body_parts);
            // 點一下選項就可以成功選取部位
            checkedListBox1.CheckOnClick = true;

            // 尚未import music之前，預設總時間為00:00
            totalTimeTextBox.Text = string.Format("{0:00}:{1:00}", 0, 0);

            // 把預設得色塊顏色指定給對應的label
            colorBtn1.BackColor = ColorTranslator.FromHtml(DEFAULT_COLOR_1);
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
            colorBtn11.BackColor = ColorTranslator.FromHtml(DEFAULT_COLOR_12);

            // 任何一格預設色塊的button被點擊，更新RGB顏色
            colorBtn1.Click += new EventHandler((sender, e)=>UpdateRGBToDefaultColor(sender, e, DEFAULT_COLOR_1));
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
            colorBtn11.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_COLOR_12));
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
            if (chosedHexColor.Length == 0)
            {
                string DEFAULT_COLOR_10 = "#000000";
                chosedHexColor = DEFAULT_COLOR_10;
            }
            // 把chosedBodyPart的每個部位都寫成一行獨立command
            string addedText = "";
            foreach(string bodyPart in chosedBodyPart)
            {
                addedText=currTime.ToString() + "," + bodyPart + "," + chosedHexColor + "\r\n";
                dataSectionListBox.Items.Add(addedText);

            }
        }

        // 把RGB更新為點擊的預設色塊button顏色
        private void UpdateRGBToDefaultColor(object sender, EventArgs e, string DEFAULT_COLOR)
        {
            Color color = (Color)ColorTranslator.FromHtml(DEFAULT_COLOR);
            chosedHexColor = DEFAULT_COLOR;
            colorPanel.BackColor = color;
        }

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
                dataSectionListBox.Items.Add("Save File OK(Just testing)");
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
    }
}
