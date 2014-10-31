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
        /// 检查服务存在的存在性
        /// DisplayName 是服务的显示名称
        /// </summary>
        /// <param name=" NameService ">服务名</param>
        /// <returns>存在返回 true,否则返回 false;</returns>
        public static void isServiceIsExisted(string NameService, out bool isExistService, out bool isEnable)
        {
            isExistService = false;
            isEnable = false;
            ServiceController[] services = ServiceController.GetServices();

            foreach (ServiceController s in services)
            {
                if (s.DisplayName.ToLower().Contains(NameService.ToLower()))
                {
                    isExistService = true;
                    if (s.Status == ServiceControllerStatus.Running)
                    {
                        isEnable = true;
                    }
                    else
                    {
                        break;
                    }
                }
               
            }
        }

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
