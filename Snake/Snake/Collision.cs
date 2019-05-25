using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class Collision
    {
        public static void Update()
        {
            int Height = Game.GAMEHEIGHT;
            int Width = Game.GAMEWIDTH;

            foreach (Tail t in Game.player.Tails)
            {
                if (t.Position.x == 0 || t.Position.y == 0) Player.alive = false; ;
                if (t.Position.x >= Width - 1 || t.Position.y >= Height - 1) Player.alive = false;
            }
        }

        public static bool PlayerObjectCollision(Player _player, Vector2 _other)
        {
            foreach (Tail t in _player.Tails)
            {
                if (t.Position == _other)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool WallCollision(Vector2 _other)
        {
            int Height = Game.GAMEHEIGHT;
            int Width = Game.GAMEWIDTH;

            if (_other.x == 0 || _other.y == 0) return true;
            if (_other.x >= Width - 1 || _other.y >= Height - 1) return true;

            return false;
        }
    }
}
