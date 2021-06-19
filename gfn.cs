using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class ProcessExtension
{
    [DllImport("kernel32.dll")]
    static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, uint dwProcessId);
    [DllImport("ntdll.dll")]
    static extern int NtSuspendProcess(IntPtr handle);
    [DllImport("ntdll.dll")]
    static extern int NtResumeProcess(IntPtr handle);

    public static void Suspend(this Process process)
    {
        var handle = OpenProcess(0x0800/*PROCESS_SUSPEND_RESUME*/, false, process.Id);
        if (handle == IntPtr.Zero)
        {
            break;
        }
        NtSuspendProcess(handle);
    }
    public static void Resume(this Process process)
    {
        var handle = OpenProcess(0x0800/*PROCESS_SUSPEND_RESUME*/, false, process.Id);
        if (handle == IntPtr.Zero)
        {
            break;
        }
        NtResumeProcess(handle);
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
