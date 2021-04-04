using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

[Flags]
public enum ThreadAccess : int
{
    TERMINATE = (0x0001),
    SUSPEND_RESUME = (0x0002),
    GET_CONTEXT = (0x0008),
    SET_CONTEXT = (0x0010),
    SET_INFORMATION = (0x0020),
    QUERY_INFORMATION = (0x0040),
    SET_THREAD_TOKEN = (0x0080),
    IMPERSONATE = (0x0100),
    DIRECT_IMPERSONATION = (0x0200)
}

public static class ProcessExtension
{
    [DllImport("kernel32.dll")]
    static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
    [DllImport("kernel32.dll")]
    static extern uint SuspendThread(IntPtr hThread);
    [DllImport("kernel32.dll")]
    static extern int ResumeThread(IntPtr hThread);

    public static void Suspend(this Process process)
    {
        foreach (ProcessThread thread in process.Threads)
        {
            var pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
            if (pOpenThread == IntPtr.Zero)
            {
                break;
            }
            SuspendThread(pOpenThread);
        }
    }
    public static void Resume(this Process process)
    {
        foreach (ProcessThread thread in process.Threads)
        {
            var pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
            if (pOpenThread == IntPtr.Zero)
            {
                break;
            }
            ResumeThread(pOpenThread);
        }
    }
}

namespace taskutil
{
    class gfn
    {
        

        public static void NoArgs()
        {
            Console.WriteLine("There were no arguments. Do taskutil /? for help.");
            return;
        }

        public static void Help()
        {
            Console.WriteLine("Welcome to Taskutil. This is a replacement taskkill for Windows, if the original taskkill is");
            Console.WriteLine("blocked somehow.");
            Console.WriteLine("Usage:" + 
                "\n Terminate Process:" + 
                "\n  taskutil /k /p <PID>" + 
                "\n  taskutil /k /n <Processname>" + 
                "\n " + 
                "\n Suspend Process:" + 
                "\n  taskutil /s /p <PID>" + 
                "\n  taskutil /s /n <ProcessName>" + 
                "\n " + 
                "\n Resume Process:" +
                "\n  taskutil /r /p <PID>" +
                "\n  taskutil /r /n <Processname>");
            return;
        }

        public static void NoProcessTypeFinder()
        {
            Console.WriteLine("You didn\'t specify a Process Type to find.\nUse /p for finding it by the PID or /n for finding it by Name.");
            return;
        }

        public static void NoProcessArg()
        {
            Console.WriteLine("Did u specify a Process?");
            return;
        }

        public static void ProcessKill(string process)
        {
            foreach (var pwet in Process.GetProcessesByName(process))
            {
                pwet.Kill();
                Console.WriteLine("The Process was killed.");
            }
        }

        public static void ProcessSuspend(string process)
        {

            foreach (var pwet in Process.GetProcessesByName(process))
            {
               
                    pwet.Suspend();
                

            }
        }

        public static void ProcessResume(string process)
        {
            foreach (var pwet in Process.GetProcessesByName(process))
            {
                    pwet.Resume();
                
            }
        }

        public static void ProcessKillPID(string process)
        {
            int id = Convert.ToInt32(process);
            Process pwet = Process.GetProcessById(id);
            string processname = pwet.ProcessName;
           
                pwet.Kill();
            

        }

        public static void ProcessSuspendPID(string process)
        {
            int id = Convert.ToInt32(process);
            Process pwet = Process.GetProcessById(id);
            string processname = pwet.ProcessName;
            
                pwet.Suspend();
            
        }

        public static void ProcessResumePID(string process)
        {
            int id = Convert.ToInt32(process);
            Process pwet = Process.GetProcessById(id);
            string processname = pwet.ProcessName;
            
                pwet.Resume();
            
        }
    }
}
