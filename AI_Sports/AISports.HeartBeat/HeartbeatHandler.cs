using AI_Sports.AISports.Util;
using Com.Bdl.Proto;
using DotNetty.Transport.Channels;
using Microsoft.Extensions.Logging;
using NLog;
using System;

namespace AISports.HeartBeat
{
    internal class HeartbeatHandler : ChannelHandlerAdapter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        //链接建立时出发，主动给客户端发数据
        public override void ChannelActive(IChannelHandlerContext context)
        {
            logger.Info("连接建立成功与宝德龙云平台");
          
        }


        //	重写基类的方法，当消息到达时触发，这里收到消息后，在控制台输出收到的内容，并原样返回了客户端
        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            
            
            var buffer = message as BodyStrongMessage;
            Console.WriteLine("收到数据:" + JsonTools.Obj2JSONStrNew(buffer));
            //BodyStrongMessage response = new BodyStrongMessage();
            //response.Sequence = buffer.Sequence > Int32.MaxValue - 1 ? 0 : buffer.Sequence + 1;
            if (buffer.MessageType !=  BodyStrongMessage.Types.MessageType.Heaerbeatresp) {
                return;
            }
            Console.WriteLine("回复的消息："+buffer.MessageType.ToString());
            switch (buffer.HeartbeatResponse.ResponseType) {
                //延长使用时间，注意区分9999和一般时间
                case HeartbeatResponse.Types.ResponseType.Addusetime:
                    TcpHeartBeatUtils.AddUseTime(buffer.HeartbeatResponse);
                    break;
                //正常心跳不做处理
                case HeartbeatResponse.Types.ResponseType.Nomal:

                    break;
                //上锁
                case HeartbeatResponse.Types.ResponseType.Lock:
                    TcpHeartBeatUtils.LockUse(buffer.HeartbeatResponse);
                    break;
                //解锁
                case HeartbeatResponse.Types.ResponseType.Unlock:
                    TcpHeartBeatUtils.UnLockUse(buffer.HeartbeatResponse);
                    break;
            }

        }

        //捕获 异常，并输出到控制台后断开链接，提示：客户端意外断开链接，也会触发
        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            context.CloseAsync();
        }
    }
}
 