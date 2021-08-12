using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Kuant.Config
{
    public static class DefaultConfig
    {
        public static readonly double DefaultNotional;
        public static readonly char DefaultDataKeyDelimiter;
        static DefaultConfig()
        {
            //todo : replace hard-coded adress
            using (StreamReader r = new StreamReader(@"D:\Data\GitProjects\KuantDotNet\Kuant.Config\Config.json"))
            {
                string json = r.ReadToEnd();
                var stuff = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                if (!Double.TryParse((string)stuff["DefaultNotional"], out DefaultNotional))
                {
                    throw new Exception("Initialize config failed.");
                }
                if (!Char.TryParse((string)stuff["DefaultDataKeyDelimiter"], out DefaultDataKeyDelimiter))
                {
                    throw new Exception("Initialize config failed.");
                }
            }
        }
    }
}
