using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinServiceManage
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: 要兼容服务名和服务的显示名称，并且这个从配置文件读取（支持多个）
            var serviceName = ConfigHelper.GetServiceName();
            bool isExistService;
            bool isEnable;
            WindowsServerManage.isServiceIsExisted(serviceName, out isExistService, out isEnable);
            if (isExistService)
            {
                Console.Write("服务存在");
                if (isEnable)
                {
                    Console.WriteLine("，并已启动");
                }
                else
                {
                    Console.WriteLine("，但未启动，是否要启动（Y/N）");
                    IsStartService(serviceName);
                }
            }
            else
            {
                Console.WriteLine("没找到对应服务");
            }

            Console.WriteLine("请按任意键退出！");
            Console.ReadKey();
        }

        public static void IsStartService(string serviceName)
        {
            string inputKey = string.Empty;
            inputKey = Console.ReadLine().ToLower();

            //因为单线程，所以do循环只有在输入y或n才会退出,否则一直循环
            do
            {
                if (inputKey.Equals("y") || inputKey.Equals("n"))
                {
                    break; //跳出循环
                }

                Console.WriteLine("输入的指令不正确！请输入 Y/N ");
                inputKey = Console.ReadLine().ToLower();

            } while (true);

            if (inputKey.Contains("n"))
            {
                Console.WriteLine("正在退出……");
                Thread.Sleep(1000);
                //退出程序
                Environment.Exit(0);
            }

            //启动服务
            if (WindowsServerManage.StartService(serviceName))
            {
                Console.WriteLine("服务启动成功！");
            }
            else
            {
                Console.WriteLine("服务启动失败！");
            }
        }

    }
}
