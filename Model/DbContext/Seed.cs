using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DbContext
{
    internal class Seed
    {
        static string _ConnectionString = ConfigurationManager.ConnectionStrings["SchatConnection"].ToString();
    }
}
