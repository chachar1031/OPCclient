
#define A16_2F_OPC_client //A16 2F設備數據採集
//#define E03_INJ_OPC_client //E03 成型機數據採集

//#define SendDebugMsg //輸出debug 訊息, 於Output window
//#define DummyUpload //假上傳到數據庫(Oracle or SQL server)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Collections;
using OPCAutomation;
using System.IO;//for file I/O
using System.Data.SqlClient;//for SQL server
using System.Net.NetworkInformation;//for ping function
using System.Net.Sockets;//for AddressFamily
//using System.Net;

#if (E03_INJ_OPC_client)
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
#endif

namespace opcClient
{
    public partial class FormMain : Form
    {

        public struct typeItem
        {
            public string ItemName;
            //public MyOPCType opc_type;
            public object Value;
            public bool Writeable;
            public string Descrip;
            public string Timestamps;
            public string Quality;

            public int itmHandleClient;
            public int itmHandleServer;
        }
        typeItem[] myItemArray=new typeItem[500];//max item number

        /*重要參數設置 *************************************/
#if (A16_2F_OPC_client)
        string FormTitle = "A16 2F OPC Client";//Form標題
        string SoftVersion = "v19.0114m";//軟件版本, 防止亂套設定檔(tmp.tmp)
        string SoftVersion = "v19.0122";//軟件版本, 防止亂套設定檔(tmp.tmp)
        //int ItemsPerRow = 6;//Grid中, 每行要新增(選取)的item數量(不含"機台ID"及"OPC連線狀態"兩個欄位), 用來自動計算 換行&各item在grid中位置
        string[] strGridColumnHeaders = { "機台ID", "(DMIP_1", "DMIP_2", "DMIP_3", "DMIP_4)", "狀態", "報警代碼", "投入數", "OK數", "NG數" };//數量為ItemsPerRow + 1
        string strServerIP = "10.194.168.179"; //上傳server IP
        int intServerPort = 1433;//預設值.//上傳server port
#endif

#if (E03_INJ_OPC_client)
        string FormTitle = "E03 INJ OPC Client";//Form標題
        string SoftVersion = "v18.1127";//軟件版本, 防止亂套設定檔(tmp.tmp)
        //int ItemsPerRow = 10;//Grid中, 每行要新增(選取)的item數量(不含"機台ID"及"OPC連線狀態"兩個欄位), 用來自動計算 換行&各item在grid中位置
        string[] strGridColumnHeaders = { "機台ID", "產量", "狀態" };//數量為ItemsPerRow + 1
        string strServerIP = "10.200.145.51";//上傳server IP
        int intServerPort = 1526;//預設值.//上傳server port
#endif
        /***************************************************/
        int ItemsPerRow = 0;//Grid中, 每行要新增(選取)的item數量, 其值改為從標題欄位數量自動計算(strGridColumnHeaders.Length-1),不含"機台ID"欄位
        int UploadTimerCount = 0;//Timer每次加1, Clock時鐘功能
        int UploadTimerCountTarget = 0;//UploadTimerCount累加到此值後,觸發upload功能算何時要Upload


        //int MaxOpcItem=100;//
        int OpcItemCount=0;//OPC item 數量,  另用於ClientHandle計算.
        bool EnableSetting_f = false;
        bool StartDeleteRow_f = false;//進入刪除整列狀態
        bool StartChangeOrder_f = false;//進入列手動排序狀態

        #region 私有变量
            
            //4個功能按鈕
            const int FuncBTN_1 = 1;//功能按鈕1
            const int FuncBTN_2 = 2;//功能按鈕2
            const int FuncBTN_3 = 3;//功能按鈕3
            const int FuncBTN_4 = 4;//功能按鈕4
            
            //各種功能
            const int FuncFINISH = 0;//finish功能
            const int FuncCONFIRM_DELETE = 11;//Confirm Delete功能

            const int FuncMOVE_UP = 21;//move up, 上移功能
            const int FuncMOVE_DOWN = 22;//move down, 下移功能


        #endregion

        public FormMain()
        {
            InitializeComponent();
        }

        
        #region 私有变量
            OPCServer KepServer;
            OPCGroups KepGroups;
            OPCGroup KepGroup;
            OPCItems KepItems;

            string strHostName = "";

        #endregion


        /// <summary>
        /// OPC服务器
        /// 开始抓取OPC数据
        /// </summary>

        private void SendMsg(string m)
        {
#if (SendDebugMsg)
            //LogHelper.WriteLog(m);
            System.Diagnostics.Debug.WriteLine(m);
#endif
        }


        /// <summary>
        /// 创建组
        /// </summary>
        private void CreateGroup()
        {
            try
            {
                KepGroups = KepServer.OPCGroups;
                KepGroup = KepGroups.Add("OpcGroup");
                SetGroupProperty();
                KepGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(KepGroup_DataChange);
                //KepGroup.AsyncWriteComplete += new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(KepGroup_AsyncWriteComplete);

                KepItems = KepGroup.OPCItems;
                //AddOpcItem();
            }
            catch (Exception err)
            {
                SendMsg("枚举本地OPC创建组出现错误：" + err.Message);
            }
        }


        /// <summary>
        /// 设置组属性, 初始值用.
        /// </summary>
        private void SetGroupProperty()
        {
            KepServer.OPCGroups.DefaultGroupIsActive = true;
            KepServer.OPCGroups.DefaultGroupDeadband = 0;
            KepGroup.UpdateRate = 300;
            KepGroup.IsActive = true;
            KepGroup.IsSubscribed = true;
        }

        /// <summary>
        /// 设置组属性, 變更用.
        /// </summary>
        private void ChangeGroupProperty()
        {
            KepServer.OPCGroups.DefaultGroupIsActive = true;
            KepServer.OPCGroups.DefaultGroupDeadband = 0;
            KepGroup.UpdateRate = Convert.ToInt32(txtboxUpdateRate.Text);
            KepGroup.IsActive = true;
            KepGroup.IsSubscribed = true;
        }


        //private void AddOpcItem()
        //{
        //    //KepItems.AddItem("a1.22.1", 1);
        //    //KepItems.AddItem("a2.22.2", 2);
        //    //KepItems.AddItem("a3.22.3", 3);
        //    KepItems.AddItem("Channel_Kenny.OMRON_CP1H.DM00", 1);
        //    KepItems.AddItem("Channel_Kenny.OMRON_CP1H.DM10", 2);
        //    KepItems.AddItem("Channel_Kenny.OMRON_CP1H.DM20", 3);
            
        //}
        private void AddOneOpcItem(int _itemNumber, string _ItemName, int _ClientHandle)
        {
            //KepItems.AddItem("a1.22.1", 1);
            //KepItems.AddItem("a2.22.2", 2);
            //KepItems.AddItem("a3.22.3", 3);

            OPCItem KepITM;
            KepITM=KepItems.AddItem(_ItemName, _ClientHandle);
            //KepItems.AddItem("Channel_Kenny.OMRON_CP1H.DM10", 2);
            //KepItems.AddItem("Channel_Kenny.OMRON_CP1H.DM20", 3);

            //KepItem = KepItems.AddItem(listBox_ShowItem.SelectedItem.ToString(), itmHandleClient);

            myItemArray[_itemNumber - 1].ItemName = _ItemName;
            myItemArray[_itemNumber - 1].itmHandleClient = _ClientHandle;
            myItemArray[_itemNumber - 1].itmHandleServer = KepITM.ServerHandle;

        }

        /// <summary>
        /// 每当项数据有变化时执行的事件
        /// </summary>
        /// <param name="TransactionID">处理ID</param>
        /// <param name="NumItems">项个数</param>
        /// <param name="ClientHandles">项客户端句柄</param>
        /// <param name="ItemValues">TAG值</param>
        /// <param name="Qualities">品质</param>
        /// <param name="TimeStamps">时间戳</param>
        private void KepGroup_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {

            SendMsg("ClientHandles-Values-Qualities-TimeStamps");

            for (int i = 1; i <= NumItems; i++)
            {
                string temp = string.Concat(ClientHandles.GetValue(i), "-", ItemValues.GetValue(i), "-", Qualities.GetValue(i), "-", TimeStamps.GetValue(i));
                SendMsg(temp);

                int ClientHDL = (int)ClientHandles.GetValue(i);//client Handle = OpcItemCount, item 個數
                   
                DGrid.Rows[gridRow(ClientHDL)].Cells[gridCell(ClientHDL)].Value = ItemValues.GetValue(i);


                /*OPC連線狀態(如有需要)*/
                if (DGrid.Columns[ItemsPerRow + 1].HeaderText == "<OPC連線狀態>")
                {
                    //DGrid.Rows[gridRow(ClientHDL)].Cells[ItemsPerRow + 1].Value = OPCquality(Qualities.GetValue(i));
                    //DGrid.Rows[gridRow(ClientHDL)].Cells[ItemsPerRow + 1].Value = OPCquality(Convert.ToInt16(Qualities.GetValue(i)));
                    DGrid.Rows[gridRow(ClientHDL)].Cells[ItemsPerRow + 1].Value = Qualities.GetValue(i);
                        
                    if ((int)Qualities.GetValue(i) < 192)
                    { DGrid.Rows[gridRow(ClientHDL)].Cells[ItemsPerRow + 1].Style.ForeColor = Color.Red; }//小於192為異常,紅字顯示
                    else
                    { DGrid.Rows[gridRow(ClientHDL)].Cells[ItemsPerRow + 1].Style.ForeColor = Color.Black; }//192以上為正常, 黑色字體
                }

            }

            SendMsg("=========================");

        }


        //ClientHandle(opc item count)於grid中的位置:
        //           (Cell_0)   (Cell_1)  (Cell_2)   (Cell_3)  (Cell_4)  (Cell_5)   (Cell_6)
        // (Row_0)      ID         IP1       IP2       IP3       IP4      State      Error
        // (Row_1)    Manual        1         2         3         4         5          6
        // (Row_2)    Manual        7         8         9        10        11         12
        // (Row_3)    Manual       13        14        15        16        17         18
        // (Row_4)    Manual       19        20        21        22        23         24


