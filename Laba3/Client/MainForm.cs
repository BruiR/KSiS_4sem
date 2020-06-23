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
using ClientHttp;

namespace Client
{
    public partial class MainForm : Form
    {
        ClientManager currentClient;
        HttpClientManager httpClient;
        public static MainForm f1;
        public bool IsLogin = false;
        public int NewMessageChatId;
        private int selectedDialog;
        private int selectedDialogId;
        public List<ClientInfo> clientsInfoList;
        public ClientInfo selectedClientDialog;
        public int CurrentFileID;
        public string CurrentFileName;


        public MainForm()
        {
            InitializeComponent();
            httpClient = new HttpClientManager();
            currentClient = new ClientManager();
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
                        Action action = delegate
                        {
                            NewMessagelabel.Text = "Вам пришло новое сообщение в Общий чат";
                            NewMessageChatId = 0;
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
                    ClientInfo findClientInfoList = clientsInfoList.Find(f => f.Id == chatMessage.ReceiverId);
                    int index = clientsInfoList.IndexOf(findClientInfoList);
                    clientsInfoList[index].MessageHistory.Add(chatMessage);
                    if (chatMessage.ReceiverId == selectedDialogId)
                    {
                        RedrawOther(chatMessage.SenderName, chatMessage.Content, chatMessage.DateTime);
                        if (chatMessage.IsAnyFiles)
                        {
                            foreach (FileInMessage fileInMessage in chatMessage.FilesInMessageList)
                            {
                                RedrawFileInDialogPanel(chatMessage.SenderName + "отправил файл", fileInMessage.fileName, chatMessage.DateTime, fileInMessage.fileID);
                            }
                        }
                    }
                }
                else 
                {
                    if (chatMessage.SenderId != selectedDialogId)
                    {
                        Action action = delegate
                        {
                            NewMessagelabel.Text = "Вам пришло новое сообщение от " + chatMessage.SenderName;
                            NewMessageChatId = chatMessage.SenderId;
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
                    ClientInfo findClientInfoList = clientsInfoList.Find(f => f.Id == chatMessage.SenderId);
                    int index = clientsInfoList.IndexOf(findClientInfoList);
                    clientsInfoList[index].MessageHistory.Add(chatMessage);
                    if (chatMessage.SenderId == selectedDialogId)
                    {
                        RedrawOther(chatMessage.SenderName, chatMessage.Content, chatMessage.DateTime);
                        if (chatMessage.IsAnyFiles)
                        {
                            foreach (FileInMessage fileInMessage in chatMessage.FilesInMessageList)
                            {
                                RedrawFileInDialogPanel(chatMessage.SenderName + "отправил файл", fileInMessage.fileName, chatMessage.DateTime, fileInMessage.fileID);
                            }
                        }
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
                if ((MessageTBox.Text.Length != 0) || (httpClient.LoadedFiles.Count != 0))
                {
                    ChatMessage chatMessage = new ChatMessage(DateTime.Now, currentClient.clientIp, currentClient.clientPort, MessageTBox.Text, currentClient.UserName, selectedDialogId);
                    
                    if (httpClient.LoadedFiles.Count != 0)
                    {
                        chatMessage.IsAnyFiles = true;
                        var fileInMessageList = new List<FileInMessage>();
                        foreach (KeyValuePair<int, string> keyValuePair in httpClient.LoadedFiles)
                        {
                            chatMessage.FilesInMessageList.Add(new FileInMessage()
                            { fileID = keyValuePair.Key, fileName = keyValuePair.Value });
                        }
                        httpClient.LoadedFiles.Clear();
                        httpClient.sizeOfLoadedFiles = 0;
                        LoadedFIlesCBox.SelectedIndex = -1;
                        UpdateFilesList();
                    }
                    if (selectedDialogId != currentClient.MyId) 
                    {
                       currentClient.SendMessage(chatMessage);                        
                    }
                    selectedClientDialog.MessageHistory.Add(chatMessage);                    
                    RedrawOther(chatMessage.SenderName, chatMessage.Content, chatMessage.DateTime);
                    if (chatMessage.IsAnyFiles)
                    {
                        foreach(FileInMessage fileInMessage in chatMessage.FilesInMessageList)
                        {
                            RedrawFileInDialogPanel(chatMessage.SenderName + "отправил файл", fileInMessage.fileName, chatMessage.DateTime, fileInMessage.fileID);
                        }
                    }
                    LoadedFIlesCBox.Text = "";
                    LoadedFIlesCBox.Items.Clear();
                    MessageTBox.Text = "";
                }
            }
        }

        public void RedrawFileInDialogPanel(string senderName, string fileName, string dateTime, int fileId)
        {
            Label lblFileName = new Label();
            lblFileName.Font = new Font("Microsoft Sans Serif", 10.0f);
            lblFileName.Visible = true;
            lblFileName.Width = 540;
            lblFileName.Height = 30;
            lblFileName.TextAlign = ContentAlignment.TopLeft;
            lblFileName.Text = "к сообщению прикреплен файл :  " + fileName;
            f1.flowLayoutPanel.BeginInvoke((MethodInvoker)(() => f1.flowLayoutPanel.Controls.Add(lblFileName)));

            Label lbl1 = new Label();
            lbl1.Font = new Font("Microsoft Sans Serif", 8.0f);
            lbl1.Visible = true;
            lbl1.Width = 540;
            lbl1.Height = 30;
            lbl1.TextAlign = ContentAlignment.TopLeft;
            lbl1.Text = "Скачать";
            lbl1.Click  += (sender, EventArgs) => { ButtonDownloadFileClick(sender, EventArgs,fileId); };
            f1.flowLayoutPanel.BeginInvoke((MethodInvoker)(() => f1.flowLayoutPanel.Controls.Add(lbl1)));

            Label lbl2 = new Label();
            lbl2.Font = new Font("Microsoft Sans Serif", 8.0f);
            lbl2.Visible = true;
            lbl2.Width = 540;
            lbl2.Height = 30;
            lbl2.TextAlign = ContentAlignment.TopLeft;
            lbl2.Text = "Информация о файле";
            lbl2.Click += (sender, EventArgs) => { ButtonFileInfoClick(sender, EventArgs,fileId); };
            f1.flowLayoutPanel.BeginInvoke((MethodInvoker)(() => f1.flowLayoutPanel.Controls.Add(lbl2)));
        }

        private void ButtonDownloadFileClick(object sender, EventArgs e, int fileId)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                httpClient.GetFileToSave(fileId, saveFileDialog1.FileName);
            }
            
        }

        private async void ButtonFileInfoClick(object sender, EventArgs eventArgs, int fileId)
        {
            string[] Info = await httpClient.GetFileInformation(fileId);
            if (Info != null)
            {
                FileNameLabel.Text = Info[0];
                FileSizeLabel.Text = Info[1];
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
                currentClient.listenTcpThread.Abort();
                currentClient.listenUdpThread.Abort();
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
                    RedrawOther(chatMessage.SenderName, chatMessage.Content, chatMessage.DateTime);
                    if (chatMessage.IsAnyFiles)
                    {
                        foreach(FileInMessage fileInMessage in chatMessage.FilesInMessageList)
                        {
                            RedrawFileInDialogPanel(chatMessage.SenderName + "отправил файл", fileInMessage.fileName, chatMessage.DateTime, fileInMessage.fileID);
                        }
                    }
                }
            }
            LoadedFIlesCBox.Text = "";
            LoadedFIlesCBox.Items.Clear();
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

        private async void LoadFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                if (httpClient.CheckFileRestrictions(filePath))
                {
                    int fileId = await httpClient.LoadFile(filePath);
                    httpClient.LoadedFiles.Add(fileId, Path.GetFileName(filePath));
                    LoadedFIlesCBox.Text = "";
                    LoadedFIlesCBox.SelectedIndex = -1;
                    UpdateFilesList();
                }
                else 
                {
                    MessageBox.Show("Файл не подходит по формату или размер файла не более 50МБ/суммарный размер файлов не более 100МБ ");
                }
            }
        }

        private void DeleteFileBtn_Click(object sender, EventArgs e)
        {
            if (LoadedFIlesCBox.SelectedIndex != -1)
            {
                int fileID = ((KeyValuePair<int, string>)LoadedFIlesCBox.SelectedItem).Key;
                httpClient.DeleteFile(fileID);
                LoadedFIlesCBox.Text = "";
                LoadedFIlesCBox.SelectedIndex = -1;
                UpdateFilesList();
            }
        }

        public void UpdateFilesList()
        {
            LoadedFIlesCBox.Items.Clear();
            foreach (KeyValuePair<int, string> file in httpClient.LoadedFiles)
            {
                LoadedFIlesCBox.Items.Add(file);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            currentClient.Disconnect();
        }
    }
}
