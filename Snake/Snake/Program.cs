﻿using System;
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
            Game g = new Game();

            Console.SetWindowSize(120, 40);

            while (Game.isRunning)
            {
                g.Run();
            }
        }
    }
}