using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Common.LogUtils;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;

namespace Wisex.Dao.SystemControl
{
    public class MenuDao : BaseDao, IMenuDao
    {
        public void Add(Menu menu)
        {
            var fields = this.GetSystemObjectFields<Menu>();
            base.CustomAdd<Menu>(menu, fields);
        }

        public bool Update(Menu menu)
        {
            var fields = this.GetSystemObjectFields<Menu>();
            base.CustomUpdate<Menu>(menu, fields);
            return true;
        }

        public bool Delete(List<int> ids)
        {
            if (base.CustomDelete<Menu>(ids) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


        public Menu GetOne(Hashtable param)
        {
            return base.QueryForObject<Menu>("GetOneMenu", param);
        }

        public List<Menu> Query(string exp, string orderExp, bool isDesc = true)
        {
            var para = new Hashtable();

            var sql = $@"
                 SELECT * FROM menu WHERE  {exp} {orderExp} 
                ";
            if (isDesc)
            {
                sql = $"{sql} desc";
            }
            else
            {
                sql = $"{sql} asc";
            }
            para.Add("sql", sql);
            return base.QueryForList<Menu>("QueryMenu", para);
        }

        public ResultModel<Menu> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc")
        {
            ResultModel<Menu> result = new ResultModel<Menu>();
            var para = new Hashtable();

            var queryDataSql = $@"
                 SELECT  *
                      FROM    ( SELECT    * ,
                      ROW_NUMBER() OVER ( ORDER BY id DESC) AS Rank
                      FROM      dbo.Menu
                      ) AS t
                      WHERE  name LIKE '%{queryBase.Keywords}%' and t.rank BETWEEN {queryBase.StartIndex} AND {queryBase.StartIndex + queryBase.PageSize}

                ";

            para.Add("sql", queryDataSql);
            result.data = base.QueryForList<Menu>("QueryMenuPaging", para);
            result.length = queryBase.PageSize;
            para.Clear();

            var queryDataSqlCount = $@"
                  SELECT  *
                      FROM    ( SELECT    * ,
                      ROW_NUMBER() OVER ( ORDER BY id DESC) AS Rank
                      FROM      dbo.Menu
                      ) AS t
                      WHERE  name LIKE '%{queryBase.Keywords}%'
                ";
            para.Add("sql", queryDataSqlCount);

            LogHelper.Instance.Info(queryDataSql);
            result.recordsTotal = base.QueryForList<Menu>("QueryMenuPaging", para).Count;
            return result;
        }

       







    }
}
