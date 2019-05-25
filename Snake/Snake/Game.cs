using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Game
    {
        public static Boolean isRunning = false;

        public const int GAMEWIDTH = 60;
        public const int GAMEHEIGHT = 30;

        private string[,] GameBoard { get; set; }
        Player p;
        Movement m;
        public void Start()
        {
            p = new Player();
            p.AddTail(
                new Vector2(5, 5),
                new Vector2(6, 5),
                new Vector2(7, 5)
                );
            m = new Movement();
            Field.DrawField();

            Food.Start(p);
        }

        public void Run()
        {
            Time.Wait();
            m.Move(p, p.CurrentDir, p.NextDir);
            Food.Update();
            p.Draw();
        }
    }
}
