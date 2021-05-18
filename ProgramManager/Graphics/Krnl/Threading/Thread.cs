using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramManager.Krnl.Threading
{
    public class Thread
    {
        static List<Thread> registeredThreads = new List<Thread>();
        Func<object[], ThreadFuncResult> Func;
        object[] args;

        public Thread(Func<object[], ThreadFuncResult> func)
        {
            Func = func;
            registeredThreads.Add(this);
        }

        public Thread(Func<object[], ThreadFuncResult> func, object[] args)
        {
            Func = func;
            this.args = args;
            registeredThreads.Add(this);
        }

        private void Update()
        {
            Func(args);
        }

        public static void UpdateThreads()
        {
            foreach(Thread thrd in registeredThreads)
            {
                thrd.Update();
                registeredThreads.Remove(thrd);
            }
        }
    }

    public class ThreadFuncResult
    {
        public object funcResult;
    }
}
