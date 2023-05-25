using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NAudio.Utils;
using NAudio.Wave;
using NAudio.WaveFormRenderer;

// 用來import音樂檔案(允許撥放音樂/讀取音樂長度/顯示現在時間)
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class Form1 : Form
    {
        // Global Variable
        // 有音檔位置, wpm, 預覽畫面的line...
        private string musicFilePath;
        private List<string> chosedBodyPart=new List<string>();
        private string chosedLedMode = "";
        private int lastChosedLedModeIdx = -1;
        //private string chosedHexColor="";
        WaveOutEvent waveOutEvent=new WaveOutEvent();
        AudioFileReader audioFileReader;
        // 計算現在時間線位置
        TimeSpan totalTime;
        TimeSpan currTime;
        // 畫出時間線，以及藉由滑鼠更新位置
        private Pen linePen = new Pen(Color.White, 1);
        private int linePosition = 0;
        private bool isDraggingLine = false;


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
            WindowState = FormWindowState.Maximized;

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
            currTimeTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKWHITE);
            totalTimeTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_DARKWHITE);
            playBtn.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_CYAN);
            groupBox1.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            groupBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            groupBox2.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            groupBox2.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            groupBox3.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            groupBox3.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            groupBox4.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            groupBox4.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            stateTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            stateTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#BFF5CC");
            stateTextBox.Font = new System.Drawing.Font("Consolas", 11);
            groupBox5.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            groupBox5.ForeColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_WHITE);
            selectAllRadioBtn.Font = new System.Drawing.Font("Consolas", 10);
            unselectAllRadioBtn.Font = new System.Drawing.Font("Consolas", 10);
            upperBodyRadioBtn.Font = new System.Drawing.Font("Consolas", 10);
            lowerBodyRadioBtn.Font = new System.Drawing.Font("Consolas", 10);
            pictureBox1.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_LIGHTGREY);
            //colorPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            // 列出所有可以控制的身體部位
            // 可以做彈性調整(目前預設: 頭/右手/右腳/左手/左腳/身體)
            checkedListBox1.Items.AddRange(available_body_parts);
            // 點一下選項就可以成功選取部位
            checkedListBox1.CheckOnClick = true;

            // 列出所有可以選擇的亮暗模式
            checkedListBox2.Items.AddRange(available_led_modes);
            checkedListBox2.CheckOnClick = true;

            // 尚未import music之前，預設時間為00:00.000
            totalTimeTextBox.Text = string.Format("{0:00}:{1:00}.{2:000}", 0, 0, 0);
            currTimeTextBox.Text = string.Format("{0:00}:{1:00}.{2:000}", 0, 0, 0);
            
            // 可以應付大部分的音樂(100BPM~140BPM)
            timer1.Interval = 400; 

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
            // 因為有個別變更部位，把select all/unselect all unchecked
            checkedListBox1.Refresh();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog importMusicFile = new OpenFileDialog();
            importMusicFile.Filter = "MP3 files only| *.mp3";
            if(importMusicFile.ShowDialog()== DialogResult.OK )
            { 
                // 先用openDialog得到音檔位置，並將其存到musicFilePath
                musicFilePath=importMusicFile.FileName;

                // 展示出波型(用rms值展現，並把波型存給pictureBox1)
                RmsPeakProvider rmsPeakProvider = new RmsPeakProvider(200); // e.g. 200
                StandardWaveFormRendererSettings myRendererSettings = new StandardWaveFormRendererSettings();
                myRendererSettings.Width = pictureBox1.Width;
                myRendererSettings.TopHeight = pictureBox1.Height / 2;
                myRendererSettings.BottomHeight = pictureBox1.Height / 2;
                myRendererSettings.BackgroundColor = Color.Transparent;
                myRendererSettings.TopPeakPen = new Pen(Color.Green);
                myRendererSettings.BottomPeakPen = new Pen(Color.DarkGreen);
                WaveFormRenderer renderer = new WaveFormRenderer();
                audioFileReader = new AudioFileReader(musicFilePath);

                totalTime = audioFileReader.TotalTime;
                Image image = renderer.Render(audioFileReader, rmsPeakProvider, myRendererSettings);
                pictureBox1.Image = image;

                // 讀取歌曲長度，並將其更新至totalTimeTextBox
                var reader = new MediaFoundationReader(musicFilePath);
                int durationMillisSeconds = (int)reader.TotalTime.TotalMilliseconds;
                int minute = durationMillisSeconds / 60000;
                int second = durationMillisSeconds / 1000 % 60;
                int millis = durationMillisSeconds % 1000;
                totalTimeTextBox.Text = string.Format("{0:00}:{1:00}.{2:000}", minute, second, millis);

                // 把檔案讀進來，中止之前的撥放狀態，重新開始並自動撥放
                stateTextBox.Text = "Successfully import " + musicFilePath;
                audioFileReader = new AudioFileReader(musicFilePath);
                waveOutEvent.Stop();
                waveOutEvent.Init(audioFileReader);
                playBtn.Text = "Play";
                playBtn.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_CYAN);
                // 還沒開始放歌，所以先關掉timer1
                timer1.Stop();
            }
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            // 防止沒有音樂也可以點撥放鍵
            if (audioFileReader==null) return;
            if (waveOutEvent.PlaybackState==PlaybackState.Playing)
            {
                waveOutEvent.Pause();
                timer1.Stop();
                playBtn.Text = "Play";
                playBtn.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_CYAN);
            }
            else
            {
                waveOutEvent.Play();
                timer1.Start();
                playBtn.Text = "Pause";
                playBtn.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_PINK);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 確定真的有放歌才開始更新時間
            if (waveOutEvent != null && waveOutEvent.PlaybackState == PlaybackState.Playing)
            {
                currTime = audioFileReader.CurrentTime;
                string formattedTime = currTime.ToString(@"mm\:ss\.fff");
                currTimeTextBox.Text = formattedTime;
                // 更新現在時間線
                pictureBox1.Refresh();
                double percentage = currTime.TotalMilliseconds / totalTime.TotalMilliseconds;
                linePosition = (int)(percentage * pictureBox1.Width);
                using (Graphics g = pictureBox1.CreateGraphics())
                {
                    g.DrawLine(linePen, linePosition, 0, linePosition, pictureBox1.Height);
                }
            }
            // 歌已經放完，把play button改回
            else if(waveOutEvent!=null&&audioFileReader!=null)
            {
                // 把音樂位置重置
                audioFileReader.Position = 0 * audioFileReader.WaveFormat.AverageBytesPerSecond;
                // 重畫時間線
                linePosition = (int)audioFileReader.Position;
                pictureBox1.Refresh();
                using (Graphics g = pictureBox1.CreateGraphics())
                {
                    g.DrawLine(linePen, linePosition, 0, linePosition, pictureBox1.Height);
                }
                waveOutEvent.Init(audioFileReader);
                // 更新時間currTimeTextBox
                currTime = waveOutEvent.GetPositionTimeSpan();
                string formattedTime = currTime.ToString(@"mm\:ss\.fff");
                currTimeTextBox.Text = formattedTime;
                playBtn.Text = "Play";
                playBtn.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_CYAN);
                // 關掉timer1
                timer1.Stop();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // addedText: 寫入檔案的資料(時間(s)+部位+RGB)
            // 有做foolproof: 防止沒有選擇部位: 印出警示提醒
            TimeSpan timeSpan = TimeSpan.ParseExact(currTimeTextBox.Text, @"mm\:ss\.fff", CultureInfo.InvariantCulture);
            int totalMillis = (int)(timeSpan.TotalMilliseconds);
            double currTime = totalMillis * 0.001;
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
                int timeMaxLength = 9;
                int bodyPartMaxLength = 11;
                int ledModeMaxLength = 12;
                string prettyCurrTime=(currTime.ToString()).PadLeft(timeMaxLength, ' ');
                string prettyBodyPart = bodyPart.PadLeft(bodyPartMaxLength, ' ');
                string prettyLedMode = chosedLedMode.PadLeft(ledModeMaxLength, ' ');
                addedText=prettyCurrTime+"|"+prettyBodyPart+"|"+prettyLedMode;
                dataSectionListBox.Items.Add(addedText);
            }
            string showingMsg="[Add] Time:"+currTime.ToString()+"s | Parts:"+chosedBodyPart.Count()+" | Mode:"+chosedLedMode;
            stateTextBox.Text = showingMsg;
            // 把資料加入成功後，依據time重新排序順序(方便使用者觀察和之後存檔)
            // 先把dataSectionListBox的資料存到List<string>，再對其排序
            // 最後，再把資料存回dataSectionListBox
            List<string> allItems=dataSectionListBox.Items.Cast<string>().ToList();
            allItems.Sort((s1, s2) => {
                s1.TrimStart();
                s2.TrimStart();
                double time1 = double.Parse(s1.Split('|')[0]);
                double time2 = double.Parse(s2.Split('|')[0]);
                return time1.CompareTo(time2);
            });
            dataSectionListBox.Items.Clear();
            dataSectionListBox.Items.AddRange(allItems.ToArray());
            // 確保dataSectionListBox一直都是顯示最下面的資料(自動滑動)
            dataSectionListBox.SelectedIndex = dataSectionListBox.Items.Count - 1;
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
                        double timeSec = double.Parse(data[0]);
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
                stateTextBox.Text = "[Save] Save data as csv file";
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            // 刪掉在listBox1中選取的line
            string selectedLine=(string)dataSectionListBox.SelectedItem;
            int selected_idx = dataSectionListBox.SelectedIndex;
            if(selectedLine == null)
            {
                MessageBox.Show("No line is chosed in data section :(", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dataSectionListBox.Items.Remove(selectedLine);
                string[] splitStr=selectedLine.Split('|');
                string showingMsg = splitStr[0]+" | " + splitStr[1]+" | " + splitStr[2];
                stateTextBox.Text = "[Delete]" + selectedLine;
                // 把選取的index設為刪除的前一個或後一個(視情況決定)
                if(selected_idx==0)selected_idx=selected_idx+1;
                else selected_idx=selected_idx-1;
                // 確保新的selected_idx有合理資料存在於dataSectionListBox
                if (dataSectionListBox.Items.Count > selected_idx)
                {
                    dataSectionListBox.SetSelected(selected_idx, true);
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
                stateTextBox.Text = "[Reset] Clear all saved work data";
            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // selectedIndex: 前一個選的mode的index
            int selectedIndex = checkedListBox2.SelectedIndex;
            if (selectedIndex < 0) return;
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

        // 所有Body Parts都選
        private void selectAllRadioBtn_Click(object sender, EventArgs e)
        {
            unselectAllRadioBtn.Checked = false;
            upperBodyRadioBtn.Checked= false;
            lowerBodyRadioBtn.Checked= false;
            selectAllRadioBtn.Checked = true;
            chosedBodyPart.Clear();
            for(int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
            checkedListBox1.Refresh();
            chosedBodyPart.AddRange(available_body_parts);
        }

        // 所有Body Parts都不選
        private void unselectAllRadioBtn_Click(object sender, EventArgs e)
        {
            selectAllRadioBtn.Checked = false;
            upperBodyRadioBtn.Checked = false;
            lowerBodyRadioBtn.Checked = false;
            unselectAllRadioBtn.Checked = true;
            chosedBodyPart.Clear();
            for(int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            checkedListBox1.Refresh();
        }

        // 只選上半身Body Parts(頭/手/身體)
        private void upperBodyRadioBtn_Click(object sender, EventArgs e)
        {
            selectAllRadioBtn.Checked = false;
            unselectAllRadioBtn.Checked = false;
            lowerBodyRadioBtn.Checked = false;
            upperBodyRadioBtn.Checked = true;
            chosedBodyPart.Clear();
            for(int i=0;i<4;i++)
            {
                checkedListBox1.SetItemChecked(i, true);
                chosedBodyPart.Add(checkedListBox1.Items[i].ToString());
            }
            for(int i=4;i<checkedListBox1.Items.Count;i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            checkedListBox1.Refresh();
        }

        // 只選下半身Body Parts(腳/鞋子)
        private void lowerBodyRadioBtn_Click(object sender, EventArgs e)
        {
            selectAllRadioBtn.Checked = false;
            unselectAllRadioBtn.Checked = false;
            upperBodyRadioBtn.Checked = false;
            lowerBodyRadioBtn.Checked = true;
            chosedBodyPart.Clear();
            for (int i = 0; i < 4; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            for (int i = 4; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
                chosedBodyPart.Add(checkedListBox1.Items[i].ToString());
            }
            checkedListBox1.Refresh();
        }

        // 判斷是否有點到時間線，代表使用者是否要改變時間
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int lineRange = 5; // 可容忍誤差
            if (Math.Abs(e.X - linePosition) <= lineRange)
            {
                isDraggingLine = true;
            }
        }

        // 判斷使用者是否有滑動滑鼠，如果有，改變時間線、播放時間和顯示時間
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraggingLine)
            {
                timer1.Stop();
                linePosition = e.X;
                // 重新畫時間線
                pictureBox1.Refresh();
                using (Graphics g = pictureBox1.CreateGraphics())
                {
                    g.DrawLine(linePen, linePosition, 0, linePosition, pictureBox1.Height);
                }

                // 更新音檔播放時間(依據時間比例計算位置)
                TimeSpan totalDuration = audioFileReader.TotalTime;
                double percentage = (double)linePosition / (double)pictureBox1.Width;
                double update_time=totalDuration.TotalSeconds * percentage;

                // 暫停並更新播放時間(用audioFileReader.Position控制位置)
                waveOutEvent.Pause();
                if((long)(update_time * audioFileReader.WaveFormat.AverageBytesPerSecond)<0)
                    audioFileReader.Position = 0;
                else audioFileReader.Position = (long)(update_time * audioFileReader.WaveFormat.AverageBytesPerSecond);
            }
        }

        // 使用者放開滑鼠，結束dragging
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDraggingLine=false;
            // 自動開始撥放音樂
            waveOutEvent.Play();
            timer1.Start();
            playBtn.Text = "Pause";
            playBtn.BackColor = System.Drawing.ColorTranslator.FromHtml(DARKMODE_PINK);
            stateTextBox.Text = "Jumped to "+audioFileReader.CurrentTime.ToString(@"mm\:ss\.fff")+"s";
        }
    }
}
