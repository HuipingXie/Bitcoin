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
            this.PositionsBox = new System.Windows.Forms.TextBox();
            this.OrdersBox = new System.Windows.Forms.TextBox();
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
            this.CancelBox = new System.Windows.Forms.Button();
            this.PidBox = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.BalanceBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PositionsBox
            // 
            this.PositionsBox.Location = new System.Drawing.Point(12, 43);
            this.PositionsBox.Multiline = true;
            this.PositionsBox.Name = "PositionsBox";
            this.PositionsBox.ReadOnly = true;
            this.PositionsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PositionsBox.Size = new System.Drawing.Size(707, 259);
            this.PositionsBox.TabIndex = 0;
            // 
            // OrdersBox
            // 
            this.OrdersBox.Location = new System.Drawing.Point(12, 308);
            this.OrdersBox.Multiline = true;
            this.OrdersBox.Name = "OrdersBox";
            this.OrdersBox.ReadOnly = true;
            this.OrdersBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OrdersBox.Size = new System.Drawing.Size(707, 89);
            this.OrdersBox.TabIndex = 1;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(763, 205);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(114, 97);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // AmountBox
            // 
            this.AmountBox.Location = new System.Drawing.Point(118, 467);
            this.AmountBox.Name = "AmountBox";
            this.AmountBox.Size = new System.Drawing.Size(100, 26);
            this.AmountBox.TabIndex = 101;
            // 
            // SymbolBox
            // 
            this.SymbolBox.Location = new System.Drawing.Point(12, 467);
            this.SymbolBox.Name = "SymbolBox";
            this.SymbolBox.Size = new System.Drawing.Size(100, 26);
            this.SymbolBox.TabIndex = 100;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(584, 461);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(114, 38);
            this.ExecuteButton.TabIndex = 105;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "symbol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "side";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 444);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "amount";
            // 
            // SideBox
            // 
            this.SideBox.FormattingEnabled = true;
            this.SideBox.Items.AddRange(new object[] {
            "buy",
            "sell"});
            this.SideBox.Location = new System.Drawing.Point(224, 467);
            this.SideBox.Name = "SideBox";
            this.SideBox.Size = new System.Drawing.Size(100, 28);
            this.SideBox.TabIndex = 102;
            // 
            // TypeBox
            // 
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.Items.AddRange(new object[] {
            "market",
            "limit"});
            this.TypeBox.Location = new System.Drawing.Point(330, 467);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(100, 28);
            this.TypeBox.TabIndex = 103;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "type";
            // 
            // PriceBox
            // 
            this.PriceBox.Location = new System.Drawing.Point(436, 467);
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(100, 26);
            this.PriceBox.TabIndex = 104;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(432, 444);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "price";
            // 
            // CancelBox
            // 
            this.CancelBox.Location = new System.Drawing.Point(727, 461);
            this.CancelBox.Name = "CancelBox";
            this.CancelBox.Size = new System.Drawing.Size(114, 38);
            this.CancelBox.TabIndex = 15;
            this.CancelBox.Text = "Cancel All";
            this.CancelBox.UseVisualStyleBackColor = true;
            this.CancelBox.Click += new System.EventHandler(this.CancelBox_Click);
            // 
            // PidBox
            // 
            this.PidBox.Location = new System.Drawing.Point(39, 531);
            this.PidBox.Name = "PidBox";
            this.PidBox.Size = new System.Drawing.Size(100, 26);
            this.PidBox.TabIndex = 106;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(160, 527);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(164, 35);
            this.CloseButton.TabIndex = 107;
            this.CloseButton.Text = "Close Position";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 534);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 20);
            this.label6.TabIndex = 108;
            this.label6.Text = "id:";
            // 
            // BalanceBox
            // 
            this.BalanceBox.Location = new System.Drawing.Point(425, 536);
            this.BalanceBox.Name = "BalanceBox";
            this.BalanceBox.ReadOnly = true;
            this.BalanceBox.Size = new System.Drawing.Size(452, 26);
            this.BalanceBox.TabIndex = 109;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(350, 539);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 110;
            this.label7.Text = "balance:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 632);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BalanceBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.PidBox);
            this.Controls.Add(this.CancelBox);
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
            this.Controls.Add(this.OrdersBox);
            this.Controls.Add(this.PositionsBox);
            this.Name = "MainForm";
            this.Text = "Bitcoin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PositionsBox;
        private System.Windows.Forms.TextBox OrdersBox;
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
        private System.Windows.Forms.Button CancelBox;
        private System.Windows.Forms.TextBox PidBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BalanceBox;
        private System.Windows.Forms.Label label7;
    }
}

