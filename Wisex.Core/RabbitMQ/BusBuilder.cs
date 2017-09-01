using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisex.Core.RabbitMQ
{
    /// <summary>
    /// 消息服务器连接器
    /// </summary>
    public class BusBuilder
    {
        public static IBus CreateMessageBus()
        {
            //消息服务器连接字符串
            var connectionString = ConfigurationManager.ConnectionStrings["RabbitMQ"];
            if (connectionString == null || connectionString.ConnectionString == string.Empty)
            {
                throw new Exception("messageserver connection string is missing or empty");
            }
         //   string connString = "host=localhost:5672;username=guest;password=guest";
            return RabbitHutch.CreateBus(connectionString.ConnectionString);
            // return RabbitHutch.CreateBus(connectionString.ConnectionString);
        }
    }
}
