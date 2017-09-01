using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Core.StructureMapWapperUtils;
using Wisex.Dao.Daos;
using Wisex.Entity.Models;

namespace Wisex.Dao.BaseDaoCore
{
    /// <summary>
    /// 根据前台传递过来的MenuID获取菜单信息，用于自动构造数据和绑定界面
    /// </summary>
    public class MenuDataUtil
    {
        private IDaoFrame daoFrame = null;

        public MenuDataUtil()
        {
            daoFrame = StructureMapWapper.GetInstance<IDaoFrame>();
        }

        /// <summary>
        /// 获取菜单详细情况
        /// </summary>
        /// <param name="menuId"></param>
        public Menu GetMenuDetail(string menuId)
        {
            var menu = daoFrame.GetOne<Menu>(Convert.ToInt32(menuId));
            return menu;
        }
    }
}
