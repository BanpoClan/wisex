using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Common.LogUtils;
using Wisex.Entity.CommonModel;

namespace Wisex.Dao.BaseDaoCore
{
    /// <summary>
    /// 数据检索逻辑
    /// </summary>
    public abstract class DataRetrieveLogical: BaseDao
    {
        /// <summary>
        /// 要查询的表名称
        /// </summary>
        private string tableMame = null;
        /// <summary>
        /// 要查询的字段（作为where）
        /// </summary>
        private string likeQueryStr = null;
        /// <summary>
        /// 前台传递的查询参数
        /// </summary>
        private QueryBase queryBase = null;

        public DataRetrieveLogical(string tableMame , string likeQueryStr, QueryBase queryBase)
        {
            this.tableMame = tableMame;
            this.likeQueryStr = likeQueryStr;
            this.queryBase = queryBase;
        }

        /// <summary>
        /// 获取数据检索的SQL
        /// </summary>
        /// <param name="tableMame">数据表名称</param>
        /// <param name="likeQueryStr">查询字符串</param>
        /// <param name="queryBase">查询参数</param>
        /// <returns>元组：item1是查询的SQL  item2是查询数据的条数</returns>
        public virtual Tuple<string, string> GetDataRetrieveSQL()
        {
            var queryDataSql = string.Empty;
            var queryDataSqlCount = string.Empty;
            if (string.IsNullOrEmpty(likeQueryStr))
            {
                likeQueryStr = "1=1";
            }
            queryDataSql = $@"
                 SELECT  *
                      FROM    ( SELECT    * ,
                      ROW_NUMBER() OVER ( ORDER BY id ) AS Rank
                      FROM      dbo.{tableMame}
                      ) AS t
                      WHERE {likeQueryStr} and t.rank BETWEEN {queryBase.StartIndex} AND {queryBase.StartIndex + queryBase.PageSize}

                ";

            queryDataSqlCount = $@"
                  SELECT  count(1)
                      FROM    ( SELECT    * ,
                      ROW_NUMBER() OVER ( ORDER BY id ) AS Rank
                      FROM      dbo.{tableMame}
                      ) AS t
                      WHERE   {likeQueryStr}
                ";

            return Tuple.Create(queryDataSql, queryDataSqlCount);

        }

        /// <summary>
        /// 获取数据检索结果
        /// </summary>
        /// <typeparam name="T">指定返回的数据类型</typeparam>
        /// <param name="param">执行参数中的SQL。Item1是获取数据SQL  item2是获取数据条数</param>
        /// <returns>返回结果模型</returns>
        public virtual ResultModel<T> GetDataRetrieveResult<T>(Tuple<string, string> param)
        {
            ResultModel<T> result = new ResultModel<T>();
            var para = new Hashtable();
            LogHelper.Instance.Info(string.Format("获取数据SQL：{0}", param.Item1));
            para.Add("sql", param.Item1);
            result.data = QueryForList<T>($"CommonDataQuery", para);
            result.length = queryBase.PageSize;
            para.Clear();

            para.Add("sql", param.Item2);
            result.recordsTotal = QueryForList<T>($"CommonDataQuery", para).Count;
            return result;

        }

    }
}
