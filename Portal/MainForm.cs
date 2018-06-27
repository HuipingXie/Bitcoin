using System;
using System.Windows.Forms;

using BitfinexAPI;

namespace Portal
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Init();
            SymbolBoxHint();
            this.radioBtnLimit.Checked = true;
        }

        private async void Init()
        {
            var orders = await Program.Backend.GetOrdersHistory();

            foreach (var i in orders)
                TradesView.Items.Add(new ListViewItem(new string[] {
                    i.id.ToString(),
                    i.is_live.ToString(),
                    i.is_cancelled.ToString(),
                    i.symbol.ToUpper(),
                    i.side.ToString(),
                    i.original_amount.ToString("N4") + " / " + i.executed_amount.ToString("N4"),
                    i.price.GetValueOrDefault().ToString("N4") + " / " + i.avg_execution_price.ToString("N4"),
                    i.type.ToString(),
                    i.timestamp.ToLocalTime().ToString(),
                }));

            var balance = await Program.Backend.GetBalances();

            foreach (var i in balance)
                if (i.amount > 0)
                    BalanceView.Items.Add(new ListViewItem(new string[] {
                        i.type.ToString(),
                        i.currency.ToUpper(),
                        i.amount.ToString("N4"),
                        i.available.ToString("N4"),
                    }));
        }

        private async void CancelButton_Click(object sender, EventArgs e)
        {
            long id = long.Parse(OidBox.Text);
            var result = await Program.Backend.CancelOrder(id);

            MessageBox.Show("id: " + result.id.ToString());
            RefreshStatus();
        }

        private async void CloseButton_Click(object sender, EventArgs e)
        {
            long id = long.Parse(PidBox.Text);
            var result = await Program.Backend.ClosePosition(id);

            MessageBox.Show((string)result["message"]);
            RefreshStatus();
        }

        private void PositionsView_ItemActivate(object sender, EventArgs e)
        {
            PidBox.Text = PositionsView.SelectedItems[0].Text;
        }

        private void OrdersView_ItemActivate(object sender, EventArgs e)
        {
            OidBox.Text = OrdersView.SelectedItems[0].Text;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshStatus();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshStatus();
        }

        private async void RefreshStatus()
        {
            var positions = await Program.Backend.GetActivePositions();

            decimal sum = 0;
            PositionsView.Items.Clear();
            foreach (var i in positions)
            {
                PositionsView.Items.Add(new ListViewItem(new string[]{
                    i.id.ToString(),
                    i.symbol.ToUpper(),
                    i.amount.ToString("N4"),
                    i.base_price.ToString("N4"),
                    (i.base_price * i.amount).ToString("N4"),
                    i.pl.ToString("N4"),
                    i.swap.ToString("N4"),
                    i.timestamp.ToLocalTime().ToString(),
                }));

                sum += i.pl;
            }

            FloatBox.Text = sum.ToString("N4");

            var orders = await Program.Backend.GetActiveOrders();

            OrdersView.Items.Clear();
            foreach (var i in orders)
                OrdersView.Items.Add(new ListViewItem(new string[] {
                    i.id.ToString(),
                    i.is_live.ToString(),
                    i.is_cancelled.ToString(),
                    i.symbol.ToUpper(),
                    i.side.ToString(),
                    i.original_amount.ToString("N4") + " / " + i.executed_amount.ToString("N4"),
                    i.price.GetValueOrDefault().ToString("N4") + " / " + i.avg_execution_price.ToString("N4"),
                    i.type.ToString(),
                    i.timestamp.ToLocalTime().ToString(),
                }));
        }


        //以下是新增代码
        private string orderType = "";
        private string[] symbolArray = { "btcusd", "bchusd", "eosusd", "ethusd", "etcusd", "iotusd", "ltcusd", "xmrusd", "neousd", "omgusd", "xrpusd", "zecusd" };



        //下单成功之后清空textbox
        private void ClearTextBox()
        {
            this.AmountBox.Text = "";
            this.PriceBox.Text = "";
            this.SymbolBox.Text = "";
            this.radioBtnLimit.Checked = true;
        }

        //给symbolBox设置提示内容
        public void SymbolBoxHint()
        {
            this.SymbolBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.SymbolBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            foreach (string symbol in symbolArray)
            {
                this.SymbolBox.AutoCompleteCustomSource.Add(symbol);
            }
        }

        //获取type的类型，并设置给orderType变量
        public void SetOrderType()
        {
            if (this.radioBtnLimit.Checked)
            {
                orderType = "LIMIT";
            }
            else if (this.radioBtnMarket.Checked)
            {
                orderType = "MARKET";
            }
            else if (this.radioBtnExcLimit.Checked)
            {
                orderType = "EXCHANGE_LIMIT";
            }
            else if (this.radioBtnExcMarket.Checked)
            {
                orderType = "EXCHANGE_MARKET";
            }

            //
        }


        private void buttonBigOrder_Click(object sender, EventArgs e)
        {
            
            TradeRecord traderec = new TradeRecord();
            traderec.Show();
        }

        private async void buttonBuy_Click(object sender, EventArgs e)
        {
            //先给orderType赋值
            SetOrderType();

            string symbol = SymbolBox.Text;
            decimal amount = decimal.Parse(AmountBox.Text);
            decimal price = decimal.Parse(PriceBox.Text);

            string sideBoxText = "BUY";

            OrderSide side = (OrderSide)Enum.Parse(typeof(OrderSide), sideBoxText);
            OrderType type = (OrderType)Enum.Parse(typeof(OrderType), orderType);

            var result = await Program.Backend.CreateOrder(symbol, amount, price, side, type);

            ClearTextBox();
            //MessageBox.Show(orderType + symbol + amount + price);
            MessageBox.Show("id: " + result.id.ToString());
            RefreshStatus();
        }

        private async void buttonSell_Click(object sender, EventArgs e)
        {
            //先给orderType赋值
            SetOrderType();
            //此处要不要加一些界面的提醒，如果输入的某项为0等...待定

            string symbol = SymbolBox.Text;
            decimal amount = decimal.Parse(AmountBox.Text);
            decimal price = decimal.Parse(PriceBox.Text);

            string sideBoxText = "SELL";

            OrderSide side = (OrderSide)Enum.Parse(typeof(OrderSide), sideBoxText);
            OrderType type = (OrderType)Enum.Parse(typeof(OrderType), orderType);

            var result = await Program.Backend.CreateOrder(symbol, amount, price, side, type);

            ClearTextBox();
            //MessageBox.Show(orderType+symbol+amount+price);
            MessageBox.Show("id: " + result.id.ToString());
            RefreshStatus();
        }

        private void radioBtnMarket_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnMarket.Checked)
            {
                PriceBox.Text = "1.00";
                PriceBox.Enabled = false;
            }
            else
            {
                PriceBox.Text = "";
                PriceBox.Enabled = true;
            }

        }

        private void radioBtnExcMarket_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnExcMarket.Checked)
            {
                PriceBox.Text = "1.00";
                PriceBox.Enabled = false;
            }
            else
            {
                PriceBox.Text = "";
                PriceBox.Enabled = true;
            }
        }


    }
}
