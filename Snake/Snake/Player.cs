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
            CurrentDir = NextDirection.UP;
            InputTask.Add(GetInput);
        }

        public List<Tail> Tails = new List<Tail>();

        public int TailLengh { get { return Tails.Count; } }

        public NextDirection CurrentDir { get; private set; }
        public NextDirection NextDir { get; private set; }

        public static bool alive = true;

        void GetInput()
        {
            // get key input
            ConsoleKeyInfo i = Console.ReadKey();
            switch (i.Key)
            {
                case ConsoleKey.LeftArrow:
                    NextDir = NextDirection.LEFT;
                    break;
                case ConsoleKey.UpArrow:
                    NextDir = NextDirection.UP;
                    break;
                case ConsoleKey.RightArrow:
                    NextDir = NextDirection.RIGHT;
                    break;
                case ConsoleKey.DownArrow:
                    NextDir = NextDirection.DOWN;
                    break;
            }
            InputTask.Add(GetInput);

            // reset object
            Vector2 v2 = Tails.Last().Position;
            v2.Right();
            Console.SetCursorPosition(v2.x, v2.y);
            if (Collision.WallCollision(v2))
                Console.Write(FieldChars.WALL);
            else
                Console.Write(FieldChars.EMPTY);
            Console.SetCursorPosition(v2.x - 1, v2.y);
        }

        public void Draw()
        {
            foreach (Tail t in Tails)
            {
                Console.SetCursorPosition(t.Position.x, t.Position.y);
                Console.Write(FieldChars.WALL);
            }
        }

        public void AddTail(int _tailCount)
        {
            int yPos = 1;
            for (int i = 0; i < _tailCount; i++)
            {
                AddTail(new Vector2(1, yPos));
                yPos++;
            }
        }

        public void AddTail(params Vector2[] _positions)
        {
            foreach (Vector2 v2 in _positions)
            {
                Tails.Add(new Tail(v2));
            }
        }

        public void SetCurrentDirection(NextDirection _currentDir)
        {
            CurrentDir = _currentDir;
        }

        public void SetNextDirection(NextDirection _nextDir)
        {
            NextDir = _nextDir;
        }

        public void ResetNextDirection()
        {
            NextDir = NextDirection.NONE;
        }


        ~Player()
        {
            Tails.Clear();
            Tails = null;
        }
    }
}
