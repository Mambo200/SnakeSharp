using Snake.Core;
using Snake.Field;
using Snake.MultiThreading;
using Snake.Music;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Game
{
    class Game
    {
        public static Player player;
        public static Boolean isRunning = false;



        public const int GAMEWIDTH = 15;
        public const int GAMEHEIGHT = 15;

        public static Vector2 TailCountWritePosition { get { return new Vector2(2, GAMEHEIGHT + 3); } }

        private string[,] GameBoard { get; set; }
        Movement m;
        public void Start()
        {
            Music.Music.Start();

            player = new Player();
            player.AddTail(5);
            m = new Movement();
            Field.Field.DrawField();
            player.SetCurrentDirection(NextDirection.RIGHT);
            Food.Start(player);
            player.Start();

            //Music.Music.Start();
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
