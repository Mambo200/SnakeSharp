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
    class Tail
    {
        public Tail(Vector2 _position)
        {
            Position = _position;
            Helper.SetCursorPosition(new Vector2(0, 0));
            Console.Write(FieldChars.WALL);
        }

        public Tail(int _x, int _y)
        {
            Vector2 v2 = new Vector2(_x, _y);
            Position = v2;
        }

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set
            {
                Console.SetCursorPosition(position.x, position.y);
                Console.Write(FieldChars.EMPTY);

                position = value;
            }
        }
        public bool removeWhenLast = false;

        public void Remove()
        {
            Console.SetCursorPosition(Position.x, Position.y);
            Console.Write(FieldChars.EMPTY);
        }

        public static void AddToList(List<Tail> _list)
        {
            Tail t = new Tail(_list[0].Position);
            _list.Add(t);
        }

        public static void DrawTail(params Tail[] _tail)
        {
            foreach (Tail t in _tail)
            {
                Console.SetCursorPosition(t.Position.x, t.Position.y);
                Console.Write(FieldChars.WALL);
            }
        }
    }
}
