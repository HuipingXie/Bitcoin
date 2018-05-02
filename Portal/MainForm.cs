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
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            var positions = await Program.Backend.GetActivePositions();

            decimal sum = 0;
            PositionsBox.Text = "";
            foreach (var i in positions)
            {
                PositionsBox.Text += i.id
                    + "    " + i.symbol.ToUpper()
                    + "    " + i.amount.ToString("N2")
                    + "    " + i.base_price.ToString("N2")
                    + "    " + (i.base_price * i.amount).ToString("N2")
                    + "    " + i.pl.ToString("N2")
                    + "\r\n";

                sum += i.pl;
            }

            var orders = await Program.Backend.GetActiveOrders();

            OrdersBox.Text = "";
            foreach (var i in orders)
                OrdersBox.Text += i.symbol
                    + "  " + i.remaining_amount.ToString("N2")
                    + "  " + i.side
                    + "  " + i.avg_execution_price.ToString("N2")
                    + "  " + i.type
                    + "  " + i.timestamp
                    + "\r\n";

            var balance = await Program.Backend.GetBalances();

            BalanceBox.Text = "net: " + sum.ToString("N2");
            foreach (var i in balance)
                if (i.type == WalletType.TRADING)
                    if (i.currency == "usd")
                        BalanceBox.Text += "      " + i.currency.ToUpper()
                            + ": " + i.amount.ToString("N2")
                            + ";    " + i.available.ToString("N2");
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

        private async void CancelBox_Click(object sender, EventArgs e)
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
    }
}
