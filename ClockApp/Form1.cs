using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockApp
{
    public partial class Form1 : Form
    {
        public static string AppDirectory = Path.GetDirectoryName(Application.ExecutablePath);  //Application.executablepath = .exe nin pathi, path.getdirectoryname = pathin hangi dosyada bulunduğunu gösterir.
        public static string imageFile = AppDirectory + @"\ClockDigits\";
        public static List<string> imageNames = new List<string>(){ imageFile + "number-0.png",imageFile +"number-1.png", imageFile + "number-2.png", imageFile + "number-3.png", imageFile + "number-4.png", imageFile + "number-5.png", imageFile + "number-6.png", imageFile + "number-7.png", imageFile + "number-8.png", imageFile + "number-9.png"};
        public static string hours, minutes, seconds;
        public static DateTime time;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            time = new DateTime();
            time = DateTime.Now;
            void ChangeHours()
            {
                pictureBox1.Image = Image.FromFile(imageNames[Convert.ToInt32(hours[0].ToString())]);
                pictureBox2.Image = Image.FromFile(imageNames[Convert.ToInt32(hours[1].ToString())]);
            }
            void ChangeMinutes()
            {
                pictureBox3.Image = Image.FromFile(imageNames[Convert.ToInt32(minutes[0].ToString())]);
                pictureBox4.Image = Image.FromFile(imageNames[Convert.ToInt32(minutes[1].ToString())]);
            }
            void ChangeSeconds()
            {
                pictureBox5.Image = Image.FromFile(imageNames[Convert.ToInt32(seconds[0].ToString())]);
                pictureBox6.Image = Image.FromFile(imageNames[Convert.ToInt32(seconds[1].ToString())]);
            }
            hours = time.Hour.ToString();
            if (Convert.ToInt32(hours) < 10) hours = "0" + hours;
            ChangeHours();
            minutes = time.Minute.ToString();
            if (Convert.ToInt32(minutes) < 10) minutes = "0" + minutes;
            ChangeMinutes();
            while (Form1.ActiveForm == this)    //aktif(ön planda) olan form buysa. yani formdan başka bir yere tıklanmadıysa
            {
                time = DateTime.Now;
                seconds = time.Second.ToString();
                if (Convert.ToInt32(seconds) < 10) seconds = "0" + seconds;
                ChangeSeconds();
                if (seconds == "00")
                {
                    minutes = time.Minute.ToString();
                    if (Convert.ToInt32(minutes) < 10) minutes = "0" + minutes;
                    ChangeMinutes();
                }
                if (minutes == "00")
                {
                    hours = time.Hour.ToString();
                    if (Convert.ToInt32(hours) < 10) hours = "0" + hours;
                    ChangeHours();
                }
                Refresh();
                System.Threading.Thread.Sleep(1000);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
