using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Core.RabbitMQ;

namespace Wisex.Core.RabbitMQ
{
    public class MQHelper
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        public static void Publish(Message msg)
        {
            //// 创建消息bus
            IBus bus = BusBuilder.CreateMessageBus();

            try
            {
                using (var publishChannel = bus.OpenPublishChannel())   //创建消息管道 
                {
                    publishChannel.Publish(msg, x => x.WithTopic(msg.MessageRouter));  //通过管道发送消息 
                }
            }
            catch (EasyNetQException)
            {
                //处理连接消息服务器异常 
                // MessageHelper.WriteFuntionExceptionLog("Publish", ex.Message + " | " + ex.StackTrace);

            }

            bus.Dispose();//与数据库connection类似，使用后记得销毁bus对象
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="msg"></param>
        public static void Subscribe(Message msg, IProcessMessage ipro)
        {
            //// 创建消息bus
            IBus bus = BusBuilder.CreateMessageBus();

            try
            {
                bus.Subscribe<Message>(msg.MessageID, message => ipro.ProcessMsg(message), x => x.WithTopic(msg.MessageRouter).WithArgument("x-ha-policy", "all"));

            }
            catch (EasyNetQException)
            {
                //处理连接消息服务器异常 
                //  MessageHelper.WriteFuntionExceptionLog("Subscribe", ex.Message + " | " + ex.StackTrace);
            }
        }
    }
}
