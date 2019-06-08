using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Snake.MultiThreading;

namespace Snake
{
    public static class DEV
    {
        public static void DoTesting()
        {
            Action a = new Action(ThreadTest);
            var token = InputTask.Add(a);
            System.Threading.Thread.Sleep(1000);
            InputTask.RemoveAll();
            //token.Cancel();

            //Thread thread = new Thread(ThreadTest);
            //thread.Start();
            //System.Threading.Thread.Sleep(1000);
            //thread.Abort();
        }
        private static void ThreadTest()
        {
            try
            {

                int i = 0;
                while (true)
                    Console.WriteLine(++i);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
