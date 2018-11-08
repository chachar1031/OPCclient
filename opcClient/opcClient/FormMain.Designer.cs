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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBoxConnect = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnConnLocalServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbServerName = new System.Windows.Forms.ComboBox();
            this.listBox_ShowItem = new System.Windows.Forms.ListBox();
            this.listBox_SelItem = new System.Windows.Forms.ListBox();
            this.DGrid = new System.Windows.Forms.DataGridView();
            this.timerUpload = new System.Windows.Forms.Timer(this.components);
            this.groupBoxRate = new System.Windows.Forms.GroupBox();
            this.btnApplyRate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtboxUploadRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtboxUpdateRate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxWriteValue = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboWriteItem = new System.Windows.Forms.ComboBox();
            this.btnWriteValue = new System.Windows.Forms.Button();
            this.txtWriteValue = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxSetting = new System.Windows.Forms.GroupBox();
            this.buttonBackSetting = new System.Windows.Forms.Button();
            this.buttonDoneSetting = new System.Windows.Forms.Button();
            this.buttonSaveSetting = new System.Windows.Forms.Button();
            this.buttonClearSetting = new System.Windows.Forms.Button();
            this.buttonChangeSetting = new System.Windows.Forms.Button();
            this.buttonStartUpload = new System.Windows.Forms.Button();
            this.labelItemCount = new System.Windows.Forms.Label();
            this.groupBoxReset = new System.Windows.Forms.GroupBox();
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
            this.MachineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConnQuality = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBoxConnect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.groupBoxRate.SuspendLayout();
            this.groupBoxWriteValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxSetting.SuspendLayout();
            this.groupBoxReset.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConnect
            // 
            this.groupBoxConnect.Controls.Add(this.label12);
            this.groupBoxConnect.Controls.Add(this.btnConnLocalServer);
            this.groupBoxConnect.Controls.Add(this.label1);
            this.groupBoxConnect.Controls.Add(this.cmbServerName);
            this.groupBoxConnect.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConnect.Name = "groupBoxConnect";
            this.groupBoxConnect.Size = new System.Drawing.Size(345, 82);
            this.groupBoxConnect.TabIndex = 7;
            this.groupBoxConnect.TabStop = false;
            this.groupBoxConnect.Text = "Connection";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 12);
            this.label12.TabIndex = 8;
            this.label12.Text = "OPC Items Filter : *B02*_";
            // 
            // btnConnLocalServer
            // 
            this.btnConnLocalServer.Location = new System.Drawing.Point(241, 47);
            this.btnConnLocalServer.Name = "btnConnLocalServer";
            this.btnConnLocalServer.Size = new System.Drawing.Size(98, 29);
            this.btnConnLocalServer.TabIndex = 7;
            this.btnConnLocalServer.Text = "connect";
            this.btnConnLocalServer.UseVisualStyleBackColor = true;
            this.btnConnLocalServer.Click += new System.EventHandler(this.btnConnLocalServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "OPC Server：";
            // 
            // cmbServerName
            // 
            this.cmbServerName.FormattingEnabled = true;
            this.cmbServerName.Location = new System.Drawing.Point(84, 21);
            this.cmbServerName.Name = "cmbServerName";
            this.cmbServerName.Size = new System.Drawing.Size(254, 20);
            this.cmbServerName.TabIndex = 5;
            // 
            // listBox_ShowItem
            // 
            this.listBox_ShowItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_ShowItem.FormattingEnabled = true;
            this.listBox_ShowItem.ItemHeight = 12;
            this.listBox_ShowItem.Location = new System.Drawing.Point(12, 100);
            this.listBox_ShowItem.Name = "listBox_ShowItem";
            this.listBox_ShowItem.Size = new System.Drawing.Size(345, 280);
            this.listBox_ShowItem.TabIndex = 9;
            this.listBox_ShowItem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_ShowItem_MouseDoubleClick);
            // 
            // listBox_SelItem
            // 
            this.listBox_SelItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_SelItem.FormattingEnabled = true;
            this.listBox_SelItem.ItemHeight = 12;
            this.listBox_SelItem.Location = new System.Drawing.Point(12, 407);
            this.listBox_SelItem.Name = "listBox_SelItem";
            this.listBox_SelItem.Size = new System.Drawing.Size(47, 160);
            this.listBox_SelItem.TabIndex = 18;
            // 
            // DGrid
            // 
            this.DGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MachineID,
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3,
            this.ErrCode,
            this.Column5,
            this.ConnQuality});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGrid.Location = new System.Drawing.Point(369, 100);
            this.DGrid.Name = "DGrid";
            this.DGrid.RowTemplate.Height = 24;
            this.DGrid.Size = new System.Drawing.Size(669, 280);
            this.DGrid.TabIndex = 19;
            this.DGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGrid_CellClick);
            // 
            // timerUpload
            // 
            this.timerUpload.Tick += new System.EventHandler(this.timerUpload_Tick);
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
            this.groupBoxRate.Location = new System.Drawing.Point(214, 395);
            this.groupBoxRate.Name = "groupBoxRate";
            this.groupBoxRate.Size = new System.Drawing.Size(143, 172);
            this.groupBoxRate.TabIndex = 33;
            this.groupBoxRate.TabStop = false;
            this.groupBoxRate.Text = "Rate";
            // 
            // btnApplyRate
            // 
            this.btnApplyRate.Location = new System.Drawing.Point(10, 135);
            this.btnApplyRate.Name = "btnApplyRate";
            this.btnApplyRate.Size = new System.Drawing.Size(121, 28);
            this.btnApplyRate.TabIndex = 23;
            this.btnApplyRate.Text = "APPLY";
            this.btnApplyRate.UseVisualStyleBackColor = true;
            this.btnApplyRate.Click += new System.EventHandler(this.btnApplyRate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "sec";
            // 
            // txtboxUploadRate
            // 
            this.txtboxUploadRate.Location = new System.Drawing.Point(13, 95);
            this.txtboxUploadRate.Name = "txtboxUploadRate";
            this.txtboxUploadRate.Size = new System.Drawing.Size(102, 22);
            this.txtboxUploadRate.TabIndex = 19;
            this.txtboxUploadRate.Text = "1";
            this.txtboxUploadRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "ms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "Upload Rate：";
            // 
            // txtboxUpdateRate
            // 
            this.txtboxUpdateRate.Location = new System.Drawing.Point(13, 38);
            this.txtboxUpdateRate.Name = "txtboxUpdateRate";
            this.txtboxUpdateRate.Size = new System.Drawing.Size(102, 22);
            this.txtboxUpdateRate.TabIndex = 15;
            this.txtboxUpdateRate.Text = "250";
            this.txtboxUpdateRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "Update Rate：";
            // 
            // groupBoxWriteValue
            // 
            this.groupBoxWriteValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxWriteValue.Controls.Add(this.label6);
            this.groupBoxWriteValue.Controls.Add(this.label5);
            this.groupBoxWriteValue.Controls.Add(this.comboWriteItem);
            this.groupBoxWriteValue.Controls.Add(this.btnWriteValue);
            this.groupBoxWriteValue.Controls.Add(this.txtWriteValue);
            this.groupBoxWriteValue.Location = new System.Drawing.Point(65, 395);
            this.groupBoxWriteValue.Name = "groupBoxWriteValue";
            this.groupBoxWriteValue.Size = new System.Drawing.Size(143, 172);
            this.groupBoxWriteValue.TabIndex = 34;
            this.groupBoxWriteValue.TabStop = false;
            this.groupBoxWriteValue.Text = "Write ONE PLC Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "Value：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "Item：";
            // 
            // comboWriteItem
            // 
            this.comboWriteItem.FormattingEnabled = true;
            this.comboWriteItem.Location = new System.Drawing.Point(11, 39);
            this.comboWriteItem.Name = "comboWriteItem";
            this.comboWriteItem.Size = new System.Drawing.Size(121, 20);
            this.comboWriteItem.TabIndex = 20;
            // 
            // btnWriteValue
            // 
            this.btnWriteValue.Location = new System.Drawing.Point(11, 136);
            this.btnWriteValue.Name = "btnWriteValue";
            this.btnWriteValue.Size = new System.Drawing.Size(121, 28);
            this.btnWriteValue.TabIndex = 19;
            this.btnWriteValue.Text = "WRITE";
            this.btnWriteValue.UseVisualStyleBackColor = true;
            this.btnWriteValue.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // txtWriteValue
            // 
            this.txtWriteValue.Location = new System.Drawing.Point(11, 94);
            this.txtWriteValue.Name = "txtWriteValue";
            this.txtWriteValue.Size = new System.Drawing.Size(119, 22);
            this.txtWriteValue.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(369, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(669, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxSetting
            // 
            this.groupBoxSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxSetting.Controls.Add(this.buttonBackSetting);
            this.groupBoxSetting.Controls.Add(this.buttonDoneSetting);
            this.groupBoxSetting.Controls.Add(this.buttonSaveSetting);
            this.groupBoxSetting.Controls.Add(this.buttonClearSetting);
            this.groupBoxSetting.Location = new System.Drawing.Point(529, 395);
            this.groupBoxSetting.Name = "groupBoxSetting";
            this.groupBoxSetting.Size = new System.Drawing.Size(143, 172);
            this.groupBoxSetting.TabIndex = 34;
            this.groupBoxSetting.TabStop = false;
            this.groupBoxSetting.Text = "Setting";
            // 
            // buttonBackSetting
            // 
            this.buttonBackSetting.Location = new System.Drawing.Point(12, 29);
            this.buttonBackSetting.Name = "buttonBackSetting";
            this.buttonBackSetting.Size = new System.Drawing.Size(121, 28);
            this.buttonBackSetting.TabIndex = 70;
            this.buttonBackSetting.Text = "BACK";
            this.buttonBackSetting.UseVisualStyleBackColor = true;
            this.buttonBackSetting.Click += new System.EventHandler(this.buttonBackSetting_Click);
            // 
            // buttonDoneSetting
            // 
            this.buttonDoneSetting.Location = new System.Drawing.Point(11, 137);
            this.buttonDoneSetting.Name = "buttonDoneSetting";
            this.buttonDoneSetting.Size = new System.Drawing.Size(121, 29);
            this.buttonDoneSetting.TabIndex = 69;
            this.buttonDoneSetting.Text = "DONE";
            this.buttonDoneSetting.UseVisualStyleBackColor = true;
            this.buttonDoneSetting.Click += new System.EventHandler(this.buttonCancelSetting_Click);
            // 
            // buttonSaveSetting
            // 
            this.buttonSaveSetting.Location = new System.Drawing.Point(11, 101);
            this.buttonSaveSetting.Name = "buttonSaveSetting";
            this.buttonSaveSetting.Size = new System.Drawing.Size(121, 28);
            this.buttonSaveSetting.TabIndex = 68;
            this.buttonSaveSetting.Text = "SAVE";
            this.buttonSaveSetting.UseVisualStyleBackColor = true;
            this.buttonSaveSetting.Click += new System.EventHandler(this.buttonSaveSetting_Click);
            // 
            // buttonClearSetting
            // 
            this.buttonClearSetting.Location = new System.Drawing.Point(12, 66);
            this.buttonClearSetting.Name = "buttonClearSetting";
            this.buttonClearSetting.Size = new System.Drawing.Size(121, 28);
            this.buttonClearSetting.TabIndex = 66;
            this.buttonClearSetting.Text = "CLEAR";
            this.buttonClearSetting.UseVisualStyleBackColor = true;
            this.buttonClearSetting.Click += new System.EventHandler(this.buttonClearSetting_Click);
            // 
            // buttonChangeSetting
            // 
            this.buttonChangeSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangeSetting.Location = new System.Drawing.Point(834, 508);
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
            this.buttonStartUpload.Location = new System.Drawing.Point(944, 509);
            this.buttonStartUpload.Name = "buttonStartUpload";
            this.buttonStartUpload.Size = new System.Drawing.Size(94, 59);
            this.buttonStartUpload.TabIndex = 64;
            this.buttonStartUpload.Text = "START";
            this.buttonStartUpload.UseVisualStyleBackColor = true;
            this.buttonStartUpload.Click += new System.EventHandler(this.buttonStartUpload_Click);
            // 
            // labelItemCount
            // 
            this.labelItemCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelItemCount.AutoSize = true;
            this.labelItemCount.Location = new System.Drawing.Point(963, 395);
            this.labelItemCount.Name = "labelItemCount";
            this.labelItemCount.Size = new System.Drawing.Size(38, 12);
            this.labelItemCount.TabIndex = 67;
            this.labelItemCount.Text = "Item：";
            this.labelItemCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // groupBoxReset
            // 
            this.groupBoxReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxReset.Controls.Add(this.comboBoxResetHour2);
            this.groupBoxReset.Controls.Add(this.label9);
            this.groupBoxReset.Controls.Add(this.comboBoxResetMin2);
            this.groupBoxReset.Controls.Add(this.checkBoxEnableReset2);
            this.groupBoxReset.Controls.Add(this.label10);
            this.groupBoxReset.Controls.Add(this.label8);
            this.groupBoxReset.Controls.Add(this.comboBoxResetMin1);
            this.groupBoxReset.Controls.Add(this.comboBoxResetHour1);
            this.groupBoxReset.Controls.Add(this.checkBoxEnableReset1);
            this.groupBoxReset.Controls.Add(this.label11);
            this.groupBoxReset.Location = new System.Drawing.Point(369, 395);
            this.groupBoxReset.Name = "groupBoxReset";
            this.groupBoxReset.Size = new System.Drawing.Size(143, 172);
            this.groupBoxReset.TabIndex = 34;
            this.groupBoxReset.TabStop = false;
            this.groupBoxReset.Text = "Reset ALL PLC Value";
            // 
            // comboBoxResetHour2
            // 
            this.comboBoxResetHour2.FormattingEnabled = true;
            this.comboBoxResetHour2.Location = new System.Drawing.Point(26, 130);
            this.comboBoxResetHour2.Name = "comboBoxResetHour2";
            this.comboBoxResetHour2.Size = new System.Drawing.Size(45, 20);
            this.comboBoxResetHour2.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(73, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 32;
            this.label9.Text = "：";
            // 
            // comboBoxResetMin2
            // 
            this.comboBoxResetMin2.FormattingEnabled = true;
            this.comboBoxResetMin2.Location = new System.Drawing.Point(91, 130);
            this.comboBoxResetMin2.Name = "comboBoxResetMin2";
            this.comboBoxResetMin2.Size = new System.Drawing.Size(45, 20);
            this.comboBoxResetMin2.TabIndex = 31;
            // 
            // checkBoxEnableReset2
            // 
            this.checkBoxEnableReset2.AutoSize = true;
            this.checkBoxEnableReset2.Location = new System.Drawing.Point(7, 99);
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
            this.label10.Location = new System.Drawing.Point(27, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 12);
            this.label10.TabIndex = 28;
            this.label10.Text = "Hour              Min";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(73, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "：";
            // 
            // comboBoxResetMin1
            // 
            this.comboBoxResetMin1.FormattingEnabled = true;
            this.comboBoxResetMin1.Location = new System.Drawing.Point(91, 55);
            this.comboBoxResetMin1.Name = "comboBoxResetMin1";
            this.comboBoxResetMin1.Size = new System.Drawing.Size(45, 20);
            this.comboBoxResetMin1.TabIndex = 26;
            // 
            // comboBoxResetHour1
            // 
            this.comboBoxResetHour1.FormattingEnabled = true;
            this.comboBoxResetHour1.Location = new System.Drawing.Point(26, 55);
            this.comboBoxResetHour1.Name = "comboBoxResetHour1";
            this.comboBoxResetHour1.Size = new System.Drawing.Size(45, 20);
            this.comboBoxResetHour1.TabIndex = 25;
            // 
            // checkBoxEnableReset1
            // 
            this.checkBoxEnableReset1.AutoSize = true;
            this.checkBoxEnableReset1.Location = new System.Drawing.Point(7, 24);
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
            this.label11.Location = new System.Drawing.Point(27, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "Hour              Min";
            // 
            // MachineID
            // 
            this.MachineID.Frozen = true;
            this.MachineID.HeaderText = "0.機台ID";
            this.MachineID.Name = "MachineID";
            this.MachineID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MachineID.Width = 75;
            // 
            // Column4
            // 
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "1.(DMIP_1";
            this.Column4.Name = "Column4";
            this.Column4.Width = 65;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "2.DMIP_2";
            this.Column1.Name = "Column1";
            this.Column1.Width = 65;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "3.DMIP_3";
            this.Column2.Name = "Column2";
            this.Column2.Width = 65;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "4.DMIP_4 )";
            this.Column3.Name = "Column3";
            this.Column3.Width = 70;
            // 
            // ErrCode
            // 
            this.ErrCode.Frozen = true;
            this.ErrCode.HeaderText = "5.狀態";
            this.ErrCode.Name = "ErrCode";
            this.ErrCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ErrCode.Width = 65;
            // 
            // Column5
            // 
            this.Column5.Frozen = true;
            this.Column5.HeaderText = "6.報警";
            this.Column5.Name = "Column5";
            this.Column5.Width = 65;
            // 
            // ConnQuality
            // 
            this.ConnQuality.Frozen = true;
            this.ConnQuality.HeaderText = "<OPC連線狀態>";
            this.ConnQuality.Name = "ConnQuality";
            this.ConnQuality.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ConnQuality.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ConnQuality.Width = 120;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1043, 578);
            this.Controls.Add(this.groupBoxReset);
            this.Controls.Add(this.labelItemCount);
            this.Controls.Add(this.buttonChangeSetting);
            this.Controls.Add(this.buttonStartUpload);
            this.Controls.Add(this.groupBoxSetting);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxWriteValue);
            this.Controls.Add(this.groupBoxRate);
            this.Controls.Add(this.DGrid);
            this.Controls.Add(this.listBox_SelItem);
            this.Controls.Add(this.listBox_ShowItem);
            this.Controls.Add(this.groupBoxConnect);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A16 OPC Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxConnect.ResumeLayout(false);
            this.groupBoxConnect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.groupBoxRate.ResumeLayout(false);
            this.groupBoxRate.PerformLayout();
            this.groupBoxWriteValue.ResumeLayout(false);
            this.groupBoxWriteValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxSetting.ResumeLayout(false);
            this.groupBoxReset.ResumeLayout(false);
            this.groupBoxReset.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConnect;
        private System.Windows.Forms.ComboBox cmbServerName;
        private System.Windows.Forms.ListBox listBox_ShowItem;
        private System.Windows.Forms.ListBox listBox_SelItem;
        public System.Windows.Forms.DataGridView DGrid;
        private System.Windows.Forms.Timer timerUpload;
        private System.Windows.Forms.GroupBox groupBoxRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtboxUploadRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtboxUpdateRate;
        private System.Windows.Forms.GroupBox groupBoxWriteValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboWriteItem;
        private System.Windows.Forms.Button btnWriteValue;
        private System.Windows.Forms.TextBox txtWriteValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxSetting;
        private System.Windows.Forms.Button buttonDoneSetting;
        private System.Windows.Forms.Button buttonSaveSetting;
        private System.Windows.Forms.Button buttonClearSetting;
        private System.Windows.Forms.Button buttonChangeSetting;
        private System.Windows.Forms.Button buttonStartUpload;
        private System.Windows.Forms.Button buttonBackSetting;
        private System.Windows.Forms.Label labelItemCount;
        private System.Windows.Forms.Button btnApplyRate;
        private System.Windows.Forms.Button btnConnLocalServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxReset;
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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewButtonColumn ConnQuality;
    }
}

