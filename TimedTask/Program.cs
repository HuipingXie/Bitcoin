using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using BitfinexAPI;
using SqlUtility;
using System.Threading;

/// <summary>
/// 此项目主要用来执行一些定时任务，及时更新数据库
/// </summary>
namespace TimedTask
{
    class Program
    {
        //static string apiKey = "LnfPu4YBTVAHF6aUEA770sYpje7GjVIVwWA94WJ29Ps";
        //static string secretKey = "pOnKgUb7d9SkPYtb9ZZPN4j5jdWemww5KfDoLxo1NMp";

        private BitfinexMethod bitfinxMethed = new BitfinexMethod(ConfigurationManager.AppSettings["ApiKey"],
                ConfigurationManager.AppSettings["SecretKey"]);

        private BitfinexSqlOperation bitfinexSqlOper = new BitfinexSqlOperation();

        static void Main(string[] args)
        {
            int countNum = 0;

            //一直循环，每次加1秒
            while (true)
            {
                Program p = new Program();
                //p.UpdateActiveOrderInfo();
                //每过61s，更新一次OrderHistory表
                if (countNum % 61 == 0)
                {
                    p.UpdateOrderHistory();
                    p.UpdateBanlanceInfo();
                }
                //每过10s,跟新一次positionInfo表
                if (countNum % 10 == 0)
                {
                    p.UpdatePositionInfo();
                }

                //记数每+1，程序停留1s
                countNum++;
                Console.WriteLine(countNum);
                Thread.Sleep(1000);
            }


        }

        //更新Orderinfo表，即存储orderhistory的数据
        public async void UpdateOrderHistory()
        {
            List<OrderInfo> historyOrder = await bitfinxMethed.GetOrdersHistory(100);
            bitfinexSqlOper.AddOrderInfo(historyOrder);

        }

        //更新activeorderinfo表
        public async void UpdateActiveOrderInfo()
        {
            List<OrderInfo> activeOrder = await bitfinxMethed.GetActiveOrders();
            //一般来说，activeOrder没有内容
            //此处更新比较平凡，倾向于直接调用接口，如果要用数据库直接调用的话，需要将数据删掉，
            //因为activeorder的数量不确定
            if (activeOrder.Count != 0)
            {
                bitfinexSqlOper.AddOrderInfo(activeOrder);
            }
        }

        //获取activebalance的内容，并插入balanceinfo表中
        public async void UpdateBanlanceInfo()
        {
            List<BalanceInfo> banlanceinfo = await bitfinxMethed.GetBalances();
            bitfinexSqlOper.AddBalanceInfo(banlanceinfo);

        }

        //获取activeposition的列表，并插入positioninfo表中
        public async void UpdatePositionInfo()
        {
            List<PositionInfo> positionInfoList = await bitfinxMethed.GetActivePositions();
            bitfinexSqlOper.AddActivePositions(positionInfoList);

        }

    }
}
