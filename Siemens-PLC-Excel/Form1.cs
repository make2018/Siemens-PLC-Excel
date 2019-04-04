using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sharp7;
using System.IO;
using System.Data.OleDb;



namespace Siemens_PLC_Excel
{
    public partial class Form1 : Form
    {
        private S7Client Client;
        private byte[] Buffer = new byte[65536];
        int i = 1;
        
      
        public Form1()
        {
            InitializeComponent();
            Client = new S7Client();
            if (IntPtr.Size == 4)
                this.Text = this.Text + " - Running 32 bit Code";
            else
                this.Text = this.Text + " - Running 64 bit Code";
            
        }

        private void connectPLC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(plcIp.Text))
            {
                listInfo.Items.Add("PLC IP 地址不能为空!");
                plcIp.Focus();
            }
            if (string.IsNullOrEmpty(plcRack.Text))
            {
                listInfo.Items.Add("PLC机架号不能为空!");
                plcRack.Focus();
            }
            if (string.IsNullOrEmpty(plcSlot.Text))
            {
                listInfo.Items.Add("PLC插槽不能为空!");
                plcSlot.Focus();
            }
            else
            {
                int Result;
                int Rack = System.Convert.ToInt32(plcRack.Text);
                int Slot = System.Convert.ToInt32(plcSlot.Text);
                Result = Client.ConnectTo(plcIp.Text, Rack, Slot);
              
                if (Result == 0)
                {

                    plcIp.Enabled = false;
                    plcRack.Enabled = false;
                     plcSlot.Enabled = false;
                    connectPlc.Enabled = false;
                    disconnectPlc.Enabled = true;               
                    startRecordExcel.Enabled = true;

                    listInfo.Items.Add("建立IP地址为 " + plcIp.Text + "的连接成功");

                }
            }
        }
        private void disconnectPlc_Click(object sender, EventArgs e)
        {
            Client.Disconnect();
            plcIp.Enabled = true;
            plcRack.Enabled = true;
            plcSlot.Enabled = true;
            connectPlc.Enabled = true;
            disconnectPlc.Enabled = false;
            listInfo.Items.Add("断开IP地址为 " + plcIp.Text + "的连接");
        }
        private void createExcelFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(excleFileName.Text))
            {
                listInfo.Items.Add("请输入文件名!");
                excleFileName.Focus();
            }


            //判断文件是否存在，如果存在，在消息框中提示文件已创建

            if (File.Exists("c:\\"+excleFileName.Text + ".xls ")) {
                listInfo.Items.Add(excleFileName.Text + ".xls "+"文件已存在，请重新创建文件");
                excleFileName.Enabled = true;
            }
            else
            {
                //连接字符串，其中文件名通过获取TextBox中的内容
                String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=c:/" + excleFileName.Text + ".xls;" + "Extended Properties=Excel 8.0;";
                //建立连接
                OleDbConnection cn = new OleDbConnection(sConnectionString);
                string sqlCreate = "CREATE TABLE TestSheet ([ID] VarChar,[参数值] VarChar)";
                OleDbCommand cmd = new OleDbCommand(sqlCreate, cn);
                //创建Excel文件
                cn.Open();
                //创建TestSheet工作表  
                cmd.ExecuteNonQuery();
                listInfo.Items.Add("创建--" + excleFileName.Text + ".xls--文件成功");
                //关闭连接
                cn.Close();
                //文件创建后，不允许修改文件名
                excleFileName.Enabled = false;
                createExcelFile.Enabled = false;
            }
            
           
        }
        private void startRecordExcel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(recordExcelCycle.Text))
            {
                listInfo.Items.Add("循环时间不能为空!");
                recordExcelCycle.Focus();
            }
            if (string.IsNullOrEmpty(dbNum.Text))
            {
                listInfo.Items.Add("DB字段不能为空!");
                dbNum.Focus();
            }
            if (string.IsNullOrEmpty(dbwNum.Text))
            {
                listInfo.Items.Add("DBW字段不能为空!");
                dbwNum.Focus();
            }
            if (string.IsNullOrEmpty(excleFileName.Text))
            {
                listInfo.Items.Add("请输入文件名或者选择文件!");
                excleFileName.Focus();
            }
            else
            {
                timer1.Start();
                startRecordExcel.Enabled = false;
                finishRecordExcel.Enabled = true;
                recordExcelCycle.Enabled = false;
                dbNum.Enabled = false;
                dbwNum.Enabled = false;
            }
        }
        private void ReadDbw()
        {
            int DBNumber;
            int Size = 10;
            int Result;

            DBNumber = System.Convert.ToInt32(dbNum.Text);
            Result = Client.DBRead(DBNumber, 0, Size, Buffer);
            if (Result == 0)
                HexDump(Buffer, Size);

        }
        private void HexDump(byte[] bytes, int Size)
        {
            if (bytes == null)
                return;
            int bytesLength = Size;
            int bytesPerLine = 16;

            char[] HexChars = "0123456789ABCDEF".ToCharArray();

            int firstHexColumn =
                  8                   // 8 characters for the address
                + 3;                  // 3 spaces

            int firstCharColumn = firstHexColumn
                + bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
                + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                + 2;                  // 2 spaces 

            int lineLength = firstCharColumn
                + bytesPerLine           // - characters to show the ascii value
                + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            char[] line = (new String(' ', lineLength - 2) + Environment.NewLine).ToCharArray();
            int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            StringBuilder result = new StringBuilder(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = HexChars[(i >> 28) & 0xF];
                line[1] = HexChars[(i >> 24) & 0xF];
                line[2] = HexChars[(i >> 20) & 0xF];
                line[3] = HexChars[(i >> 16) & 0xF];
                line[4] = HexChars[(i >> 12) & 0xF];
                line[5] = HexChars[(i >> 8) & 0xF];
                line[6] = HexChars[(i >> 4) & 0xF];
                line[7] = HexChars[(i >> 0) & 0xF];

                int hexColumn = firstHexColumn;
                int charColumn = firstCharColumn;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        byte b = bytes[i + j];
                        line[hexColumn] = HexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = HexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '·' : (char)b);
                    }
                    hexColumn += 3;
                    charColumn++;
                }
                result.Append(line);
            }

        }
        private void getDbwValues()
        {


            ReadDbw();
            int Pos = System.Convert.ToInt32(dbwNum.Text);
            int S7Int = S7.GetIntAt(Buffer, Pos);
            dbwVaule.Text = System.Convert.ToString(S7Int);
            listInfo.Items.Add(DateTime.Now.ToString());
            listInfo.Items.Add("从DB" + dbNum.Text + "获取到的DBW" + dbwNum.Text + "的值是" + System.Convert.ToString(S7Int));
            if (listInfo.Items.Count > 30)
            {
                listInfo.Items.Clear();
            }





        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = System.Convert.ToInt32(recordExcelCycle.Text);
         
            xuLie.Text=i.ToString();
            i++;
            getDbwValues();
            writeIntoExcel();
        }
        private void finishRecordExcel_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            listInfo.Items.Add("数据采集结束");
            finishRecordExcel.Enabled = false;
            startRecordExcel.Enabled = true;
            recordExcelCycle.Enabled = true;
            dbNum.Enabled = true;
            dbwNum.Enabled = true;
        }
        private void writeIntoExcel()
        {
            String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=c:/" + excleFileName.Text + ".xls;" + "Extended Properties=Excel 8.0;";
            OleDbConnection cn = new OleDbConnection(sConnectionString);     
            string sqlCreate = "INSERT INTO TestSheet VALUES(" + xuLie.Text + "," + dbwVaule.Text+")";
            OleDbCommand cmd = new OleDbCommand(sqlCreate, cn);
            cn.Open();
            //插入数据
            cmd.ExecuteNonQuery();
            listInfo.Items.Add(DateTime.Now.ToString()+"插入数据" + dbwVaule.Text + "成功");
            //关闭连接
            cn.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //1.将Form属性ShowInTaskbar改为false，这样程序将不会在任务栏中显示。
            //2.将Form属性WindowState选择为 Minimized，以便起来自动最小化隐藏。
            string startup = Application.ExecutablePath;       //取得程序路径   
            int pp = startup.LastIndexOf("\\");
            startup = startup.Substring(0, pp);

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide(); //或者是this.Visible = false;
                this.notifyIcon1.Visible = true;
            }

        }

        //二 双击窗体上的菜单项，添加相关代码
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要退出程序吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
            }

        }

        private void hideMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void showMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();

        }

        //三 转到窗体设计模式，右击notifyIcon1 ，选择属性，双击其中DoubleClick，添加相关代码
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;

                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            // 将窗体变为最小化
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
