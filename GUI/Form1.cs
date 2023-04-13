using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private string chosedBodyPart="";
        private string chosedHexColor="";
        string[] available_body_parts = { "Head", "Right Hand", "Right Foot", "Left Hand", "Left Foot"};
        bool isPlayingAudio = false;

        public Form1()
        {
            InitializeComponent();
            // 列出所有可以控制的身體部位
            // 可以做彈性調整(目前預設: 頭/右手/右腳/左手/左腳)
            checkedListBox1.Items.AddRange(available_body_parts);
            // 點一下選項就可以成功選取部位
            checkedListBox1.CheckOnClick = true;

            // 設定RGB調整條的基本參數(預設: (0,0,0))
            redTrackBar.Value = 0;
            greenTrackBar.Value = 0;
            blueTrackBar.Value = 0;
            Color currColor = Color.FromArgb(redTrackBar.Value, greenTrackBar.Value, blueTrackBar.Value);
            colorPanel.BackColor = currColor;
            redTextBox.Text = "0";
            greenTextBox.Text = "0";
            blueTextBox.Text = "0";
            // 當有任一個RGB trackBar被拖動，更新RGB值和panel顯示的顏色
            redTrackBar.Scroll += new EventHandler(RGBTrackChanged);
            greenTrackBar.Scroll += new EventHandler(RGBTrackChanged);
            blueTrackBar.Scroll += new EventHandler(RGBTrackChanged);
            //當有任何一個RGB textBox被輸入值，更新RGB值和panel顯示的顏色
            redTextBox.TextChanged += new EventHandler(RGBtextBoxChanged);
            greenTextBox.TextChanged += new EventHandler(RGBtextBoxChanged);
            blueTextBox.TextChanged += new EventHandler(RGBtextBoxChanged);
            // 尚未import music之前，預設總時間為00:00
            totalTimeTextBox.Text = string.Format("{0:00}:{1:00}", 0, 0);
        }

        // 把textBox RGB值更新，並更新colorPanel的顏色
        // 並且將RGB值轉成Hex Color Code，並寫在textBox
        private void RGBTrackChanged(object sender, EventArgs e)
        {
            redTextBox.Text = redTrackBar.Value.ToString();
            greenTextBox.Text = greenTrackBar.Value.ToString();
            blueTextBox.Text = blueTrackBar.Value.ToString();
            Color currColor= Color.FromArgb(redTrackBar.Value, greenTrackBar.Value, blueTrackBar.Value);
            colorPanel.BackColor = currColor;
            chosedHexColor=currColor.ToArgb().ToString("X6");
        }

        // trackBar RGB值更新，並更新colorPanel的顏色
        private void RGBtextBoxChanged(object sender, EventArgs e)
        {
            int.TryParse(redTextBox.Text, out int red_value);
            // 防呆(怕輸入>255)
            if(red_value <= 255)
                redTrackBar.Value = red_value;
            int.TryParse(greenTextBox.Text, out int green_value);
            if(green_value <= 255)    
                greenTrackBar.Value = green_value;
            int.TryParse(blueTextBox.Text,out int blue_value);
            if (blue_value <= 255)
                blueTrackBar.Value = blue_value;
            Color currColor = Color.FromArgb(redTrackBar.Value, greenTrackBar.Value, blueTrackBar.Value);
            colorPanel.BackColor = currColor;
            chosedHexColor = currColor.ToArgb().ToString("X6");
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 先reset選擇的bodyPart string
            chosedBodyPart = "";
            // 檢查是否點選的都有真的被讀到
            foreach (string item in checkedListBox1.CheckedItems)
            {
                chosedBodyPart += item.ToString()+",";
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
                playBtn.BackColor = Color.LightGreen;
            }
            else
            {
                wmp.controls.play();
                timer1.Start();
                isPlayingAudio = true;
                playBtn.Text = "Pause";
                playBtn.BackColor = Color.LightPink;
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
            if (chosedBodyPart.Length == 0)
            {
                MessageBox.Show("The body parts cannot be empty :(", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 不再繼續寫入資料
            }
            if (chosedHexColor.Length == 0)
            {
                Color currColor = Color.FromArgb(0, 0, 0);
                chosedHexColor= currColor.ToArgb().ToString("X6");
            }
            string addedText = currTime.ToString() + "," + chosedBodyPart + chosedHexColor + "\r\n";
            textBox1.AppendText(addedText);
            // 把選擇部位和顏色重新reset
            redTextBox.Text = "0";
            greenTextBox.Text = "0";
            blueTextBox.Text = "0";
        }
    }
}
