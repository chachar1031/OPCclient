namespace opcClient
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxConnect = new System.Windows.Forms.GroupBox();
            this.label_ItemAddingMode = new System.Windows.Forms.Label();
            this.cmbServerName = new System.Windows.Forms.ComboBox();
            this.label_OpcFilterString = new System.Windows.Forms.Label();
            this.label_ServerIP = new System.Windows.Forms.Label();
            this.label_localIP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_ShowItem = new System.Windows.Forms.ListBox();
            this.listBox_SelItem = new System.Windows.Forms.ListBox();
            this.Clock_Timer = new System.Windows.Forms.Timer(this.components);
            this.groupBoxRate = new System.Windows.Forms.GroupBox();
            this.btnApplyRate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtboxUploadRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtboxUpdateRate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxSetting = new System.Windows.Forms.GroupBox();
            this.buttonChangeOrder = new System.Windows.Forms.Button();
            this.buttonDelRow = new System.Windows.Forms.Button();
            this.buttonBackSetting = new System.Windows.Forms.Button();
            this.buttonClearSetting = new System.Windows.Forms.Button();
            this.buttonChangeSetting = new System.Windows.Forms.Button();
            this.buttonStartUpload = new System.Windows.Forms.Button();
            this.labelItemCount = new System.Windows.Forms.Label();
            this.groupBoxAutoReset = new System.Windows.Forms.GroupBox();
            this.comboBoxResetHour2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxResetMin2 = new System.Windows.Forms.ComboBox();
            this.checkBoxEnableReset2 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxResetMin1 = new System.Windows.Forms.ComboBox();
            this.comboBoxResetHour1 = new System.Windows.Forms.ComboBox();
            this.checkBoxEnableReset1 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.DGrid = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.listBox_log = new System.Windows.Forms.ListBox();
            this.groupBoxFunction = new System.Windows.Forms.GroupBox();
            this.buttonFunc4 = new System.Windows.Forms.Button();
            this.buttonFunc3 = new System.Windows.Forms.Button();
            this.buttonFunc2 = new System.Windows.Forms.Button();
            this.buttonFunc1 = new System.Windows.Forms.Button();
            this.groupBoxSave = new System.Windows.Forms.GroupBox();
            this.buttonSaveSetting = new System.Windows.Forms.Button();
            this.buttonDoneSetting = new System.Windows.Forms.Button();
            this.groupBoxManualReset = new System.Windows.Forms.GroupBox();
            this.btnRomoveResetTime = new System.Windows.Forms.Button();
            this.listBox_ResetTime = new System.Windows.Forms.ListBox();
            this.btnAddResetTime = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerManualReset = new System.Windows.Forms.DateTimePicker();
            this.comboBoxManualResetMin = new System.Windows.Forms.ComboBox();
            this.comboBoxManualResetHour = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBoxConnect.SuspendLayout();
            this.groupBoxRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxSetting.SuspendLayout();
            this.groupBoxAutoReset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBoxLog.SuspendLayout();
            this.groupBoxFunction.SuspendLayout();
            this.groupBoxSave.SuspendLayout();
            this.groupBoxManualReset.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConnect
            // 
            this.groupBoxConnect.Controls.Add(this.label_ItemAddingMode);
            this.groupBoxConnect.Controls.Add(this.cmbServerName);
            this.groupBoxConnect.Controls.Add(this.label_OpcFilterString);
            this.groupBoxConnect.Controls.Add(this.label_ServerIP);
            this.groupBoxConnect.Controls.Add(this.label_localIP);
            this.groupBoxConnect.Controls.Add(this.label1);
            this.groupBoxConnect.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConnect.Name = "groupBoxConnect";
            this.groupBoxConnect.Size = new System.Drawing.Size(344, 94);
            this.groupBoxConnect.TabIndex = 7;
            this.groupBoxConnect.TabStop = false;
            this.groupBoxConnect.Text = "Connection";
            // 
            // label_ItemAddingMode
            // 
            this.label_ItemAddingMode.AutoSize = true;
            this.label_ItemAddingMode.Location = new System.Drawing.Point(185, 75);
            this.label_ItemAddingMode.Name = "label_ItemAddingMode";
            this.label_ItemAddingMode.Size = new System.Drawing.Size(76, 12);
            this.label_ItemAddingMode.TabIndex = 11;
            this.label_ItemAddingMode.Text = "Adding Mode :";
            // 
            // cmbServerName
            // 
            this.cmbServerName.FormattingEnabled = true;
            this.cmbServerName.Location = new System.Drawing.Point(83, 21);
            this.cmbServerName.Name = "cmbServerName";
            this.cmbServerName.Size = new System.Drawing.Size(247, 20);
            this.cmbServerName.TabIndex = 5;
            this.cmbServerName.SelectedIndexChanged += new System.EventHandler(this.cmbServerName_SelectedIndexChanged);
            // 
            // label_OpcFilterString
            // 
            this.label_OpcFilterString.AutoSize = true;
            this.label_OpcFilterString.Location = new System.Drawing.Point(12, 75);
            this.label_OpcFilterString.Name = "label_OpcFilterString";
            this.label_OpcFilterString.Size = new System.Drawing.Size(66, 12);
            this.label_OpcFilterString.TabIndex = 10;
            this.label_OpcFilterString.Text = "Filter String :";
            // 
            // label_ServerIP
            // 
            this.label_ServerIP.AutoSize = true;
            this.label_ServerIP.Location = new System.Drawing.Point(185, 53);
            this.label_ServerIP.Name = "label_ServerIP";
            this.label_ServerIP.Size = new System.Drawing.Size(54, 12);
            this.label_ServerIP.TabIndex = 9;
            this.label_ServerIP.Text = "Server IP :";
            // 
            // label_localIP
            // 
            this.label_localIP.AutoSize = true;
            this.label_localIP.Location = new System.Drawing.Point(12, 53);
            this.label_localIP.Name = "label_localIP";
            this.label_localIP.Size = new System.Drawing.Size(50, 12);
            this.label_localIP.TabIndex = 8;
            this.label_localIP.Text = "Local IP :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "OPC Server：";
            // 
            // listBox_ShowItem
            // 
            this.listBox_ShowItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_ShowItem.FormattingEnabled = true;
            this.listBox_ShowItem.HorizontalScrollbar = true;
            this.listBox_ShowItem.ItemHeight = 12;
            this.listBox_ShowItem.Location = new System.Drawing.Point(12, 112);
            this.listBox_ShowItem.Name = "listBox_ShowItem";
            this.listBox_ShowItem.Size = new System.Drawing.Size(344, 268);
            this.listBox_ShowItem.TabIndex = 9;
            this.listBox_ShowItem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_ShowItem_MouseDoubleClick);
            // 
            // listBox_SelItem
            // 
            this.listBox_SelItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_SelItem.FormattingEnabled = true;
            this.listBox_SelItem.ItemHeight = 12;
            this.listBox_SelItem.Location = new System.Drawing.Point(309, 220);
            this.listBox_SelItem.Name = "listBox_SelItem";
            this.listBox_SelItem.Size = new System.Drawing.Size(47, 160);
            this.listBox_SelItem.TabIndex = 18;
            // 
            // Clock_Timer
            // 
            this.Clock_Timer.Tick += new System.EventHandler(this.Clock_Timer_Tick);
            // 
            // groupBoxRate
            // 
            this.groupBoxRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxRate.Controls.Add(this.btnApplyRate);
            this.groupBoxRate.Controls.Add(this.label4);
            this.groupBoxRate.Controls.Add(this.txtboxUploadRate);
            this.groupBoxRate.Controls.Add(this.label3);
            this.groupBoxRate.Controls.Add(this.label2);
            this.groupBoxRate.Controls.Add(this.txtboxUpdateRate);
            this.groupBoxRate.Controls.Add(this.label7);
            this.groupBoxRate.Location = new System.Drawing.Point(12, 394);
            this.groupBoxRate.Name = "groupBoxRate";
            this.groupBoxRate.Size = new System.Drawing.Size(118, 172);
            this.groupBoxRate.TabIndex = 33;
            this.groupBoxRate.TabStop = false;
            this.groupBoxRate.Text = "Rate";
            // 
            // btnApplyRate
            // 
            this.btnApplyRate.Location = new System.Drawing.Point(20, 133);
            this.btnApplyRate.Name = "btnApplyRate";
            this.btnApplyRate.Size = new System.Drawing.Size(68, 28);
            this.btnApplyRate.TabIndex = 23;
            this.btnApplyRate.Text = "APPLY";
            this.btnApplyRate.UseVisualStyleBackColor = true;
            this.btnApplyRate.Click += new System.EventHandler(this.btnApplyRate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "sec";
            // 
            // txtboxUploadRate
            // 
            this.txtboxUploadRate.Location = new System.Drawing.Point(6, 92);
            this.txtboxUploadRate.Name = "txtboxUploadRate";
            this.txtboxUploadRate.Size = new System.Drawing.Size(82, 22);
            this.txtboxUploadRate.TabIndex = 19;
            this.txtboxUploadRate.Text = "1";
            this.txtboxUploadRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "ms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "Upload (to Server)：";
            // 
            // txtboxUpdateRate
            // 
            this.txtboxUpdateRate.Location = new System.Drawing.Point(7, 38);
            this.txtboxUpdateRate.Name = "txtboxUpdateRate";
            this.txtboxUpdateRate.Size = new System.Drawing.Size(81, 22);
            this.txtboxUpdateRate.TabIndex = 15;
            this.txtboxUpdateRate.Text = "250";
            this.txtboxUpdateRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "Update (from PLC)：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(369, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(539, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxSetting
            // 
            this.groupBoxSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxSetting.Controls.Add(this.buttonChangeOrder);
            this.groupBoxSetting.Controls.Add(this.buttonDelRow);
            this.groupBoxSetting.Controls.Add(this.buttonBackSetting);
            this.groupBoxSetting.Controls.Add(this.buttonClearSetting);
            this.groupBoxSetting.Location = new System.Drawing.Point(369, 394);
            this.groupBoxSetting.Name = "groupBoxSetting";
            this.groupBoxSetting.Size = new System.Drawing.Size(160, 92);
            this.groupBoxSetting.TabIndex = 34;
            this.groupBoxSetting.TabStop = false;
            this.groupBoxSetting.Text = "Setting";
            // 
            // buttonChangeOrder
            // 
            this.buttonChangeOrder.Location = new System.Drawing.Point(84, 56);
            this.buttonChangeOrder.Name = "buttonChangeOrder";
            this.buttonChangeOrder.Size = new System.Drawing.Size(65, 28);
            this.buttonChangeOrder.TabIndex = 72;
            this.buttonChangeOrder.Text = "ReORDER";
            this.buttonChangeOrder.UseVisualStyleBackColor = true;
            this.buttonChangeOrder.Click += new System.EventHandler(this.buttonChangeOrder_Click);
            // 
            // buttonDelRow
            // 
            this.buttonDelRow.Location = new System.Drawing.Point(84, 21);
            this.buttonDelRow.Name = "buttonDelRow";
            this.buttonDelRow.Size = new System.Drawing.Size(65, 28);
            this.buttonDelRow.TabIndex = 71;
            this.buttonDelRow.Text = "Del ROW";
            this.buttonDelRow.UseVisualStyleBackColor = true;
            this.buttonDelRow.Click += new System.EventHandler(this.buttonDelRow_Click);
            // 
            // buttonBackSetting
            // 
            this.buttonBackSetting.Location = new System.Drawing.Point(12, 21);
            this.buttonBackSetting.Name = "buttonBackSetting";
            this.buttonBackSetting.Size = new System.Drawing.Size(66, 28);
            this.buttonBackSetting.TabIndex = 70;
            this.buttonBackSetting.Text = "BACK";
            this.buttonBackSetting.UseVisualStyleBackColor = true;
            this.buttonBackSetting.Click += new System.EventHandler(this.buttonBackSetting_Click);
            // 
            // buttonClearSetting
            // 
            this.buttonClearSetting.Location = new System.Drawing.Point(12, 56);
            this.buttonClearSetting.Name = "buttonClearSetting";
            this.buttonClearSetting.Size = new System.Drawing.Size(66, 28);
            this.buttonClearSetting.TabIndex = 66;
            this.buttonClearSetting.Text = "CLEAR";
            this.buttonClearSetting.UseVisualStyleBackColor = true;
            this.buttonClearSetting.Click += new System.EventHandler(this.buttonClearSetting_Click);
            // 
            // buttonChangeSetting
            // 
            this.buttonChangeSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangeSetting.Location = new System.Drawing.Point(816, 444);
            this.buttonChangeSetting.Name = "buttonChangeSetting";
            this.buttonChangeSetting.Size = new System.Drawing.Size(94, 59);
            this.buttonChangeSetting.TabIndex = 65;
            this.buttonChangeSetting.Text = "SETTING";
            this.buttonChangeSetting.UseVisualStyleBackColor = true;
            this.buttonChangeSetting.Click += new System.EventHandler(this.buttonChangeSetting_Click);
            // 
            // buttonStartUpload
            // 
            this.buttonStartUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartUpload.Location = new System.Drawing.Point(816, 509);
            this.buttonStartUpload.Name = "buttonStartUpload";
            this.buttonStartUpload.Size = new System.Drawing.Size(94, 59);
            this.buttonStartUpload.TabIndex = 64;
            this.buttonStartUpload.Text = "START";
            this.buttonStartUpload.UseVisualStyleBackColor = true;
            this.buttonStartUpload.Click += new System.EventHandler(this.buttonStartUpload_Click);
            // 
            // labelItemCount
            // 
            this.labelItemCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelItemCount.AutoSize = true;
            this.labelItemCount.Location = new System.Drawing.Point(814, 403);
            this.labelItemCount.Name = "labelItemCount";
            this.labelItemCount.Size = new System.Drawing.Size(70, 12);
            this.labelItemCount.TabIndex = 67;
            this.labelItemCount.Text = "Item Count：";
            this.labelItemCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // groupBoxAutoReset
            // 
            this.groupBoxAutoReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxAutoReset.Controls.Add(this.comboBoxResetHour2);
            this.groupBoxAutoReset.Controls.Add(this.label9);
            this.groupBoxAutoReset.Controls.Add(this.comboBoxResetMin2);
            this.groupBoxAutoReset.Controls.Add(this.checkBoxEnableReset2);
            this.groupBoxAutoReset.Controls.Add(this.label10);
            this.groupBoxAutoReset.Controls.Add(this.label8);
            this.groupBoxAutoReset.Controls.Add(this.comboBoxResetMin1);
            this.groupBoxAutoReset.Controls.Add(this.comboBoxResetHour1);
            this.groupBoxAutoReset.Controls.Add(this.checkBoxEnableReset1);
            this.groupBoxAutoReset.Controls.Add(this.label11);
            this.groupBoxAutoReset.Location = new System.Drawing.Point(136, 394);
            this.groupBoxAutoReset.Name = "groupBoxAutoReset";
            this.groupBoxAutoReset.Size = new System.Drawing.Size(122, 172);
            this.groupBoxAutoReset.TabIndex = 34;
            this.groupBoxAutoReset.TabStop = false;
            this.groupBoxAutoReset.Text = "Auto Reset Time";
            // 
            // comboBoxResetHour2
            // 
            this.comboBoxResetHour2.FormattingEnabled = true;
            this.comboBoxResetHour2.Location = new System.Drawing.Point(13, 135);
            this.comboBoxResetHour2.Name = "comboBoxResetHour2";
            this.comboBoxResetHour2.Size = new System.Drawing.Size(41, 20);
            this.comboBoxResetHour2.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 32;
            this.label9.Text = "：";
            // 
            // comboBoxResetMin2
            // 
            this.comboBoxResetMin2.FormattingEnabled = true;
            this.comboBoxResetMin2.Location = new System.Drawing.Point(73, 135);
            this.comboBoxResetMin2.Name = "comboBoxResetMin2";
            this.comboBoxResetMin2.Size = new System.Drawing.Size(41, 20);
            this.comboBoxResetMin2.TabIndex = 31;
            // 
            // checkBoxEnableReset2
            // 
            this.checkBoxEnableReset2.AutoSize = true;
            this.checkBoxEnableReset2.Location = new System.Drawing.Point(5, 102);
            this.checkBoxEnableReset2.Name = "checkBoxEnableReset2";
            this.checkBoxEnableReset2.Size = new System.Drawing.Size(105, 16);
            this.checkBoxEnableReset2.TabIndex = 29;
            this.checkBoxEnableReset2.Text = "RESET TIME #2";
            this.checkBoxEnableReset2.UseVisualStyleBackColor = true;
            this.checkBoxEnableReset2.CheckedChanged += new System.EventHandler(this.checkBoxEnableReset2_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 12);
            this.label10.TabIndex = 28;
            this.label10.Text = "Hour              Min";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "：";
            // 
            // comboBoxResetMin1
            // 
            this.comboBoxResetMin1.FormattingEnabled = true;
            this.comboBoxResetMin1.Location = new System.Drawing.Point(73, 59);
            this.comboBoxResetMin1.Name = "comboBoxResetMin1";
            this.comboBoxResetMin1.Size = new System.Drawing.Size(41, 20);
            this.comboBoxResetMin1.TabIndex = 26;
            // 
            // comboBoxResetHour1
            // 
            this.comboBoxResetHour1.FormattingEnabled = true;
            this.comboBoxResetHour1.Location = new System.Drawing.Point(13, 59);
            this.comboBoxResetHour1.Name = "comboBoxResetHour1";
            this.comboBoxResetHour1.Size = new System.Drawing.Size(41, 20);
            this.comboBoxResetHour1.TabIndex = 25;
            // 
            // checkBoxEnableReset1
            // 
            this.checkBoxEnableReset1.AutoSize = true;
            this.checkBoxEnableReset1.Location = new System.Drawing.Point(5, 23);
            this.checkBoxEnableReset1.Name = "checkBoxEnableReset1";
            this.checkBoxEnableReset1.Size = new System.Drawing.Size(105, 16);
            this.checkBoxEnableReset1.TabIndex = 24;
            this.checkBoxEnableReset1.Text = "RESET TIME #1";
            this.checkBoxEnableReset1.UseVisualStyleBackColor = true;
            this.checkBoxEnableReset1.CheckedChanged += new System.EventHandler(this.checkBoxEnableReset1_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "Hour              Min";
            // 
            // DGrid
            // 
            this.DGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGrid.Location = new System.Drawing.Point(369, 112);
            this.DGrid.Name = "DGrid";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGrid.RowTemplate.Height = 24;
            this.DGrid.Size = new System.Drawing.Size(539, 268);
            this.DGrid.TabIndex = 68;
            this.DGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGrid_CellClick);
            this.DGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGrid_CellContentClick);
            this.DGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGrid_CellDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(915, 22);
            this.statusStrip1.TabIndex = 69;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxLog.Controls.Add(this.listBox_log);
            this.groupBoxLog.Location = new System.Drawing.Point(742, 394);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(68, 172);
            this.groupBoxLog.TabIndex = 71;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Log";
            // 
            // listBox_log
            // 
            this.listBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_log.FormattingEnabled = true;
            this.listBox_log.HorizontalScrollbar = true;
            this.listBox_log.ItemHeight = 12;
            this.listBox_log.Location = new System.Drawing.Point(6, 18);
            this.listBox_log.Name = "listBox_log";
            this.listBox_log.Size = new System.Drawing.Size(56, 148);
            this.listBox_log.TabIndex = 71;
            // 
            // groupBoxFunction
            // 
            this.groupBoxFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxFunction.Controls.Add(this.buttonFunc4);
            this.groupBoxFunction.Controls.Add(this.buttonFunc3);
            this.groupBoxFunction.Controls.Add(this.buttonFunc2);
            this.groupBoxFunction.Controls.Add(this.buttonFunc1);
            this.groupBoxFunction.Location = new System.Drawing.Point(264, 395);
            this.groupBoxFunction.Name = "groupBoxFunction";
            this.groupBoxFunction.Size = new System.Drawing.Size(80, 171);
            this.groupBoxFunction.TabIndex = 72;
            this.groupBoxFunction.TabStop = false;
            this.groupBoxFunction.Text = "Function";
            // 
            // buttonFunc4
            // 
            this.buttonFunc4.Location = new System.Drawing.Point(6, 127);
            this.buttonFunc4.Name = "buttonFunc4";
            this.buttonFunc4.Size = new System.Drawing.Size(67, 28);
            this.buttonFunc4.TabIndex = 3;
            this.buttonFunc4.Text = "Function_4";
            this.buttonFunc4.UseVisualStyleBackColor = true;
            this.buttonFunc4.Click += new System.EventHandler(this.buttonFunc4_Click);
            // 
            // buttonFunc3
            // 
            this.buttonFunc3.Location = new System.Drawing.Point(6, 93);
            this.buttonFunc3.Name = "buttonFunc3";
            this.buttonFunc3.Size = new System.Drawing.Size(67, 28);
            this.buttonFunc3.TabIndex = 2;
            this.buttonFunc3.Text = "Function_3";
            this.buttonFunc3.UseVisualStyleBackColor = true;
            this.buttonFunc3.Click += new System.EventHandler(this.buttonFunc3_Click);
            // 
            // buttonFunc2
            // 
            this.buttonFunc2.Location = new System.Drawing.Point(6, 58);
            this.buttonFunc2.Name = "buttonFunc2";
            this.buttonFunc2.Size = new System.Drawing.Size(67, 28);
            this.buttonFunc2.TabIndex = 1;
            this.buttonFunc2.Text = "Function_2";
            this.buttonFunc2.UseVisualStyleBackColor = true;
            this.buttonFunc2.Click += new System.EventHandler(this.buttonFunc2_Click);
            // 
            // buttonFunc1
            // 
            this.buttonFunc1.Location = new System.Drawing.Point(6, 24);
            this.buttonFunc1.Name = "buttonFunc1";
            this.buttonFunc1.Size = new System.Drawing.Size(67, 28);
            this.buttonFunc1.TabIndex = 0;
            this.buttonFunc1.Text = "Function_1";
            this.buttonFunc1.UseVisualStyleBackColor = true;
            this.buttonFunc1.Click += new System.EventHandler(this.buttonFunc1_Click);
            // 
            // groupBoxSave
            // 
            this.groupBoxSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxSave.Controls.Add(this.buttonSaveSetting);
            this.groupBoxSave.Controls.Add(this.buttonDoneSetting);
            this.groupBoxSave.Location = new System.Drawing.Point(369, 513);
            this.groupBoxSave.Name = "groupBoxSave";
            this.groupBoxSave.Size = new System.Drawing.Size(160, 52);
            this.groupBoxSave.TabIndex = 73;
            this.groupBoxSave.TabStop = false;
            this.groupBoxSave.Text = "Saving";
            // 
            // buttonSaveSetting
            // 
            this.buttonSaveSetting.Location = new System.Drawing.Point(10, 17);
            this.buttonSaveSetting.Name = "buttonSaveSetting";
            this.buttonSaveSetting.Size = new System.Drawing.Size(68, 28);
            this.buttonSaveSetting.TabIndex = 77;
            this.buttonSaveSetting.Text = "SAVE";
            this.buttonSaveSetting.UseVisualStyleBackColor = true;
            this.buttonSaveSetting.Click += new System.EventHandler(this.buttonSaveSetting_Click);
            // 
            // buttonDoneSetting
            // 
            this.buttonDoneSetting.Location = new System.Drawing.Point(84, 17);
            this.buttonDoneSetting.Name = "buttonDoneSetting";
            this.buttonDoneSetting.Size = new System.Drawing.Size(65, 29);
            this.buttonDoneSetting.TabIndex = 76;
            this.buttonDoneSetting.Text = "DONE";
            this.buttonDoneSetting.UseVisualStyleBackColor = true;
            this.buttonDoneSetting.Click += new System.EventHandler(this.buttonDoneSetting_Click);
            // 
            // groupBoxManualReset
            // 
            this.groupBoxManualReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxManualReset.Controls.Add(this.btnRomoveResetTime);
            this.groupBoxManualReset.Controls.Add(this.listBox_ResetTime);
            this.groupBoxManualReset.Controls.Add(this.btnAddResetTime);
            this.groupBoxManualReset.Controls.Add(this.label5);
            this.groupBoxManualReset.Controls.Add(this.dateTimePickerManualReset);
            this.groupBoxManualReset.Controls.Add(this.comboBoxManualResetMin);
            this.groupBoxManualReset.Controls.Add(this.comboBoxManualResetHour);
            this.groupBoxManualReset.Controls.Add(this.label13);
            this.groupBoxManualReset.Controls.Add(this.label12);
            this.groupBoxManualReset.Location = new System.Drawing.Point(535, 393);
            this.groupBoxManualReset.Name = "groupBoxManualReset";
            this.groupBoxManualReset.Size = new System.Drawing.Size(222, 172);
            this.groupBoxManualReset.TabIndex = 35;
            this.groupBoxManualReset.TabStop = false;
            this.groupBoxManualReset.Text = "Manual Reset";
            // 
            // btnRomoveResetTime
            // 
            this.btnRomoveResetTime.Location = new System.Drawing.Point(8, 137);
            this.btnRomoveResetTime.Name = "btnRomoveResetTime";
            this.btnRomoveResetTime.Size = new System.Drawing.Size(84, 28);
            this.btnRomoveResetTime.TabIndex = 73;
            this.btnRomoveResetTime.Text = "DEL";
            this.btnRomoveResetTime.UseVisualStyleBackColor = true;
            this.btnRomoveResetTime.Click += new System.EventHandler(this.btnRomoveResetTime_Click);
            // 
            // listBox_ResetTime
            // 
            this.listBox_ResetTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_ResetTime.FormattingEnabled = true;
            this.listBox_ResetTime.HorizontalScrollbar = true;
            this.listBox_ResetTime.ItemHeight = 12;
            this.listBox_ResetTime.Location = new System.Drawing.Point(98, 19);
            this.listBox_ResetTime.Name = "listBox_ResetTime";
            this.listBox_ResetTime.Size = new System.Drawing.Size(118, 148);
            this.listBox_ResetTime.TabIndex = 72;
            // 
            // btnAddResetTime
            // 
            this.btnAddResetTime.Location = new System.Drawing.Point(9, 104);
            this.btnAddResetTime.Name = "btnAddResetTime";
            this.btnAddResetTime.Size = new System.Drawing.Size(83, 31);
            this.btnAddResetTime.TabIndex = 24;
            this.btnAddResetTime.Text = "ADD";
            this.btnAddResetTime.UseVisualStyleBackColor = true;
            this.btnAddResetTime.Click += new System.EventHandler(this.btnAddResetTime_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "Date";
            // 
            // dateTimePickerManualReset
            // 
            this.dateTimePickerManualReset.Location = new System.Drawing.Point(10, 35);
            this.dateTimePickerManualReset.Name = "dateTimePickerManualReset";
            this.dateTimePickerManualReset.Size = new System.Drawing.Size(82, 22);
            this.dateTimePickerManualReset.TabIndex = 34;
            // 
            // comboBoxManualResetMin
            // 
            this.comboBoxManualResetMin.FormattingEnabled = true;
            this.comboBoxManualResetMin.Location = new System.Drawing.Point(57, 78);
            this.comboBoxManualResetMin.Name = "comboBoxManualResetMin";
            this.comboBoxManualResetMin.Size = new System.Drawing.Size(35, 20);
            this.comboBoxManualResetMin.TabIndex = 26;
            // 
            // comboBoxManualResetHour
            // 
            this.comboBoxManualResetHour.FormattingEnabled = true;
            this.comboBoxManualResetHour.Location = new System.Drawing.Point(10, 78);
            this.comboBoxManualResetHour.Name = "comboBoxManualResetHour";
            this.comboBoxManualResetHour.Size = new System.Drawing.Size(35, 20);
            this.comboBoxManualResetHour.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 12);
            this.label13.TabIndex = 14;
            this.label13.Text = "Hour        Min";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "：";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(915, 595);
            this.Controls.Add(this.groupBoxManualReset);
            this.Controls.Add(this.groupBoxSave);
            this.Controls.Add(this.groupBoxFunction);
            this.Controls.Add(this.groupBoxLog);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.DGrid);
            this.Controls.Add(this.groupBoxAutoReset);
            this.Controls.Add(this.labelItemCount);
            this.Controls.Add(this.buttonChangeSetting);
            this.Controls.Add(this.buttonStartUpload);
            this.Controls.Add(this.groupBoxSetting);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxRate);
            this.Controls.Add(this.listBox_SelItem);
            this.Controls.Add(this.listBox_ShowItem);
            this.Controls.Add(this.groupBoxConnect);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxConnect.ResumeLayout(false);
            this.groupBoxConnect.PerformLayout();
            this.groupBoxRate.ResumeLayout(false);
            this.groupBoxRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxSetting.ResumeLayout(false);
            this.groupBoxAutoReset.ResumeLayout(false);
            this.groupBoxAutoReset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxFunction.ResumeLayout(false);
            this.groupBoxSave.ResumeLayout(false);
            this.groupBoxManualReset.ResumeLayout(false);
            this.groupBoxManualReset.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConnect;
        private System.Windows.Forms.ComboBox cmbServerName;
        private System.Windows.Forms.ListBox listBox_ShowItem;
        private System.Windows.Forms.ListBox listBox_SelItem;
        private System.Windows.Forms.Timer Clock_Timer;
        private System.Windows.Forms.GroupBox groupBoxRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtboxUploadRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtboxUpdateRate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxSetting;
        private System.Windows.Forms.Button buttonClearSetting;
        private System.Windows.Forms.Button buttonChangeSetting;
        private System.Windows.Forms.Button buttonStartUpload;
        private System.Windows.Forms.Button buttonBackSetting;
        private System.Windows.Forms.Label labelItemCount;
        private System.Windows.Forms.Button btnApplyRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxAutoReset;
        private System.Windows.Forms.CheckBox checkBoxEnableReset1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxResetMin1;
        private System.Windows.Forms.ComboBox comboBoxResetHour1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxResetMin2;
        private System.Windows.Forms.CheckBox checkBoxEnableReset2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxResetHour2;
        private System.Windows.Forms.Label label_localIP;
        private System.Windows.Forms.DataGridView DGrid;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.ListBox listBox_log;
        private System.Windows.Forms.Button buttonDelRow;
        private System.Windows.Forms.Button buttonChangeOrder;
        private System.Windows.Forms.Label label_ServerIP;
        private System.Windows.Forms.GroupBox groupBoxFunction;
        private System.Windows.Forms.Button buttonFunc4;
        private System.Windows.Forms.Button buttonFunc3;
        private System.Windows.Forms.Button buttonFunc2;
        private System.Windows.Forms.Button buttonFunc1;
        private System.Windows.Forms.GroupBox groupBoxSave;
        private System.Windows.Forms.Button buttonSaveSetting;
        private System.Windows.Forms.Button buttonDoneSetting;
        private System.Windows.Forms.GroupBox groupBoxManualReset;
        private System.Windows.Forms.DateTimePicker dateTimePickerManualReset;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxManualResetMin;
        private System.Windows.Forms.ComboBox comboBoxManualResetHour;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddResetTime;
        private System.Windows.Forms.ListBox listBox_ResetTime;
        private System.Windows.Forms.Button btnRomoveResetTime;
        private System.Windows.Forms.Label label_OpcFilterString;
        private System.Windows.Forms.Label label_ItemAddingMode;
    }
}

