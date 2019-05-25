using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Game
    {
        public static Player player;
        public static Boolean isRunning = false;

        public const int GAMEWIDTH = 60;
        public const int GAMEHEIGHT = 30;

        private string[,] GameBoard { get; set; }
        Movement m;
        public void Start()
        {
            player = new Player();
            player.AddTail(8);
            m = new Movement();
            Field.DrawField();
            player.SetCurrentDirection(NextDirection.RIGHT);
            Food.Start(player);
        }

        public void Run()
        {
            Time.Wait();
            m.Move(player, player.CurrentDir, player.NextDir);
            Food.Update();
            Collision.Update();
            player.Draw();
        }
    }
}
