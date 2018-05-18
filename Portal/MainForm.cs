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
                    i.original_amount.ToString("N2") + " / " + i.executed_amount.ToString("N2"),
                    i.price.GetValueOrDefault().ToString("N2") + " / " + i.avg_execution_price.ToString("N2"),
                    i.type.ToString(),
                    i.timestamp.ToLocalTime().ToString(),
                }));

            var balance = await Program.Backend.GetBalances();

            foreach (var i in balance)
                if (i.amount > 0)
                    BalanceView.Items.Add(new ListViewItem(new string[] {
                        i.type.ToString(),
                        i.currency.ToUpper(),
                        i.amount.ToString("N2"),
                        i.available.ToString("N2"),
                    }));
        }

        private async void ExecuteButton_Click(object sender, EventArgs e)
        {
            string symbol = SymbolBox.Text;
            decimal amount = decimal.Parse(AmountBox.Text);
            decimal price = decimal.Parse(PriceBox.Text);
            OrderSide side = (OrderSide)Enum.Parse(typeof(OrderSide), SideBox.Text);
            OrderType type = (OrderType)Enum.Parse(typeof(OrderType), TypeBox.Text);

            var result = await Program.Backend.CreateOrder(symbol, amount, price, side, type);

            MessageBox.Show("id: " + result.id.ToString());
            RefreshStatus();
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
                    i.amount.ToString("N2"),
                    i.base_price.ToString("N2"),
                    (i.base_price * i.amount).ToString("N2"),
                    i.pl.ToString("N2"),
                    i.swap.ToString("N2"),
                    i.timestamp.ToLocalTime().ToString(),
                }));

                sum += i.pl;
            }

            FloatBox.Text = sum.ToString("N2");

            var orders = await Program.Backend.GetActiveOrders();

            OrdersView.Items.Clear();
            foreach (var i in orders)
                OrdersView.Items.Add(new ListViewItem(new string[] {
                    i.id.ToString(),
                    i.is_live.ToString(),
                    i.is_cancelled.ToString(),
                    i.symbol.ToUpper(),
                    i.side.ToString(),
                    i.original_amount.ToString("N2") + " / " + i.executed_amount.ToString("N2"),
                    i.price.GetValueOrDefault().ToString("N2") + " / " + i.avg_execution_price.ToString("N2"),
                    i.type.ToString(),
                    i.timestamp.ToLocalTime().ToString(),
                }));
        }
    }
}