        /*計算grid row 值*/
        int gridRow(int count)
        {
            return (count - 1) / ItemsPerRow;
        }

        /*計算grid cell (column)值*/
        int gridCell(int count)
        {
            return ((count - 1) % ItemsPerRow) + 1;
        }
        


        private void Form1_Load(object sender, EventArgs e)
        {
            ItemsPerRow = strGridColumnHeaders.Length - 1;//Grid中, 每行要新增(選取)的item數量, 其值改為從標題欄位數量自動計算(strGridColumnHeaders.Length-1),不含"機台ID"欄位

            Outlook_setting();//外觀設定

            EnableSetting(false);//設定功能預設禁用

            /*Add ResetHour combo items*/
            for (int i = 0; i <= 23; i++)
            {
                comboBoxResetHour1.Items.Add((string.Concat(i)).PadLeft(2, '0')); //若不足2位,前面補0
                comboBoxResetHour2.Items.Add((string.Concat(i)).PadLeft(2,'0'));//若不足2位,前面補0
            }

            /*Add ResetMin combo items*/
            for (int i = 0; i <= 59; i++)
            {
                comboBoxResetMin1.Items.Add((string.Concat(i)).PadLeft(2, '0')); //若不足2位,前面補0
                comboBoxResetMin2.Items.Add((string.Concat(i)).PadLeft(2, '0')); //若不足2位,前面補0
            }

            ////获取本地计算机IP,计算机名称
            label_localIP.Text =  "Local IP  ：" + GetLocalIP() ;
            label_ServerIP.Text = "Server IP ：" + strServerIP;

            KepServer = new OPCServer();

            if (!GetLocalServer())//        /// 枚举本地OPC服务器
                return;
            
            if (!ConnectOPCserver())
            {
                MessageBox.Show("OPC server 連接失敗!");
                LOG("OPC server 連接失敗!");
                return;
            }

            RecurBrowse(KepServer.CreateBrowser());//search and show OPC items in ListBox


            CreateGroup();
            //AddOpcItem();

            if (!Load_setting())//載入設定檔
            {
                MessageBox.Show("預存之設定檔有問題，請移除並重新設置!"); 
                return;
            }
            

            ChangeGroupProperty();//變更屬性(採集頻率)


#if(DummyUpload)
            toolStripStatusLabel1.Text = "Dummy Upload";
#endif


        }

        private void Outlook_setting()
        {

            this.Text = FormTitle + "__" + SoftVersion;//表單標題+版本別

            /* grid setting  *******************************************************/
            DGrid.ColumnCount = ItemsPerRow + 1;//設置Grid總欄數

            //在grid最後,添加"<OPC連線狀態>一欄, 為textbox樣式
            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn.Name = "<OPC連線狀態>";
            //DGrid.Columns.Add(btn);

            DataGridViewTextBoxColumn tbox = new DataGridViewTextBoxColumn();
            tbox.Name = "<OPC連線狀態>";
            tbox.DefaultCellStyle.BackColor = Color.LightGray;
            tbox.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tbox.SortMode=DataGridViewColumnSortMode.NotSortable;//禁止點擊header排序
            DGrid.Columns.Add(tbox);


            //設置各欄標題
            for (int i = 0; i < DGrid.ColumnCount-1; i++)
            {
                DGrid.Columns[i].Name = i + "." + strGridColumnHeaders[i]; //設置各欄標題
                DGrid.Columns[i].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleRight ;//內容靠右對齊
                DGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;//禁止點擊header排序
            }

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;//欄寛自動調整
            //DGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //DGrid.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//列標題靠左對齊
            DGrid.RowHeadersWidth = 60;//標題欄寛度設定.     

            groupBoxSetting.Width = 270;

            groupBoxLog.Width = 430;
            groupBoxLog.Location = groupBoxSetting.Location;

            groupBoxFunction.Width = 135;
            //groupBoxFunction.Location = groupBoxSetting.Location;



            //自動計算grid及windows寛度
            //int TotalColWidth=0;//所有column寛度總合
            //for (int i = 0; i < DGrid.ColumnCount; i++)
            //{
            //    TotalColWidth=TotalColWidth+DGrid.Columns[i].Width;
            //}
            //if (TotalColWidth != 0)
            //{
                //DGrid.Width = TotalColWidth + 80;
                pictureBox1.Width = DGrid.Width;
                //this.Width = DGrid.Width + 390;
            //}
           
            
            
            /* *********************************************************************/



        }
        #region 方法
        /// <summary>
        /// 枚举本地OPC服务器
        /// </summary>
        private bool GetLocalServer()
        {
            ////获取本地计算机IP,计算机名称
            //IPHostEntry IPHost = Dns.Resolve(Environment.MachineName);

            //if (IPHost.AddressList.Length > 0)
            //{
            //    strHostIP = IPHost.AddressList[0].ToString();
            //}
            //else
            //{
            //    return;
            //}

            ////通过IP来获取计算机名称，可用在局域网内
            //IPHostEntry ipHostEntry = Dns.GetHostByAddress(strHostIP);
            //strHostName = ipHostEntry.HostName.ToString();

            string hostname = Dns.GetHostName();


            //获取本地计算机上的OPCServerName
            try
            {
                KepServer = new OPCServer();
                object serverList = KepServer.GetOPCServers(strHostName);

                foreach (string turn in (Array)serverList)
                {
                    cmbServerName.Items.Add(turn);
                }

                cmbServerName.SelectedIndex = 0;
                btnConnLocalServer.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("枚举本地OPC服务器出错：" + err.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LOG("枚举本地OPC服务器出错：" + err.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 列出OPC服务器中所有节点
        /// </summary>
        /// <param name="oPCBrowser"></param>
        private void RecurBrowse(OPCBrowser oPCBrowser)
        {
            listBox_ShowItem.Items.Clear();

            //展开分支
            oPCBrowser.ShowBranches();
            //展开叶子
            oPCBrowser.ShowLeafs(true);
            foreach (object turn in oPCBrowser)
            {

                if (turn.ToString().Contains("*B02*_"))//篩選指定的Item.(Item名稱需包含"*B02*_" 字串)
                {
                    //listBox_ShowItem.Items.Add(turn.ToString());
                    listBox_ShowItem.Items.Insert(0, turn.ToString());
                }

            }
        }
        #endregion

        private void btnConnLocalServer_Click(object sender, EventArgs e)
        {

            //try
            //{
                //KepServer = new OPCServer();
                //string hostname = Dns.GetHostName();

                //KepServer.Connect("10.200.168.219", "KEPware.KEPServerEx.V4");
                KepServer.Connect("KEPware.KEPServerEx.V4", "localhost");

                //判断连接状态
                if (KepServer.ServerState == (int)OPCServerState.OPCRunning)
                {
                    SendMsg("已连接到-" + KepServer.ServerName);
                }
                else
                {
                    SendMsg("状态：" + KepServer.ServerState.ToString());
                    return;
                }

                RecurBrowse(KepServer.CreateBrowser());

                //KepGroups = KepServer.OPCGroups;

                //Task.Factory.StartNew(CreateGroup);
                CreateGroup();
                //AddOpcItem();

                //this.GatherData = true;

            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }


        private bool ConnectOPCserver()
        {
            try
            {
                //KepServer = new OPCServer();
                //string hostname = Dns.GetHostName();

                //KepServer.Connect("10.200.168.219", "KEPware.KEPServerEx.V4");
                KepServer.Connect("KEPware.KEPServerEx.V4", "localhost");
            }
            catch (Exception e)
            {
                throw e;
            }


            //判断连接状态
            if (KepServer.ServerState == (int)OPCServerState.OPCRunning)
            { 
                LOG("已連接到" + KepServer.ServerName);
                SendMsg("已連接到" + KepServer.ServerName);
            }
            else
            {
                SendMsg("狀態：" + KepServer.ServerState.ToString());
                return false;
            }

            return true;
        
        }

        private void listBox_ShowItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listBox_ShowItem.SelectedItem != null)
            {
                /*計算此Item預計要插入Grid的位置(Row),是否己先填好ID */
                if (DGrid.Rows[gridRow(OpcItemCount + 1)].Cells[0].Value == null || string.Concat(DGrid.Rows[gridRow(OpcItemCount + 1)].Cells[0].Value) == "")
                {
                    MessageBox.Show("ID欄位無資料,請先填入");
                }
                else
                {
                    if (gridCell(OpcItemCount + 1)==1)//如果要新增的item是新的一筆資料的第一個item(column[1}位置), 則從grid 複製ID到listbox中
                    {
                        listBox_SelItem.Items.Add(string.Concat(DGrid.Rows[gridRow(OpcItemCount + 1)].Cells[0].Value));//儲存選取項目(item)
                    }
                    AddOpcItemProcess(listBox_ShowItem.SelectedItem.ToString());
                    listBox_SelItem.Items.Add(listBox_ShowItem.SelectedIndex);//儲存選取項目(item)

                }
            }
        }

        private void AddOpcItemProcess(string itemName)
        {
            OpcItemCount = OpcItemCount + 1;//opc item 數量

            //DGrid.Rows[(OpcItemCount - 1) / 6].Cells[((OpcItemCount - 1) % 6) + 1].Selected = false;//取消現有儲存格的選取(反白).
            //DGrid.Rows[gridRow(OpcItemCount)].Cells[gridCell(OpcItemCount)].Selected = false;//現有儲存格的選取(反白)取消.

            if (OpcItemCount % ItemsPerRow == 1)//每新增N個opcItem 後, grid新增一行
            {
                if ((OpcItemCount / ItemsPerRow) >= (DGrid.RowCount - 1))
                {
                    DGrid.Rows.Add(1);
                    for (int i = 0; i < DGrid.RowCount; i++)
                    {
                        DGrid.Rows[i].HeaderCell.Value = string.Concat(i + 1);//列標題
                    }
                }
            }
            
            //Data_Array[0].NameForOPC = listBox_ShowItem.SelectedItem.ToString();
            ////Data_Array[0].Value = 0;
            ////Data_Array[0].opc_type = MyOPCType._byte;
            //Data_Array[0].itmHandleClient = OpcItemCount;
            ////Data_Array[0].Writeable = false;

            AddOneOpcItem(OpcItemCount, itemName, OpcItemCount);


            //comboWriteItem.Items.Add(itemName);

            labelItemCount.Text = "Item： " + OpcItemCount;
 
            int NextItemCount = OpcItemCount + 1;

            /*計算下一個Item顯示位置(反白選取),及判斷是否要新增一行********************/
            if (gridRow(NextItemCount) > DGrid.RowCount-1)
            {
                DGrid.Rows.Add(1);//新增一行
                for (int i = 0; i < DGrid.RowCount; i++)
                {
                    DGrid.Rows[i].HeaderCell.Value = string.Concat(i + 1);//列標題
                }
             }

            DGrid.ClearSelection();//取消選取
            DGrid.Rows[gridRow(NextItemCount)].Cells[gridCell(NextItemCount)].Selected = true;//下一儲存格的選取(反白)

            /***************************************************************************/

            SendMsg("NextItemCount:" + NextItemCount + ", gridRow:" + gridRow(NextItemCount) + ", gridCell:" + gridCell(NextItemCount));

        }

        /*获取本地计算机IP,计算机名称*/
        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取本机IP出错:" + ex.Message);
                return "";
            }
        }

