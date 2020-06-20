using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class SignForm : Form
    {
        MainForm fmain;
        ClientManager currentClient;
        public SignForm(MainForm f1, ClientManager client)
        {
            fmain = f1;
            currentClient = client;
            InitializeComponent();
        }

        public string UserName;
        private void SignInBtn_Click(object sender, EventArgs e)
        {
            UserName = LoginBox.Text;
            if (IsLoginCorrect(UserName) && currentClient.ServerInformation)
            {

                try
                {                    
                    if (currentClient.Connect(UserName))
                    {
                        fmain.IsLogin = true;
                        fmain.UserNameLabel.Text = UserName;
                        this.Hide();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка связи с сервером!");
                }                    
            }
        }

        private bool IsLoginCorrect(string UserName) 
        {
            if(UserName.Length<2 || UserName.Length > 15) 
            {
                MessageBox.Show("Длина имени от 2 до 15 символов");
                return false;
            }
            if (!Regex.IsMatch(UserName,"^([A-Za-z0-9А-Яа-я]{2,18})$"))
            {
                MessageBox.Show("Имя  может состоят из букв и цифр");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentClient.ServerInformation) 
            {
                MessageBox.Show("Сервер найден!");
                ServerInfoLabel.Text =("ServerIp = " + currentClient.ServerIp.ToString() + ",  ServerPort = " + currentClient.ServerPort.ToString());
            } 
            else 
            { 
                MessageBox.Show("Сервер не найден!");  
            }
        }


    }
}
