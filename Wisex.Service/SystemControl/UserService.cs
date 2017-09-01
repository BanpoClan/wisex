using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using Wisex.Common.Enums;
using Wisex.Core;
using Wisex.Core.StructureMapWapperUtils;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;
using Wisex.Core.Extentions;
using Wisex.Dao.SystemControl;
using System.Collections;

namespace Wisex.Service.SystemControl
{
    public class UserService : IUserService
    {
        public ILoginLogDao loginLogDao { get; set; }
        public IUserDao userDao { get; set; }
        public UserService()
        {
            userDao = StructureMapWapper.GetInstance<IUserDao>();
            loginLogDao = StructureMapWapper.GetInstance<ILoginLogDao>();
        }

        public List<Menu> GetMyMenus(int userId)
        {
            return userDao.GetMenu(userId);
        }

        public Result<UserModel> Login(UserModel dto)
        {
            var res = new Result<UserModel>();
            try
            {
                var user = userDao.GetOne(dto.LoginName);
                if (user == null)
                    res.msg = "无效的用户";
                else
                {
                    //记录登录日志
                    loginLogDao.Add(new LoginLog
                    {
                        UserId = user.Id,
                        LoginName = user.LoginName,
                        IP = WebHelper.GetClientIP(),
                        Mac = WebHelper.GetClientMACAddress()
                    });
                    if (user.Password != dto.Password.ToMD5())
                        res.msg = "登录密码错误";
                    else if (user.IsDeleted)
                        res.msg = "用户已被删除";
                    else if (user.Status == UserStatus.未激活)
                        res.msg = "账号未被激活";
                    else if (user.Status == UserStatus.禁用)
                        res.msg = "账号被禁用";
                    else
                    {
                        res.flag = true;
                        res.msg = "登录成功";
                        res.data = user;

                        //写入注册信息
                        DateTime expiration = dto.IsRememberMe
                            ? DateTime.Now.AddDays(7)
                            : DateTime.Now.Add(FormsAuthentication.Timeout);

                        FormsAuthentication.SetAuthCookie(user.LoginName, true, FormsAuthentication.FormsCookiePath);

                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2,
                            user.LoginName,
                            DateTime.Now,
                            expiration,
                            true,
                            user.Id.ToString(),
                            FormsAuthentication.FormsCookiePath);
                        FormsIdentity identity = new FormsIdentity(ticket);

                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                            FormsAuthentication.Encrypt(ticket))
                        {
                            HttpOnly = true,
                            Expires = expiration
                        };
                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }
                }
            }
            catch (Exception ex)
            {
                res.msg = ex.Message;
                
            }
            return res;
        }

        public bool Add(UserModel user)
        {
          return userDao.Add(user);
        }

        public ResultModel<UserModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc")
        {
            return userDao.GetWithPages(queryBase, orderBy, orderDir);
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public ResultModel<Role> GetMyRoles(QueryBase query, int userId)
        {
            throw new NotImplementedException();
        }

        public ResultModel<Role> GetNotMyRoles(QueryBase query, int userId)
        {
            throw new NotImplementedException();
        }

        public bool Add(List<UserModel> models)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserModel user)
        {
            return userDao.Update(user);
        }

        public bool Update(IEnumerable<UserModel> users)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<int> ids)
        {
            return userDao.Delete(ids);
        }

        public bool Delete(Expression<Func<UserModel, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public UserModel GetOne(Hashtable param)
        {
            return userDao.GetOne(param);
        }
    }
}
