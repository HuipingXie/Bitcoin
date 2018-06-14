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


        private BitfinexMethod bitfinxMethed = new BitfinexMethod(
            ConfigurationManager.AppSettings["ApiKey"],
            ConfigurationManager.AppSettings["SecretKey"]
            );

        private BitfinexSqlOperation bitfinexSqlOper = new BitfinexSqlOperation(
            ConfigurationManager.AppSettings["Server"],
            ConfigurationManager.AppSettings["User"],
            ConfigurationManager.AppSettings["Password"],
            ConfigurationManager.AppSettings["Database"],
            ConfigurationManager.AppSettings["Port"],
            ConfigurationManager.AppSettings["Charset"]
            );

        static void Main(string[] args)
        {
            int countNum = 1;
            //当该数字达到一定程度，删除表中数据
            int delCount = 1;

            //一直循环，每次加1秒
            while (true)
            {
                Program p = new Program();
                //p.UpdateActiveOrderInfo();
                //每过80s，更新一次OrderHistory表
                if (countNum % 65 == 0)
                {
                    p.UpdateOrderHistory();
                }
                if (countNum % 75 == 0)
                {
                    p.UpdateBanlanceInfo(delCount);
                    countNum = 1;
                }

                //每过10s,更新一次positionInfo表
                if (countNum % 10 == 0)
                {
                    //p.UpdatePositionInfo();
                }

                //


                //记数每+1，程序停留1s
                Console.WriteLine(countNum);
                countNum++;
                delCount++;
                Thread.Sleep(1000);
            }


        }

        //更新Orderinfo表，即存储orderhistory的数据
        public async void UpdateOrderHistory()
        {
            List<OrderInfo> historyOrders = await bitfinxMethed.GetOrdersHistory(100);
            List<OrderInfo> newHistoryOrders = SelectNewOrdersHist(historyOrders);

            //如果新增的记录条数不为0，则更新数据库
            if (newHistoryOrders.Count != 0)
            {
                bitfinexSqlOper.AddOrderInfo(newHistoryOrders);
            }
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
        public async void UpdateBanlanceInfo(int delNum)
        {
            if (delNum % 3600==0)
            {
                bitfinexSqlOper.ClearAllData("balanceinfo");
            }
            List<BalanceInfo> banlanceinfo = await bitfinxMethed.GetBalances();
            bitfinexSqlOper.AddBalanceInfo(banlanceinfo);

        }

        //
        public void delTableValue(string tableName)
        {
            bitfinexSqlOper.ClearAllData(tableName);
        }


        //获取activeposition的列表，并插入positioninfo表中
        public async void UpdatePositionInfo()
        {
            List<PositionInfo> positionInfoList = await bitfinxMethed.GetActivePositions();
            bitfinexSqlOper.AddActivePositions(positionInfoList);

        }


        //选取接口返回数据中，数据库中不存在的ordershistory的记录
        public List<OrderInfo> SelectNewOrdersHist(List<OrderInfo> ordershistory)
        {
            List<long> apiordersIDList = ordershistory.Select(a => a.id).ToList();
            List<long> dbOrdersIDlist = bitfinexSqlOper.GetHistoryOrdersId();
            List<long> newOrderIDlist = apiordersIDList.Except(dbOrdersIDlist).ToList();

            List<OrderInfo> newOrderHistory = ordershistory.Where(x => newOrderIDlist.Contains(x.id)).ToList();
            return newOrderHistory;
        }



    }
}
