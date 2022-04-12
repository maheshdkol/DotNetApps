using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;


namespace FirstCoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var NLogger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

            
            CreateWebHostBuilder(args).Build().Run();
            NLogger.Debug("Application Starting Up"); // Not working yet
            NLog.LogManager.Shutdown();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
            }).UseNLog();
        //UseNLog() issue => https://github.com/NLog/NLog.Web/issues/254
    }
}
