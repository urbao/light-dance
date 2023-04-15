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
        string DEFAULT_RED = "#C70039";
        string DEFAULT_ORANGE = "#FF5733";
        string DEFAULT_YELLOW = "#FFC300";
        string DEFAULT_GREEN = "#00ff67";
        string DEFAULT_DARKGREEN = "#0d9b46";
        string DEFAULT_CYAN = "#00FFFF";
        string DEFAULT_BLUE = "#0d7f9b";
        string DEFAULT_PURPLE = "#c007dc";
        string DEFAULT_PINK = "#f44ae0";
        string DEFAULT_BLACK = "#000000";
        string DEFAULT_LIGHTPINK = "#FFB6C1";
        string DEFAULT_LIGHTBLUE = "#B0C4DE";
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
            listBox1.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            listBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            listBox1.Font = new System.Drawing.Font("Consolas", 11);
            checkedListBox1.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            checkedListBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            checkedListBox1.Font = new System.Drawing.Font("Consolas", 10);
            trackBarTimeLine.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            currTimeTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKWHITE);
            totalTimeTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKWHITE);
            redTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKWHITE);
            greenTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKWHITE);
            blueTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKWHITE);
            redTrackBar.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            greenTrackBar.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            blueTrackBar.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            playBtn.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_CYAN);

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

            // 把預設得色塊顏色指定給對應的label
            redColorBtn.BackColor = ColorTranslator.FromHtml(DEFAULT_RED);
            orangeColorBtn.BackColor = ColorTranslator.FromHtml(DEFAULT_ORANGE);
            yellowColorBtn.BackColor = ColorTranslator.FromHtml(DEFAULT_YELLOW);
            greenColorBtn.BackColor=ColorTranslator.FromHtml(DEFAULT_GREEN);
            darkGreenColorBtn.BackColor = ColorTranslator.FromHtml(DEFAULT_DARKGREEN);
            cyanColorBtn.BackColor = ColorTranslator.FromHtml(DEFAULT_CYAN);
            blueColorBtn.BackColor=ColorTranslator.FromHtml(DEFAULT_BLUE);
            purpleColorBtn.BackColor = ColorTranslator.FromHtml(DEFAULT_PURPLE);
            pinkColorBtn.BackColor=ColorTranslator.FromHtml(DEFAULT_PINK);
            blackColorBtn.BackColor = ColorTranslator.FromHtml(DEFAULT_BLACK);
            lightPinkColorBtn.BackColor = ColorTranslator.FromHtml(DEFAULT_LIGHTPINK);
            lightBlueColorBtn.BackColor = ColorTranslator.FromHtml(DEFAULT_LIGHTBLUE);

            // 任何一格預設色塊的button被點擊，更新RGB顏色
            redColorBtn.Click += new EventHandler((sender, e)=>UpdateRGBToDefaultColor(sender, e, DEFAULT_RED));
            orangeColorBtn.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_ORANGE));
            yellowColorBtn.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_YELLOW));
            greenColorBtn.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_GREEN));
            darkGreenColorBtn.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_DARKGREEN));
            cyanColorBtn.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_CYAN));
            blueColorBtn.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_BLUE));
            purpleColorBtn.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_PURPLE));
            pinkColorBtn.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_PINK));
            blackColorBtn.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_BLACK));
            lightPinkColorBtn.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_LIGHTPINK));
            lightBlueColorBtn.Click += new EventHandler((sender, e) => UpdateRGBToDefaultColor(sender, e, DEFAULT_LIGHTBLUE));
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
            chosedHexColor = "#"+currColor.ToArgb().ToString("X6").Substring(2);
        }

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
                Color currColor = Color.FromArgb(0, 0, 0);
                chosedHexColor= currColor.ToArgb().ToString("X6");
            }
            // 把chosedBodyPart的每個部位都寫成一行獨立command
            string addedText = "";
            foreach(string bodyPart in chosedBodyPart)
            {
                addedText=currTime.ToString() + "," + bodyPart + "," + chosedHexColor + "\r\n";
                listBox1.Items.Add(addedText);

            }
        }

        // 把RGB更新為點擊的預設色塊button顏色
        private void UpdateRGBToDefaultColor(object sender, EventArgs e, string DEFAULT_COLOR)
        {
            Color color = (Color)ColorTranslator.FromHtml(DEFAULT_COLOR);
            redTextBox.Text = color.R.ToString();
            greenTextBox.Text = color.G.ToString();
            blueTextBox.Text = color.B.ToString();
        }

        private void saveFileBtn_Click(object sender, EventArgs e)
        {
            // 先檢查是否有資料可以存檔，如果沒有，印出警示
            if (listBox1.Items.Count == 0)
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
                listBox1.Items.Add("Save File OK(Just testing)");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 刪掉在listBox1中選取的line
            string selectedLine=(string)listBox1.SelectedItem;
            if(selectedLine == null)
            {
                MessageBox.Show("No line is chosed in data section :(", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                listBox1.Items.Remove(selectedLine);
            }
        }

        // 當使用者選取某行資料，並且按下delete鍵，則delete該行
        private void listBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
        }
    }
}
