using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Common.LogUtils;

namespace Wisex.Core.StructureMapWapperUtils
{
    public class StructureMapWapper
    {
        public static void Init()
        {
            try
            {
                ObjectFactory.Initialize(c =>
                {
                    c.AddConfigurationFromXmlFile("Config\\StructureMap\\Business.config");
                    c.AddConfigurationFromXmlFile("Config\\StructureMap\\DataAccess.config");
                });

            }
            catch (Exception ex)
            {
                //加系统日志
                LogHelper.Instance.Error("初始化StructureMap组件错误",ex);
                throw;
            }

        }

        public static T GetInstance<T>()
        {
            return ObjectFactory.TryGetInstance<T>();
        }
    }
}
