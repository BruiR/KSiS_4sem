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
            this.StickersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sticker1_pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sticker2_pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sticker3_pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sticker4_pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickerPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddFileBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.matBox.Location = new System.Drawing.Point(27, 75);
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
            this.OnlineListBox.Location = new System.Drawing.Point(12, 98);
            this.OnlineListBox.Name = "OnlineListBox";
            this.OnlineListBox.Size = new System.Drawing.Size(166, 303);
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
            this.StickersPanel.Location = new System.Drawing.Point(192, 322);
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
            this.AddFileBtn.Location = new System.Drawing.Point(12, 413);
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
            this.UserNameLabel.Size = new System.Drawing.Size(24, 25);
            this.UserNameLabel.TabIndex = 13;
            this.UserNameLabel.Text = "g";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(861, 541);
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
    }
}

