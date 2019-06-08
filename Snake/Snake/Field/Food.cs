using Snake.Core;
using Snake.Game;
using Snake.MultiThreading;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snake.Field
{
    static class Food
    {
        const char FOODCHAR = '\u2591';
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

            Helper.SetCursorPosition(position);
            Console.Write(FOODCHAR);
            Position = position;

        }

        private static Vector2 NewPosition()
        {
            return
                new Vector2(
                    rnd.Next(1, Game.Game.GAMEWIDTH - 1),
                    rnd.Next(1, Game.Game.GAMEHEIGHT - 1)
                    );
        }

        public static void ResetPosition()
        {
            Spawn();
        }
    }
}
