using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class Food
    {
        private static Random rnd = new Random();
        private static Player m_player;

        public static Vector2 Position { get; private set; }
        private static DateTime spawnTime;

        public static void Start(Player _player)
        {
            m_player = _player;
            Spawn();
        }

        public static void Update()
        {

        }

        private static void Spawn()
        {
            Vector2 position;

            do
            {
                position = NewPosition();

            } while (Collision.PlayerObjectCollision(m_player, position));

        }

        private static Vector2 NewPosition()
        {
            return new Vector2(rnd.Next(1, Game.GAMEWIDTH), rnd.Next(1, Game.GAMEHEIGHT));
        }
    }
}
