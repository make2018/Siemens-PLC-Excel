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
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;



namespace Siemens_PLC_Excel
{
    public partial class Form1 : Form
    {
        private S7Client Client;
        private byte[] Buffer = new byte[65536];

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
                    connectStatus.BackColor = Color.Green;
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
            connectStatus.BackColor = Color.DarkGray;
            listInfo.Items.Add("断开IP地址为 " + plcIp.Text + "的连接");

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
            else
            {
                timer1.Start();
                startRecordExcel.Enabled = false;
                finishRecordExcel.Enabled = true;
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
            listInfo.Items.Add("---");
            if (listInfo.Items.Count > 20)
            {
                listInfo.Items.Clear();
            }





        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = System.Convert.ToInt32(recordExcelCycle.Text);
            getDbwValues();
        }

        private void finishRecordExcel_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            listInfo.Items.Add("数据采集结束");
            finishRecordExcel.Enabled = false;
            startRecordExcel.Enabled = true;
        }

        public static void DTToExcel(string Path, System.Data.DataTable dt)
        {
            string strCon = string.Empty;
            FileInfo file = new FileInfo(Path);
            string extension = file.Extension;
            switch (extension)
            {
                case ".xls":
                    strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + ";Extended Properties=Excel 8.0;";
                    //strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=0;'";
                    //strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=2;'";
                    break;
                case ".xlsx":
                    //strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties=Excel 12.0;";
                    //strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=2;'";    //出现错误了
                    strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=0;'";
                    break;
                default:
                    strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=0;'";
                    break;
            }
            try
            {
                using (System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(strCon))
                {
                    con.Open();
                    StringBuilder strSQL = new StringBuilder();
                    System.Data.OleDb.OleDbCommand cmd;
                    try
                    {
                        cmd = new System.Data.OleDb.OleDbCommand(string.Format("drop table {0}", dt.TableName), con);    //覆盖文件时可能会出现Table 'Sheet1' already exists.所以这里先删除了一下
                        cmd.ExecuteNonQuery();
                    }
                    catch { }
                    //创建表格字段
                    strSQL.Append("CREATE TABLE ").Append("[" + dt.TableName + "]");
                    strSQL.Append("(");
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        strSQL.Append("[" + dt.Columns[i].ColumnName + "] text,");
                    }
                    strSQL = strSQL.Remove(strSQL.Length - 1, 1);
                    strSQL.Append(")");

                    cmd = new System.Data.OleDb.OleDbCommand(strSQL.ToString(), con);
                    cmd.ExecuteNonQuery();
                    //添加数据
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strSQL.Clear();
                        StringBuilder strvalue = new StringBuilder();
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            strvalue.Append("'" + dt.Rows[i][j].ToString() + "'");
                            if (j != dt.Columns.Count - 1)
                            {
                                strvalue.Append(",");
                            }
                            else
                            {
                            }
                        }
                        cmd.CommandText = strSQL.Append(" insert into [" + dt.TableName + "] values (").Append(strvalue).Append(")").ToString();
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch { }
        }

        private void saveToExcel_Click(object sender, EventArgs e)
        {
            string currentPath = Directory.GetCurrentDirectory();
            WriteExcel(currentPath + "\\results.xlsx");

            MessageBox.Show("Success!");
    
        }

        public void WriteExcel(string filename)
        {
            //new an excel object
            Excel.Application excelApp = new Excel.ApplicationClass();
            if (excelApp == null)
            {
                // if equal null means EXCEL is not installed.
                MessageBox.Show("Excel is not properly installed!");
                return;
            }

            // open a workbook,if not exist, create a new one
            Excel.Workbook workBook;
            if (File.Exists(filename))
            {
                workBook = excelApp.Workbooks.Open(filename, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            }
            else
            {
                workBook = excelApp.Workbooks.Add(true);
            }

            //new a worksheet
            Excel.Worksheet workSheet = workBook.ActiveSheet as Excel.Worksheet;

            //write data
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);//获得第i个sheet，准备写入
            workSheet.Cells[1, 3] = "(1,3)Content";

            //set visible the Excel will run in background
            excelApp.Visible = false;
            //set false the alerts will not display
            excelApp.DisplayAlerts = false;

            //workBook.SaveAs(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            workBook.SaveAs(filename);
            workBook.Close(false, Missing.Value, Missing.Value);

            //quit and clean up objects
            excelApp.Quit();
            workSheet = null;
            workBook = null;
            excelApp = null;
            GC.Collect();
        }



    }
}
