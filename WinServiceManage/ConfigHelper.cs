using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WinServiceManage
{
    public class ConfigHelper
    {
        public static string GetServiceName()
        {
            string serviceName = ConfigurationManager.AppSettings["ServiceName"];
            return string.IsNullOrEmpty(serviceName) ? "" : serviceName;
        }
    }
}
