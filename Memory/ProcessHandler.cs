using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;

namespace mw2_fps_unlocker.Memory
{
    internal class ProcessHandler
    {
        public delegate void ProcessFoundCallback(Process proc);

        private BackgroundWorker thread;

        private ProcessFoundCallback processFoundCallback;
        private Process? proc;
        private string processName;
        
        public ProcessHandler() {}

        /// <summary>
        /// Find a process by name. When the process is found this will call the
        /// callback function with a Process object as argument. Example of a 
        /// callback signature:
        /// <code>private void ProcessFoundCallback(Process proc)</code>
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="callback"></param>
        internal void FindByName(string processName, ProcessFoundCallback callback)
        {
            this.processName = processName;
            processFoundCallback = callback;

            thread = new BackgroundWorker();
            thread.DoWork += Thread_DoWork;
            thread.RunWorkerAsync();
        }

        private void Thread_DoWork(object? sender, DoWorkEventArgs e)
        {
            while(!GetProcessByName(processName, out proc))
                Thread.Sleep(2000);

            processFoundCallback(proc);
        }

        private bool GetProcessByName(string processName, [NotNullWhen(true)] out Process? process)
        {
            Process[] procs = Process.GetProcessesByName(processName);

            if (procs.Length > 0)
            {
                process = procs[0];
                return true;
            }
            else
            {
                process = null;
                return false;
            }
        }

        /// <summary>
        /// Checks whether the process is currently running or not.
        /// </summary>
        /// <returns>True if running</returns>
        internal bool IsRunning()
        {
            if(proc != null)
            {
                if (GetProcessByName(proc.ProcessName, out _))
                    return true;
                else 
                    return false;

            }
            return false;
        }
    }
}
