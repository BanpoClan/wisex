using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QiGuanBaoCustomerEntities;
using Wisex.Core.Elastic;
using Nest;

namespace Wisex.Service.ESServices
{
    public class ESService : IESService
    {


        public string Query(string name)
        {

            ESRequest es = new ESRequest( "enterprise-type");
            string json_query = @"
            { ""query"":{
                    ""match"":{
                        ""baseInfo.industry"":""" + name + @"""
                    }
                }
            }
            ";

            return es.ExecuteQeury(json_query);
        }
    }
}
