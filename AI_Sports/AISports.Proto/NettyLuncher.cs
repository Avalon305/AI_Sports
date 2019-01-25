using DotNetty.Handlers.Logging;
using DotNetty.Handlers.Tls;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DotNetty.Codecs;
using DotNetty.Buffers;
using DotNetty.Codecs.Protobuf;

namespace AI_Sports.Proto
{
    public class NettyLuncher
    {
        private volatile static NettyLuncher instance = new NettyLuncher();

        public static NettyLuncher GetInstance()
        {
            return instance;
        }
        private NettyLuncher()
        {

        }

        private ManualResetEvent _mainThread = new ManualResetEvent(false);
        public void ShutdownGracefully()
        {
            _mainThread.Set();
        }

        public async Task Start()
        {

            int port = 6920;
            string p = ConfigurationManager.AppSettings["NettyPort"];
            if (p == null || "".Equals(p))
            {
                port = int.Parse(p);
            }


            var bossGroup = new MultithreadEventLoopGroup(1);
            var workerGroup = new MultithreadEventLoopGroup();
            try
            {
                var bootstrap = new ServerBootstrap();
                bootstrap
                    .Group(bossGroup, workerGroup) //  
                    .Channel<TcpServerSocketChannel>() // 
                    .Option(ChannelOption.SoBacklog, 100) //  
                    .Handler(new LoggingHandler("SRV-LSTN")) // 
                    .ChildHandler(new ActionChannelInitializer<ISocketChannel>(channel =>
                    { // 
                        IChannelPipeline pipeline = channel.Pipeline;
                        pipeline.AddLast("frameDecoder", new ProtobufVarint32FrameDecoder());
                        pipeline.AddLast("decoder", new ProtobufDecoder(Message.Parser));
                        pipeline.AddLast("frameEncoder", new ProtobufVarint32LengthFieldPrepender());
                        pipeline.AddLast("encoder", new ProtobufEncoder());
                        pipeline.AddLast("tcpHandler", new ProtocolHandler());
                    }));

                // bootstrap bind port 
                IChannel boundChannel = await bootstrap.BindAsync(port);
                //线程阻塞在这

                _mainThread.WaitOne();
                //关闭服务
                await boundChannel.CloseAsync();
            }
            finally
            {
                await Task.WhenAll(
                    bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)),
                    workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
            }
        }
    }
}
