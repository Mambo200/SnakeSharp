using Snake.Game;
using Snake.MultiThreading;
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
            Game.Game.isRunning = true;
            Core.Keyboard kb = new Core.Keyboard();
            Console.SetWindowSize(120, 40);

            //InputTask.Add(DEV.DoTesting);

            while (Game.Game.isRunning)
            {
                Player.alive = true;
                Game.Game g = new Game.Game();
                g.Start();
                while (Player.alive)
                {
                    //InputTask.Update();
                    InputThread.Update();
                    g.Run();
                }

                //InputTask.Update(); // one last time to remove all
                InputThread.RemoveAll();
                // Simulate Keyinput to end Playerinput-Thread "Snake.Game.GetInput()"
                kb.Send(Core.Keyboard.ScanCodeShort.KEY_A);
                Console.SetCursorPosition(5, 5);
                Console.WriteLine("Game Over");
                Console.SetCursorPosition(5, 6);
                Console.WriteLine("Continue? y/n");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.N)
                    Game.Game.isRunning = false;
            }

        }
    }
}
