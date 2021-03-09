using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Zoomtel.Logging.Serilog;

namespace Zoomtel.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Console.WriteLine(str);
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
        return    WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
            //.UseLogging()
        }
    }
}
