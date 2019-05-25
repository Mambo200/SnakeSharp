using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    static class InputTask
    {
        #region Add Task
        public static void Add(Action _action)
        {
            var tokenSource2 = new CancellationTokenSource();
            CancellationToken ct = tokenSource2.Token;
            

            Task t = new Task(_action);
            TaskToRun.Add(t, false);
            t.Start();
        }

        public static void Add(Task _task)
        {
            TaskToRun.Add(_task, false);
            _task.Start();
        }
        #endregion

        #region Remove Task
        public static void Remove(Action _action)
        {
            Task t = new Task(_action);
            TaskToRun.Remove(t);
            
        }

        internal static void RemoveAll()
        {
            Dictionary<Task, bool> backup = new Dictionary<Task, bool>(TaskToRun);
            foreach (KeyValuePair<Task, bool> t in backup)
            {
                
            }

            TaskToRun.Clear();
        }

        public static void Remove(Task _task)
        {
            TaskToRun.Remove(_task);
        }
        #endregion

        public static void Update()
        {
            Dictionary<Task, bool> backup = new Dictionary<Task, bool>(TaskToRun);
            foreach(KeyValuePair<Task, bool> entry in backup)
            {
                if (entry.Key.IsCompleted)
                {
                    TaskToRun.Remove(entry.Key);
                }
            }
        }

        private static Dictionary<Task, bool> TaskToRun = new Dictionary<Task, bool>();
    }
}
