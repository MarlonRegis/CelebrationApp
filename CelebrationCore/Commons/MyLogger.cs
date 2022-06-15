using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationCore.Commons
{
    public static class MyLogger 
    {

        public static void logInfo(string msg)
        {
            NLog.LogManager.GetLogger("logfile").Info(msg);
        }
    }
}
