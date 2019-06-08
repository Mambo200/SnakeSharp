using Snake.Field;
using Snake.Game;
using Snake.MultiThreading;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Core
{
    static class Time
    {
        private static long OldWaitTime { get { return 1500000; } }
        public static TimeSpan WaitTime { get { return new TimeSpan((long)OldWaitTime); } }

        private static DateTime started = DateTime.Now;

        private static DateTime drawed;

        public static void Wait()
        {
            if (drawed <= started)
            {
                drawed = DateTime.Now;
                return;
            }

            DateTime now = DateTime.Now;
            TimeSpan ts = now - drawed;
            if ((ts <= WaitTime))
            {
                System.Threading.Thread.Sleep(WaitTime - ts);
            }
            drawed = DateTime.Now;
        }
    }
}
