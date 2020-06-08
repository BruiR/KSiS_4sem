using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        public string Password;
        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            UserName = LoginBox.Text;
            Password = PasswordBox.Text;
            currentClient.Connect();
            if (currentClient.SendSignUpData(UserName, Password))
            {
                fmain.IsLogin = true;
                fmain.UserNameLabel.Text = UserName;
                this.Hide();
            }
        }

        private void SignInBtn_Click(object sender, EventArgs e)
        {
            UserName = LoginBox.Text;
            Password = PasswordBox.Text;
            currentClient.Connect();
            if (currentClient.SendSignInData(UserName, Password)) 
            {
                fmain.IsLogin = true;
                fmain.UserNameLabel.Text = UserName;
                this.Hide();
            }
        }
    }
}
