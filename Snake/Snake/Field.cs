using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FC = Snake.FieldChars;

namespace Snake
{
    static class Field
    {
        public static string[] DrawField()
        {
            Console.Clear();

            int height = Game.GAMEHEIGHT;
            int width = Game.GAMEWIDTH;
            string[] toDraw = new string[height];

            // draw borders
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    if (w == 0 || h == 0 || w == width - 1 || h == height - 1)
                    {
                        toDraw[h] += FC.WALL;
                    }
                    else
                    {
                        toDraw[h] += FC.EMPTY;
                    }
                }
            }

            Console.WriteLine(ArrayToString(toDraw));
            return toDraw;
        }

        private static string ArrayToString(string[] _array)
        {
            string toReturn = "";

            foreach (string s in _array)
            {
                toReturn += s + '\n';
            }

            return toReturn;
        }
    }


    public static class FieldChars
    {
        /// <summary>"█"</summary>
        public const char WALL = '\u2588';
        /// <summary>"#"</summary>
        public const char FOOD = '\u0023';

        /// <summary>Empty field. " "</summary>
        public const char EMPTY = '\u2000';

        /// <summary>Up and Down. "│"</summary>
        public const char PLAYER_VERTICAL = '\u2502';
        /// <summary>left and Right. "─"</summary>
        public const char PLAYER_HORIZONTAL = '\u2500';

        /// <summary>Down to Right. "└"</summary>
        public const char PLAYER_D2R = '\u2514';
        /// <summary>Left to Up. "└"</summary>
        public const char PLAYER_L2U = '\u2514';

        /// <summary>Down to Left. "┘"</summary>
        public const char PLAYER_D2L = '\u2518';
        /// <summary>Right to Down. "┘"</summary>
        public const char PLAYER_R2U = '\u2518';

        /// <summary>Up to Right. "┌"</summary>
        public const char PLAYER_U2R = '\u250C';
        /// <summary>Left to Down. "┌"</summary>
        public const char PLAYER_L2D = '\u250C';

        /// <summary>Up to Left. "┐"</summary>
        public const char PLAYER_U2L = '\u2510';
        /// <summary>Right to Down. "┐"</summary>
        public const char PLAYER_R2D = '\u2510';
    }
}
