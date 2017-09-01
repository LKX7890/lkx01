using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace NetFrame
{
    /// <summary>
    /// 用户连接对象
    /// </summary>
    class UserToken
    {
        /// <summary>
        /// 用户连接
        /// </summary>
        public Socket conn;
        //用户异步网络数据对象
        public SocketAsyncEventArgs receiveSAEA;
        //用户发送网络数据对象
        public SocketAsyncEventArgs sendSAEA;

        // 委托
        public LengthEncode LE;         // 粘包编写器
        public LengthDecode LD;         // 粘包解码器
        public encode encode;           // 编码
        public decode decode;           // 解码

        // 声明委托 & 初始化确定方法定义
        public delegate void SendProcess(SocketAsyncEventArgs e);
        public SendProcess sendProcess;

        List<byte> cache = new List<byte>();        // 接收消息缓存

        private bool isReading = false;     // 状态机
        private bool isWriting = false;

        Queue<byte[]> writeQueue = new Queue<byte[]>();     // 发送消息缓存
        public UserToken()
        {
            receiveSAEA = new SocketAsyncEventArgs();
            sendSAEA = new SocketAsyncEventArgs();
            receiveSAEA.UserToken = this;
            sendSAEA.UserToken = this;

        }

        public void receive(byte[] buff)
        {
            // 将消息写入缓存
            cache.AddRange(buff);
            if (!isReading)
            {
                isReading = true;
                onData();           // 处理数据
            }
        }

        // 缓存中有数据处理
        void onData()
        {
            // 解码消息存储对象
            byte[] buff = null;

            // 当粘包解码器存在的时候，进行粘包处理
            if (LD != null)
            {
                buff = LD(ref cache);           // 形参匹配函数

                // 消息未接收全，退出数据处理等待下次消息处理
                if (buff == null)
                {
                    isReading = false;
                    return;
                }
            }
            else
            {
                // 缓存区中没有数据 直接跳出数据处理等待下次消息达到
                if (cache.Count == 0)
                {
                    isReading = false;
                    return;
                }
            }

            // 反序列化方法是否存在
            if (decode == null)
            {
                throw new Exception("message decode process is null");
            }

            // 进行反序列化
            object message = decode(buff);

            // TODO 通知应用层 有消息达到

            // 尾递归，防止在消息处理过程中，有其他消息到达没有处理
            onData();
        }

        public void write(byte[] value)
        {
            if (conn == null)
            {
                // 连接断开
                return;
            }

            // 将对象添加的队列尾
            writeQueue.Enqueue(value);

            if (!isWriting)
            {
                isWriting = true;
                onWrite();
            }
        }
        public void onWrite()
        {
            // 判断发送消息队列是否有消息
            if (writeQueue.Count == 0)
            {
                isWriting = false;
                return;
            }

            // 取出第一条待发消息
            byte[] buff = writeQueue.Dequeue();

            // 设置消息发送异步对象的发送数据缓冲区数据
            sendSAEA.SetBuffer(buff, 0, buff.Length);

            // 开启异步发送
            bool result = conn.SendAsync(sendSAEA);

            // 是否挂起
            if (!result)
            {
                // 初始化，使用ServerStart里的方法
                sendProcess(sendSAEA);
            }
        }

        public void writed()
        {
            // 与onData尾递归同理
            onWrite();
        }

        public void Close()
        {
            try
            {
                writeQueue.Clear();
                cache.Clear();
                isReading = false;
                isWriting = false;
                conn.Shutdown(SocketShutdown.Both);
                conn.Close();
                conn = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