        private void buttonStartUpload_Click(object sender, EventArgs e)
        {
            if (buttonStartUpload.Text == "START")
            {
                if (!CheckGridData()) //*檢查grid內容是否正確*/
                    return;

                buttonStartUpload.Text = "STOP";
                BackColor = Color.LimeGreen;
                timerUpload.Interval = 1000;//Clock功能,固定每秒累加一次, 儘量不動
                UploadTimerCountTarget = int.Parse(txtboxUploadRate.Text);//計算每count幾次(秒),觸發上傳一次

                timerUpload.Start(); //Start Upload timer

                LOG("Uploading START...");
                buttonChangeSetting.Enabled = false;//禁止變更設定
            }
            else
            {
                buttonStartUpload.Text = "START";
                BackColor = SystemColors.ActiveCaption;
                timerUpload.Stop();

                LOG("Uploading STOP.");
                buttonChangeSetting.Enabled = true;//允許變更設定
            }

        }

#if (A16_2F_OPC_client)
        /*Upload data to SQL server*/
        public void UploadToSQL()
        {
            /* make SQL server connect String;*/
            SqlConnectionStringBuilder Builder = new SqlConnectionStringBuilder();
            //string strServerIP = "10.194.169.11";
            //string strServerIP = "10.194.168.179";

            Builder.DataSource = strServerIP;       //SQL Server的IP位址,若預設port不同,可以在ip後面用逗號再加port號
            Builder.InitialCatalog = "AutoJianKongA16";      //SQL Server的資料庫名稱
            Builder.UserID = "MonitorA16";                             //SQL Server的連線帳號
            Builder.Password = "MonitorA16&Auto";
            string SQLConnString = Builder.ConnectionString;


            System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(SQLConnString);
            try
            {
                sqlConnection1.Open();
            }
            catch (Exception err)
            {
                //MessageBox.Show("SQL server 連接出錯：" + err.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LOG("SQL server 連接出錯：" + err.Message);
                return;
            }


            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;


            /* Clear table, 清空table資料*/
            //cmd.CommandText = "DELETE FROM MonitorMachineTabel";//clear whoe Table data
            //cmd.Connection = sqlConnection1;+
            //cmd.ExecuteNonQuery();


            //上傳grid to SQL server 
            //改為update方式, 不刪除/新增動作, Kenny, 2018-7-31
            //機台離線時,只更新連線狀態及時間欄位, 2018-11-08

            //for (int i = 0; i < DGrid.RowCount - 1; i++)
            //for (int i = 0; i < listBox_SelItem.Items.Count / ItemsPerRow; i++)//應有資料的列
            for (int i = 0; i < OpcItemCount / ItemsPerRow; i++)

            {
                string ID = string.Concat(DGrid.Rows[i].Cells[0].Value);//機台ID
                //string ID = "1101";/*Debug測試用*/
                //int ConnState = OPCquality((int)DGrid.Rows[i].Cells[7].Value);//opc連線狀態 0:NG  1:OK
                int ConnState = OPCquality(Convert.ToInt32(DGrid.Rows[i].Cells[ItemsPerRow+1].Value));//opc連線狀態 0:NG  1:OK
                string myTime = DateTime.Now.ToString("yyyy-MM-dd,HH:mm:ss");//系統時間

                if (ConnState!=0) //OPC正常連線狀態
                {
                    string DMIP = string.Concat(DGrid.Rows[i].Cells[1].Value, ".", DGrid.Rows[i].Cells[2].Value, ".", DGrid.Rows[i].Cells[3].Value, ".", DGrid.Rows[i].Cells[4].Value);
                    //int STATE = (int)DGrid.Rows[i].Cells[5].Value;
                    //int ERR = (int)DGrid.Rows[i].Cells[6].Value;
                    uint STATE = Convert.ToUInt32(DGrid.Rows[i].Cells[5].Value);//
                    uint ERR = Convert.ToUInt32(DGrid.Rows[i].Cells[6].Value);//報警狀態位數擴充(Word->DWORD)，變數Type對應(int->uint), 32位
                    uint InputCnt = Convert.ToUInt32(DGrid.Rows[i].Cells[7].Value);//投入數量
                    uint OKCnt = Convert.ToUInt32(DGrid.Rows[i].Cells[8].Value);//OK數量
                    uint NGCnt = Convert.ToUInt32(DGrid.Rows[i].Cells[9].Value);//NG數量

                    //cmd.CommandText = MakeUpdateString(ID, DMIP, STATE, ERR, ConnState, myTime);
                    cmd.CommandText = MakeUpdateString(ID, DMIP, STATE, ERR, InputCnt, OKCnt, NGCnt, ConnState, myTime);
                }
                else//OPC離線狀態(item欄位可能為空)
                {
                    cmd.CommandText = MakeUpdateStringOFFLine(ID, ConnState, myTime); //只更新狀態、時間
                }

                cmd.Connection = sqlConnection1;
#if(!DummyUpload)
                cmd.ExecuteNonQuery();
#endif
            }

            sqlConnection1.Close();
        
        }

#endif


#if (E03_INJ_OPC_client)
        /*Upload  data to Oracle server*/
        public void UploadToOracle()
        {

            //Oracle database connect setting
            string strDataSource = MakeOracleConnString(strServerIP, intServerPort.ToString(), "PS4");// IP,Port,S_ID for Oracle server
            string strUserId = "PS4ZDH";
            string strPassword = "PS4ZDH";

            string orcConString = "Data Source=" + strDataSource + ";User Id=" + strUserId + ";Password=" + strPassword + ";";
            OracleConnection orcCon = new OracleConnection(orcConString);

            try
            {
                orcCon.Open();
            }
            catch (OracleException orcEx)
            {
                //MessageBox.Show("Oracle server 連接出錯：" + orcEx.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LOG("Oracle server 連接出錯：" + orcEx.Message);
                return;
            }

            /* Clear table, 清空Oracle table資料*/
            string clearString = "DELETE FROM INJ_TRANKING_WARNING_T";//clear whole Table data
            OracleCommand CLRorcCMD = new OracleCommand(clearString, orcCon);
#if(!DummyUpload)
            CLRorcCMD.ExecuteNonQuery();
#endif

            /* 上傳grid data to Oracle server */ 
            //for (int i = 0; i < DGrid.RowCount - 1; i++)
            //for (int i = 0; i < listBox_SelItem.Items.Count / ItemsPerRow; i++)//應有資料的列
            for (int i = 0; i < OpcItemCount / ItemsPerRow; i++)//應有資料的列
            {
                if (string.Concat(DGrid.Rows[i].Cells[0].Value)!=null) //確認第一欄(ID)不為空
                {
                    string ID = string.Concat(DGrid.Rows[i].Cells[0].Value);
                    int ConnState = OPCquality(Convert.ToInt32(DGrid.Rows[i].Cells[ItemsPerRow + 1].Value));//opc連線狀態 0:NG  1:OK
                    //string myTime = DateTime.Now.ToString("yyyy-MM-dd,HH:mm:ss");//系統時間

                    if (ConnState != 0) //OPC正常連線狀態
                    {
                        //int AMOUNT = (int)DGrid.Rows[i].Cells[1].Value;
                        //int STATE = (int)DGrid.Rows[i].Cells[2].Value;
                        uint AMOUNT = Convert.ToUInt32(DGrid.Rows[i].Cells[1].Value);
                        uint STATE = Convert.ToUInt32(DGrid.Rows[i].Cells[2].Value);

                        //cmd.CommandText = MakeUpdateString(ID, DMIP, STATE, ERR, myTime);//UPDATE 方式
                        string sqlString = MakeInsertString(ID, STATE, AMOUNT);//INSERT方式

                        OracleCommand orcCMD = new OracleCommand(sqlString, orcCon);
#if(!DummyUpload)
                        orcCMD.ExecuteNonQuery();
#endif
                    }
                    
                }
            }

            orcCon.Close();
 
        }

#endif

        public string MakeOracleConnString(string host, string port, string servicename)
        {
            return String.Format(
              "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
              "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));",
              host,
              port,
              servicename);
        }

