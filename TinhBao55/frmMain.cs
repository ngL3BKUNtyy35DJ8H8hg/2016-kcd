using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TinhBao55
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

           

            
        }

        public NhanProcess NhanProcess1;
        public SoundPlayer mySound;
        private FileStream mySoundStream;

        private void StartNhan(string pConnectName)
        {
            if (this.txtServer.Text.Length > 0)
            {
                myModule.myServerComputer = this.txtServer.Text;
            }
            else
            {
                myModule.myServerComputer = "localhost";
            }
            if (this.NhanProcess1 == null)
            {
                try
                {
                    this.NhanProcess1 = new NhanProcess(myModule.myServerComputer, 10062);
                    this.NhanProcess1.RefusedEvent += new NhanProcess.RefusedEventHandler(this.NhanProcess1_Refused);
                    this.NhanProcess1.LineReceivedEvent += new NhanProcess.LineReceivedEventHandler(this.NhanProcess1_LineReceived);
                    this.NhanProcess1.DisconnectedEvent += new NhanProcess.DisconnectedEventHandler(this.NhanProcess1_Disconnected);
                    this.NhanProcess1.ConnectedEvent += new NhanProcess.ConnectedEventHandler(this.NhanProcess1_Connected);

                    this.NhanProcess1.StartThread();
                    if (!this.NhanProcess1.myClient.AttemptConnect(pConnectName))
                    {
                        //MessageBox.Show("Không kết nối được.", "Thông báo", MessageBoxButtons.Exclamation, this.Text);
                        MessageBox.Show("Không kết nối được.");
                        this.KetNoiOff();
                    }
                }
                catch (Exception expr_8C)
                {
                    //MessageBox.Show("Server không hoạt động.  Chạy Server rồi kết nối lại.", "Thông báo", MessageBoxButtons.Exclamation, this.Text);
                    MessageBox.Show("Server không hoạt động.  Chạy Server rồi kết nối lại.");
                    this.NhanProcess1 = null;
                    this.KetNoiOff();
                }
            }
        }
        private void StopNhan()
        {
            try
            {
                if (this.NhanProcess1 != null)
                {
                    this.NhanProcess1.StopThread();
                    this.NhanProcess1 = null;
                }
            }
            catch (Exception expr_21)
            {
                throw expr_21;
            }
        }
        private void KetNoiOff()
        {
            this.StopNhan();
            this.btnKetNoi.Enabled = true;
            this.btnNgatKetNoi.Enabled = false;
        }
        private void KetNoiOn()
        {
            this.btnKetNoi.Enabled = false;
            if (btnNgatKetNoi.InvokeRequired)
            {
                btnNgatKetNoi.Invoke(new MethodInvoker(delegate { btnNgatKetNoi.Enabled = true; }));
            }
            //this.btnNgatKetNoi.Enabled = true;
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!this.btnKetNoi.Enabled)
                {
                    this.btnNgatKetNoi_Click(null, null);
                }
            }
            catch (Exception expr_17)
            {
                throw expr_17;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "Bản tin tình báo 5x5";
            if (File.Exists(myModule.myCTPara))
            {
                if (myModule.LoadPara(myModule.myCTPara))
                {
                    if (!modSound.populateSoundDataDict())
                    {
                        MessageBox.Show("Không thấy đủ file âm thanh cần thiết, Stop!", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    this.txtServer.Text = myModule.myServerComputer;
                    this.lblLine.Text = "";
                    this.lblLoi.Text = "";
                }
                else
                {
                    MessageBox.Show("Xem lại file '" + myModule.myCTPara + "', Stop!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Không thấy file '" + myModule.myCTPara + "', Stop!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }
        private void PlaySound(string pStr)
        {
            try
            {
                this.mySoundStream = modSound.GetSoundStream(pStr);
                if (this.mySoundStream != null)
                {
                    this.mySound = new SoundPlayer();
                    this.mySound.LoadCompleted += new AsyncCompletedEventHandler(this.mySound_LoadCompleted);

                    this.mySound.Stream = this.mySoundStream;
                    this.mySound.LoadAsync();
                }
            }
            catch (Exception expr_42)
            {
                throw expr_42;
            }
        }
        private void mySound_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                this.mySound.Play();
                this.mySoundStream.Close();
            }
            catch (Exception expr_18)
            {
                throw expr_18;
            }
        }
        private void btnReRead_Click(object sender, EventArgs e)
        {
            try
            {
                this.mySound.Stop();
            }
            catch (Exception expr_0D)
            {
                throw expr_0D;
            }
            if (this.lblLoi.Text.Length > 0)
            {
                this.PlaySound(this.lblLoi.Text);
            }
        }
        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            this.btnKetNoi.Enabled = false;
            this.StartNhan("TB5x5");
        }
        private void btnNgatKetNoi_Click(object sender, EventArgs e)
        {
            this.NhanProcess1.myClient.SendData("DISCONNECT|");
            this.KetNoiOff();
        }
        private void NhanProcess1_Connected(NhanProcess sender)
        {
            this.KetNoiOn();
        }
        private void NhanProcess1_Disconnected(NhanProcess sender)
        {
            this.KetNoiOff();
        }
        private void NhanProcess1_LineReceived(NhanProcess sender, string line)
        {
            this.DocLine(line);
        }
        private void DocLine(string line)
        {
            try
            {
                if (line.Length > 0)
                {
                   
                    if (this.lblLine.InvokeRequired)
                    {
                        this.lblLine.Invoke(new MethodInvoker(delegate { this.lblLine.Text = line; }));
                    }
                    CDongBanTin cDongBanTin = new CDongBanTin();
                    cDongBanTin.LoadFromString(line);
                    string text = cDongBanTin.ToString();
                    if (this.lblLoi.InvokeRequired)
                    {
                        this.lblLoi.Invoke(new MethodInvoker(delegate { this.lblLoi.Text = line; }));
                    }
                    try
                    {
                        //this.mySound.Stop();
                    }
                    catch (Exception expr_42)
                    {
                        throw expr_42;
                    }
                    if (text.Length > 0)
                    {
                        this.PlaySound(text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: DocLine" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                this.KetNoiOff();
            }
        }

        private void NhanProcess1_Refused(NhanProcess sender)
        {
            MessageBox.Show("Kết nối bị từ chối.", "Thông báo", MessageBoxButtons.OK);
            this.KetNoiOff();
        }
    }
}
