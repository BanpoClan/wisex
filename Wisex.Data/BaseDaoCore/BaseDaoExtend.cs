using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Common.Attributes;
using Wisex.Common.DataTypeMgr;
using Wisex.Common.LogUtils;
using Wisex.Dao.BaseDaoCore;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;

namespace Wisex.Dao
{
    public partial class BaseDao
    {
        #region Custom Query
        public ResultModel<T> GetWithPages<T>(QueryBase queryBase, string orderBy, string orderDir = "desc")
        {
            ResultModel<T> result = new ResultModel<T>();

            var typeT = typeof(T);
            var tableMame = string.Empty;
            var likeQueryStr = string.Empty;
            if (typeT.Name == "String")
            {
                var menuDataDetail = new MenuDataUtil();
                var dataDetail = menuDataDetail.GetMenuDetail(queryBase.MenuId);
                if (dataDetail != null && !string.IsNullOrEmpty(dataDetail.TableName))
                {
                    tableMame = dataDetail.TableName;

                    PrimitiveTypeDataRetrieveLogical primitiveTypeLogical = new PrimitiveTypeDataRetrieveLogical(tableMame, likeQueryStr, queryBase);
                    result = primitiveTypeLogical.GetDataRetrieveResult<T>(primitiveTypeLogical.GetDataRetrieveSQL());

                }
                else
                {
                    LogHelper.Instance.Warn("该菜单没有配置相关的数据表！");

                }


            }
            else
            {

                var attributes = AttributeUtils.CheckIsExistAttribute<T>(typeof(TableMappingAttribute));

                if (attributes.Length == 0)
                {
                    LogHelper.Instance.Warn("类型没有配置表映射关系！");
                }
                else
                {
                    var likeQueryFields = new List<string>();
                    foreach (var attribute in attributes)
                    {
                        var tmp = attribute as TableMappingAttribute;
                        if (tmp != null)
                        {
                            tableMame = tmp.TableName;
                            if (tmp.LikeQueryFields != null)
                            {
                                likeQueryFields.AddRange(tmp.LikeQueryFields.Split(','));

                            }
                            break;
                        }
                    }

                    likeQueryStr = GetLikeQueryStr(likeQueryFields, queryBase.Keywords);

                    GenericsTypeDataRetrieveLogical genericsTypeLogical = new GenericsTypeDataRetrieveLogical(tableMame, likeQueryStr, queryBase);
                    result = genericsTypeLogical.GetDataRetrieveResult<T>(genericsTypeLogical.GetDataRetrieveSQL());
                }
            }

            return result;
        }

        private string GetLikeQueryStr(List<string> columns, string keyWords)
        {
            List<string> str = new List<string>();
            foreach (var item in columns)
            {
                str.Add($"{item} LIKE '%{keyWords}%'");
            }
            return string.Join(" or ", str);
        }

        public T GetOne<T>(int id)
        {
            var typeT = typeof(T);

            TableMappingAttribute attribute = BaseDaoAttribute.GetTableMappingAttribute(typeT);
            if (attribute == null)
                return default(T);



            var sql = $@"SELECT *FROM {attribute.TableName} where id={id} ";

            var param = new Hashtable();
            param.Add("sql", sql);
            return QueryForObject<T>($"GetOne{attribute.TableName}", param);
        }
        #endregion

        #region Query Data by id
        public List<T> GetDataList<T>(string exp, string orderExp, bool isDesc = true)
        {
            var typeT = typeof(T);
            TableMappingAttribute attribute = BaseDaoAttribute.GetTableMappingAttribute(typeT);
            if (attribute == null)
                return null;

            var sql = $"SELECT *FROM dbo.{attribute.TableName} WHERE {exp}";
            var para = new Hashtable();
            para.Add("sql", sql);
            return QueryForList<T>($"Query{attribute.TableName}", para);

        }
        #endregion


        #region Custom Add
        public void CustomAdd<T>(T t, List<SystemObjectFields> fields)
        {
            //找到表名称
            var typeT = typeof(T);
            TableMappingAttribute attribute = BaseDaoAttribute.GetTableMappingAttribute(typeT);
            if (attribute == null)
                return;

            //新增用反射把各个字段赋值，动态创建插入语句
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
            var properties = typeT.GetProperties();
            foreach (var propertiy in properties)
            {
                var tmp = fields.FirstOrDefault(c => c.FieldName == propertiy.Name && !c.PKConstraint);
                if (tmp != null)
                {
                    list1.Add($"[{propertiy.Name}]");
                    var propertyType = propertiy.PropertyType;
                    var newVal = TypeConversionTool.ConvertToTarget(tmp.TypeName, propertyType, propertiy.GetValue(t));
                    var result = string.IsNullOrEmpty(newVal.Item2) ? newVal.Item1 : "";
                    list2.Add($"'{result}'");
                }

            }
            string mainSql = string.Join(",", list1);
            var subSql = string.Join(",", list2);
            var sql = $@"INSERT INTO [dbo].{attribute.TableName}
                       ({mainSql})
                 VALUES
                       ({subSql})";

            var para = new Hashtable();
            para.Add("sql", sql);
            this.Add($"Add{attribute.TableName}", sql);
        }
        #endregion

