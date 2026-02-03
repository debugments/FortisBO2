using Method_Bo2Unlocks;
using MetroFramework;
using MetroFramework.Controls;
using PS3Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace main
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

      public static  PS3API PS3 = new PS3API();
      public static  CCAPI CCAPI = new CCAPI();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PS3.ConnectTarget())
                {
                    MessageBox.Show("Connected !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    metroLabel4.Text = "Connected!";
                    metroLabel4.ForeColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("Check Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Check Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (PS3.AttachProcess())
                {
                    PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Welcome To Fortis");
                    MessageBox.Show("Attached !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    metroLabel6.Text = "Attached!";
                    metroLabel6.ForeColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("Check Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Check Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Disconnecting...");
            PS3.CCAPI.DisconnectTarget();
        }
        private void SetClass(uint offset, string input)
        {
            PS3.SetMemory(offset, new byte[16]);
            Form1.PS3.SetMemory(offset, new byte[16]);
            byte[] B = new byte[1] { (byte)4 };
            byte[] bytes = Encoding.ASCII.GetBytes(input);
            PS3.SetMemory(offset, bytes.Multiply(B));
            Form1.PS3.SetMemory(offset, bytes.Multiply(B));
        }
        public void setName(string name)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(name);
            Array.Resize<byte>(ref bytes, bytes.Length + 1);
            PS3.SetMemory(40633944U, bytes);
            PS3.SetMemory(40633944U, bytes);
            PS3.SetMemory(40633983U, bytes);
            PS3.SetMemory(40633983U, bytes);
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.TargetManager);
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void metroButton20_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.ClearTargetInfo();
            this.CELL_Temperature.Text = PS3.CCAPI.GetTemperatureCELL();
            this.RSX_Temperature.Text = PS3.CCAPI.GetTemperatureRSX();
            this.Firmware.Text = PS3.CCAPI.GetFirmwareVersion();
            this.Console_type.Text = PS3.CCAPI.GetFirmwareType();
        }

        private void metroButton22_Click(object sender, EventArgs e)
        {

        }

        private void metroButton21_Click(object sender, EventArgs e)
        {
            if (this.GreenOff.Checked)
                PS3.CCAPI.SetConsoleLed(PS3Lib.CCAPI.LedColor.Green, PS3Lib.CCAPI.LedMode.Off);
            if (this.GreenOn.Checked)
                PS3.CCAPI.SetConsoleLed(PS3Lib.CCAPI.LedColor.Green, PS3Lib.CCAPI.LedMode.On);
            if (this.GreenBlink.Checked)
                PS3.CCAPI.SetConsoleLed(PS3Lib.CCAPI.LedColor.Green, PS3Lib.CCAPI.LedMode.Blink);
            if (this.RedOff.Checked)
                PS3.CCAPI.SetConsoleLed(PS3Lib.CCAPI.LedColor.Red, PS3Lib.CCAPI.LedMode.Off);
            if (this.RedOn.Checked)
                PS3.CCAPI.SetConsoleLed(PS3Lib.CCAPI.LedColor.Red, PS3Lib.CCAPI.LedMode.On);
            if (!this.RedBlink.Checked)
                return;
            PS3.CCAPI.SetConsoleLed(PS3Lib.CCAPI.LedColor.Red, PS3Lib.CCAPI.LedMode.Blink);
        }

        private void metroButton22_Click_1(object sender, EventArgs e)
        {
            int selectedIndex = this.metroComboBox1.SelectedIndex;
            string text = this.metroTextBox2.Text;
            if (PS3.GetCurrentAPI() == SelectAPI.ControlConsole)
            {
                PS3.CCAPI.Notify(selectedIndex, text);
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.ShutDown(CCAPI.RebootFlags.SoftReboot);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.ShutDown(CCAPI.RebootFlags.HardReboot);
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.ShutDown(CCAPI.RebootFlags.ShutDown);
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(Prestige.Value));
            PS3.SetMemory(40882196U, bytes);
            PS3.SetMemory(40882196U, bytes);
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(Score.Value));
            PS3.SetMemory(40882256U, bytes);
            PS3.SetMemory(40882256U, bytes);
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(Kills.Value));
            PS3.SetMemory(40881008U, bytes);
            PS3.SetMemory(40881008U, bytes);
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(Deaths.Value));
            PS3.SetMemory(40880450U, bytes);
            PS3.SetMemory(40880450U, bytes);
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(Headshots.Value));
            PS3.SetMemory(40880708U, bytes);
            PS3.SetMemory(40880708U, bytes);
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[25]
      {
        (byte) 0,
        (byte) 0,
        (byte) 15,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 15,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 54,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 76,
        (byte) 15,
        (byte) 19
      };
            PS3.SetMemory(40882198U, buffer);
            PS3.SetMemory(40882198U, buffer);
        }

        private void metroButton17_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[2]
{
        byte.MaxValue,
        byte.MaxValue
};
            PS3.SetMemory(40921400U, buffer);
            PS3.SetMemory(40921400U, buffer);
        }

        private void metroButton18_Click(object sender, EventArgs e)
        {
            // Days Played
            decimal num = 32 * 86400M;
            decimal num2 = 8 * 3600M;
            decimal num3 = 23 * 60M;
            decimal num4 = (num + num2) + num3;
            byte[] bytes = BitConverter.GetBytes(Convert.ToUInt32(num4.ToString()));
            PS3.SetMemory(0x26FD10A, bytes);
            PS3.SetMemory(0x26FD10A, bytes);
            //Deaths
            byte[] bytes1 = BitConverter.GetBytes(Convert.ToInt32(242346.ToString()));
            PS3.SetMemory(0x26FC942, bytes1);
            PS3.SetMemory(0x26FC942, bytes1);
            //Kills
            byte[] bytes2 = BitConverter.GetBytes(Convert.ToInt32(343568.ToString()));
            PS3.SetMemory(0x26FCB70, bytes2);
            PS3.SetMemory(0x26FCB70, bytes2);
            //Score
            byte[] bytes3 = BitConverter.GetBytes(Convert.ToInt32(18456272.ToString()));
            PS3.SetMemory(0x26FD050, bytes3);
            PS3.SetMemory(0x26FD050, bytes3);
            //Wins
            byte[] bytes4 = BitConverter.GetBytes(Convert.ToInt32(28871.ToString()));
            PS3.SetMemory(0x26FD152, bytes4);
            PS3.SetMemory(0x26FD152, bytes4);
            //Losses
            byte[] bytes5 = BitConverter.GetBytes(Convert.ToInt32(21671.ToString()));
            PS3.SetMemory(0x26FCBE2, bytes5);
            PS3.SetMemory(0x26FCBE2, bytes5);
            //Level 55
            byte[] rank = new byte[] { 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4C, 0x0F, 0x13 };
            PS3.SetMemory(0x26FD016, rank);
            PS3.SetMemory(0x26FD016, rank);
        }

        private void metroButton19_Click(object sender, EventArgs e)
        {
            //Days Played
            decimal num = 32 * 86400M;
            decimal num2 = 8 * 3600M;
            decimal num3 = 23 * 60M;
            decimal num4 = (num + num2) + num3;
            byte[] bytes = BitConverter.GetBytes(Convert.ToUInt32(num4.ToString()));
            PS3.SetMemory(0x26FD10A, bytes);
            PS3.SetMemory(0x26FD10A, bytes);
            //Deaths
            byte[] bytes1 = BitConverter.GetBytes(Convert.ToInt32(14234.ToString()));
            PS3.SetMemory(0x26FC942, bytes1);
            PS3.SetMemory(0x26FC942, bytes1);
            //Kills
            byte[] bytes2 = BitConverter.GetBytes(Convert.ToInt32(34356.ToString()));
            PS3.SetMemory(0x26FCB70, bytes2);
            PS3.SetMemory(0x26FCB70, bytes2);
            //Score
            byte[] bytes3 = BitConverter.GetBytes(Convert.ToInt32(1845627.ToString()));
            PS3.SetMemory(0x26FD050, bytes3);
            PS3.SetMemory(0x26FD050, bytes3);
            //Wins
            byte[] bytes4 = BitConverter.GetBytes(Convert.ToInt32(2887.ToString()));
            PS3.SetMemory(0x26FD152, bytes4);
            PS3.SetMemory(0x26FD152, bytes4);
            //Losses
            byte[] bytes5 = BitConverter.GetBytes(Convert.ToInt32(1167.ToString()));
            PS3.SetMemory(0x26FCBE2, bytes5);
            PS3.SetMemory(0x26FCBE2, bytes5);
            //Level 55
            byte[] rank = new byte[] { 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4C, 0x0F, 0x13 };
            PS3.SetMemory(0x26FD016, rank);
            PS3.SetMemory(0x26FD016, rank);
        }

        private void metroButton23_Click(object sender, EventArgs e)
        {
            //Days Played
            decimal num = 32 * 86400M;
            decimal num2 = 8 * 3600M;
            decimal num3 = 23 * 60M;
            decimal num4 = (num + num2) + num3;
            byte[] bytes = BitConverter.GetBytes(Convert.ToUInt32(num4.ToString()));
            PS3.SetMemory(0x26FD10A, bytes);
            PS3.SetMemory(0x26FD10A, bytes);
            //Deaths
            byte[] bytes1 = BitConverter.GetBytes(Convert.ToInt32(142346.ToString()));
            PS3.SetMemory(0x26FC942, bytes1);
            PS3.SetMemory(0x26FC942, bytes1);
            //Kills
            byte[] bytes2 = BitConverter.GetBytes(Convert.ToInt32(643568.ToString()));
            PS3.SetMemory(0x26FCB70, bytes2);
            PS3.SetMemory(0x26FCB70, bytes2);
            //Score
            byte[] bytes3 = BitConverter.GetBytes(Convert.ToInt32(18456272.ToString()));
            PS3.SetMemory(0x26FD050, bytes3);
            PS3.SetMemory(0x26FD050, bytes3);
            //Wins
            byte[] bytes4 = BitConverter.GetBytes(Convert.ToInt32(448871.ToString()));
            PS3.SetMemory(0x26FD152, bytes4);
            PS3.SetMemory(0x26FD152, bytes4);
            //Losses
            byte[] bytes5 = BitConverter.GetBytes(Convert.ToInt32(116701.ToString()));
            PS3.SetMemory(0x26FCBE2, bytes5);
            PS3.SetMemory(0x26FCBE2, bytes5);
            //Level 55
            byte[] rank = new byte[] { 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4C, 0x0F, 0x13 };
            PS3.SetMemory(0x26FD016, rank);
            PS3.SetMemory(0x26FD016, rank);
        }

        private void metroButton24_Click(object sender, EventArgs e)
        {
            //Days Played
            decimal num = 32 * 86400M;
            decimal num2 = 8 * 3600M;
            decimal num3 = 23 * 60M;
            decimal num4 = (num + num2) + num3;
            byte[] bytes = BitConverter.GetBytes(Convert.ToUInt32(num4.ToString()));
            PS3.SetMemory(0x26FD10A, bytes);
            PS3.SetMemory(0x26FD10A, bytes);
            //Deaths
            byte[] bytes1 = BitConverter.GetBytes(Convert.ToInt32(142346.ToString()));
            PS3.SetMemory(0x26FC942, bytes1);
            PS3.SetMemory(0x26FC942, bytes1);
            //Kills
            byte[] bytes2 = BitConverter.GetBytes(Convert.ToInt32(343568.ToString()));
            PS3.SetMemory(0x26FCB70, bytes2);
            PS3.SetMemory(0x26FCB70, bytes2);
            //Score
            byte[] bytes3 = BitConverter.GetBytes(Convert.ToInt32(18456272.ToString()));
            PS3.SetMemory(0x26FD050, bytes3);
            PS3.SetMemory(0x26FD050, bytes3);
            //Wins
            byte[] bytes4 = BitConverter.GetBytes(Convert.ToInt32(28871.ToString()));
            PS3.SetMemory(0x26FD152, bytes4);
            PS3.SetMemory(0x26FD152, bytes4);
            //Losses
            byte[] bytes5 = BitConverter.GetBytes(Convert.ToInt32(11671.ToString()));
            PS3.SetMemory(0x26FCBE2, bytes5);
            PS3.SetMemory(0x26FCBE2, bytes5);
            //Level 55
            byte[] rank = new byte[] { 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4C, 0x0F, 0x13 };
            PS3.SetMemory(0x26FD016, rank);
            PS3.SetMemory(0x26FD016, rank);
        }

        private void metroButton25_Click(object sender, EventArgs e)
        {
            PS3.Extension.WriteBytes(40889614U, new byte[1]
     {
        byte.MaxValue
     });
            PS3.Extension.WriteBytes(40889614U, new byte[1]
            {
        byte.MaxValue
            });
        }

        private void metroButton26_Click(object sender, EventArgs e)
        {
            UnlockAll32.UnlockAll();
            int num = (int)MessageBox.Show("Black Ops 2 Unlock All Method Complete.", "Check Your Callsign's and Custom Classes.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            for (int index = 0; index < 10; ++index)
                this.SetClass((uint)(40925895 + index * 16), "0^6Fortis^1RTM");
        }

        private void metroButton27_Click(object sender, EventArgs e)
        {
            byte[] buffer1 = new byte[1] { (byte)48 };
            PS3.SetMemory(40926412U, buffer1);
            PS3.SetMemory(40926412U, buffer1);
            byte[] buffer2 = new byte[1] { (byte)47 };
            PS3.SetMemory(40926426U, buffer2);
            PS3.SetMemory(40926426U, buffer2);
            byte[] buffer3 = new byte[5]
            {
        (byte) 141,
        (byte) 0,
        (byte) 154,
        (byte) 0,
        (byte) 0
            };
            PS3.SetMemory(40926446U, buffer3);
            PS3.SetMemory(40926446U, buffer3);
            byte[] buffer4 = new byte[6]
            {
        (byte) 74,
        (byte) 205,
        (byte) 208,
        (byte) 74,
        (byte) 80,
        (byte) 69
            };
            PS3.SetMemory(40926440U, buffer4);
            PS3.SetMemory(40926440U, buffer4);
            byte[] buffer5 = new byte[1] { (byte)96 };
            PS3.SetMemory(40926457U, buffer5);
            PS3.SetMemory(40926457U, buffer5);
            byte[] buffer6 = new byte[1] { (byte)96 };
            PS3.SetMemory(40926460U, buffer6);
            PS3.SetMemory(40926460U, buffer6);
            byte[] buffer7 = new byte[1] { (byte)176 };
            PS3.SetMemory(40925370U, buffer7);
            PS3.SetMemory(40925370U, buffer7);
            byte[] buffer8 = new byte[1] { (byte)79 };
            PS3.SetMemory(40925384U, buffer8);
            PS3.SetMemory(40925384U, buffer8);
            byte[] buffer9 = new byte[5]
            {
        (byte) 47,
        (byte) 0,
        (byte) 116,
        (byte) 0,
        (byte) 0
            };
            PS3.SetMemory(40925404U, buffer9);
            PS3.SetMemory(40925404U, buffer9);
            byte[] buffer10 = new byte[5]
            {
        (byte) 161,
        (byte) 160,
        (byte) 149,
        (byte) 156,
        (byte) 158
            };
            PS3.SetMemory(40925398U, buffer10);
            PS3.SetMemory(40925398U, buffer10);
            byte[] buffer11 = new byte[1] { (byte)96 };
            PS3.SetMemory(40925415U, buffer11);
            PS3.SetMemory(40925415U, buffer11);
            byte[] buffer12 = new byte[1] { (byte)96 };
            PS3.SetMemory(40925418U, buffer12);
            PS3.SetMemory(40925418U, buffer12);
            byte[] buffer13 = new byte[2] { (byte)144, (byte)5 };
            PS3.SetMemory(40926062U, buffer13);
            PS3.SetMemory(40926062U, buffer13);
            byte[] buffer14 = new byte[1] { (byte)224 };
            PS3.SetMemory(40926076U, buffer14);
            PS3.SetMemory(40926076U, buffer14);
            byte[] buffer15 = new byte[5]
            {
        (byte) 9,
        (byte) 192,
        (byte) 4,
        (byte) 0,
        (byte) 0
            };
            PS3.SetMemory(40926097U, buffer15);
            PS3.SetMemory(40926097U, buffer15);
            byte[] buffer16 = new byte[6]
            {
        (byte) 212,
        (byte) 4,
        (byte) 173,
        (byte) 228,
        (byte) 244,
        (byte) 4
            };
            PS3.SetMemory(40926090U, buffer16);
            PS3.SetMemory(40926090U, buffer16);
            byte[] buffer17 = new byte[1] { (byte)8 };
            PS3.SetMemory(40926108U, buffer17);
            PS3.SetMemory(40926108U, buffer17);
            byte[] buffer18 = new byte[1] { (byte)28 };
            PS3.SetMemory(40926111U, buffer18);
            PS3.SetMemory(40926111U, buffer18);
        }

        private void metroButton28_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[8]
      {
        (byte) 68,
        (byte) 128,
        (byte) 8,
        (byte) 16,
        (byte) 1,
        (byte) 34,
        (byte) 64,
        (byte) 4
      };
            PS3.SetMemory(40928546U, buffer);
            PS3.SetMemory(40928546U, buffer);
        }

        private void metroButton29_Click(object sender, EventArgs e)
        {
            setName(namechanger.Text);
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton30_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Flash.Checked)
            {
                if (Flash.Checked)
                {
                    int BIS = new Random().Next(0, 9);
                    setName("^" + BIS + namechanger.Text);
                }
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Flash.Checked)
            {
                nameTimer.Start();
            }
            else
            {
                nameTimer.Stop();
                setName(namechanger.Text);
            }
        }

        private void metroButton30_Click_1(object sender, EventArgs e)
        {
            this.Clockname.Start();
            Functions.WriteStr(40633944U, DateTime.Now.ToString("HH:mm:ss"));
            Functions.WriteStr(40633983U, DateTime.Now.ToString("HH:mm:ss"));

        }

        private void metroButton31_Click(object sender, EventArgs e)
        {
            this.Clockname.Stop();
            this.metroButton31.Text = "STOP";
            setName("Please Change Name");
        }

        private void metroButton32_Click(object sender, EventArgs e)
        {
            setName("[{togglemenu}]");
        }

        private void metroButton35_Click(object sender, EventArgs e)
        {
            setName("[{+switchseat}]");
        }

        private void metroButton33_Click(object sender, EventArgs e)
        {
            setName("[{+frag}]");
        }

        private void metroButton36_Click(object sender, EventArgs e)
        {
            setName("[{+melee}]");
        }

        private void metroButton34_Click(object sender, EventArgs e)
        {
            setName("[{+forward}]");
        }

        private void metroButton37_Click(object sender, EventArgs e)
        {
            setName("[{+Back}]");
        }

        private void metroButton38_Click(object sender, EventArgs e)
        {
            setName("[{+speed_throw}]");
        }

        private void metroComboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void metroButton39_Click(object sender, EventArgs e)
        {
            setName(" ^6Fortis ^1RTM");
        }

        private void metroButton40_Click(object sender, EventArgs e)
        {
            setName(" ^6Debug");
        }

        private void metroButton41_Click(object sender, EventArgs e)
        {
            setName(" ^4Reimagined");
        }

        private void metroButton42_Click(object sender, EventArgs e)
        {
            setName("www.youtube.com/@Debugmentss");
        }

        private void metroButton43_Click(object sender, EventArgs e)
        {
            setName("discord.gg/REP8AqnKdd");
        }
    }
    }



        

