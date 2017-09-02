using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisex.Core.Elastic
{
    using Nest;
    using System.IO;
    using System.Net;

    public class ESRequest
    {
        string es_host;
        string es_port;
        string es_index;
        string es_type;
        private string url;

        public ESRequest(string type, string port = "9200")
        {
            es_host = ESSetting.ESConStr;
            es_port = port;
            es_index = ESSetting.DefaultIndex;
            es_type = type;

            string requst_cache = "request_cache=true";
            url = string.Format("{0}/{2}/{3}/_search?{4}", es_host, es_port, es_index, es_type, requst_cache);
        }

        public string ExecuteQeury(string json_query)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "aplication/json";
            request.Method = "POST";
            request.Timeout = 1000 * 60;
            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(json_query);
                sw.Flush();
                sw.Close();
            }

            var response = (HttpWebResponse)request.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }


    }
}
