using AI_Sports.AISports.Http;
using AI_Sports.AISports.View.Pages;
using AI_Sports.Proto;
using AI_Sports.Service;
using AISports.HeartBeat;
using Com.Bdl.Proto;
using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace AI_Sports
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        MemberService memberService = new MemberService();
        /// <summary>
        /// 应用启动的时候生命周期
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {

            //全局异常处理机制，UI异常
            Current.DispatcherUnhandledException += App_OnDispatcherUnhandledException;
            //全局异常处理机制，线程异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
           

            //启动netty
            Thread th = new Thread(() =>
            {
                try
                {
                    NettyLuncher.GetInstance().Start().Wait();
                    

                }
                catch (AggregateException ee)
                {
                    App.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        MessageBoxX.Show("提示","Socket通信端口被占用");
                        System.Environment.Exit(0);
                    }));
                }
            });
            th.Start();
            //大数据线程
            //每隔五分钟上传二十条数据
            Thread bdth = new Thread(() =>
            {
                while (true)
                {
                    try {
                        BigDataOfficer bigDataOfficer = new BigDataOfficer();
                        bigDataOfficer.Run();
                        //int heartBeatRate = (int)CommUtil.GetBigDataRate();
                        Thread.Sleep(1000 * 300);
                        //Console.WriteLine("-----------------boom");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("异常");
                        Console.WriteLine(ex.ToString());
                    }

                }
                
                
            });
            bdth.Start();
            //心跳线程
            Thread hbth = new Thread(() =>
            {

                ProtoBufSocket socket = null;
                try
                {
                    socket = new ProtoBufSocket();
                    socket.Connect();
                }
                catch (Exception exception)
                {
                    Console.WriteLine("连接失败:" + exception.StackTrace);
                    TcpHeartBeatUtils.WriteLogFile("连接失败:" + exception.StackTrace);
                }

                while (true)
                {
                    try
                    {
                        BodyStrongMessage bodyStrongMessage = new BodyStrongMessage
                        {
                            MessageType = BodyStrongMessage.Types.MessageType.Heaerbeatreq,
                            //可能为null
                            HeartbeatRequest = TcpHeartBeatUtils.GetHeartBeatByCurrent()
                        };
                        socket.SendMessage(bodyStrongMessage);
                        Console.WriteLine("发送msg!!");
                        //Thread.Sleep(5000);
                    }
                    catch (Exception eee)
                    {
                        Console.WriteLine("发送msg失败" + eee.StackTrace);
                        TcpHeartBeatUtils.WriteLogFile("发送msg失败" + eee.StackTrace);
                    }
                    finally
                    {
                        Thread.Sleep(5000);
                    }
                }

            });
            hbth.Start();
            try
            {
                //清楚APP.config中的登陆缓存
                memberService.Logout();
                //起调UWP蓝牙项目
                Process process = new Process();
                Process.Start(new ProcessStartInfo("bluetoothzcr:"));
            }
            catch (Exception ex)
            {

                logger.Error("蓝牙UWP启动失败" + ex.ToString());

            }

            base.OnStartup(e);
        }

        
        


        /// <summary>
        /// 退出的时候清理各种资源，尤其是Netty端口占用
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e)
        {
            System.Environment.Exit(0);
            base.OnExit(e);
        }

        /// <summary>
        /// UI线程抛出全局异常事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                logger.Error("UI线程全局异常" + e.Exception.ToString());
                if (e.Exception is MySqlException)
                {
                    //MessageBox.Show(LanguageUtils.GetCurrentLanuageStrByKey("App.DbException"));
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                logger.Error("不可恢复的UI线程全局异常" + ex.ToString());

                System.Environment.Exit(0);
            }
        }

        /// <summary>
        /// 非UI线程抛出全局异常事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var exception = e.ExceptionObject as Exception;
                if (exception != null)
                {
                    logger.Error("非UI线程全局异常" + exception.ToString());

                }
            }
            catch (Exception ex)
            {
                logger.Error("不可恢复的非UI线程全局异常" + ex.ToString());

                System.Environment.Exit(0);
            }
        }

    }
}
