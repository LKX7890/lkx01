using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace LOLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //server.Bind(new IPEndPoint(IPAddress.Any, port));

            //// 置于监听状态
            //server.Listen(10);
            //Socket client = server.Accept();
            //byte[] buff = new byte[1024];
            //client.Receive(buff);
            //client.Send(buff);

            // 服务器初始化
            ServerStart ss = new ServerStart(9000);
            ss.Start(6666);
        }
    }
}
