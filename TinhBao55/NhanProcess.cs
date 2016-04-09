using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
namespace TinhBao55
{
	public partial class NhanProcess
	{
        public delegate void ConnectedEventHandler(NhanProcess sender);
        public delegate void DisconnectedEventHandler(NhanProcess sender);
        public delegate void RefusedEventHandler(NhanProcess sender);
        public delegate void LineReceivedEventHandler(NhanProcess sender, string line);
		public NhanProcess.ConnectedEventHandler ConnectedEvent;
        public NhanProcess.DisconnectedEventHandler DisconnectedEvent;
        public NhanProcess.RefusedEventHandler RefusedEvent;
        public NhanProcess.LineReceivedEventHandler LineReceivedEvent;
        public CClient myClient;
		private bool m_Done;
		private Thread myThread;

        //public event NhanProcess.ConnectedEventHandler Connected
        //{
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    add
        //    {
        //        this.ConnectedEvent = (NhanProcess.ConnectedEventHandler)Delegate.Combine(this.ConnectedEvent, value);
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    remove
        //    {
        //        this.ConnectedEvent = (NhanProcess.ConnectedEventHandler)Delegate.Remove(this.ConnectedEvent, value);
        //    }
        //}

        //public event NhanProcess.DisconnectedEventHandler Disconnected
        //{
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    add
        //    {
        //        this.DisconnectedEvent = (NhanProcess.DisconnectedEventHandler)Delegate.Combine(this.DisconnectedEvent, value);
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    remove
        //    {
        //        this.DisconnectedEvent = (NhanProcess.DisconnectedEventHandler)Delegate.Remove(this.DisconnectedEvent, value);
        //    }
        //}

        //public event NhanProcess.RefusedEventHandler Refused
        //{
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    add
        //    {
        //        this.RefusedEvent = (NhanProcess.RefusedEventHandler)Delegate.Combine(this.RefusedEvent, value);
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    remove
        //    {
        //        this.RefusedEvent = (NhanProcess.RefusedEventHandler)Delegate.Remove(this.RefusedEvent, value);
        //    }
        //}

        //public event NhanProcess.LineReceivedEventHandler LineReceived
        //{
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    add
        //    {
        //        this.LineReceivedEvent = (NhanProcess.LineReceivedEventHandler)Delegate.Combine(this.LineReceivedEvent, value);
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    remove
        //    {
        //        this.LineReceivedEvent = (NhanProcess.LineReceivedEventHandler)Delegate.Remove(this.LineReceivedEvent, value);
        //    }
        //}

		public NhanProcess(string pServer, int pPort)
		{
			this.m_Done = false;
			this.myClient = new CClient(pServer, pPort);
			this.m_Done = false;

            this.myClient.LineReceivedEvent += new CClient.LineReceivedEventHandler(this.myClient_LineReceived);
            this.myClient.DisconnectedEvent += new CClient.DisconnectedEventHandler(this.myClient_Disconnected);
		}
		public void Run()
		{
			while (!this.m_Done)
			{
			}
			Thread.CurrentThread.Abort();
		}
		public void StartThread()
		{
			if (this.myThread == null)
			{
				this.myThread = new Thread(new ThreadStart(this.Run));
				this.myThread.Start();
			}
		}
		public void StopThread()
		{
			this.myThread.Abort();
			this.myThread = null;
		}
		private void myClient_Disconnected(CClient sender)
		{
			NhanProcess.DisconnectedEventHandler disconnectedEvent = this.DisconnectedEvent;
			if (disconnectedEvent != null)
			{
				disconnectedEvent(this);
			}
		}
		private void myClient_LineReceived(CClient sender, ArrayList alData)
		{
			int count = alData.Count;
			checked
			{
				byte[] array = new byte[count - 1 + 1];
				alData.CopyTo(array);
				string @string = Encoding.UTF8.GetString(array, 0, array.GetUpperBound(0) + 1);
				string[] array2 = @string.Split(new char[]
				{
					'|'
				});
				string left = array2[0];
				if (left == "JOIN")
				{
					this.m_Done = false;
					NhanProcess.ConnectedEventHandler connectedEvent = this.ConnectedEvent;
					if (connectedEvent != null)
					{
						connectedEvent(this);
					}
				}
				else if (left == "REFUSE")
				{
					NhanProcess.RefusedEventHandler refusedEvent = this.RefusedEvent;
					if (refusedEvent != null)
					{
						refusedEvent(this);
					}
				}
				else if (left == "STOP")
				{
					NhanProcess.DisconnectedEventHandler disconnectedEvent = this.DisconnectedEvent;
					if (disconnectedEvent != null)
					{
						disconnectedEvent(this);
					}
				}
				else if (left == "BROAD")
				{
					NhanProcess.LineReceivedEventHandler lineReceivedEvent = this.LineReceivedEvent;
					if (lineReceivedEvent != null)
					{
						lineReceivedEvent(this, array2[1]);
					}
				}
				else
				{
					NhanProcess.DisconnectedEventHandler disconnectedEvent = this.DisconnectedEvent;
					if (disconnectedEvent != null)
					{
						disconnectedEvent(this);
					}
				}
			}
		}
	}
}