        public string MakeInsertString(string _ip, uint _state, uint _amount)
        {
            //string strSQL = "INSERT INTO MonitorMachineTabel (IP,State,ErrCode) VALUES (" + "'" + _ip + "'" + ',' + _state + "," + _err + ")";
            //return strSQL;

            return string.Concat("INSERT INTO INJ_TRANKING_WARNING_T (INJ_ID,STATE,AMOUNT) VALUES (" + "'" + _ip + "'" + ',' + _state + "," + _amount + ")");
        }

        //public string MakeUpdateString(string _id, string _dmip, int _state, int _err, int _connState, string _time)
        //public string MakeUpdateString(string _id, string _dmip, uint _state, uint _err, int _connState, string _time)
        public string MakeUpdateString(string _id, string _dmip, uint _state, uint _err, uint _input, uint _ok, uint _ng, int _connState, string _time)
        {
            //string strSQL = "UPDATE MonitorMachineTabel SET DMIP='111111',State='3',ErrCode='122' WHERE MachineID='1901'";
            //string strSQL = "UPDATE MonitorMachineTabel SET DMIP='" + _dmip + "',State='" + _state + "',ErrCode='" + _err + "' WHERE MachineID='" + _id + "'";
            //return strSQL;

            //return string.Concat("UPDATE MonitorMachineTabel SET DMIP='" + _dmip + "',State='" + _state +
            //    "',ErrCode='" + _err + "',connectFlag='" + _connState + "',Timestamp='" + _time + "' WHERE MachineID='" + _id + "'");
            return string.Concat("UPDATE MonitorMachineTabel SET DMIP='" + _dmip + "',State='" + _state +
                "',ErrCode='" + _err + "',AmountofInput='" + _input + "',OKNums='" + _ok + "',NGNums='" + _ng +
                "',connectFlag='" + _connState + "',Timestamp='" + _time + "' WHERE MachineID='" + _id + "'");

        }

        public string MakeUpdateStringOFFLine(string _id, int _connState, string _time)
        {
            //string strSQL = "UPDATE MonitorMachineTabel SET DMIP='111111',State='3',ErrCode='122' WHERE MachineID='1901'";
            //string strSQL = "UPDATE MonitorMachineTabel SET DMIP='" + _dmip + "',State='" + _state + "',ErrCode='" + _err + "' WHERE MachineID='" + _id + "'";
            //return strSQL;

            //return string.Concat("UPDATE MonitorMachineTabel SET connectFlag='" + _connState + "',Timestamp='" + _time + "' WHERE MachineID='" + _id + "'");
            //2019/1/3 Kenny modified, 當機器處於離線狀態, 上傳server時,將設備狀態設為0.避免斷線時長時間停在報警狀態
            return string.Concat("UPDATE MonitorMachineTabel SET connectFlag='" + _connState + "',State='" + 0 + "',Timestamp='" + _time + "' WHERE MachineID='" + _id + "'");
     
        }

        private void timerUpload_Tick(object sender, EventArgs e)
        {
            UploadTimerCount = UploadTimerCount + 1;//每秒累加1.

            if (DateTime.Now.ToString("ss") == "00")//每整分報時,確認程式還活著
            { LOG("OPC client alive."); }

            bool f_ResetPLC = false;//true:Reset PLC中

            /*指定時間, 自動清空PLC數據*/
            if (checkBoxEnableReset1.CheckState == CheckState.Checked)//第一組時間
            {
                if (DateTime.Now.ToString("HHmm") == string.Concat(comboBoxResetHour1.SelectedItem.ToString() + comboBoxResetMin1.SelectedItem.ToString())) //時+分, HH為24小時制, hh為12小時制
                {
                    ResetPLCitemValue();//清空PLC數據
                    f_ResetPLC = true;
                    //MessageBox.Show("reset 1");
                }
            }
            if (checkBoxEnableReset2.CheckState == CheckState.Checked)//第二組時間
            {
                if (DateTime.Now.ToString("HHmm") == string.Concat(comboBoxResetHour2.SelectedItem.ToString() + comboBoxResetMin2.SelectedItem.ToString())) //時+分, HH為24小時制, hh為12小時制
                {
                    ResetPLCitemValue();//清空PLC數據
                    f_ResetPLC = true;
                }
            }


            /*上傳時間(頻率)到了,啟動上傳*/
            if ((UploadTimerCount >= UploadTimerCountTarget) && (!f_ResetPLC)) //Count時間到了,並且在非ResetPLC時間
            {
                UploadTimerCount = 0;//reset

                if (ConnectionExists(strServerIP, intServerPort))//測試與server間連線是否正常,正常再開始上傳數據庫
                {
                    Upload_Process(); //Upload主程式
                }
            }
        }


        private void Upload_Process()
        {
            //LOG("Upload_Process( )");

#if (A16_2F_OPC_client)
            /*數據上傳SQL server*/
            UploadToSQL();//DataGrid數據上傳SQL server
#endif

#if (E03_INJ_OPC_client)
            /*數據上傳Oracle server*/
            UploadToOracle();//DataGrid數據上傳Oracle server
#endif


            /*閃爍動畫效果*/
            if (DGrid.BackgroundColor == SystemColors.AppWorkspace)
            {
                DGrid.BackgroundColor = SystemColors.ControlDarkDark;
            }
            else
            {
                DGrid.BackgroundColor = SystemColors.AppWorkspace;
            }
        
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            KepServer.Disconnect();
            LOG("Windows closing");
        }


        private void AsyncWriteOpcItem(int _ServerHDL, string _Value)
        {

            //OPCItem bItem = KepItems.GetOPCItem(itmHandleServer);
            //OPCItem bItem = KepItems.GetOPCItem(myItemArray[0].itmHandleServer);
            //int[] temp = new int[2] { 0, bItem.ServerHandle };

            int[] temp = new int[2] { 0, _ServerHDL };

            Array serverHandles = (Array)temp;
            object[] valueTemp = new object[2] { "", _Value };
            Array values = (Array)valueTemp;
            Array Errors;
            int cancelID;
            KepGroup.AsyncWrite(1, ref serverHandles, ref values, out Errors, 2009, out cancelID);
            //KepItem.Write(txtWriteTagValue.Text);//这句也可以写入，但并不触发写入事件
            GC.Collect();
      
        }




        private void SaveSetting()
        {
            ///*save setting*/

            //判断文件的存在
            string Path = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "tmp.tmp";
            string filePath = System.IO.Path.Combine(Path, fileName);

            /*===============================================================================================*/
            ///指定日志文件的目录
            //string fname = Directory.GetCurrentDirectory() + "\\LogFile.txt";
            string fname = filePath;
            /**/
            ///定义文件信息对象

            FileInfo finfo = new FileInfo(fname);

            if (!finfo.Exists)//if file not exit, create first
            {
                FileStream fs;
                fs = File.Create(fname);
                fs.Close();
            }

            /*開啟CSV檔案, create header for each column*/
            //FileStream FS = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            FileStream FS = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(FS, System.Text.Encoding.Default);

            /*儲存版本號*/
            sw.Write(string.Concat("VER:" + SoftVersion + "\r\n"));

            /*儲存所有KEPserver上的ITEM(from listBox_ShowItem to file)*/
            for (int i = 0; i < listBox_ShowItem.Items.Count; i++) //每一筆device
            {
                sw.Write(string.Concat("Source:" + listBox_ShowItem.Items[i] + "\r\n"));//加上id欄位
            }


            /*update ID in listbox, from grid.*/
            for (int i = 0; i < OpcItemCount / ItemsPerRow; i++) //Grid每一列
            {
                listBox_SelItem.Items[i*(ItemsPerRow+1)]=string.Concat( DGrid.Rows[i].Cells[0].Value);//將grid中的ID,覆蓋到listbox中.
            }

            /*儲存MachineData( ID + Items....), from listbox to file */
            for (int i = 0; i < OpcItemCount / ItemsPerRow; i++) //每一筆device
            {
                int IDpsn=i*(ItemsPerRow+1);
                string IDstr = string.Concat(listBox_SelItem.Items[IDpsn]);
                string ITEMstr = "";
                
                for (int j = 1; j < ItemsPerRow+1; j++)
                { ITEMstr = ITEMstr + string.Concat("," + listBox_SelItem.Items[IDpsn+j]); }

                sw.Write(string.Concat("Device:" + IDstr + ITEMstr + "\r\n"));//加上id欄位
            }


            /*儲存採集頻率*/
            sw.Write(string.Concat("UpdateRate:" + txtboxUpdateRate.Text + "\r\n"));

            /*儲存上傳數據庫頻率*/
            sw.Write(string.Concat("UploadRate:" + txtboxUploadRate.Text + "\r\n"));

            /*儲存RESET Enable 狀態*/
            if (checkBoxEnableReset1.CheckState == CheckState.Checked)//選中狀態
                sw.Write(string.Concat("ResetCheck1:" + "1" + "\r\n"));
            else
                sw.Write(string.Concat("ResetCheck1:" + "0" + "\r\n"));
            

            if (checkBoxEnableReset2.CheckState == CheckState.Checked)//選中狀態
                sw.Write(string.Concat("ResetCheck2:" + "1" + "\r\n"));
            else
                sw.Write(string.Concat("ResetCheck2:" + "0" + "\r\n"));



            /*儲存RESET Hour*/
            sw.Write(string.Concat("ResetHour1:" + comboBoxResetHour1.SelectedIndex  + "\r\n"));

            /*儲存RESET Minute*/
            sw.Write(string.Concat("ResetMinute1:" + comboBoxResetMin1.SelectedIndex + "\r\n"));


            /*儲存RESET Hour*/
            sw.Write(string.Concat("ResetHour2:" + comboBoxResetHour2.SelectedIndex + "\r\n"));

            /*儲存RESET Minute*/
            sw.Write(string.Concat("ResetMinute2:" + comboBoxResetMin2.SelectedIndex + "\r\n"));


            sw.Close();

        }

