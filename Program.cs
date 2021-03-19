using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taskutil
{
    class Program
    {

        static void Main(string[] args)
        {
            bool gui = false;
            gfn gfn = new gfn();

            if (args.Length == 0)
            {
                gui = true;
                Application.EnableVisualStyles();
                Application.Run(new taskutilgui(gui));
            }
            else
            {
                if (args[0] == "/?")
                {
                    gfn.Help();
                }
                if (args[0] == "/k")
                {
                    if (args.Length == 1)
                    {
                        gfn.NoProcessTypeFinder();
                    }
                    if (args.Length == 2)
                    {
                        gfn.NoProcessArg();
                    }
                    if (args[1] == "/p")
                    {
                        gfn.ProcessKillPID(args[2]);
                    }
                    if (args[1] == "/n")
                    {
                        gfn.ProcessKill(args[2]);
                    }
                }
                if (args[0] == "/s")
                {
                    if (args.Length == 1)
                    {
                        gfn.NoProcessTypeFinder();
                    }
                    if (args.Length == 2)
                    {
                        gfn.NoProcessArg();
                    }
                    if (args[1] == "/p")
                    {
                        gfn.ProcessSuspendPID(args[2]);
                    }
                    if (args[1] == "/n")
                    {
                        gfn.ProcessSuspend(args[2]);
                    }
                }
                if (args[0] == "/r")
                {
                    if (args.Length == 1)
                    {
                        gfn.NoProcessTypeFinder();
                    }
                    if (args.Length == 2)
                    {
                        gfn.NoProcessArg();
                    }
                    if (args[1] == "/p")
                    {
                        gfn.ProcessResumePID(args[2]);
                    }
                    if (args[1] == "/n")
                    {
                        gfn.ProcessResume(args[2]);
                    }
                }
            }
        }
    }
}
