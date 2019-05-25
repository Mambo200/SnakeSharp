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
    }
}