        private bool Load_setting()
        {
            LOG("設定檔載入開始...");

            /* Read setting from file*/
            ///指定日志文件的目录
            string Path = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "tmp.tmp";
            string filePathName = System.IO.Path.Combine(Path, fileName);

            FileInfo finfo = new FileInfo(filePathName);


            /*確認軟件&設置檔版本搭配*/
            if (finfo.Exists)
            {
                System.IO.StreamReader sr = File.OpenText(filePathName);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Substring(0, 1) != "*")
                    {
                        string[] sArray = line.Split(':');

                        if (sArray[0] == "VER")
                        {
                            if (sArray[1] != SoftVersion)
                            {
                                LOG("版本不匹配");
                                sr.Close();
                                return false;
                            }
                        }
                    }
                }
                sr.Close();
            }
            else
            { 
                LOG("無暫存設置檔");
            }

            /*確認KEPserver(listBox_ShowItem上)的來源是否有變更*/
            List<string> SourceList = new List<string>();            
            if (finfo.Exists)
            {
                //讀取儲取的來源
                //System.IO.StreamReader sr = File.OpenText(filePathName);
                System.IO.StreamReader sr = new System.IO.StreamReader(filePathName, System.Text.Encoding.Default);
                // 指定 Encoding 為 System.Text.Encoding.Default (作業系統目前 ANSI 字碼頁的編碼方式)
                // 而非预设之Unicode方式,以支援含中文的內容(OPCitem)
               
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Substring(0, 1) != "*")
                    {
                        string[] sArray = line.Split(':');

                        if (sArray[0] == "Source")
                            SourceList.Add(sArray[1]);
                    }
                }

                //與listBox_ShowItem上進行比對是否完全相同
                for (int i = 0; i < SourceList.Count; i++) //每一筆device
                {
                    if (SourceList[i] != listBox_ShowItem.Items[i].ToString())//加上id欄位
                    {
                        LOG("KEPserver內容有更動!");
                        sr.Close();
                        return false;
                    }
                }
                
                sr.Close();
            }



            /*載入預選取之OPC items ================================================================*/

            /*Load OPC items, file -> listbox*/
            if (finfo.Exists)
            {
                System.IO.StreamReader sr = File.OpenText(filePathName);
                String line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Substring(0, 1) != "*")
                    {
                        string[] sArray = line.Split(':');
                        if (sArray[0] == "Device")
                        {
                            string[] pArray = sArray[1].Split(',');//ID+items
                            if (pArray.Count() != ItemsPerRow+1)
                            {
                                LOG("Items個數不match");
                                return false;
                            }
                            else
                            {   
                                //Load Device data(ID & OpcItems) to listbox
                                for (int i = 0; i < pArray.Count(); i++)
                                {
                                    listBox_SelItem.Items.Add(pArray[i]); //先load到選取item之listbox
                                }
                            }
                       }
                    }
                }
                sr.Close();

                ///*Load OPC items, listbox -> datagrid */
                ///*remove ALL opc items*/
                //for (int i = 0; i < OpcItemCount; i++)
                //{ RemoveOPCitem(myItemArray[i].itmHandleServer); }

                LoadOPCitemsFromListBox();//重新載入OPCitems, 從listbox -> grid


                ///*Load OPC Items要先做,否則自動增加行時會把已填好的數據往下擠*/
                //for (int DevideIndex = 0; DevideIndex < listBox_SelItem.Items.Count / (ItemsPerRow + 1); DevideIndex++)
                //{
                //    int IDpsn = DevideIndex * (ItemsPerRow + 1);//每個device 有(ItemsPerRow+1)個位置

                //    //put Items
                //    for (int i = 1; i < ItemsPerRow + 1; i++)
                //    {
                //        int p = int.Parse(string.Concat(listBox_SelItem.Items[IDpsn + i]));
                //        string itemName = (string)listBox_ShowItem.Items[p];

                //        AddOpcItemProcess(itemName);
                //    }

                //    //put ID
                //    DGrid.Rows[DevideIndex].Cells[0].Value = listBox_SelItem.Items[IDpsn];

                //    //填入OPC連線狀態欄位, 初始值0*
                //    DGrid.Rows[DevideIndex].Cells[ItemsPerRow + 1].Value = (int)0;

                //}

            }

            /////*Add opc items in Grid, 依Listbox內容, 加入opc items, 依數量自動新增Grid行數*/
            //for (int i = 0; i < listBox_SelItem.Items.Count; i++)
            //{
            //    int p = int.Parse(string.Concat(listBox_SelItem.Items[i]));

            //    if (p < listBox_ShowItem.Items.Count)
            //    {
            //        string itemName = (string)listBox_ShowItem.Items[p];
            //        AddOpcItemProcess(itemName);
            //    }
            //    else
            //    {   /**/
            //        return false;
            //    }
            //}

            /////*填入 機台ID in Grid */
            //if (finfo.Exists)
            //{
            //    System.IO.StreamReader sr = File.OpenText(filePathName);
            //    String line;
            //    int j = 0;
            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        if (line.Substring(0, 1) != "*")
            //        {
            //            string[] sArray = line.Split(':');
            //            if (sArray[0] == "M_ID")
            //            {
            //                if (j >= DGrid.RowCount)
            //                    return false;

            //                DGrid.Rows[j].Cells[0].Value = sArray[1];
            //                j++;//下一行
            //            }
            //        }
            //    }
            //    sr.Close();
            //}
            /*===============================================================================================*/


            /*載入其他設置參數*/
            if (finfo.Exists)
            {
                System.IO.StreamReader sr = File.OpenText(filePathName);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Substring(0, 1) != "*")
                    {
                        string[] sArray = line.Split(':');
                        
                        //if (sArray[0] == "VER")
                        //{
                        //    if (sArray[1] != SoftVersion)
                        //    {
                        //        return false;
                        //    }
                        //}
                        if (sArray[0] == "UpdateRate")
                        {
                            txtboxUpdateRate.Text = sArray[1];
                        }
                        else if (sArray[0] == "UploadRate")
                        {
                            txtboxUploadRate.Text = sArray[1];
                            KepGroup.UpdateRate = int.Parse(txtboxUploadRate.Text);
                        }
                        else if (sArray[0] == "ResetCheck1")
                        {
                            if (string.Concat(sArray[1]) == "1")
                                checkBoxEnableReset1.Checked = true;
                            else
                                checkBoxEnableReset1.Checked = false;
                        }
                        else if (sArray[0] == "ResetCheck2")
                        {
                            if (string.Concat(sArray[1]) == "1")
                                checkBoxEnableReset2.Checked = true;
                            else
                                checkBoxEnableReset2.Checked = false;
                        }
                        else if (sArray[0] == "ResetHour1")
                        {
                            comboBoxResetHour1.SelectedIndex = int.Parse(sArray[1]);
                        }
                        else if (sArray[0] == "ResetMinute1")
                        {
                            comboBoxResetMin1.SelectedIndex = int.Parse(sArray[1]);
                        }
                        else if (sArray[0] == "ResetHour2")
                        {
                            comboBoxResetHour2.SelectedIndex = int.Parse(sArray[1]);
                        }
                        else if (sArray[0] == "ResetMinute2")
                        {
                            comboBoxResetMin2.SelectedIndex = int.Parse(sArray[1]);
                        }
                    }
                }
                sr.Close();
            }

            LOG("設定檔載入完成.");
            return true;
        }


        private void buttonClearSetting_Click(object sender, EventArgs e)
        {
            /* opc server 斷開*/
            KepServer.Disconnect();

            /*clear listbox items.*/
            listBox_ShowItem.Items.Clear();
            listBox_SelItem.Items.Clear();
            //comboWriteItem.Items.Clear();

            /*Clear grid*/
            DGrid.Rows.Clear();

            /*remove ALL opc items*/
            OpcItemCount = 0;
            //for (int i = 0; i < listBox_SelItem.Items.Count; i++)
            for (int i = 0; i < OpcItemCount; i++)
            {
                RemoveOPCitem(myItemArray[i].itmHandleServer);
            }
            
            ///*刪除設置文件內容==========================================================================================*/
            ////判断文件的存在
            //string Path = AppDomain.CurrentDomain.BaseDirectory;
            //string fileName = "tmp.tmp";
            //string filePath = System.IO.Path.Combine(Path, fileName);


            /////指定日志文件的目录
            ////string fname = Directory.GetCurrentDirectory() + "\\LogFile.txt";
            //string fname = filePath;
            ///**/
            /////定义文件信息对象

            //FileInfo finfo = new FileInfo(fname);

            //if (!finfo.Exists)//if file not exit, create first
            //{
            //    FileStream fs;
            //    fs = File.Create(fname);
            //    fs.Close();
            //}

            ////開啟CSV檔案, create header for each column
            ////FileStream FS = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            //FileStream FS = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            //StreamWriter sw = new StreamWriter(FS, System.Text.Encoding.Default);

            //for (int i = 0; i < listBox_SelItem.Items.Count; i++)
            //{
            //    //sw.Write(string.Concat("Item:" + listBox_SelItem.Items[i] + "\n"));
            //    //寫入空值
            //}

            //sw.Close();
            ///*刪除設置文件內容==========================================================================================*/

        }

        //private void btnWrite_Click(object sender, EventArgs e)
        //{

        //    for (int i = 0; i < listBox_SelItem.Items.Count; i++)
        //    {
        //        if (myItemArray[i].ItemName == comboWriteItem.SelectedItem.ToString())
        //        {
        //            AsyncWriteOpcItem(myItemArray[i].itmHandleServer, txtWriteValue.Text);                    
        //            break;
        //        }
        //    }
        //}

        /*清空所有選取的Item 對應的PLC DM區之值*/
        private void ResetPLCitemValue()
        {
            LOG("Reset/Clear PLC");
            //for (int i = 0; i < listBox_SelItem.Items.Count; i++)
            for (int i = 0; i < OpcItemCount/ItemsPerRow; i++)
            {
                AsyncWriteOpcItem(myItemArray[i].itmHandleServer, "0");
            }
        }

        private void buttonSaveSetting_Click(object sender, EventArgs e)
        {
            if (!CheckGridData()) //*檢查grid內容是否正確*/
                return;

            SaveSetting();//儲存設置參數,下次可自動調用.

        }

 
        private void RemoveOPCitem(int _ServerHDL)
        {
            Array Errors;
            //OPCItem bItem = KepItems.GetOPCItem(itmHandleServer);
            //注：OPC中以1为数组的基数
            int[] temp = new int[2] { 0, _ServerHDL };
            Array serverHandle = (Array)temp;
            //移除上一次选择的项
            //KepItems.Remove(KepItems.Count, ref serverHandle, out Errors);
            KepItems.Remove(1, ref serverHandle, out Errors);

        }


        //private bool PingIP(string _ip)
        //{
        //    Ping pingSender = new Ping();
        //    //IPAddress address = IPAddress.Loopback;
        //    IPAddress address=IPAddress.Parse(_ip);
        //    PingReply reply = pingSender.Send(address);

        //    if (reply.Status == IPStatus.Success)
        //    {
        //        //Console.WriteLine("Address: {0}", reply.Address.ToString());
        //        //Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
        //        //Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
        //        //Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
        //        //Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
        //        return true;
        //    }
        //    else
        //    {
        //        //Console.WriteLine(reply.Status);
        //        return false;
        //    }
        //}

        bool ConnectionExists(string _ip, int _port)//確認連線是否正常
        {
            try
            {
                //System.Net.Sockets.TcpClient clnt = new System.Net.Sockets.TcpClient("www.google.com", 80);
                System.Net.Sockets.TcpClient clnt = new System.Net.Sockets.TcpClient(_ip, _port);

                clnt.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                LOG("Server連線異常：" + ex.Message);
                return false;
            }
        }

        private void buttonChangeSetting_Click(object sender, EventArgs e)
        {
            FormPWD frmPWD = new FormPWD(this);
            //this.Visible = false;
            frmPWD.ShowDialog();               
        }

        public void EnableSetting(bool _enable)
        {

                if (_enable)//true
                {
                    /*Enable Setting */
                    EnableSetting_f = true;
                    
                    groupBoxConnect.Enabled = true;
                    listBox_SelItem.Enabled = true;
                    listBox_ShowItem.Enabled = true;
                    //DGrid.Enabled = true;
                    DGrid.ReadOnly = false;//內容可編輯
                    groupBoxRate.Enabled = true;
                    //groupBoxWriteValue.Enabled = true;
                    groupBoxReset.Enabled = true;

                    BackColor = Color.Gold;

                    buttonStartUpload.Visible = false;
                    buttonChangeSetting.Visible = false;

                    groupBoxSetting.Visible = true;
                    groupBoxLog.Visible = false;

                    //listBox_SelItem.Visible = true;
                }
                else
                {   
                    /*Disable Setting */
                    EnableSetting_f = false;
                    
                    groupBoxConnect.Enabled = false;
                    listBox_SelItem.Enabled = false;
                    listBox_ShowItem.Enabled = false;
                    //DGrid.Enabled = false;
                    DGrid.ReadOnly = true;//內容不可編輯
                    groupBoxRate.Enabled = false;
                    //groupBoxWriteValue.Enabled = false;
                    groupBoxReset.Enabled = false;

                    BackColor = SystemColors.ActiveCaption;

                    buttonStartUpload.Visible = true;
                    buttonChangeSetting.Visible = true;

                    groupBoxSetting.Visible = false;
                    groupBoxLog.Visible = true;

                    groupBoxFunction.Visible = false;

                    //listBox_SelItem.Visible = false;
                }
        }

        private void buttonCancelSetting_Click(object sender, EventArgs e)
        {
            if (!CheckGridData()) //*檢查grid內容是否正確*/
                return;

            EnableSetting(false);
        }


        //public void EnableRESETsetting(bool _enable)
        //{
        //    if (_enable)//true
        //    {
        //        checkBoxEnableReset
        //    }
        //    else
        //    {
            
        //    }
        //}

        private void buttonBackSetting_Click(object sender, EventArgs e)
        {
            
            /*  Kenny: reaload all items  ----------------------------------------------------*/
            //if (listBox_SelItem.Items.Count < 1)
            if(OpcItemCount==0)
            {
                MessageBox.Show("無item!");
                return;
            }

            
            listBox_SelItem.Items.RemoveAt(listBox_SelItem.Items.Count - 1);//移除最新的一項.

            //如果移除的item是一筆資料的第一個item(column[1}位置), 則一併把listbox中殘留的id一併移除
            if(listBox_SelItem.Items.Count%(ItemsPerRow+1)==1)
            {
                listBox_SelItem.Items.RemoveAt(listBox_SelItem.Items.Count - 1);//移除最新的一項(殘留ID).
            }


            LoadOPCitemsFromListBox();//重新載入OPCitems, 從listbox -> grid



        }

        private void btnApplyRate_Click(object sender, EventArgs e)
        {
            /*for Update rate*/
            //timerUpload.Interval = int.Parse(txtboxUploadRate.Text) * 1000;//每n秒上傳一次, 於start button按下後assign

            /*for Upload rate*/
            ChangeGroupProperty();//變更屬性(採集頻率)

        }


        private void DGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (EnableSetting_f)
            {
                if (e.ColumnIndex >= 1 && e.ColumnIndex <= ItemsPerRow)//點選資料欄(不含"ID"欄位及"OPC連線品質"欄位)
                {
                    //MessageBox.Show("2," + e.RowIndex + "," + e.ColumnIndex);
                    DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)DGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    if (cell.Value != null)
                    {

                        /*---------------------*/
                        //int itemOrder = e.RowIndex * ItemsPerRow + e.ColumnIndex;//從cell位置,推算item順序

                        //SendMsg(string.Concat( listBox_SelItem.Items[itemOrder - 1]));

                        //int itemIndex = Int32.Parse(string.Concat(listBox_SelItem.Items[itemOrder - 1]));//從item順序, 推算item在list中的位置.

                        int SELpsn = e.RowIndex * (ItemsPerRow+1) + e.ColumnIndex;//從cell位置,推算item順序
                        int itemIndex = Int32.Parse(string.Concat(listBox_SelItem.Items[SELpsn]));//從item順序, 推算item在list中的位置.

                        listBox_ShowItem.SelectedIndex = itemIndex;
                    }
                    else
                    {
                        listBox_ShowItem.ClearSelected();//清除選取
                    }
                }
            }

            ///*for debug*/
            //string Pos = string.Concat("(" + e.RowIndex + "," + e.ColumnIndex + ")= ");
            //if (cell.Value == null)
            //    SendMsg(Pos + "null");
            //else
            //    SendMsg(Pos + string.Concat(cell.Value));
        }

        /*清除Grid資料,但保留原有列數、行數*/
        private void ClearDGrid()
        {
            for (int i = 0; i < DGrid.RowCount; i++)
            {
                for (int j = 0; j < DGrid.ColumnCount; j++)
                { 
                    DGrid.Rows[i].Cells[j].Value=null;
                }
            }
        }


        public bool CheckGridData()
        {

            ///*確認grid內容是否正確*/

            if (listBox_SelItem .Items.Count==0)
            {
                LOG("Grid無資料");
                MessageBox.Show("無資料");
                return false;
            }

            //if (listBox_SelItem.Items.Count % (ItemsPerRow+1) != 0) //需為倍數
            if (OpcItemCount % ItemsPerRow != 0)//需為倍數
            {
                LOG("Grid資料不完整1");
                MessageBox.Show("Grid資料不完整1");
                return false;
            }


            //確認每一列的機台ID欄位不可為空
            //for (int i = 0; i < listBox_SelItem.Items.Count / (ItemsPerRow + 1); i++) // (listBox_SelItem.Items.Count/ItemsPerRow): Grid應有的行數
            for (int i = 0; i < (OpcItemCount % ItemsPerRow); i++) // (listBox_SelItem.Items.Count/ItemsPerRow): Grid應有的行數
            {
                if (DGrid.Rows[i].Cells[0].Value == null || string.Concat(DGrid.Rows[i].Cells[0].Value) == "")
                {
                    LOG("Grid資料不完整2");
                    MessageBox.Show("Grid資料不完整2");
                    return false;
                }
                                
            }


            ////確認每一列的機台ID欄位不可為空
            //for (int i = 0; i < DGrid.RowCount; i++)
            //{
            //    if (i < listBox_SelItem.Items.Count / ItemsPerRow)//應有資料的列
            //    {
            //        if (DGrid.Rows[i].Cells[0].Value == null || string.Concat(DGrid.Rows[i].Cells[0].Value) == "") //機台ID欄位有空
            //        {
            //            MessageBox.Show("Grid資料不完整");
            //            return false;
            //        }
            //    }
            //    else //應無資料的列
            //    {
            //        if (DGrid.Rows[i].Cells[0].Value != null || string.Concat(DGrid.Rows[i].Cells[0].Value) != "")
            //        {
            //            MessageBox.Show("Grid資料不完整");
            //            return false;
            //        }
            //    }
            //}

            return true;
        }


        private void checkBoxEnableReset1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnableReset1.CheckState == CheckState.Checked)
            {
                //checkBoxEnableReset.Checked = false;
                comboBoxResetHour1.Enabled = true;
                comboBoxResetMin1.Enabled = true;
            }
            else
            {
                //checkBoxEnableReset.Checked = true;
                comboBoxResetHour1.Enabled = false;
                comboBoxResetMin1.Enabled = false;
            }

        }

        private void checkBoxEnableReset2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnableReset2.CheckState == CheckState.Checked)
            {
                //checkBoxEnableReset.Checked = false;
                comboBoxResetHour2.Enabled = true;
                comboBoxResetMin2.Enabled = true;
            }
            else
            {
                //checkBoxEnableReset.Checked = true;
                comboBoxResetHour2.Enabled = false;
                comboBoxResetMin2.Enabled = false;
            }
        }


        private int OPCquality(int _value)
        {
            /*OPC連線品質代碼*/
            //Hex   Decimal	OPC Specification Definition
            //C0	192	    Good
            //D8	216	    Good--Local Override, Value Forced
            //0	    0	    Bad
            //4	    4	    Bad - Configuration Error in Server
            //8	    8	    Bad - Not Connected
            //C	    12	    Bad - Device Failure
            //10	16	    Bad - Sensor Failure
            //14	20	    Bad - Last Know Value Passed
            //18	24	    Bad - Comm Failure
            //1C	28	    Bad - Item Set InActive
            //40	64	    Uncertain
            //44	68	    Uncertain - Last Usable Value - timeout of some kind
            //50	80	    Uncertain - Sensor not Accurate - outside of limits
            //54	84	    Uncertain - Engineering Units exceeded
            //58	88	    Uncertain - Value from multiple sources 
            
            int Status;//OPC連線狀態, 0:NG,  1:OK

            if (_value >= 192)
                Status = 1;
            else
                Status = 0;

            return Status;

        }

        private void checkBox_OPCitemFilter_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox_OPCitemFilter.CheckState == CheckState.Checked)
            //{
            //    //checkBoxEnableReset.Checked = false;
            //    comboBoxResetHour1.Enabled = true;
            //    comboBoxResetMin1.Enabled = true;
            //}
            //else
            //{
            //    //checkBoxEnableReset.Checked = true;
            //    comboBoxResetHour1.Enabled = false;
            //    comboBoxResetMin1.Enabled = false;
            //}
        }


        private void LOG(string _msg)
        {
            string LogMSG = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ==> " + _msg ;
            
            listBox_log.Items.Add(LogMSG);

            /*保時LOG listbox 容量*/
            if (listBox_log.Items.Count > 4000)
            {
                for (int j = 0; j < 2000; j++)
                { listBox_log.Items.RemoveAt(0); } //移除指定列資料.
            }

            listBox_log.SelectedIndex = listBox_log.Items.Count - 1;//保持listbox滾動到底部
            
            Write2LogFile(LogMSG);//寫入file
        }

        private void Write2LogFile(string _msg)
        {
            string Path = AppDomain.CurrentDomain.BaseDirectory + @"RunningLog\" + DateTime.Now.ToString("yyyy") +
            "\\" + DateTime.Now.ToString("MM");

            //判断文件夹的存在
            if (Directory.Exists(Path) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(Path);
            }

            ///定义文件信息对象
            string fileName = "Log_" + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + ".txt";
            string filePath = System.IO.Path.Combine(Path, fileName);

            //判断文件的存在
            FileInfo finfo = new FileInfo(filePath);
            if (!finfo.Exists)
            {
                FileStream fs;
                fs = File.Create(filePath);
                fs.Close();
            }

            //创建的文件流
            FileStream FS = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            //创建写数据流
            StreamWriter sw = new StreamWriter(FS, System.Text.Encoding.Default);

            ///设置写数据流的起始位置为文件流的末尾
            sw.BaseStream.Seek(0, SeekOrigin.End);

            //log 内容
            //sw.Write(_msg + "\r\n");
            sw.Write(_msg + "\r\n");

            ///清空缓冲区内容，并把缓冲区内容写入基础流
            sw.Flush();

            ///关闭写数据流
            sw.Close();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!StartChangeOrder_f)
            {
                StartChangeOrder_f = true;

                //在datagridview中添加button按钮
                DataGridViewCheckBoxColumn ckbCLM = new DataGridViewCheckBoxColumn();

                ckbCLM.HeaderText = "移動列";
                ckbCLM.DefaultCellStyle.BackColor = Color.Yellow;

                DGrid.Columns.Add(ckbCLM);

                //button color change
                buttonFunc1.Text = "MOVE UP !";
                buttonFunc1.Visible = true;
                //buttonFunc1.BackColor = Color.Yellow;

                buttonFunc2.Text = "MOVE DOWN !";
                buttonFunc2.Visible = true;
                
                buttonFunc3.Visible = false;

                buttonFunc4.Text = "FINISH";
                buttonFunc4.Visible = true;


                groupBoxFunction.Visible = true;

                groupBoxSetting.Visible = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //MOVE UP button
            if (StartChangeOrder_f)
            {
                DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                
                //檢查是否有重覆勾選
                bool f_FindTick=false;
                int TickedRow = 0;
                //for (int i = 0; i < DGrid.RowCount; i++)
                for (int i = 0; i < OpcItemCount/ItemsPerRow; i++)
                {
                    cell = (DataGridViewCheckBoxCell)DGrid.Rows[i].Cells[ItemsPerRow + 2];
                    if ((bool)cell.EditedFormattedValue == true)
                    {
                        if (f_FindTick == false)
                        { 
                            f_FindTick = true;
                            TickedRow = i;//記錄勾選的列
                        }
                        else
                        {
                            MessageBox.Show("不可重複勾選!");
                            return;
                        }
                    }
                }

                if (f_FindTick && TickedRow>0)
                {
                    //儲存並刪除第TickedRow筆資料
                    List<string> DataList = new List<string>();
                    for (int j = 0; j < (ItemsPerRow + 1); j++)
                    {
                        int PSN = TickedRow * (ItemsPerRow + 1);
                        DataList.Add((string)listBox_SelItem.Items[PSN]);
                        listBox_SelItem.Items.RemoveAt(PSN);//移除指定列資料.
                    }

                    //將儲存的第TickedRow筆資料插入到上一筆(TickedRow-1)的位置
                    for (int j = 0; j < (ItemsPerRow + 1); j++)
                    {
                        int PSN = (TickedRow-1) * (ItemsPerRow + 1);
                        listBox_SelItem.Items.Insert(PSN+j, DataList[j]);
                    }


                    LoadOPCitemsFromListBox();//重新載入OPCitems, 從listbox -> grid


                    DGrid.Rows[TickedRow - 1].Cells[ItemsPerRow + 2].Value = true;
                    DGrid.ClearSelection();//取消選取
                    DGrid.Rows[TickedRow - 1].Selected = true;
                }
            }

        }

        private void LoadOPCitemsFromListBox()
        {
            ClearDGrid(); /*清除Grid資料,但保留原有列數、行數*/
            
            /*remove ALL opc items*/
            for (int i = 0; i < OpcItemCount; i++)
            { RemoveOPCitem(myItemArray[i].itmHandleServer); }

            OpcItemCount = 0;//reset count
            labelItemCount.Text = "Item： " + OpcItemCount;

            List<string> IDlist = new List<string>();

            int itemIndex = 0;
            while (itemIndex < listBox_SelItem.Items.Count)
            {
                if (itemIndex % (ItemsPerRow+1) == 0)//ID node
                {
                    //save ID into List
                    IDlist.Add((string)listBox_SelItem.Items[itemIndex]);
                }
                else
                {   //load opc items
                    int p = int.Parse(string.Concat(listBox_SelItem.Items[itemIndex]));
                    string itemName = (string)listBox_ShowItem.Items[p];

                    AddOpcItemProcess(itemName);
                }

                itemIndex++;
            }

            /*put ID, from List to grid*/
            for (int i = 0; i < IDlist.Count; i++)
            {
                DGrid.Rows[i].Cells[0].Value=IDlist[i];
            }

            ///*Load OPC items, listbox -> datagrid */
            /////*Load OPC Items要先做,否則自動增加行時會把已填好的數據往下擠*/
            //for (int DevideIndex = 0; DevideIndex < listBox_SelItem.Items.Count / (ItemsPerRow + 1); DevideIndex++)
            //{
            //    int IDpsn = DevideIndex * (ItemsPerRow + 1);//每個device 有(ItemsPerRow+1)個位置

            //    //put Items
            //    for (int i = 1; i < ItemsPerRow + 1; i++)
            //    {
            //        int p = int.Parse(string.Concat(listBox_SelItem.Items[IDpsn + i]));
            //        string itemName = (string)listBox_ShowItem.Items[p];

            //        AddOpcItemProcess(itemName);
            //    }

            //    //put ID
            //    DGrid.Rows[DevideIndex].Cells[0].Value = listBox_SelItem.Items[IDpsn];

            //    //填入OPC連線狀態欄位, 初始值0*
            //    DGrid.Rows[DevideIndex].Cells[ItemsPerRow + 1].Value = (int)0;

            //}


        }

        private void buttonDelRow_Click(object sender, EventArgs e)
        {
            if (!StartDeleteRow_f)
            {
                StartDeleteRow_f = true;

                //在datagridview中添加button按钮
                DataGridViewCheckBoxColumn ckbCLM = new DataGridViewCheckBoxColumn();

                ckbCLM.HeaderText = "刪除列";
                ckbCLM.DefaultCellStyle.BackColor = Color.Yellow;

                DGrid.Columns.Add(ckbCLM);

                //button color change
                buttonFunc1.Text = "CONFIRM DELETE !";
                buttonFunc1.Visible = true;
                //buttonFunc1.BackColor = Color.Yellow;

                buttonFunc2.Visible = false;
                buttonFunc3.Visible = false;

                buttonFunc4.Text = "FINISH";
                buttonFunc4.Visible = true;


                groupBoxFunction.Visible = true;

                groupBoxSetting.Visible = false;
            }

        }

        private void buttonChangeOrder_Click(object sender, EventArgs e)
        {
            if (!StartChangeOrder_f)
            {
                StartChangeOrder_f = true;

                //在datagridview中添加button按钮
                DataGridViewCheckBoxColumn ckbCLM = new DataGridViewCheckBoxColumn();

                ckbCLM.HeaderText = "移動列";
                ckbCLM.DefaultCellStyle.BackColor = Color.Yellow;

                DGrid.Columns.Add(ckbCLM);

                //button color change
                buttonFunc1.Text = "MOVE UP !";
                buttonFunc1.Visible = true;
                //buttonFunc1.BackColor = Color.Yellow;

                buttonFunc2.Text = "MOVE DOWN !";
                buttonFunc2.Visible = true;
                
                buttonFunc3.Visible = false;

                buttonFunc4.Text = "FINISH";
                buttonFunc4.Visible = true;


                groupBoxFunction.Visible = true;

                groupBoxSetting.Visible = false;
            }
        }

        private void buttonFunc1_Click(object sender, EventArgs e)
        {

            if (StartDeleteRow_f)
            {
                ButtonFunction(FuncBTN_1, FuncCONFIRM_DELETE); /*CONFIRM DELETE button function*/
            }


            if (StartChangeOrder_f)
            {
                ButtonFunction(FuncBTN_1, FuncMOVE_UP);/*MOVE UP button function*/
            }

        }


        private void buttonFunc2_Click(object sender, EventArgs e)
        {            
            if (StartChangeOrder_f)
            {
                ButtonFunction(FuncBTN_2, FuncMOVE_DOWN);/*MOVE DOWN button function*/
            }
        }

        private void buttonFunc3_Click(object sender, EventArgs e)
        {

        }

        private void buttonFunc4_Click(object sender, EventArgs e)
        {
            if (StartDeleteRow_f)
            {
                ButtonFunction(FuncBTN_4, FuncFINISH);
                StartDeleteRow_f = false;/*回覆原狀態*/
            }

            if (StartChangeOrder_f)
            {
                ButtonFunction(FuncBTN_4, FuncFINISH);
                StartChangeOrder_f = false;/*回覆原狀態*/
            }

            ///*Cancel function*/
            //if (StartDeleteRow_f)
            //{
            //    /*回覆原狀態*/
            //    StartDeleteRow_f = false;

            //    //關掉新增的checkBoxcolum
            //    DataGridViewCheckBoxColumn ckbCLM = new DataGridViewCheckBoxColumn();
            //    ckbCLM = (DataGridViewCheckBoxColumn)DGrid.Columns[ItemsPerRow + 2];
            //    DGrid.Columns.Remove(ckbCLM);

            //    groupBoxFunction.Visible = false;
            //    groupBoxSetting.Visible = true;
            //}

            //if (StartChangeOrder_f)
            //{
            //    /*回覆原狀態*/
            //    StartChangeOrder_f = false;

            //    //關掉新增的checkBoxcolum
            //    DataGridViewCheckBoxColumn ckbCLM = new DataGridViewCheckBoxColumn();
            //    ckbCLM = (DataGridViewCheckBoxColumn)DGrid.Columns[ItemsPerRow + 2];
            //    DGrid.Columns.Remove(ckbCLM);

            //    groupBoxFunction.Visible = false;
            //    groupBoxSetting.Visible = true;

            //}

        }

        private void ButtonFunction(int _button, int _function)
        {
            switch (_button)
            {

                case FuncBTN_1://按鍵1

                    if (_function == FuncCONFIRM_DELETE)
                        BF_ConfirmDelete();
                    else if (_function == FuncMOVE_UP)
                        BF_MoveUP();

                    break;


                case FuncBTN_2://按鍵2
                    if (_function == FuncMOVE_DOWN)
                        BF_MoveDown();

                    break;



                case FuncBTN_3://按鍵3
                    break;



                case FuncBTN_4://按鍵4
                    if (_function == FuncFINISH)
                        BF_Finish();

                    break;




            }
        
        }

        private void BF_ConfirmDelete()
        {
            //搜尋是否有勾選刪除的列.
            DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
            for (int i = 0; i < DGrid.RowCount; i++)
            {
                cell = (DataGridViewCheckBoxCell)DGrid.Rows[i].Cells[ItemsPerRow + 2];

                if ((bool)cell.EditedFormattedValue == true)
                {
                    //MessageBox.Show("Delete row_," + i);
                    DGrid.Rows.Remove(DGrid.Rows[i]);

                    for (int j = 0; j < (ItemsPerRow + 1); j++)
                    {
                        listBox_SelItem.Items.RemoveAt(i * (ItemsPerRow + 1));//移除指定.
                    }
                }
            }

            LoadOPCitemsFromListBox();//重新載入OPCitems, 從listbox -> grid
        
        }

        private void BF_Finish()
        {
            /*Finish function*/
            //if (StartDeleteRow_f)
            //{
                /*回覆原狀態*/
                //StartDeleteRow_f = false;

                //關掉新增的checkBoxcolum
                DataGridViewCheckBoxColumn ckbCLM = new DataGridViewCheckBoxColumn();
                ckbCLM = (DataGridViewCheckBoxColumn)DGrid.Columns[ItemsPerRow + 2];
                DGrid.Columns.Remove(ckbCLM);

                groupBoxFunction.Visible = false;
                groupBoxSetting.Visible = true;
            //}

            //if (StartChangeOrder_f)
            //{
            //    /*回覆原狀態*/
            //    StartChangeOrder_f = false;

            //    //關掉新增的checkBoxcolum
            //    DataGridViewCheckBoxColumn ckbCLM = new DataGridViewCheckBoxColumn();
            //    ckbCLM = (DataGridViewCheckBoxColumn)DGrid.Columns[ItemsPerRow + 2];
            //    DGrid.Columns.Remove(ckbCLM);

            //    groupBoxFunction.Visible = false;
            //    groupBoxSetting.Visible = true;

            //}
        }


        private void BF_MoveUP()
        {
            DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();

            //檢查是否有重覆勾選
            bool f_FindTick = false;
            int TickedRow = 0;
            //for (int i = 0; i < DGrid.RowCount; i++)
            for (int i = 0; i < OpcItemCount / ItemsPerRow; i++)
            {
                cell = (DataGridViewCheckBoxCell)DGrid.Rows[i].Cells[ItemsPerRow + 2];
                if ((bool)cell.EditedFormattedValue == true)
                {
                    if (f_FindTick == false)
                    {
                        f_FindTick = true;
                        TickedRow = i;//記錄勾選的列
                    }
                    else
                    {
                        MessageBox.Show("不可重複勾選!");
                        return;
                    }
                }
            }

            if (f_FindTick && TickedRow > 0)
            {
                //儲存並刪除第TickedRow筆資料
                List<string> DataList = new List<string>();
                for (int j = 0; j < (ItemsPerRow + 1); j++)
                {
                    int PSN = TickedRow * (ItemsPerRow + 1);
                    //DataList.Add((string)listBox_SelItem.Items[PSN]);
                    DataList.Add(listBox_SelItem.Items[(int)PSN].ToString());

                    listBox_SelItem.Items.RemoveAt(PSN);//移除指定列資料.
                }

                //將儲存的第TickedRow筆資料插入到上一筆(TickedRow-1)的位置
                for (int j = 0; j < (ItemsPerRow + 1); j++)
                {
                    int PSN = (TickedRow - 1) * (ItemsPerRow + 1);
                    listBox_SelItem.Items.Insert(PSN + j, DataList[j]);
                }

                LoadOPCitemsFromListBox();//重新載入OPCitems, 從listbox -> grid

                DGrid.Rows[TickedRow].Cells[ItemsPerRow + 2].Value = false;//取消原勾選位置
                DGrid.Rows[TickedRow - 1].Cells[ItemsPerRow + 2].Value = true;//勾選新的位置

                DGrid.ClearSelection();//取消選取
                DGrid.Rows[TickedRow - 1].Selected = true;
            }
        }

        private void BF_MoveDown()
        {
            /*MOVE DOWN button*/
            if (StartChangeOrder_f)
            {
                DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();

                //檢查是否有重覆勾選
                bool f_FindTick = false;
                int TickedRow = 0;
                //for (int i = 0; i < DGrid.RowCount; i++)
                for (int i = 0; i < OpcItemCount / ItemsPerRow; i++)
                {
                    cell = (DataGridViewCheckBoxCell)DGrid.Rows[i].Cells[ItemsPerRow + 2];
                    if ((bool)cell.EditedFormattedValue == true)
                    {
                        if (f_FindTick == false)
                        {
                            f_FindTick = true;
                            TickedRow = i;//記錄勾選的列
                        }
                        else
                        {
                            MessageBox.Show("不可重複勾選!");
                            return;
                        }
                    }
                }

                if (f_FindTick && (TickedRow < (OpcItemCount / ItemsPerRow) - 1))//勾選非最後一列
                {
                    //儲存並刪除第TickedRow筆資料
                    List<string> DataList = new List<string>();
                    for (int j = 0; j < (ItemsPerRow + 1); j++)
                    {
                        int PSN = TickedRow * (ItemsPerRow + 1);

                        //DataList.Add((string)listBox_SelItem.Items[PSN]);
                        DataList.Add(listBox_SelItem.Items[(int)PSN].ToString());


                        listBox_SelItem.Items.RemoveAt(PSN);//移除指定列資料.
                    }

                    //將儲存的第TickedRow筆資料插入到下一筆(TickedRow+1)的位置
                    for (int j = 0; j < (ItemsPerRow + 1); j++)
                    {
                        int PSN = (TickedRow + 1) * (ItemsPerRow + 1);
                        listBox_SelItem.Items.Insert(PSN + j, DataList[j]);
                    }

                    LoadOPCitemsFromListBox();//重新載入OPCitems, 從listbox -> grid

                    DGrid.Rows[TickedRow].Cells[ItemsPerRow + 2].Value = false;//取消原勾選位置
                    DGrid.Rows[TickedRow + 1].Cells[ItemsPerRow + 2].Value = true;//勾選新的位置

                    DGrid.ClearSelection();//取消選取
                    DGrid.Rows[TickedRow + 1].Selected = true;
                }
            }
        }

    }



}
