using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using System.Threading;
using BitfinexAPI;
using System.Configuration;

namespace Portal
{
    public partial class TradeRecord : Form
    {
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private BitfinexStream bs = new BitfinexStream();


        public TradeRecord()
        {
            InitializeComponent();
            ThreadPool.QueueUserWorkItem(h => AddTradeRecode("eosusd"), tokenSource.Token);
            ThreadPool.QueueUserWorkItem(h => AddTradeRecode("btcusd"), tokenSource.Token);
            ThreadPool.QueueUserWorkItem(h => AddTradeRecode("ethusd"), tokenSource.Token);
            ThreadPool.QueueUserWorkItem(h => AddTradeRecode("bchusd"), tokenSource.Token);
        }

        ~TradeRecord()
        {
            tokenSource.Cancel();
            bs.CloseAllSocketConnet();
        }

        public void AddTradeRecode(object symbolObj)
        {
            string symbol=symbolObj.ToString();
            if (symbol == "btcusd")
            {
                bs.RetrieveTrades(AddRecodeForBTC, symbol);
            }
            else if (symbol == "ethusd")
            {
                bs.RetrieveTrades(AddRecodeForETH, symbol);
            }
            else if (symbol == "eosusd")
            {
                bs.RetrieveTrades(AddRecodeForEOS, symbol);
            }
            else if (symbol == "bchusd")
            {
                bs.RetrieveTrades(AddRecodeForBCH, symbol);
            }


        }

        //构造大单交易数据：时间、名称、方向、数量、价格
        public ListViewItem getTradeRec(PairInfo pairinfo, string symbol)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = pairinfo.timestamp.ToString();
            lvi.SubItems.Add(symbol);
            string direction = "";
            //
            if (pairinfo.amount > 0)
            {
                direction = "买入";
                lvi.ForeColor = Color.Green;
            }
            else
            {
                direction = "卖出";
                lvi.ForeColor = Color.Red;
            }
            lvi.SubItems.Add(direction);
            lvi.SubItems.Add(Math.Abs(pairinfo.amount).ToString());
            lvi.SubItems.Add(pairinfo.price.ToString());
            return lvi;
        }


        private delegate void SetListCallBack(PairInfo p, string symbol);

        private void SetListView(PairInfo p, string symbol)
        {
            if (!tokenSource.IsCancellationRequested)
            {
                if (this.tradeDitail.InvokeRequired)
                {
                    SetListCallBack d = new SetListCallBack(SetListView);
                    this.tradeDitail.Invoke(d, new object[] {p, symbol });
                }
                else
                {
                    var item = this.getTradeRec(p, symbol);
                    this.tradeDitail.Items.Add(item);
                    //让滑动条显示在最下面
                    tradeDitail.Items[tradeDitail.Items.Count - 1].EnsureVisible();
                }
            }
        }

        //由于websocket的回调函数只接收PairInfo类型的一个参数，因此，针对不同的币种，需要写不同的函数
        //同时，争对不同的币种，提醒的数值设置也不同
        private void AddRecodeForETH(PairInfo p)
        {
            if (Math.Abs(p.amount) >=250)
            {
                this.SetListView(p, "ethusd");
            }
        }

        private void AddRecodeForBTC(PairInfo p)
        {
            if (Math.Abs(p.amount) >=20)
            {
                this.SetListView(p, "btcusd");
            }
        }

        private void AddRecodeForEOS(PairInfo p)
        {
            if (Math.Abs(p.amount) >=2500)
            {
                this.SetListView(p, "eosusd");
            }
        }

        private void AddRecodeForBCH(PairInfo p)
        {
            if (Math.Abs(p.amount) >=150)
            {
                this.SetListView(p, "bchusd");
            }
        }

    }
}
