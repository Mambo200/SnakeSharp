using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Player
    {
        public Player()
        {
            NextDir = NextDirection.NONE;
            CurrentDir = NextDirection.TOP;
        }

        public List<Tail> Tails = new List<Tail>();

        public int TailLengh { get { return Tails.Count; } }

        public NextDirection CurrentDir { get; private set; }
        public NextDirection NextDir { get; private set; }

        void GetInput()
        {
            ConsoleKeyInfo i = Console.ReadKey();
            switch (i.Key)
            {
                case ConsoleKey.LeftArrow:
                    NextDir = NextDirection.LEFT;
                    break;
                case ConsoleKey.UpArrow:
                    NextDir = NextDirection.TOP;
                    break;
                case ConsoleKey.RightArrow:
                    NextDir = NextDirection.RIGHT;
                    break;
                case ConsoleKey.DownArrow:
                    NextDir = NextDirection.DOWN;
                    break;
            }
        }

        public void Draw()
        {
            foreach (Tail t in Tails)
            {
                Console.SetCursorPosition(t.Position.x, t.Position.y);
                Console.Write(FieldChars.WALL);
            }
        }

        public void AddTail(params Vector2[] _positions)
        {
            foreach (Vector2 v2 in _positions)
            {
                Tails.Add(new Tail(v2));
            }
        }

        ~Player()
        {
            Tails.Clear();
            Tails = null;
        }
    }
}
