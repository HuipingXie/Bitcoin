using System;
using System.Collections.Generic;
using System.Windows.Forms;

using BitfinexAPI;

namespace Portal
{
    public partial class MainForm : Form
    {
        private List<BalanceInfo> _balance;
        private List<OrderInfo> _orders;

        public MainForm()
        {
            InitializeComponent();

            Init();
        }

        private async void Init()
        {
            _orders = await Program.Backend.GetOrdersHistory();
            _balance = await Program.Backend.GetBalances();

            RefreshTimer.Enabled = true;
            RefreshButton.Enabled = true;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshTimer_Tick(null, null);
        }

        private async void ExecuteButton_Click(object sender, EventArgs e)
        {
            string symbol = SymbolBox.Text;
            decimal amount = decimal.Parse(AmountBox.Text);
            decimal price = decimal.Parse(PriceBox.Text);
            OrderSide side = (OrderSide)Enum.Parse(typeof(OrderSide), SideBox.Text);
            OrderType type = (OrderType)Enum.Parse(typeof(OrderType), TypeBox.Text);

            var result = await Program.Backend.CreateOrder(symbol, amount, price, side, type);

            MessageBox.Show("ok");
        }

        private async void CancelButton_Click(object sender, EventArgs e)
        {
            var result = await Program.Backend.CancelAllOrders();

            MessageBox.Show((string)result["result"]);
        }

        private async void CloseButton_Click(object sender, EventArgs e)
        {
            long id = long.Parse(PidBox.Text);
            var result = await Program.Backend.ClosePosition(id);

            MessageBox.Show((string)result["message"]);
        }

        private void PositionsView_ItemActivate(object sender, EventArgs e)
        {
            PidBox.Text = PositionsView.SelectedItems[0].Text;
        }

        private async void RefreshTimer_Tick(object sender, EventArgs e)
        {
            var positions = await Program.Backend.GetActivePositions();

            decimal sum = 0;
            PositionsView.Items.Clear();
            foreach (var i in positions)
            {
                PositionsView.Items.Add(new ListViewItem(new string[]{
                    i.id.ToString(),
                    i.symbol.ToUpper(),
                    i.amount.ToString("N2"),
                    i.base_price.ToString("N2"),
                    (i.base_price * i.amount).ToString("N2"),
                    i.pl.ToString("N2"),
                }));

                sum += i.pl;
            }

            var orders = await Program.Backend.GetActiveOrders();
            orders.AddRange(_orders);

            OrdersView.Items.Clear();
            foreach (var i in orders)
                OrdersView.Items.Add(new ListViewItem(new string[] {
                    i.symbol.ToUpper(),
                    i.side.ToString(),
                    i.price.GetValueOrDefault().ToString("N2"),
                    i.original_amount.ToString("N2"),
                    i.type.ToString(),
                    i.avg_execution_price.ToString("N2"),
                    i.executed_amount.ToString("N2"),
                    i.timestamp.ToLocalTime().ToString(),
                }));

            BalanceBox.Text = "float: " + sum.ToString("N2");
            foreach (var i in _balance)
                if (i.type == WalletType.TRADING)
                    if (i.currency == "usd")
                        BalanceBox.Text += "      deposit: " + i.amount.ToString("N2")
                            + "      available: " + i.available.ToString("N2");
        }
    }
}
