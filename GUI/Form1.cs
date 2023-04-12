using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 列出所有可以控制的身體部位
            // 可以做彈性調整(目前預設: 頭/右手/右腳/左手/左腳)
            string[] body_parts = { "Head", "Right Hand", "Right Foot", "Left Hand", "Left Foot" };
            checkedListBox1.Items.AddRange(body_parts);
            // 點一下選項就可以成功選取部位
            checkedListBox1.CheckOnClick = true;

            // 設定RGB調整條的基本參數(預設: (0,0,0))
            redTrackBar.Value = 0;
            greenTrackBar.Value = 0;
            blueTrackBar.Value = 0;
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
        }

        // 把textBox RGB值更新，並更新colorPanel的顏色
        private void RGBTrackChanged(object sender, EventArgs e)
        {
            redTextBox.Text = redTrackBar.Value.ToString();
            greenTextBox.Text = greenTrackBar.Value.ToString();
            blueTextBox.Text = blueTrackBar.Value.ToString();
            colorPanel.BackColor = Color.FromArgb(redTrackBar.Value, greenTrackBar.Value, blueTrackBar.Value);
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
            colorPanel.BackColor = Color.FromArgb(redTrackBar.Value, greenTrackBar.Value, blueTrackBar.Value);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 檢查是否點選的都有真的被讀到
            string selected_items = "";
            foreach (string item in checkedListBox1.CheckedItems)
            {
                selected_items += item.ToString()+"\r\n";
                textBox1.Text = selected_items;
            }
        }
    }
}
