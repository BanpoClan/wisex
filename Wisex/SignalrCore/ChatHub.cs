using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Wisex.SignalrCore
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        public void AddToRoom(string groupId, string userName)
        {
            //将分组Id放到上下文中
            Groups.Add(Context.ConnectionId, groupId);
            //群发人员进入信息提示
            Clients.Group(groupId, new string[0]).addUserIn(groupId, userName);
        }
        public void Send(string groupId, string detail, string userName)
        {
            //Clients.All.addSomeMessage(detail);//群发给所有
            //发给某一个组
            Clients.Group(groupId, new string[0]).addSomeMessage(groupId, detail, userName);
        }
    }
}