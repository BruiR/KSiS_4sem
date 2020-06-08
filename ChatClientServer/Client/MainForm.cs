using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        ClientManager currentClient;
        WordFilterHelper filter;

        public static MainForm f1;
        public bool IsLogin = false;
        public MainForm()
        {

            f1 = this;
            currentClient = new ClientManager(f1);
            InitializeComponent();
            SignForm SignForm = new SignForm(f1, currentClient);
            SignForm.ShowDialog();
            filter = new WordFilterHelper();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            currentClient.SendMessage(MessageTBox.Text);
            MessageTBox.Text = "";
        }

        private void AddFileBtn_Click(object sender, EventArgs e)
        {
            /*
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string path = openFileDialog1.FileName;
            currentClient.SendFile(path);
            */
        }

        public void Redraw(string str)
        {
            try
            {

                string[] split = str.Split(":".ToCharArray());
                Label lbl1 = new Label();
                lbl1.Font = new Font("Microsoft Sans Serif", 16.0f);
                lbl1.Visible = true;
                lbl1.Width = 540;
                lbl1.TextAlign = ContentAlignment.TopLeft;
                lbl1.Text = split[0];
                f1.flowLayoutPanel.Controls.Add(lbl1);
                str = str.Replace(split[0] + ":", "");
                TextBox txtBox = new TextBox();
                txtBox.Multiline = true;
                txtBox.Enabled = false;
                txtBox.Width = 540;
                txtBox.WordWrap = true;
                txtBox.Height = 30 + (str.Length / 63) * 30;
                txtBox.Text = str;
                txtBox.BackColor = Color.Snow;
                txtBox.Font = new Font("Microsoft Sans Serif", 12.0f);
                txtBox.Visible = true;
                f1.flowLayoutPanel.Controls.Add(txtBox);
                Label lbl = new Label();
                lbl.Font = new Font("Microsoft Sans Serif", 8.0f);
                lbl.Visible = true;
                lbl.Width = 540;
                lbl.TextAlign = ContentAlignment.TopRight;
                lbl.Text = DateTime.Now.ToShortDateString() + ", " + DateTime.Now.ToLongTimeString();
                f1.flowLayoutPanel.Controls.Add(lbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public  void RedrawSticker(string str, string MesUserName) 
        {
            try
            {
                Label lbl1 = new Label();
                lbl1.Font = new Font("Microsoft Sans Serif", 16.0f);
                lbl1.Visible = true;
                lbl1.Width = 540;
                lbl1.TextAlign = ContentAlignment.TopLeft;
                lbl1.Text = MesUserName;
                f1.flowLayoutPanel.BeginInvoke((MethodInvoker)(() => f1.flowLayoutPanel.Controls.Add(lbl1)));
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = imageList1.Images[Int32.Parse(str)];
                pb.Width = 540;
                pb.Height = 128;
                f1.flowLayoutPanel.BeginInvoke((MethodInvoker)(() => f1.flowLayoutPanel.Controls.Add(pb)));
                pb.Image = imageList1.Images[int.Parse(str)];
                Label lbl = new Label();
                lbl.Font = new Font("Microsoft Sans Serif", 8.0f);
                lbl.Visible = true;
                lbl.Width = 540;
                lbl.TextAlign = ContentAlignment.TopRight;
                lbl.Text = DateTime.Now.ToShortDateString() + ", " + DateTime.Now.ToLongTimeString();
                f1.flowLayoutPanel.BeginInvoke((MethodInvoker)(() => f1.flowLayoutPanel.Controls.Add(lbl)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void RedrawOther(string str)
        {
            try
            {

                if (matBox.Checked)
                {
                    str = filter.ReplaceBadWords(str);
                }
                string[] split = str.Split(":".ToCharArray());
                Label lbl1 = new Label();
                lbl1.Font = new Font("Microsoft Sans Serif", 16.0f);
                lbl1.Visible = true;
                lbl1.Width = 540;
                lbl1.TextAlign = ContentAlignment.TopLeft;
                lbl1.Text = split[0];
                f1.flowLayoutPanel.BeginInvoke((MethodInvoker)(() => f1.flowLayoutPanel.Controls.Add(lbl1)));
                str = str.Replace(split[0] + ":", "");
                TextBox txtBox = new TextBox();
                txtBox.Multiline = true;
                txtBox.Enabled = false;
                txtBox.Width = 540;
                txtBox.WordWrap = true;
                string[] split2 = str.Split("\n".ToCharArray());
                if (split2.Length - 1 == 0)
                {
                    txtBox.Height = 30 + (str.Length / 77) * 20;
                }
                else
                {
                    int height = 10;
                    for (int i = 0; i <= split2.Length - 1; i++)
                    {
                        if (split2[i].Length > 77)
                        {
                            height += 20 + (split2[i].Length / 77) * 20;
                        }
                        else
                        {
                            height += 20;
                        }
                    }
                    txtBox.Height = height;
                }
                txtBox.Text = str;
                txtBox.BackColor = Color.Snow;
                txtBox.Font = new Font("Microsoft Sans Serif", 12.0f);
                txtBox.Visible = true;
                f1.flowLayoutPanel.BeginInvoke((MethodInvoker)(() => f1.flowLayoutPanel.Controls.Add(txtBox)));
                Label lbl = new Label();
                lbl.Font = new Font("Microsoft Sans Serif", 8.0f);
                lbl.Visible = true;
                lbl.Width = 540;
                lbl.TextAlign = ContentAlignment.TopRight;
                lbl.Text = DateTime.Now.ToShortDateString() + ", " + DateTime.Now.ToLongTimeString();
                f1.flowLayoutPanel.BeginInvoke((MethodInvoker)(() => f1.flowLayoutPanel.Controls.Add(lbl)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            currentClient.Disconnect();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (IsLogin)
            {
                currentClient.ConnectToChat();
            }
            else
            {
                f1.Close();
            }
        }

        public void UpdatePeopleListbox(string[] PeopleList)
        {
            f1.OnlineListBox.BeginInvoke((MethodInvoker)(() => f1.OnlineListBox.Items.Clear()));
            foreach (String people in PeopleList) 
            {
                f1.OnlineListBox.BeginInvoke((MethodInvoker)(() => f1.OnlineListBox.Items.Insert(0, people)));
               
            }
        }
        public void RemoveHumanFromListbox(string people)
        {
            f1.OnlineListBox.BeginInvoke((MethodInvoker)(() => f1.OnlineListBox.Items.Remove(people)));
        }
        public void AddHumanToListbox(string people)
        {
            f1.OnlineListBox.BeginInvoke((MethodInvoker)(() => f1.OnlineListBox.Items.Insert(0, people)));
        }

        private void flowLayoutPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            flowLayoutPanel.ScrollControlIntoView(flowLayoutPanel.Controls[flowLayoutPanel.Controls.Count - 1]);
        }

        private void StickerPBox_Click(object sender, EventArgs e)
        {
            if (StickersPanel.Visible == false) 
            {
                StickersPanel.Visible = true;
            }
            else 
            {
                StickersPanel.Visible = false;
            }
        }

        private void Sticker1_pBox_Click(object sender, EventArgs e)
        {
            currentClient.SendStickerMessage("0");
        }

        private void Sticker2_pBox_Click(object sender, EventArgs e)
        {
            currentClient.SendStickerMessage("1");
        }

        private void Sticker3_pBox_Click(object sender, EventArgs e)
        {
            currentClient.SendStickerMessage("2");
        }

        private void Sticker4_pBox_Click(object sender, EventArgs e)
        {
            currentClient.SendStickerMessage("3");
        }
    }
}
