using Snake.Core;
using Snake.Field;
using Snake.MultiThreading;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snake.Game
{
    class Player
    {
        public Player()
        {
            NextDir = NextDirection.NONE;
            CurrentDir = NextDirection.UP;
            //InputTask.Add(GetInput);
            InputThread.Add(new System.Threading.Thread(GetInput));
        }

        public void Start()
        {
            WriteTailAmountText();
            WriteScore();

            foreach (Tail t in Tails)
            {
                Console.SetCursorPosition(t.Position.x, t.Position.y);
                Console.Write(FieldChars.WALL);
            }
        }

        private int score = 0;

        public List<Tail> Tails = new List<Tail>();

        public int TailLengh { get { return Tails.Count; } }

        public NextDirection CurrentDir { get; private set; }
        public NextDirection NextDir { get; private set; }

        public static bool alive = true;

        void GetInput()
        {
            try
            {
                // get key input
                ConsoleKeyInfo i = Console.ReadKey();
                if (!alive)
                    return;
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

                InputThread.Add(new System.Threading.Thread(GetInput));

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
            catch (Exception _ex)
            {

            }
        }

        public void Draw()
        {
            foreach (Tail t in Tails)
            {
                Console.SetCursorPosition(t.Position.x, t.Position.y);
                Console.Write(FieldChars.WALL);
            }

            Helper.SetCursorPosition(Console.WindowWidth - 5, Console.WindowHeight - 5);
        }

        /// <summary>
        /// Add Tail while in Game.
        /// </summary>
        public void AddTail()
        {
            Vector2 lastTailPos = Tails[Tails.Count - 1].Position;
            Tails.Add(new Tail(lastTailPos));

            WriteTailAmountText();
            WriteScore();
        }

        /// <summary>
        /// Start Method
        /// </summary>
        /// <param name="_tailCount">tail count</param>
        public void AddTail(int _tailCount)
        {
            int yPos = 1;
            for (int i = 0; i < _tailCount; i++)
            {
                AddTail(new Vector2(1, yPos));
                yPos++;
            }

            WriteTailAmountText();
        }

        public void AddTail(params Vector2[] _positions)
        {
            foreach (Vector2 v2 in _positions)
            {
                Tails.Add(new Tail(v2));
            }

            WriteTailAmountText();
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

        public void AddScore()
        {
            score++;
            WriteScore();
        }

        public void WriteTailAmountText()
        {
            Helper.SetCursorPosition(Game.TailCountWritePosition);
            Console.Write("Tails: " + TailLengh);
        }

        public void WriteScore()
        {
            Helper.SetCursorPosition(Game.TailCountWritePosition + new Vector2(0, 1));
            Console.Write("Score: " + score);
        }

        ~Player()
        {
            Tails.Clear();
            Tails = null;
        }
    }
}
