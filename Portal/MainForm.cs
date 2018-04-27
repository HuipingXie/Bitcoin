using System;
using System.Configuration;
using System.Windows.Forms;

using BitfinexAPI;

namespace Portal
{
    public partial class MainForm : Form
    {
        BitfinexMethod _backend = new BitfinexMethod(
            ConfigurationManager.AppSettings["ApiKey"],
            ConfigurationManager.AppSettings["SecretKey"]);

        public MainForm()
        {
            InitializeComponent();
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            var positions = await _backend.GetActivePositions();

            decimal sum = 0;
            PositionsBox.Text = "";
            foreach (var i in positions)
            {
                PositionsBox.Text += i.id
                    + "    " + i.symbol
                    + "    " + i.amount.ToString("N4")
                    + "    " + i.base_price.ToString("N4")
                    + "    " + (i.base_price * i.amount).ToString("N4")
                    + "    " + i.pl.ToString("N4")
                    + "\r\n";

                sum += i.pl;
            }

            var btc = await _backend.GetTrades("BTCUSD");
            sum = sum * btc[0].price;

            var orders = await _backend.GetActiveOrders();

            OrdersBox.Text = "";
            foreach (var i in orders)
                OrdersBox.Text += i.symbol
                    + "  " + i.remaining_amount.ToString("N4")
                    + "  " + i.side
                    + "  " + i.avg_execution_price.ToString("N4")
                    + "  " + i.type
                    + "  " + i.timestamp
                    + "\r\n";

            var balance = await _backend.GetBalances();

            BalanceBox.Text = "net: " + sum.ToString("N4") + "    ";
            foreach (var i in balance)
                if (i.type == WalletType.TRADING)
                    if (i.currency == "usd")
                        BalanceBox.Text += i.currency
                            + ": " + i.amount.ToString("N4")
                            + ";  " + i.available.ToString("N4") + "   ";
        }

        private async void ExecuteButton_Click(object sender, EventArgs e)
        {
            string symbol = SymbolBox.Text;
            decimal amount = decimal.Parse(AmountBox.Text);
            decimal price = decimal.Parse(PriceBox.Text);
            OrderSide side = (OrderSide)Enum.Parse(typeof(OrderSide), SideBox.Text);
            OrderType type = (OrderType)Enum.Parse(typeof(OrderType), TypeBox.Text);

            var result = await _backend.CreateOrder(symbol, amount, price, side, type);

            MessageBox.Show("ok");
        }

        private async void CancelBox_Click(object sender, EventArgs e)
        {
            var result = await _backend.CancelAllOrders();

            MessageBox.Show((string)result["result"]);
        }

        private async void CloseButton_Click(object sender, EventArgs e)
        {
            long id = long.Parse(PidBox.Text);
            var result = await _backend.ClosePosition(id);

            MessageBox.Show((string)result["message"]);
        }
    }
}