        #region Custom Update
        public void CustomUpdate<T>(T t, List<SystemObjectFields> fields)
        {
            //找到表名称
            var typeT = typeof(T);
            TableMappingAttribute attribute = BaseDaoAttribute.GetTableMappingAttribute(typeT);
            if (attribute == null)
                return;

            List<string> updateColumns = new List<string>();
            var properties = typeT.GetProperties();

            foreach (var propertiy in properties)
            {
                var tmp = fields.FirstOrDefault(c => c.FieldName == propertiy.Name && !c.PKConstraint);
                if (tmp != null)
                {
                    var propertyType = propertiy.PropertyType;
                    var str = $"[{tmp.FieldName}]='{TypeConversionTool.ConvertToTarget(tmp.TypeName, propertyType, propertiy.GetValue(t)).Item1}'";
                    updateColumns.Add(str);
                }

            }

            var PKConstraintColumnName = fields.FirstOrDefault(c => c.PKConstraint);
            var pType = properties.FirstOrDefault(c => c.Name == PKConstraintColumnName.FieldName);
            var PKConstraintColumnValue = TypeConversionTool.ConvertToTarget(PKConstraintColumnName.TypeName, pType.PropertyType, pType.GetValue(t)).Item1;

            var sql = $@" update {attribute.TableName} set {string.Join(",", updateColumns)} where {PKConstraintColumnName.FieldName}='{PKConstraintColumnValue}' ";
            var para = new Hashtable();
            para.Add("sql", sql);

            this.Update($"Update{attribute.TableName}", para);
        }
        #endregion

        #region Custom Delete
        public int CustomDelete<T>(List<int> ids)
        {
            //找到表名称
            var typeT = typeof(T);
            TableMappingAttribute attribute = BaseDaoAttribute.GetTableMappingAttribute(typeT);
            if (attribute == null)
                return -1;

            var sql = $@"DELETE FROM {attribute.TableName}  WHERE Id IN ({string.Join(",", ids)})";
            var para = new Hashtable();
            para.Add("sql", sql);
            return this.Delete($"Delete{attribute.TableName}", para);
        }
        #endregion

        #region 获取字段
        public List<SystemObjectFields> GetSystemObjectFields<T>()
        {
            var para = new Hashtable();
            var typeT = typeof(T);
            TableMappingAttribute attribute = BaseDaoAttribute.GetTableMappingAttribute(typeT);
            if (attribute == null)
                return null;

            para.Add("ObjectName", attribute.TableName);
            return QueryForList<SystemObjectFields>("QuerySystemObjectFields", para);
        }
        #endregion
    }
}

#region 注释代码

//var para = new Hashtable();

//var queryDataSql = string.Empty;
//var queryDataSqlCount = string.Empty;
//            if (string.IsNullOrEmpty(likeQueryStr))
//            {
//                likeQueryStr = "1=1";
//            }
//            queryDataSql = $@"
//                 SELECT  *
//                      FROM    ( SELECT    * ,
//                      ROW_NUMBER() OVER ( ORDER BY id ) AS Rank
//                      FROM      dbo.{tableMame}
//                      ) AS t
//                      WHERE {likeQueryStr} and t.rank BETWEEN {queryBase.StartIndex} AND {queryBase.StartIndex + queryBase.PageSize}

//                ";

//            queryDataSqlCount = $@"
//                  SELECT  *
//                      FROM    ( SELECT    * ,
//                      ROW_NUMBER() OVER ( ORDER BY id ) AS Rank
//                      FROM      dbo.{tableMame}
//                      ) AS t
//                      WHERE   {likeQueryStr}
//                ";

//            LogHelper.Instance.Info(queryDataSql);
//            para.Add("sql", queryDataSql);
//            result.data = QueryForList<T>($"Query{tableMame}Paging", para);
//            result.length = queryBase.PageSize;
//            para.Clear();

//            para.Add("sql", queryDataSqlCount);
//            result.recordsTotal = QueryForList<T>($"Query{tableMame}Paging", para).Count;
//            return result;
#endregion
