using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace Wisex.Core.Elastic
{
    public class ESSetting
    {
        public static string ESConStr =  System.Configuration.ConfigurationManager.AppSettings["ESServer"];
        public static string DefaultIndex = System.Configuration.ConfigurationManager.AppSettings["DefaultIndex"];
        public static Uri Node
        {
            get
            {
                return new Uri(ESConStr);
            }
        }
        public static ConnectionSettings ConnectionSettings
        {
            get
            {
                return new ConnectionSettings(Node).DefaultIndex(DefaultIndex);
            }
        }
    }
}
