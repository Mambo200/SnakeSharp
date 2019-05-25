using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class DEV
    {
        public static void DoTesting()
        {
            do
            {
                ConsoleKeyInfo kI = Console.ReadKey();
                string toWrite = "";
                switch (kI.Key)
                {
                    case ConsoleKey.LeftArrow:
                        toWrite += FieldChars.PLAYER_HORIZONTAL + "\n";
                        toWrite += FieldChars.PLAYER_D2L + "\n";
                        toWrite += FieldChars.PLAYER_R2U + "\n";
                        break;
                    case ConsoleKey.UpArrow:
                        toWrite += FieldChars.PLAYER_VERTICAL + "\n";
                        break;
                    case ConsoleKey.RightArrow:
                        toWrite += FieldChars.PLAYER_HORIZONTAL + "\n";
                        toWrite += FieldChars.PLAYER_U2R + "\n";
                        toWrite += FieldChars.PLAYER_L2D + "\n";
                        break;
                    case ConsoleKey.DownArrow:
                        toWrite += FieldChars.PLAYER_VERTICAL + "\n";
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        break;
                    case ConsoleKey.W:
                        toWrite += FieldChars.WALL + "\n";
                        break;
                    case ConsoleKey.F:
                        toWrite += FieldChars.FOOD + "\n";
                        break;
                    default:
                        break;
                }

                Console.Write(toWrite);
            } while (true);
        }
    }
}
