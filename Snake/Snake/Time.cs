using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class Time
    {
        public static TimeSpan WaitTime { get { return new TimeSpan((long)3000000); } }

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
