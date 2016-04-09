using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
namespace TinhBao55
{
	public partial class CClient
	{
		public delegate void DisconnectedEventHandler(CClient sender);
		public delegate void LineReceivedEventHandler(CClient sender, ArrayList alData);
		private const int READ_BUFFER_SIZE = 255;
		public CClient.DisconnectedEventHandler DisconnectedEvent;
		public CClient.LineReceivedEventHandler LineReceivedEvent;
		private byte[] readBuffer;
		private TcpClient objClient;
		private ArrayList malData;
        //public event CClient.DisconnectedEventHandler Disconnected
        //{
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    add
        //    {
        //        this.DisconnectedEvent = (CClient.DisconnectedEventHandler)Delegate.Combine(this.DisconnectedEvent, value);
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    remove
        //    {
        //        this.DisconnectedEvent = (CClient.DisconnectedEventHandler)Delegate.Remove(this.DisconnectedEvent, value);
        //    }
        //}
        //public event CClient.LineReceivedEventHandler LineReceived
        //{
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    add
        //    {
        //        this.LineReceivedEvent = (CClient.LineReceivedEventHandler)Delegate.Combine(this.LineReceivedEvent, value);
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    remove
        //    {
        //        this.LineReceivedEvent = (CClient.LineReceivedEventHandler)Delegate.Remove(this.LineReceivedEvent, value);
        //    }
        //}
		public CClient(string pServer, int pPort)
		{
			this.readBuffer = new byte[256];
			this.objClient = new TcpClient(myModule.myServerComputer, 10062);
			this.malData = new ArrayList();
		}
		private void DoRead(IAsyncResult ar)
		{
			try
			{
				NetworkStream stream = this.objClient.GetStream();
				int num = 0;
				lock (stream)
				{
					num = this.objClient.GetStream().EndRead(ar);
				}
				if (num < 1)
				{
					CClient.DisconnectedEventHandler disconnectedEvent = this.DisconnectedEvent;
					if (disconnectedEvent != null)
					{
						disconnectedEvent(this);
					}
				}
				else
				{
					this.BuildString(this.readBuffer, 0, num);
					NetworkStream stream2 = this.objClient.GetStream();
					lock (stream2)
					{
						this.objClient.GetStream().BeginRead(this.readBuffer, 0, 255, new AsyncCallback(this.DoRead), null);
					}
				}
			}
			catch (Exception expr_9D)
			{
				throw expr_9D;
				CClient.DisconnectedEventHandler disconnectedEvent = this.DisconnectedEvent;
				if (disconnectedEvent != null)
				{
					disconnectedEvent(this);
				}
							}
		}
		private void BuildString(byte[] Bytes, int offset, int count)
		{
			checked
			{
				int num = offset + count - 1;
				for (int i = offset; i <= num; i++)
				{
					if (Bytes[i] == 13)
					{
						CClient.LineReceivedEventHandler lineReceivedEvent = this.LineReceivedEvent;
						if (lineReceivedEvent != null)
						{
							lineReceivedEvent(this, this.malData);
						}
						this.malData.Clear();
					}
					else
					{
						this.malData.Add(Bytes[i]);
					}
				}
			}
		}
		public bool AttemptConnect(string pConnectName)
		{
			bool result = false;
			try
			{
				this.objClient.GetStream().BeginRead(this.readBuffer, 0, 255, new AsyncCallback(this.DoRead), null);
				this.SendData("CONNECT|" + pConnectName);
				result = true;
			}
			catch (Exception expr_42)
			{
				throw expr_42;
							}
			return result;
		}
		public void SendData(string data)
		{
			NetworkStream stream = this.objClient.GetStream();
			lock (stream)
			{
				StreamWriter streamWriter = new StreamWriter(this.objClient.GetStream());
				streamWriter.Write(data + "\r");
				streamWriter.Flush();
			}
		}
	}
}