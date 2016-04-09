using System;
using System.Runtime.CompilerServices;
using System.Threading;
namespace HuanLuyen
{
    public class CHLProcess
    {
        public delegate void UpdateXongEventHandler(int pDelay);
        private CHLProcess.UpdateXongEventHandler UpdateXongEvent;
        private bool m_Done;
        private Thread myThread;
        public event CHLProcess.UpdateXongEventHandler UpdateXong
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.UpdateXongEvent = (CHLProcess.UpdateXongEventHandler)Delegate.Combine(this.UpdateXongEvent, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.UpdateXongEvent = (CHLProcess.UpdateXongEventHandler)Delegate.Remove(this.UpdateXongEvent, value);
            }
        }
        public CHLProcess()
        {
            this.m_Done = false;
        }
        public void Run()
        {
            //[CONVERT FAIL]
            //while (!this.m_Done)
            //{
            //    try
            //    {
            //        int num = modHuanLuyen.fHuanLuyen.UpdateFlights();
            //        CHLProcess.UpdateXongEventHandler updateXongEvent = this.UpdateXongEvent;
            //        if (updateXongEvent != null)
            //        {
            //            updateXongEvent(num);
            //        }
            //        Thread.Sleep(num);
            //    }
            //    catch (Exception expr_26)
            //    {
            //        throw expr_26;
            //    }
            //}
            //Thread.CurrentThread.Abort();
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
            this.m_Done = true;
            this.myThread.Abort();
            this.myThread = null;
        }
        private void RunPooledThread(object state)
        {
            this.Run();
        }
        public void StartPooledThread()
        {
            WaitCallback callBack = new WaitCallback(this.RunPooledThread);
            ThreadPool.QueueUserWorkItem(callBack, null);
        }
    }
}