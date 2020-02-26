using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDomain
{
    public class ConnectionStringFactory
    {
        public static string GetConnectionString()
        {
            var conStr = "data source=.;initial catalog=ExistekLibrary;integrated security=True;MultipleActiveResultSets=True;";

            return conStr;

            //return "name=BookContext";
        }
    }
}
