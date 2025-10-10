using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public static class ConfigurationLoader
    {
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)

                            .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);

            IConfigurationRoot config = builder.Build();

            return config.GetConnectionString("DefaultConnection");
        }
    }
}
