using Snake.Core;
using Snake.Field;
using Snake.Game;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake.MultiThreading
{
    class InputThread
    {
        public static int Count { get { return allThreads.Count; } }
        private static List<Thread> allThreads = new List<Thread>();

        public static void Add(Thread _thread)
        {
            allThreads.Add(_thread);
            _thread.Start();
        }

        public static void Remove(Thread _thread, bool _abort = true)
        {
            allThreads.Remove(_thread);
            if (_abort)
            {
                _thread.Abort();
            }
        }

        internal static void RemoveAll()
        {
            foreach (Thread t in allThreads)
            {
                t.Abort();
            }

            allThreads.Clear();
        }

        public static void Update()
        {
            List<Thread> backup = new List<Thread>(allThreads);
            foreach (Thread thread in backup)
            {
                if (thread.IsAlive == false)
                    allThreads.Remove(thread);
            }
        }

       
    }
}
