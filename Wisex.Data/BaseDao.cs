using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Common.LogUtils;
using Wisex.Entity.CommonModel;

namespace Wisex.Dao
{
    public partial class BaseDao
    {
        //返回SqlMapper 的实例  用单件模式    
        private static readonly object syncInvoke = new object();
        private static SqlMapper _SqlMapperInstance;

        public SqlMapper SqlMapperInstance
        {
            get
            {
                if (_SqlMapperInstance == null)
                {
                    lock (syncInvoke)
                    {
                        if (_SqlMapperInstance == null)
                        {
                            _SqlMapperInstance = (SqlMapper)Mapper.Instance();

                        }
                    }
                }

                return _SqlMapperInstance;
            }
        }


        #region 得到运行时ibatis.net动态生成的SQL
        /// <summary>
        /// 得到运行时ibatis.net动态生成的SQL
        /// </summary>
        /// <param name="sqlMapper"></param>
        /// <param name="statementName"></param>
        /// <param name="paramObject"></param>
        /// <returns></returns>
        protected virtual string GetRuntimeSql(string statementName, object paramObject)
        {
            string result = string.Empty;
            try
            {
                IMappedStatement statement = _SqlMapperInstance.GetMappedStatement(statementName);
                if (!_SqlMapperInstance.IsSessionStarted)
                {
                    _SqlMapperInstance.OpenConnection();
                }
                RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, _SqlMapperInstance.LocalSession);
                result = scope.PreparedStatement.PreparedSql;
            }
            catch (Exception ex)
            {
                result = "获取SQL语句出现异常:" + ex.Message;
                LogHelper.Instance.Error(ex.StackTrace);
            }
            return result;
        }

        protected virtual string GetStatementName<T>(string name)
        {
            return string.Format("{0}.{1}", typeof(T).Namespace, name);
        }

        #endregion

        #region 查询方法

        public object Add(string statementName, Hashtable parameterObject)
        {
            return this.SqlMapperInstance.Insert(statementName, parameterObject);
        }

        public object Add(string statementName, object parameterObject)
        {
            return this.SqlMapperInstance.Insert(statementName, parameterObject);
        }

        /// <summary>
        /// 返回单个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <returns></returns>
        public T QueryForObject<T>(string statementName)
        {
            return this.SqlMapperInstance.QueryForObject<T>(statementName, null);
        }

        /// <summary>
        /// 返回单个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <returns></returns>
        public T QueryForObject<T>(string statementName, Hashtable parameterObject)
        {
            return this.SqlMapperInstance.QueryForObject<T>(statementName, parameterObject);
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <returns></returns>
        public IList<T> QueryForList<T>(string statementName)
        {
            return this.SqlMapperInstance.QueryForList<T>(statementName, null);
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <returns></returns>
        public List<T> QueryForList<T>(string statementName, Hashtable parameterObject)
        {
            return this.SqlMapperInstance.QueryForList<T>(statementName, parameterObject).ToList();
        }

        public int Delete(string statementName, object parameterObject)
        {
            return this.SqlMapperInstance.Delete(statementName, parameterObject);
        }

        public int Update(string statementName, object parameterObject)
        {
            return this.SqlMapperInstance.Update(statementName, parameterObject);
        }


        #endregion

        
    }
}
