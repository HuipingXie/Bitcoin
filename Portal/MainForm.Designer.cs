namespace Portal
{
    partial class MainForm
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
            this.RefreshButton = new System.Windows.Forms.Button();
            this.AmountBox = new System.Windows.Forms.TextBox();
            this.SymbolBox = new System.Windows.Forms.TextBox();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SideBox = new System.Windows.Forms.ComboBox();
            this.TypeBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PriceBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.PidBox = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.BalanceBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PositionsView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OrdersView = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.FloatBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TradesView = new System.Windows.Forms.ListView();
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // RefreshButton
            // 
            this.RefreshButton.Enabled = false;
            this.RefreshButton.Location = new System.Drawing.Point(967, 110);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(114, 97);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // AmountBox
            // 
            this.AmountBox.Location = new System.Drawing.Point(145, 535);
            this.AmountBox.Name = "AmountBox";
            this.AmountBox.Size = new System.Drawing.Size(127, 26);
            this.AmountBox.TabIndex = 101;
            // 
            // SymbolBox
            // 
            this.SymbolBox.Location = new System.Drawing.Point(12, 535);
            this.SymbolBox.Name = "SymbolBox";
            this.SymbolBox.Size = new System.Drawing.Size(127, 26);
            this.SymbolBox.TabIndex = 100;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(715, 516);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(114, 65);
            this.ExecuteButton.TabIndex = 105;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 513);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "symbol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 513);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "side";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 512);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "amount";
            // 
            // SideBox
            // 
            this.SideBox.FormattingEnabled = true;
            this.SideBox.Items.AddRange(new object[] {
            "BUY",
            "SELL"});
            this.SideBox.Location = new System.Drawing.Point(278, 535);
            this.SideBox.Name = "SideBox";
            this.SideBox.Size = new System.Drawing.Size(100, 28);
            this.SideBox.TabIndex = 102;
            // 
            // TypeBox
            // 
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.Items.AddRange(new object[] {
            "MARKET",
            "LIMIT"});
            this.TypeBox.Location = new System.Drawing.Point(384, 535);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(100, 28);
            this.TypeBox.TabIndex = 103;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 513);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "type";
            // 
            // PriceBox
            // 
            this.PriceBox.Location = new System.Drawing.Point(490, 535);
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(127, 26);
            this.PriceBox.TabIndex = 104;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(486, 512);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "price";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(919, 516);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(114, 65);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "Cancel All";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PidBox
            // 
            this.PidBox.Location = new System.Drawing.Point(111, 604);
            this.PidBox.Name = "PidBox";
            this.PidBox.Size = new System.Drawing.Size(147, 26);
            this.PidBox.TabIndex = 106;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(264, 590);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(164, 55);
            this.CloseButton.TabIndex = 107;
            this.CloseButton.Text = "Close Position";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 607);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 108;
            this.label6.Text = "position id:";
            // 
            // BalanceBox
            // 
            this.BalanceBox.Location = new System.Drawing.Point(835, 604);
            this.BalanceBox.Name = "BalanceBox";
            this.BalanceBox.ReadOnly = true;
            this.BalanceBox.Size = new System.Drawing.Size(305, 26);
            this.BalanceBox.TabIndex = 109;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(760, 607);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 110;
            this.label7.Text = "balance:";
            // 
            // PositionsView
            // 
            this.PositionsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.PositionsView.FullRowSelect = true;
            this.PositionsView.GridLines = true;
            this.PositionsView.Location = new System.Drawing.Point(12, 12);
            this.PositionsView.Name = "PositionsView";
            this.PositionsView.Size = new System.Drawing.Size(865, 290);
            this.PositionsView.TabIndex = 111;
            this.PositionsView.UseCompatibleStateImageBehavior = false;
            this.PositionsView.View = System.Windows.Forms.View.Details;
            this.PositionsView.ItemActivate += new System.EventHandler(this.PositionsView_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "id";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "symbol";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "amount";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "base price";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "value";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "p/l";
            this.columnHeader6.Width = 90;
            // 
            // OrdersView
            // 
            this.OrdersView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader14});
            this.OrdersView.FullRowSelect = true;
            this.OrdersView.GridLines = true;
            this.OrdersView.Location = new System.Drawing.Point(12, 308);
            this.OrdersView.Name = "OrdersView";
            this.OrdersView.Size = new System.Drawing.Size(1153, 175);
            this.OrdersView.TabIndex = 112;
            this.OrdersView.UseCompatibleStateImageBehavior = false;
            this.OrdersView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "living";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "cancelled";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "symbol";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "side";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "amount (o/e)";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "price (o/e)";
            this.columnHeader10.Width = 120;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "type";
            this.columnHeader11.Width = 120;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "timestamp";
            this.columnHeader14.Width = 120;
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 60000;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // FloatBox
            // 
            this.FloatBox.Location = new System.Drawing.Point(571, 604);
            this.FloatBox.Name = "FloatBox";
            this.FloatBox.ReadOnly = true;
            this.FloatBox.Size = new System.Drawing.Size(137, 26);
            this.FloatBox.TabIndex = 113;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(521, 607);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 114;
            this.label8.Text = "float:";
            // 
            // TradesView
            // 
            this.TradesView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22});
            this.TradesView.FullRowSelect = true;
            this.TradesView.GridLines = true;
            this.TradesView.Location = new System.Drawing.Point(12, 683);
            this.TradesView.Name = "TradesView";
            this.TradesView.Size = new System.Drawing.Size(1153, 220);
            this.TradesView.TabIndex = 115;
            this.TradesView.UseCompatibleStateImageBehavior = false;
            this.TradesView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "living";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "cancelled";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "symbol";
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "side";
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "amount (o/e)";
            this.columnHeader19.Width = 120;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "price (o/e)";
            this.columnHeader20.Width = 120;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "type";
            this.columnHeader21.Width = 120;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "timestamp";
            this.columnHeader22.Width = 120;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 915);
            this.Controls.Add(this.TradesView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.FloatBox);
            this.Controls.Add(this.OrdersView);
            this.Controls.Add(this.PositionsView);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BalanceBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.PidBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PriceBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TypeBox);
            this.Controls.Add(this.SideBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.SymbolBox);
            this.Controls.Add(this.AmountBox);
            this.Controls.Add(this.RefreshButton);
            this.Name = "MainForm";
            this.Text = "Bitcoin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.TextBox AmountBox;
        private System.Windows.Forms.TextBox SymbolBox;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SideBox;
        private System.Windows.Forms.ComboBox TypeBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PriceBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox PidBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BalanceBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView PositionsView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView OrdersView;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.TextBox FloatBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView TradesView;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
    }
}

