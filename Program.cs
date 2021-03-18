using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskutil
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            gfn gfn = new gfn();

            if (args.Length == 0)
            {
                gfn.NoArgs();
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
                        gfn.NoProcessArg();
                    }
                    if (args[1] == "/p")
                    {

                    }
                    if (args[1] == "/n")
                    {

                    }
                }
                if (args[0] == "/r")
                {
                    if (args.Length == 1)
                    {
                        gfn.NoProcessArg();
                    }
                    if (args[1] == "/p")
                    {

                    }
                    if (args[1] == "/n")
                    {

                    }
                }
            }
        }
    }
}
