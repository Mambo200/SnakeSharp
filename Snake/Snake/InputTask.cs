using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class InputTask
    {
        #region Add Task
        public static void Add(Action _action)
        {
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

        public static void Remove(Task _task)
        {
            TaskToRun.Remove(_task);
        }
        #endregion

        public static void Update()
        {
            foreach(KeyValuePair<Task, bool> entry in TaskToRun)
            {
                if (entry.Value)
                {
                    entry.Key.Start();
                    TaskToRun[entry.Key] = false;
                }
            }
        }

        private static Dictionary<Task, bool> TaskToRun = new Dictionary<Task, bool>();
    }
}
