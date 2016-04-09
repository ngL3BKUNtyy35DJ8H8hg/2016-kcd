using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
namespace HuanLuyen
{
    public class UserConnection
    {
        public delegate void LineReceivedEventHandler(UserConnection sender, string Data);
        private const int READ_BUFFER_SIZE = 255;
        private TcpClient client;
        private byte[] readBuffer;
        private string strName;
        private UserConnection.LineReceivedEventHandler LineReceivedEvent;
        public event UserConnection.LineReceivedEventHandler LineReceived
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.LineReceivedEvent = (UserConnection.LineReceivedEventHandler)Delegate.Combine(this.LineReceivedEvent, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.LineReceivedEvent = (UserConnection.LineReceivedEventHandler)Delegate.Remove(this.LineReceivedEvent, value);
            }
        }
        public string Name
        {
            get
            {
                return this.strName;
            }
            set
            {
                this.strName = value;
            }
        }
        public UserConnection(TcpClient client)
        {
            this.readBuffer = new byte[256];
            this.client = client;
            this.client.GetStream().BeginRead(this.readBuffer, 0, 255, new AsyncCallback(this.StreamReceiver), null);
        }
        public void SendData(string Data)
        {
            NetworkStream stream = this.client.GetStream();
            lock (stream)
            {
                StreamWriter streamWriter = new StreamWriter(this.client.GetStream());
                streamWriter.Write(Data + "\r");
                streamWriter.Flush();
            }
        }
        private void StreamReceiver(IAsyncResult ar)
        {
            try
            {
                NetworkStream stream = this.client.GetStream();
                int num;
                lock (stream)
                {
                    num = this.client.GetStream().EndRead(ar);
                }
                string @string = Encoding.UTF8.GetString(this.readBuffer, 0, checked(num - 1));
                UserConnection.LineReceivedEventHandler lineReceivedEvent = this.LineReceivedEvent;
                if (lineReceivedEvent != null)
                {
                    lineReceivedEvent(this, @string);
                }
                NetworkStream stream2 = this.client.GetStream();
                lock (stream2)
                {
                    this.client.GetStream().BeginRead(this.readBuffer, 0, 255, new AsyncCallback(this.StreamReceiver), null);
                }
            }
            catch (Exception expr_A2)
            {
                throw expr_A2;
            }
        }
    }
}