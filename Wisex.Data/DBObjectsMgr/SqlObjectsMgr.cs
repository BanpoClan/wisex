using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisex.Dao.DBObjectsMgr
{
    /// <summary>
    /// SQL对象管理
    /// 
    /// 在创建菜单的时候，若是填写了数据库表名称，就自动创建表，若是为空，就删除该表
    /// 
    /// 
    /// </summary>
    public class SqlObjectsMgr
    {
        public void CreateTable(string tableName)
        { }

        public void CreateFields(string tableName,string[] fields)
        { }

        public void CreateFields(string tableName, string fields)
        { }

        public void AlterTableName(string curTableName,string newTableName)
        { }

        public void AlterTableFields(string tableName, string fields)
        { }
    }
}
