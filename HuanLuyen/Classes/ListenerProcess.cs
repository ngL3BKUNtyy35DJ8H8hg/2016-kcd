using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
namespace HuanLuyen
{
    public class ListenerProcess
    {
        public delegate void ConnectedEventHandler(ListenerProcess sender, string userName, UserConnection userconnection);
        public delegate void DisconnectedEventHandler(ListenerProcess sender, UserConnection userconnection);
        public delegate void UnknownMessageEventHandler(ListenerProcess sender, string msg, UserConnection userconnection);
        private ListenerProcess.ConnectedEventHandler ConnectedEvent;
        private ListenerProcess.DisconnectedEventHandler DisconnectedEvent;
        private ListenerProcess.UnknownMessageEventHandler UnknownMessageEvent;
        private TcpListener listener;
        private Thread listenerThread;
        private int listenerPort;
        private Hashtable clients;
        private int clientID;
        private int SttUser;
        //public event ListenerProcess.ConnectedEventHandler Connected
        //{
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    add
        //    {
        //        this.ConnectedEvent = (ListenerProcess.ConnectedEventHandler)Delegate.Combine(this.ConnectedEvent, value);
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    remove
        //    {
        //        this.ConnectedEvent = (ListenerProcess.ConnectedEventHandler)Delegate.Remove(this.ConnectedEvent, value);
        //    }
        //}
        //public event ListenerProcess.DisconnectedEventHandler Disconnected
        //{
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    add
        //    {
        //        this.DisconnectedEvent = (ListenerProcess.DisconnectedEventHandler)Delegate.Combine(this.DisconnectedEvent, value);
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    remove
        //    {
        //        this.DisconnectedEvent = (ListenerProcess.DisconnectedEventHandler)Delegate.Remove(this.DisconnectedEvent, value);
        //    }
        //}
        //public event ListenerProcess.UnknownMessageEventHandler UnknownMessage
        //{
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    add
        //    {
        //        this.UnknownMessageEvent = (ListenerProcess.UnknownMessageEventHandler)Delegate.Combine(this.UnknownMessageEvent, value);
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    remove
        //    {
        //        this.UnknownMessageEvent = (ListenerProcess.UnknownMessageEventHandler)Delegate.Remove(this.UnknownMessageEvent, value);
        //    }
        //}
        public ListenerProcess(int pPort)
        {
            this.clients = new Hashtable();
            this.clientID = 0;
            this.SttUser = 0;
            this.listenerPort = pPort;
        }
        public void StartThread()
        {
            if (this.listenerThread == null)
            {
                this.listenerThread = new Thread(new ThreadStart(this.DoListen));
                this.listenerThread.Start();
            }
        }
        public void StopThread()
        {
            try
            {
                this.Broadcast("STOP");
                this.listener.Stop();
            }
            catch (Exception expr_18)
            {
                throw expr_18;
            }
        }
        private void DoListen()
        {
            try
            {
                this.listener = new TcpListener(IPAddress.Any, this.listenerPort);
                this.listener.Start();
                while (true)
                {
                    UserConnection userConnection = new UserConnection(this.listener.AcceptTcpClient());
                    userConnection.LineReceived += new UserConnection.LineReceivedEventHandler(this.OnLineReceived);
                }
            }
            catch (Exception arg_47_0)
            {
                throw arg_47_0;
            }
        }
        private void OnLineReceived(UserConnection sender, string data)
        {
            string[] array = data.Split(new char[]{'|'});
            string left = array[0];
            if (left == "DISCONNECT")
            {
                this.DisconnectUser(sender);
                ListenerProcess.DisconnectedEventHandler disconnectedEvent = this.DisconnectedEvent;
                if (disconnectedEvent != null)
                {
                    disconnectedEvent(this, sender);
                }
            }
            else if (left == "CONNECT")
            {
                this.ConnectUser(array[1], sender);
                ListenerProcess.ConnectedEventHandler connectedEvent = this.ConnectedEvent;
                if (connectedEvent != null)
                {
                    connectedEvent(this, array[1], sender);
                }
            }
            else
            {
                this.DisconnectUser(sender);
                ListenerProcess.UnknownMessageEventHandler unknownMessageEvent = this.UnknownMessageEvent;
                if (unknownMessageEvent != null)
                {
                    unknownMessageEvent(this, data, sender);
                }
            }
        }
        private void ConnectUser(string userName, UserConnection sender)
        {
            string text = userName;
            checked
            {
                if (this.clients.Contains(userName))
                {
                    this.SttUser++;
                    text += this.SttUser.ToString("00");
                }
                sender.Name = text;
                this.clients.Add(text, sender);
                this.ReplyToSender("JOIN", sender);
            }
        }
        private void DisconnectUser(UserConnection sender)
        {
            this.clients.Remove(sender.Name);
        }
        public void Broadcast(string strMessage)
        {
            UserConnection userConnection = null;
            IDictionaryEnumerator enumerator = this.clients.GetEnumerator();
            while (enumerator.MoveNext())
            {
                object expr_16 = enumerator.Current;
                DictionaryEntry dictionaryEntry2;
                DictionaryEntry dictionaryEntry = (expr_16 != null) ? ((DictionaryEntry)expr_16) : dictionaryEntry2;
                try
                {
                    userConnection = (UserConnection)dictionaryEntry.Value;
                    userConnection.SendData(strMessage);
                }
                catch (Exception expr_3F)
                {
                    if (userConnection != null)
                    {
                        this.DisconnectUser(userConnection);
                    }
                    break;
                }
            }
        }
        public void Broadcast(string pLoaiTB, string strMessage)
        {
            UserConnection userConnection = null;
            IDictionaryEnumerator enumerator = this.clients.GetEnumerator();
            while (enumerator.MoveNext())
            {
                object expr_16 = enumerator.Current;
                DictionaryEntry dictionaryEntry2;
                DictionaryEntry dictionaryEntry = (expr_16 != null) ? ((DictionaryEntry)expr_16) : dictionaryEntry2;
                try
                {
                    userConnection = (UserConnection)dictionaryEntry.Value;
                    if (userConnection.Name.IndexOf(pLoaiTB) >= 0)
                    {
                        userConnection.SendData(strMessage);
                    }
                }
                catch (Exception expr_4E)
                {
                    if (userConnection != null)
                    {
                        this.DisconnectUser(userConnection);
                    }
                    break;
                }
            }
        }
        private void SendToClients(string strMessage, UserConnection sender)
        {
            IDictionaryEnumerator enumerator = this.clients.GetEnumerator();
            while (enumerator.MoveNext())
            {
                object expr_14 = enumerator.Current;
                DictionaryEntry dictionaryEntry;
                UserConnection userConnection = (UserConnection)((expr_14 != null) ? ((DictionaryEntry)expr_14) : dictionaryEntry).Value;
                if (userConnection.Name != sender.Name)
                {
                    userConnection.SendData(strMessage);
                }
            }
        }
        private void ReplyToSender(string strMessage, UserConnection sender)
        {
            sender.SendData(strMessage);
        }
    }
}