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
    static class InputTask
    {

        #region Add Task
        public static CancellationTokenSource Add(Action _action)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Task t = new Task(_action, tokenSource.Token);
            TaskToRun.Add(tokenSource, t);
            t.Start();
            return tokenSource;
        }

        public static void Add(Task _task, CancellationTokenSource _cancelToken)
        {
            TaskToRun.Add(_cancelToken, _task);
            _task.Start();
        }
        #endregion

        #region Remove Task
        public static void Remove(CancellationTokenSource _cancelToken)
        {
            _cancelToken.Cancel();

            bool work = TaskToRun.Remove(_cancelToken);

            if (!work)
                throw new InvalidOperationException("Token not Found!");
            
            _cancelToken.Dispose();
        }

        public static void RemoveAll()
        {
            foreach (KeyValuePair<CancellationTokenSource, Task> t in TaskToRun)
            {
                t.Key.Cancel();
            }

            TaskToRun.Clear();
        }

        public static void Remove(Task _task)
        {
            Dictionary<CancellationTokenSource, Task> backup = new Dictionary<CancellationTokenSource, Task>(TaskToRun);
            foreach (KeyValuePair<CancellationTokenSource, Task> entry in backup)
            {
                if (entry.Value == _task)
                {
                    TaskToRun.Remove(entry.Key);
                    break;
                }
            }
        }
        #endregion

        public static void Update()
        {
            if (!Player.alive)
            {
                RemoveAll();
                return;
            }

            Dictionary<CancellationTokenSource, Task> backup = new Dictionary<CancellationTokenSource, Task>(TaskToRun);
            foreach(KeyValuePair<CancellationTokenSource, Task> entry in backup)
            {
                if (entry.Value.IsCompleted)
                {
                    TaskToRun.Remove(entry.Key);
                }
            }
        }

        private static Dictionary<CancellationTokenSource, Task> TaskToRun = new Dictionary<CancellationTokenSource, Task>();
    }
}
