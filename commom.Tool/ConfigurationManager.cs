using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace common.Tools
{
    public class ConfigurationManager
    {
        public static IConfigurationRoot config;
        public static IConfigurationSection section;

        public static IConfigurationSection AppSettings => new ConfigurationBuilder().AddJsonFile(Directory.GetCurrentDirectory() + @"\appsettings.json")
            .Build()
            .GetSection("AppSetting");

        public static IConfigurationSection ConnectionStrings => new ConfigurationBuilder().AddJsonFile(Directory.GetCurrentDirectory() + @"\appsettings.json").Build().GetSection("Connection");
        //public static IConfigurationSection RedisConfig => new ConfigurationBuilder().AddJsonFile(Directory.GetCurrentDirectory() + @"\appsettings.json").Build().GetSection("RedisConfig");
        public static string GetSection(string key)
        {
            // return new ConfigurationBuilder().AddJsonFile(Directory.GetCurrentDirectory() + @"\appsettings.json").Build().GetSection(key);
            //var ddd = new ConfigurationBuilder().AddJsonFile(Directory.GetCurrentDirectory() + @"\appsettings.json");
            //var bbb = ddd.Build();
            //var ccc = ddd.Build().GetSection(key);
            //return ccc;

            JObject jsonConfig = (JObject)JsonConvert.DeserializeObject(System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + @"\appsettings.json", Encoding.Default));
            return jsonConfig[key].ToString();

        }

    }
}
