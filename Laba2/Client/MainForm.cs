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
using System.Diagnostics;
using ChatHelpingLibrary;

namespace Client
{
    public partial class MainForm : Form
    {
        ClientManager currentClient;

        public static MainForm f1;
        public bool IsLogin = false;
        public int NewMessageChatId;
        private int selectedDialog;
        private int selectedDialogId;
        public List<ClientInfo> clientsInfoList;
        public ClientInfo selectedClientDialog;
        public MainForm()
        {
            InitializeComponent();
            currentClient = new ClientManager(f1);
            currentClient.ReceiveMessageHandler += HandleReceivedMessages;
            f1 = this;
            currentClient.FindServer();
            SignForm SignForm = new SignForm(f1, currentClient);
            SignForm.ShowDialog();
        }

        public void HandleReceivedMessages(ChatHelpingLibrary.Message message)
        {
            if (message is ChatMessage)
            {
                ChatMessage chatMessage = (ChatMessage)message;
                if (chatMessage.ReceiverId == 0 )
                {
                    if (selectedDialogId != 0)
                    {
                        NewMessagelabel.Text = "Вам пришло новое сообщение в Общий чат";
                        NewMessageChatId = 0;
                    }
                    ClientInfo findClientInfoList = clientsInfoList.Find(f => f.Id == chatMessage.ReceiverId);
                    int index = clientsInfoList.IndexOf(findClientInfoList);
                    clientsInfoList[index].MessageHistory.Add(chatMessage);
                    if (chatMessage.ReceiverId == selectedDialogId)
                    {
                        RedrawOther(chatMessage.senderName, chatMessage.Content, chatMessage.dateTime);
                    }
                }
                else 
                {
                    if (chatMessage.SenderId != selectedDialogId)
                    {
                        NewMessagelabel.Text = "Вам пришло новое сообщение от " + chatMessage.senderName;
                        NewMessageChatId = chatMessage.SenderId;
                    }
                    ClientInfo findClientInfoList = clientsInfoList.Find(f => f.Id == chatMessage.SenderId);
                    int index = clientsInfoList.IndexOf(findClientInfoList);
                    clientsInfoList[index].MessageHistory.Add(chatMessage);
                    if (chatMessage.SenderId == selectedDialogId)
                    {
                        RedrawOther(chatMessage.senderName, chatMessage.Content, chatMessage.dateTime);
                    }
                }

            }
            if (message is ClientsListMessage)
            {
                ClientsListMessage clientsListMessage = (ClientsListMessage)message;
                clientsInfoList = clientsListMessage.clientInfoList;
                currentClient.MyId = clientsListMessage.YourId;
                RefreshOnlineListBox();


            }
            if (message is ActionWithClientMessage)
            {
                ActionWithClientMessage actionWithClientMessage = (ActionWithClientMessage)message;
                if (actionWithClientMessage.ActionType == 1) 
                {
                    ClientInfo clientInfo = new ClientInfo();
                    clientInfo.Id = actionWithClientMessage.ClientId;
                    clientInfo.Name = actionWithClientMessage.ClientName;
                    clientsInfoList.Add(clientInfo);

                } 
                else  if (actionWithClientMessage.ActionType == 0)
                {
                    var removeValue = clientsInfoList.First(x => x.Id == actionWithClientMessage.ClientId);
                    clientsInfoList.Remove(removeValue);
                }
                RefreshOnlineListBox();
            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            if (selectedDialog != -1)
            {
                if (MessageTBox.Text.Length != 0)
                {
                    ChatMessage chatMessage = new ChatMessage(DateTime.Now, currentClient.clientIp, currentClient.clientPort, MessageTBox.Text, currentClient.UserName, selectedDialogId);
                    if (selectedDialogId != currentClient.MyId) 
                    {
                       currentClient.SendMessage(chatMessage);                        
                    }
                    selectedClientDialog.MessageHistory.Add(chatMessage);
                    RedrawOther(currentClient.UserName, MessageTBox.Text, DateTime.Now.ToString());
                    MessageTBox.Text = "";
                }
            }
        }

        public void RedrawOther(string senderName, string str, string dateTime)
        {
            try
            {
                Label lbl1 = new Label();
                lbl1.Font = new Font("Microsoft Sans Serif", 16.0f);
                lbl1.Visible = true;
                lbl1.Width = 540;
                lbl1.Height = 30;
                lbl1.TextAlign = ContentAlignment.TopLeft;
                lbl1.Text = senderName;
                f1.flowLayoutPanel.BeginInvoke((MethodInvoker)(() => f1.flowLayoutPanel.Controls.Add(lbl1)));
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
                lbl.Text = dateTime;
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
                OnlineListBox.SelectedItem = 0;
                selectedDialog = 0;
                ChangeDialog();
            }
            else
            {
                f1.Close();
            }
        }

        private void flowLayoutPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            flowLayoutPanel.ScrollControlIntoView(flowLayoutPanel.Controls[flowLayoutPanel.Controls.Count - 1]);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            int cursorPlace = MessageTBox.SelectionStart;
            MessageTBox.Text = MessageTBox.Text.Insert(MessageTBox.SelectionStart, lbl.Text);
            MessageTBox.SelectionStart = cursorPlace + lbl.Text.Length;
        }

        private void ChangeDialog()
        {
            selectedClientDialog = (ClientInfo)OnlineListBox.SelectedItem;
            ChatNameLabel.Text = selectedClientDialog.Name;
            RefreshChatPanel(selectedClientDialog.MessageHistory);            
        }

        private void RefreshChatPanel(List<ChatMessage> selectedDialogMessages) 
        {
            flowLayoutPanel.Controls.Clear();
            if (selectedDialogMessages.Count>0) 
            {                   
                foreach (ChatMessage chatMessage in selectedDialogMessages)
                {
                    RedrawOther(chatMessage.senderName, chatMessage.Content, chatMessage.dateTime);
                }
            }
        }

        private void RefreshOnlineListBox()
        {
            Action action = delegate
            {
                OnlineListBox.DataSource = null;
                OnlineListBox.DataSource = clientsInfoList;
                OnlineListBox.DisplayMember = "Name";
                OnlineListBox.ValueMember = "Id";
            };
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((OnlineListBox.SelectedIndex != selectedDialog) && (OnlineListBox.SelectedIndex >= 0))
            {                
                selectedDialogId = (int)OnlineListBox.SelectedValue;
                selectedDialog = OnlineListBox.SelectedIndex;
                if (NewMessageChatId == selectedDialogId) 
                {
                    NewMessagelabel.Text = "";
                }
                ChangeDialog();
            }
        }
    }
}
