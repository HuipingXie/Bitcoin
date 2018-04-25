using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BitfinexAPI;

namespace Portal
{
    public partial class MainForm : Form
    {
        BitfinexMethod _backend = new BitfinexMethod(
            "R9iBSQT2tqFsnZAvFVx06x3JoMXIpXwI3AUxZxLbTmf",
            "bNEJpx1LYc7Cdn2QYbvoNpcu4NOAUSrofYwPETSgRAB");

        public MainForm()
        {
            InitializeComponent();
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            var positions = await _backend.GetActivePositions();

            PositionsBox.Text = "";
            foreach (var i in positions)
                PositionsBox.Text += i.id
                    + "  " + i.symbol
                    + "  " + i.amount
                    + "  " + i.base_price
                    + "  " + i.pl
                    + "\r\n";

            var orders = await _backend.GetActiveOrders();

            OrdersBox.Text = "";
            foreach (var i in orders)
                OrdersBox.Text += i.symbol + "  " + i.original_amount + "  " + i.side + "  " + i.price + "\r\n";
        }

        private async void ExecuteButton_Click(object sender, EventArgs e)
        {
            string symbol = SymbolBox.Text;
            decimal amount = decimal.Parse(AmountBox.Text);
            decimal price = decimal.Parse(PriceBox.Text);
            string side = SideBox.Text;
            string type = TypeBox.Text;

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
