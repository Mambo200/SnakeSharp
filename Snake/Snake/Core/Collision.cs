using Snake.Field;
using Snake.Game;
using Snake.MultiThreading;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snake.Core
{
    static class Collision
    {
        /// <summary>
        /// Check Collision every Frame.
        /// </summary>
        public static void Update()
        {
            int Height = Game.Game.GAMEHEIGHT;
            int Width = Game.Game.GAMEWIDTH;

            // check wall collision
            foreach (Tail t in Game.Game.player.Tails)
            {
                if (t.Position.x == 0 || t.Position.y == 0) Player.alive = false;

                if (t.Position.x >= Width - 1 || t.Position.y >= Height - 1)
                {
                    Player.alive = false;
                    //Music.Music.PlayGameOver();
                }
            }

            // check if player collided with any Tail
            {
                for (int i = 0; i < Game.Game.player.TailLengh; i++)
                {
                    if (i == 0) continue;

                    if (Game.Game.player.Tails[0].Position == Game.Game.player.Tails[i].Position)
                    {
                        Player.alive = false;
                        //Music.Music.PlayGameOver();
                    }
                }
            }

            // check if player collided with food
            if (Game.Game.player.Tails[0].Position == Food.Position)
            {
                Game.Game.player.AddTail();
                Game.Game.player.AddScore();
                Food.ResetPosition(false);
            }
        }

        public static bool PlayerObjectCollision(Player _player, Vector2 _other)
        {
            foreach (Tail t in _player.Tails)
            {
                if (t.Position == _other)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool WallCollision(Vector2 _other)
        {
            int Height = Game.Game.GAMEHEIGHT;
            int Width = Game.Game.GAMEWIDTH;

            if (_other.x == 0 || _other.y == 0) return true;
            if (_other.x >= Width - 1 || _other.y >= Height - 1) return true;

            return false;
        }
    }
}
