namespace Siemens_PLC_Excel
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.connectStatus = new System.Windows.Forms.Button();
            this.disconnectPlc = new System.Windows.Forms.Button();
            this.connectPlc = new System.Windows.Forms.Button();
            this.plcSlot = new System.Windows.Forms.TextBox();
            this.plcRack = new System.Windows.Forms.TextBox();
            this.plcIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dbwVaule = new System.Windows.Forms.TextBox();
            this.finishRecordExcel = new System.Windows.Forms.Button();
            this.startRecordExcel = new System.Windows.Forms.Button();
            this.dbwNum = new System.Windows.Forms.TextBox();
            this.dbNum = new System.Windows.Forms.TextBox();
            this.recordExcelCycle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.采样周期 = new System.Windows.Forms.Label();
            this.listInfo = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.connectStatus);
            this.groupBox1.Controls.Add(this.disconnectPlc);
            this.groupBox1.Controls.Add(this.connectPlc);
            this.groupBox1.Controls.Add(this.plcSlot);
            this.groupBox1.Controls.Add(this.plcRack);
            this.groupBox1.Controls.Add(this.plcIp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "创建PLC连接";
            // 
            // connectStatus
            // 
            this.connectStatus.Location = new System.Drawing.Point(271, 71);
            this.connectStatus.Name = "connectStatus";
            this.connectStatus.Size = new System.Drawing.Size(58, 23);
            this.connectStatus.TabIndex = 9;
            this.connectStatus.UseVisualStyleBackColor = true;
            // 
            // disconnectPlc
            // 
            this.disconnectPlc.Location = new System.Drawing.Point(89, 71);
            this.disconnectPlc.Name = "disconnectPlc";
            this.disconnectPlc.Size = new System.Drawing.Size(58, 23);
            this.disconnectPlc.TabIndex = 8;
            this.disconnectPlc.Text = "断开";
            this.disconnectPlc.UseVisualStyleBackColor = true;
            this.disconnectPlc.Click += new System.EventHandler(this.disconnectPlc_Click);
            // 
            // connectPlc
            // 
            this.connectPlc.Location = new System.Drawing.Point(8, 71);
            this.connectPlc.Name = "connectPlc";
            this.connectPlc.Size = new System.Drawing.Size(58, 23);
            this.connectPlc.TabIndex = 7;
            this.connectPlc.Text = "连接";
            this.connectPlc.UseVisualStyleBackColor = true;
            this.connectPlc.Click += new System.EventHandler(this.connectPLC_Click);
            // 
            // plcSlot
            // 
            this.plcSlot.Location = new System.Drawing.Point(297, 31);
            this.plcSlot.Name = "plcSlot";
            this.plcSlot.Size = new System.Drawing.Size(32, 21);
            this.plcSlot.TabIndex = 6;
            // 
            // plcRack
            // 
            this.plcRack.Location = new System.Drawing.Point(224, 31);
            this.plcRack.Name = "plcRack";
            this.plcRack.Size = new System.Drawing.Size(32, 21);
            this.plcRack.TabIndex = 5;
            // 
            // plcIp
            // 
            this.plcIp.Location = new System.Drawing.Point(53, 31);
            this.plcIp.Name = "plcIp";
            this.plcIp.Size = new System.Drawing.Size(118, 21);
            this.plcIp.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "插槽";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "机架号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "label6";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dbwVaule);
            this.groupBox2.Controls.Add(this.finishRecordExcel);
            this.groupBox2.Controls.Add(this.startRecordExcel);
            this.groupBox2.Controls.Add(this.dbwNum);
            this.groupBox2.Controls.Add(this.dbNum);
            this.groupBox2.Controls.Add(this.recordExcelCycle);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.采样周期);
            this.groupBox2.Location = new System.Drawing.Point(12, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "创建PLC连接";
            // 
            // dbwVaule
            // 
            this.dbwVaule.Location = new System.Drawing.Point(304, 9);
            this.dbwVaule.Name = "dbwVaule";
            this.dbwVaule.ReadOnly = true;
            this.dbwVaule.Size = new System.Drawing.Size(38, 21);
            this.dbwVaule.TabIndex = 13;
            // 
            // finishRecordExcel
            // 
            this.finishRecordExcel.Location = new System.Drawing.Point(89, 71);
            this.finishRecordExcel.Name = "finishRecordExcel";
            this.finishRecordExcel.Size = new System.Drawing.Size(58, 23);
            this.finishRecordExcel.TabIndex = 12;
            this.finishRecordExcel.Text = "结束";
            this.finishRecordExcel.UseVisualStyleBackColor = true;
            this.finishRecordExcel.Click += new System.EventHandler(this.finishRecordExcel_Click);
            // 
            // startRecordExcel
            // 
            this.startRecordExcel.Location = new System.Drawing.Point(8, 71);
            this.startRecordExcel.Name = "startRecordExcel";
            this.startRecordExcel.Size = new System.Drawing.Size(58, 23);
            this.startRecordExcel.TabIndex = 9;
            this.startRecordExcel.Text = "开始";
            this.startRecordExcel.UseVisualStyleBackColor = true;
            this.startRecordExcel.Click += new System.EventHandler(this.startRecordExcel_Click);
            // 
            // dbwNum
            // 
            this.dbwNum.Location = new System.Drawing.Point(291, 31);
            this.dbwNum.Name = "dbwNum";
            this.dbwNum.Size = new System.Drawing.Size(38, 21);
            this.dbwNum.TabIndex = 11;
            // 
            // dbNum
            // 
            this.dbNum.Location = new System.Drawing.Point(187, 31);
            this.dbNum.Name = "dbNum";
            this.dbNum.Size = new System.Drawing.Size(38, 21);
            this.dbNum.TabIndex = 10;
            // 
            // recordExcelCycle
            // 
            this.recordExcelCycle.Location = new System.Drawing.Point(69, 31);
            this.recordExcelCycle.Name = "recordExcelCycle";
            this.recordExcelCycle.Size = new System.Drawing.Size(38, 21);
            this.recordExcelCycle.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(152, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "DB块";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "DBW";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "ms";
            // 
            // 采样周期
            // 
            this.采样周期.AutoSize = true;
            this.采样周期.Location = new System.Drawing.Point(6, 35);
            this.采样周期.Name = "采样周期";
            this.采样周期.Size = new System.Drawing.Size(53, 12);
            this.采样周期.TabIndex = 1;
            this.采样周期.Text = "采样周期";
            // 
            // listInfo
            // 
            this.listInfo.FormattingEnabled = true;
            this.listInfo.ItemHeight = 12;
            this.listInfo.Location = new System.Drawing.Point(374, 22);
            this.listInfo.Name = "listInfo";
            this.listInfo.Size = new System.Drawing.Size(250, 208);
            this.listInfo.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(12, 256);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(345, 100);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "创建";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 21);
            this.textBox1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.listInfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Name = "Form1";
            this.Text = "Siemens-PLC-Excel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label 采样周期;
        private System.Windows.Forms.Button disconnectPlc;
        private System.Windows.Forms.Button connectPlc;
        private System.Windows.Forms.TextBox plcSlot;
        private System.Windows.Forms.TextBox plcRack;
        private System.Windows.Forms.TextBox plcIp;
        private System.Windows.Forms.TextBox dbwVaule;
        private System.Windows.Forms.Button finishRecordExcel;
        private System.Windows.Forms.Button startRecordExcel;
        private System.Windows.Forms.TextBox dbwNum;
        private System.Windows.Forms.TextBox dbNum;
        private System.Windows.Forms.TextBox recordExcelCycle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listInfo;
        private System.Windows.Forms.Button connectStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

