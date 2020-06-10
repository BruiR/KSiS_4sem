namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MessageTBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.matBox = new System.Windows.Forms.CheckBox();
            this.OnlineListBox = new System.Windows.Forms.ListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.StickersPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Sticker1_pBox = new System.Windows.Forms.PictureBox();
            this.Sticker2_pBox = new System.Windows.Forms.PictureBox();
            this.Sticker3_pBox = new System.Windows.Forms.PictureBox();
            this.Sticker4_pBox = new System.Windows.Forms.PictureBox();
            this.StickerPBox = new System.Windows.Forms.PictureBox();
            this.AddFileBtn = new System.Windows.Forms.PictureBox();
            this.SendBtn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.FilesListBox = new System.Windows.Forms.ListBox();
            this.fileeListlabel = new System.Windows.Forms.Label();
            this.PeopleListlabel = new System.Windows.Forms.Label();
            this.OpenFileBtn = new System.Windows.Forms.Button();
            this.StickersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sticker1_pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sticker2_pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sticker3_pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sticker4_pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickerPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddFileBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(193, 52);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(629, 349);
            this.flowLayoutPanel.TabIndex = 1;
            this.flowLayoutPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanel_ControlAdded);
            // 
            // MessageTBox
            // 
            this.MessageTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageTBox.Location = new System.Drawing.Point(267, 417);
            this.MessageTBox.Multiline = true;
            this.MessageTBox.Name = "MessageTBox";
            this.MessageTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageTBox.Size = new System.Drawing.Size(484, 63);
            this.MessageTBox.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // matBox
            // 
            this.matBox.AutoSize = true;
            this.matBox.Checked = true;
            this.matBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.matBox.Location = new System.Drawing.Point(12, 527);
            this.matBox.Name = "matBox";
            this.matBox.Size = new System.Drawing.Size(94, 17);
            this.matBox.TabIndex = 6;
            this.matBox.Text = "Фильтр мата";
            this.matBox.UseVisualStyleBackColor = true;
            // 
            // OnlineListBox
            // 
            this.OnlineListBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.OnlineListBox.FormattingEnabled = true;
            this.OnlineListBox.Location = new System.Drawing.Point(12, 89);
            this.OnlineListBox.Name = "OnlineListBox";
            this.OnlineListBox.Size = new System.Drawing.Size(166, 238);
            this.OnlineListBox.TabIndex = 7;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.png");
            this.imageList1.Images.SetKeyName(1, "2.png");
            this.imageList1.Images.SetKeyName(2, "3.png");
            this.imageList1.Images.SetKeyName(3, "4.png");
            // 
            // StickersPanel
            // 
            this.StickersPanel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StickersPanel.BackColor = System.Drawing.Color.MediumTurquoise;
            this.StickersPanel.Controls.Add(this.Sticker1_pBox);
            this.StickersPanel.Controls.Add(this.Sticker2_pBox);
            this.StickersPanel.Controls.Add(this.Sticker3_pBox);
            this.StickersPanel.Controls.Add(this.Sticker4_pBox);
            this.StickersPanel.Location = new System.Drawing.Point(192, 320);
            this.StickersPanel.Name = "StickersPanel";
            this.StickersPanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.StickersPanel.Size = new System.Drawing.Size(353, 95);
            this.StickersPanel.TabIndex = 12;
            this.StickersPanel.Visible = false;
            // 
            // Sticker1_pBox
            // 
            this.Sticker1_pBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Sticker1_pBox.Image = global::Client.Properties.Resources._1;
            this.Sticker1_pBox.Location = new System.Drawing.Point(3, 8);
            this.Sticker1_pBox.Name = "Sticker1_pBox";
            this.Sticker1_pBox.Size = new System.Drawing.Size(80, 80);
            this.Sticker1_pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Sticker1_pBox.TabIndex = 0;
            this.Sticker1_pBox.TabStop = false;
            this.Sticker1_pBox.Click += new System.EventHandler(this.Sticker1_pBox_Click);
            // 
            // Sticker2_pBox
            // 
            this.Sticker2_pBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Sticker2_pBox.Image = global::Client.Properties.Resources._2;
            this.Sticker2_pBox.Location = new System.Drawing.Point(89, 8);
            this.Sticker2_pBox.Name = "Sticker2_pBox";
            this.Sticker2_pBox.Size = new System.Drawing.Size(80, 80);
            this.Sticker2_pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Sticker2_pBox.TabIndex = 1;
            this.Sticker2_pBox.TabStop = false;
            this.Sticker2_pBox.Click += new System.EventHandler(this.Sticker2_pBox_Click);
            // 
            // Sticker3_pBox
            // 
            this.Sticker3_pBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Sticker3_pBox.Image = global::Client.Properties.Resources._3;
            this.Sticker3_pBox.Location = new System.Drawing.Point(175, 8);
            this.Sticker3_pBox.Name = "Sticker3_pBox";
            this.Sticker3_pBox.Size = new System.Drawing.Size(80, 80);
            this.Sticker3_pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Sticker3_pBox.TabIndex = 2;
            this.Sticker3_pBox.TabStop = false;
            this.Sticker3_pBox.Click += new System.EventHandler(this.Sticker3_pBox_Click);
            // 
            // Sticker4_pBox
            // 
            this.Sticker4_pBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Sticker4_pBox.Image = global::Client.Properties.Resources._4;
            this.Sticker4_pBox.Location = new System.Drawing.Point(261, 8);
            this.Sticker4_pBox.Name = "Sticker4_pBox";
            this.Sticker4_pBox.Size = new System.Drawing.Size(80, 80);
            this.Sticker4_pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Sticker4_pBox.TabIndex = 3;
            this.Sticker4_pBox.TabStop = false;
            this.Sticker4_pBox.Click += new System.EventHandler(this.Sticker4_pBox_Click);
            // 
            // StickerPBox
            // 
            this.StickerPBox.Image = global::Client.Properties.Resources.sticker;
            this.StickerPBox.Location = new System.Drawing.Point(192, 416);
            this.StickerPBox.Name = "StickerPBox";
            this.StickerPBox.Size = new System.Drawing.Size(69, 64);
            this.StickerPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.StickerPBox.TabIndex = 8;
            this.StickerPBox.TabStop = false;
            this.StickerPBox.Click += new System.EventHandler(this.StickerPBox_Click);
            // 
            // AddFileBtn
            // 
            this.AddFileBtn.Image = global::Client.Properties.Resources.send_file_btn;
            this.AddFileBtn.InitialImage = null;
            this.AddFileBtn.Location = new System.Drawing.Point(192, 481);
            this.AddFileBtn.Name = "AddFileBtn";
            this.AddFileBtn.Size = new System.Drawing.Size(68, 63);
            this.AddFileBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AddFileBtn.TabIndex = 4;
            this.AddFileBtn.TabStop = false;
            this.AddFileBtn.Click += new System.EventHandler(this.AddFileBtn_Click);
            // 
            // SendBtn
            // 
            this.SendBtn.Image = global::Client.Properties.Resources.send_btn;
            this.SendBtn.Location = new System.Drawing.Point(757, 417);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(65, 63);
            this.SendBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SendBtn.TabIndex = 3;
            this.SendBtn.TabStop = false;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 58);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.BackColor = System.Drawing.Color.White;
            this.UserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserNameLabel.Location = new System.Drawing.Point(81, 15);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(0, 25);
            this.UserNameLabel.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.label10);
            this.flowLayoutPanel1.Controls.Add(this.label11);
            this.flowLayoutPanel1.Controls.Add(this.label12);
            this.flowLayoutPanel1.Controls.Add(this.label13);
            this.flowLayoutPanel1.Controls.Add(this.label14);
            this.flowLayoutPanel1.Controls.Add(this.label15);
            this.flowLayoutPanel1.Controls.Add(this.label16);
            this.flowLayoutPanel1.Controls.Add(this.label17);
            this.flowLayoutPanel1.Controls.Add(this.label18);
            this.flowLayoutPanel1.Controls.Add(this.label19);
            this.flowLayoutPanel1.Controls.Add(this.label20);
            this.flowLayoutPanel1.Controls.Add(this.label21);
            this.flowLayoutPanel1.Controls.Add(this.label22);
            this.flowLayoutPanel1.Controls.Add(this.label23);
            this.flowLayoutPanel1.Controls.Add(this.label24);
            this.flowLayoutPanel1.Controls.Add(this.label25);
            this.flowLayoutPanel1.Controls.Add(this.label26);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(267, 486);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(484, 58);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "😎";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(40, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "😲";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(77, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "😄";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(114, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "😘";
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(151, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "😟";
            this.label5.Click += new System.EventHandler(this.label1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(188, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "🤤";
            this.label6.Click += new System.EventHandler(this.label1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(225, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "😏";
            this.label7.Click += new System.EventHandler(this.label1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(262, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 24);
            this.label8.TabIndex = 7;
            this.label8.Text = "🤣";
            this.label8.Click += new System.EventHandler(this.label1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(299, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 24);
            this.label9.TabIndex = 8;
            this.label9.Text = "😇";
            this.label9.Click += new System.EventHandler(this.label1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(336, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 24);
            this.label10.TabIndex = 9;
            this.label10.Text = "🙃";
            this.label10.Click += new System.EventHandler(this.label1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(373, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 24);
            this.label11.TabIndex = 10;
            this.label11.Text = "🙄";
            this.label11.Click += new System.EventHandler(this.label1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(410, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 24);
            this.label12.TabIndex = 11;
            this.label12.Text = "😥";
            this.label12.Click += new System.EventHandler(this.label1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(447, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 24);
            this.label13.TabIndex = 12;
            this.label13.Text = "🤕";
            this.label13.Click += new System.EventHandler(this.label1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(3, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 24);
            this.label14.TabIndex = 13;
            this.label14.Text = "👍🏻";
            this.label14.Click += new System.EventHandler(this.label1_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(38, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 24);
            this.label15.TabIndex = 14;
            this.label15.Text = "👎🏻";
            this.label15.Click += new System.EventHandler(this.label1_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(73, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(25, 24);
            this.label16.TabIndex = 15;
            this.label16.Text = "👌🏻";
            this.label16.Click += new System.EventHandler(this.label1_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(104, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 24);
            this.label17.TabIndex = 16;
            this.label17.Text = "👊🏻";
            this.label17.Click += new System.EventHandler(this.label1_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(139, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 24);
            this.label18.TabIndex = 17;
            this.label18.Text = "👏🏻";
            this.label18.Click += new System.EventHandler(this.label1_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(175, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 24);
            this.label19.TabIndex = 18;
            this.label19.Text = "💪🏻";
            this.label19.Click += new System.EventHandler(this.label1_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(212, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 24);
            this.label20.TabIndex = 19;
            this.label20.Text = "🙏🏻";
            this.label20.Click += new System.EventHandler(this.label1_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(249, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 24);
            this.label21.TabIndex = 20;
            this.label21.Text = "💖";
            this.label21.Click += new System.EventHandler(this.label1_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(286, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(31, 24);
            this.label22.TabIndex = 21;
            this.label22.Text = "💤";
            this.label22.Click += new System.EventHandler(this.label1_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(323, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 24);
            this.label23.TabIndex = 22;
            this.label23.Text = "🙈";
            this.label23.Click += new System.EventHandler(this.label1_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label24.Location = new System.Drawing.Point(360, 24);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(31, 24);
            this.label24.TabIndex = 23;
            this.label24.Text = "🙉";
            this.label24.Click += new System.EventHandler(this.label1_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.Location = new System.Drawing.Point(397, 24);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(31, 24);
            this.label25.TabIndex = 24;
            this.label25.Text = "🙊";
            this.label25.Click += new System.EventHandler(this.label1_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.Location = new System.Drawing.Point(434, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(31, 24);
            this.label26.TabIndex = 25;
            this.label26.Text = "💜";
            this.label26.Click += new System.EventHandler(this.label1_Click);
            // 
            // FilesListBox
            // 
            this.FilesListBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.FilesListBox.FormattingEnabled = true;
            this.FilesListBox.Location = new System.Drawing.Point(12, 359);
            this.FilesListBox.Name = "FilesListBox";
            this.FilesListBox.Size = new System.Drawing.Size(166, 121);
            this.FilesListBox.TabIndex = 15;
            // 
            // fileeListlabel
            // 
            this.fileeListlabel.AutoSize = true;
            this.fileeListlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileeListlabel.Location = new System.Drawing.Point(12, 336);
            this.fileeListlabel.Name = "fileeListlabel";
            this.fileeListlabel.Size = new System.Drawing.Size(136, 20);
            this.fileeListlabel.TabIndex = 16;
            this.fileeListlabel.Text = "Список файлов :";
            // 
            // PeopleListlabel
            // 
            this.PeopleListlabel.AutoSize = true;
            this.PeopleListlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PeopleListlabel.Location = new System.Drawing.Point(12, 66);
            this.PeopleListlabel.Name = "PeopleListlabel";
            this.PeopleListlabel.Size = new System.Drawing.Size(75, 20);
            this.PeopleListlabel.TabIndex = 17;
            this.PeopleListlabel.Text = "Онлайн :";
            // 
            // OpenFileBtn
            // 
            this.OpenFileBtn.BackColor = System.Drawing.Color.LightCyan;
            this.OpenFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OpenFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFileBtn.Location = new System.Drawing.Point(39, 487);
            this.OpenFileBtn.Name = "OpenFileBtn";
            this.OpenFileBtn.Size = new System.Drawing.Size(109, 26);
            this.OpenFileBtn.TabIndex = 18;
            this.OpenFileBtn.Text = "Открыть файл";
            this.OpenFileBtn.UseVisualStyleBackColor = false;
            this.OpenFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(861, 552);
            this.Controls.Add(this.OpenFileBtn);
            this.Controls.Add(this.PeopleListlabel);
            this.Controls.Add(this.fileeListlabel);
            this.Controls.Add(this.FilesListBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.StickersPanel);
            this.Controls.Add(this.StickerPBox);
            this.Controls.Add(this.OnlineListBox);
            this.Controls.Add(this.matBox);
            this.Controls.Add(this.AddFileBtn);
            this.Controls.Add(this.MessageTBox);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "LiteChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.StickersPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Sticker1_pBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sticker2_pBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sticker3_pBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sticker4_pBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickerPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddFileBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox SendBtn;
        private System.Windows.Forms.PictureBox AddFileBtn;
        private System.Windows.Forms.TextBox MessageTBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.CheckBox matBox;
        private System.Windows.Forms.ListBox OnlineListBox;
        private System.Windows.Forms.PictureBox StickerPBox;
        private System.Windows.Forms.FlowLayoutPanel StickersPanel;
        private System.Windows.Forms.PictureBox Sticker1_pBox;
        private System.Windows.Forms.PictureBox Sticker2_pBox;
        private System.Windows.Forms.PictureBox Sticker3_pBox;
        private System.Windows.Forms.PictureBox Sticker4_pBox;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ListBox FilesListBox;
        private System.Windows.Forms.Label fileeListlabel;
        private System.Windows.Forms.Label PeopleListlabel;
        private System.Windows.Forms.Button OpenFileBtn;
    }
}

