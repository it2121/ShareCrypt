﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tester
{
    public static class Tools
    {
        public static string GetConnectionString(string name = "DF")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
