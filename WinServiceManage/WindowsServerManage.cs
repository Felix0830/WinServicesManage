using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceProcess;

namespace WinServiceManage
{
    public class WindowsServerManage
    {
        /// <summary>
        /// 检查服务存在的存在性（可以是服务的显示名称或是运行名称）
        /// DisplayName 是服务的显示名称
        /// ServiceName 是服务运行的名称
        /// </summary>
        /// <param name="serviceName">服务名</param>
        /// <returns>存在返回 true,否则返回 false;</returns>
        public static void IsExistedService(string serviceName, out bool isExistService, out bool isEnable)
        {
            isExistService = false;
            isEnable = false;
            ServiceController[] services = ServiceController.GetServices();

            foreach (ServiceController sc in services)
            {
                if (sc.DisplayName.ToUpper().Contains(serviceName.ToUpper())
                    || sc.ServiceName.ToUpper().Equals(serviceName.ToUpper()))
                {
                    isExistService = true;
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        isEnable = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        public static bool StartService(string sName)
        {
            try
            {
                ServiceController serviceObj = new ServiceController(sName);
                serviceObj.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
