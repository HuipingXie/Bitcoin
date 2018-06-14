using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitfinexAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

/// <summary>
/// 因为不同的表对应的数据可能存在不同的问题，因此add操作不同的表是独立的
/// </summary>

namespace SqlUtility
{
    public class BitfinexSqlOperation
    {
        private MysqlConnector mc;

        //
        public BitfinexSqlOperation(string server,string user,string password,string database,string port,string charset)
        {
            this.mc = new MysqlConnector(server, user, password, database);
            this.mc.server = server;
            this.mc.userid = user;
            this.mc.password = password;
            this.mc.database = database;
            this.mc.port=port;
            this.mc.charset = charset;
            
        }


        

        //将DateTime转成int的时间戳
        private int GetTimeStamp(DateTime dt)
        {
            DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
            int timeStamp = Convert.ToInt32((dt - dateStart).TotalSeconds);
            return timeStamp;
        }


        //1.1添加OrderInfo的数据,添加历史记录
        public int AddOrderInfo(List<OrderInfo> orderList)
        {
            

            string sqlString = "insert into `orderinfo`(id,symbol,exchange,price,avg_execution_price,side,type,timestamp,is_live,is_cancelled,is_hidden,was_forced,original_amount,remaining_amount,executed_amount) values";

            //
            foreach (OrderInfo order in orderList)
            {
                //添加到表的时候，avg_ex...等可能为空，错误还是比较多的，因此此处置为0
                if (order.avg_execution_price.ToString() == "")
                {
                    order.avg_execution_price = 0;
                }
                if (order.price.ToString() == "")
                {
                    order.price = 0;
                }

                string value = String.Format("({0},'{1}','{2}',{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12},{13},{14})", order.id, order.symbol, order.exchange, order.price, order.avg_execution_price, order.side, order.type, GetTimeStamp(order.timestamp).ToString(), order.is_live, order.is_cancelled, order.is_hidden, order.was_forced, order.original_amount, order.remaining_amount, order.executed_amount);
                sqlString += value + ",";
            }
            //删除字符串最末尾多出的“,”
            sqlString = sqlString.Substring(0, sqlString.Length - 1);
            return mc.ExeUpdate(sqlString);
        }


        //1.2获取历史订单OrderInfo信息，orderinfo表
        public List<OrderInfo> GetOrderHistory(int limit = 100)
        {
            return GetValueFromDB<OrderInfo>("orderinfo", 0, limit);
        }


        //2.1添加ActiveOrderInfo的内容
        public int AddActiveOrderInfo(List<OrderInfo> activeOrderList)
        {
            //MysqlConnector mc = new MysqlConnector();

            string sqlString = "insert into `activeorderinfo`(id,symbol,exchange,price,avg_execution_price,side,type,timestamp,is_live,is_cancelled,is_hidden,was_forced,original_amount,remaining_amount,executed_amount) values";

            //
            foreach (OrderInfo order in activeOrderList)
            {
                //添加到表的时候，avg_ex...可能为空，错误还是比较多的，因此此处置为0
                if (order.avg_execution_price.ToString() == "")
                {
                    order.avg_execution_price = 0;
                }
                if (order.price.ToString() == "")
                {
                    order.price = 0;
                }

                string value = String.Format("({0},'{1}','{2}',{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12},{13},{14})", order.id, order.symbol, order.exchange, order.price, order.avg_execution_price, order.side, order.type, GetTimeStamp(order.timestamp).ToString(), order.is_live, order.is_cancelled, order.is_hidden, order.was_forced, order.original_amount, order.remaining_amount, order.executed_amount);
                sqlString += value + ",";
            }
            //删除字符串最末尾多出的“,”
            sqlString = sqlString.Substring(0, sqlString.Length - 1);

            return mc.ExeUpdate(sqlString);

        }

        //2.2获取activeorderinfo表中的数据
        public List<OrderInfo> getActiveOrderInfo(int limit)
        {
            return GetValueFromDB<OrderInfo>("activeorderinfo", 0, limit);
        }


        //3.1添加activepositions表中的数据
        public int AddActivePositions(List<PositionInfo> activePositionsList)
        {
            //MysqlConnector mc = new MysqlConnector();

            string sqlString = "insert into `positioninfo`(id,symbol,status,base,amount,timestamp,swap,pl) values";

            //
            foreach (PositionInfo position in activePositionsList)
            {

                string value = String.Format("({0},'{1}','{2}',{3},{4},'{5}',{6},{7})", position.id, position.symbol, position.status, position.base_price, position.amount, GetTimeStamp(position.timestamp).ToString(), position.swap, position.pl);
                sqlString += value + ",";
            }
            //删除字符串最末尾多出的“,”
            sqlString = sqlString.Substring(0, sqlString.Length - 1);
            return mc.ExeUpdate(sqlString);
        }

        //3.2获取 activepositions表中的数据
        public List<PositionInfo> GetActivePositions(int limit = 12)
        {
            return GetValueFromDB<PositionInfo>("positioninfo", 0, limit);
        }



        //4.1添加balanceinfo表中的数据
        public int AddBalanceInfo(List<BalanceInfo> balanceInfoList)
        {
            //MysqlConnector mc = new MysqlConnector();

            string sqlString = "insert into `balanceinfo`(type,currency,amount,available) values";

            //
            foreach (BalanceInfo balanceItem in balanceInfoList)
            {

                string value = String.Format("('{0}','{1}',{2},{3})", balanceItem.type, balanceItem.currency, balanceItem.amount, balanceItem.available);
                sqlString += value + ",";
            }
            //删除字符串最末尾多出的“,”
            sqlString = sqlString.Substring(0, sqlString.Length - 1);
            return mc.ExeUpdate(sqlString);
        }


        //4.2获取balanceInfo表中的数据，返回格式为List<BalanceInfo>
        public List<BalanceInfo> GetBalanceInfos(int limit = 17)
        {
            return GetValueFromDB<BalanceInfo>("balanceinfo", 0, limit);
        }


        //此处为通用的数据库操作,但是因为不同的表可能出现的问题不一样，因此待定吧
        public int InsertValueToDB<T>(string databaseName, List<T> listData)
        {


            return 0;
        }


        //此处为通用的获取数据库内容的函数
        public List<T> GetValueFromDB<T>(string databaseName, int start = 0, int limit = 100)
        {
            int end = start + limit;

            //MysqlConnector mc = new MysqlConnector();

            string sqlStr = String.Format("select * from {0} order by auto_id desc limit {1},{2}", databaseName, start, end);
            MySqlDataReader dr = mc.ExeQuery(sqlStr);
            List<Dictionary<string, object>> orderDictList = new List<Dictionary<string, object>>();
            while (dr.Read())
            {
                Dictionary<string, object> orderDict = new Dictionary<string, object>();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    string Tkey = dr.GetName(i).ToString();
                    var Tvalue = dr.GetValue(i);
                    orderDict.Add(Tkey, Tvalue);
                }
                orderDictList.Add(orderDict);
                //每读完一行，将字典的内容置空
                orderDict = null;
            }
            //先将类型转为json
            string data = JsonConvert.SerializeObject(orderDictList);
            //再将json格式化为List<OrderInfo>
            return JsonConvert.DeserializeObject<List<T>>(data);

        }


        //清除表中的数据
        public int ClearAllData(string dataName)
        {
            //MysqlConnector mc = new MysqlConnector();
            string sqlString = "truncate " + dataName;
            return mc.ExeUpdate(sqlString);
        }

    }
}
