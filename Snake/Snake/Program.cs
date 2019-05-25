using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.isRunning = true;

            Console.SetWindowSize(120, 40);


            //InputTask.Add(DEV.DoTesting);

            while (Game.isRunning)
            {
                Player.alive = true;
                Game g = new Game();
                g.Start();
                while (Player.alive)
                {
                    InputTask.Update();
                    g.Run();
                }

                InputTask.RemoveAll();
                Console.SetCursorPosition(5, 5);
                Console.WriteLine("Game Over");
                Console.SetCursorPosition(5, 6);
                Console.WriteLine("Continue? y/n");
                if (Console.ReadKey().Key == ConsoleKey.N)
                    Game.isRunning = false;
            }

        }
    }
}
