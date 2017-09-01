using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wisex.Common.DataTypeMgr
{
    /// <summary>
    /// 类型转换工具
    /// </summary>
    public class TypeConversionTool
    {
        public static Tuple<object, string> ConvertToTarget(string typeName, Type typeExtend, object originalVal)
        {
            object newVal = null;
            string errMsg = string.Empty;
            try
            {
                if (typeExtend.IsEnum && originalVal != null)
                {
                    var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(c => c.FullName == typeExtend.Assembly.FullName);
                    if (assembly != null)
                    {
                        var elemType = assembly.GetTypes().FirstOrDefault(c => c.Name == typeExtend.Name);
                        newVal = Convert.ToInt32(Enum.Parse(elemType, originalVal.ToString()));
                    }
                }
                else
                {
                    switch (typeName)
                    {
                        case "int": newVal = Convert.ToInt32(originalVal); break;
                        case "text": newVal = Convert.ToString(originalVal); break;
                        case "bigint": newVal = Convert.ToInt64(originalVal); break;
                        case "bit": newVal = Convert.ToBoolean(originalVal); break;
                        case "char": newVal = Convert.ToString(originalVal); break;
                        case "datetime": newVal = Convert.ToString(originalVal); break;
                        case "decimal": newVal = Convert.ToDecimal(originalVal); break;
                        case "float": newVal = Convert.ToDouble(originalVal); break;
                        case "money": newVal = Convert.ToDecimal(originalVal); break;
                        case "nchar": newVal = Convert.ToString(originalVal); break;
                        case "ntext": newVal = Convert.ToString(originalVal); break;
                        case "numeric": newVal = Convert.ToDecimal(originalVal); break;
                        case "nvarchar": newVal = Convert.ToString(originalVal); break;
                        case "real": newVal = Convert.ToSingle(originalVal); break;
                        case "smalldatetime": newVal = Convert.ToDateTime(originalVal); break;
                        case "smallint": newVal = Convert.ToInt16(originalVal); break;
                        case "smallmoney": newVal = Convert.ToDecimal(originalVal); break;
                        case "timestamp": newVal = Convert.ToDateTime(originalVal); break;
                        case "tinyint": newVal = Convert.ToByte(originalVal); break;
                        case "varchar": newVal = Convert.ToString(originalVal); break;
                        case "Variant": newVal = originalVal; break;
                        default:

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.ToString();
            }
            return Tuple.Create(newVal, errMsg);
        }
    }
}
