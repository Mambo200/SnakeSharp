using Snake.Core;
using Snake.Field;
using Snake.Game;
using Snake.MultiThreading;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class Helper
    {
        public static void SetCursorPosition(Vector2 _newPos)
        {
            Console.SetCursorPosition(_newPos.x, _newPos.y);
        }

        public static void SetCursorPosition(int _x, int _y)
        {
            Console.SetCursorPosition(_x, _y);
        }

    }
}
