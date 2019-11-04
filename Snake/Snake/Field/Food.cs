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
        private static TimeSpan FoodLiveTime { get; set; }

        public static void Start(Player _player)
        {
            m_player = _player;
            Spawn();
            FoodLiveTime = new TimeSpan(0, 0, 5);
        }

        public static void Update()
        {
            // Check if living time of Food
            if(DateTime.Now - spawnTime >= FoodLiveTime)
            {
                // Food expired
                ResetPosition(true);
            }
        }

        /// <summary>
        /// Spawn Food
        /// </summary>
        private static void Spawn()
        {
            Vector2 position;

            // Get empty collision by random
            do
            {
                position = NewPosition();
            } while (Collision.PlayerObjectCollision(m_player, position));

            Helper.SetCursorPosition(position);
            Console.Write(FOODCHAR);
            Position = position;

            spawnTime = DateTime.Now;

        }

        /// <summary>
        /// Get a random Position inside the game field
        /// </summary>
        /// <returns>new random Position</returns>
        private static Vector2 NewPosition()
        {
            return
                new Vector2(
                    rnd.Next(1, Game.Game.GAMEWIDTH - 1),
                    rnd.Next(1, Game.Game.GAMEHEIGHT - 1)
                    );
        }

        public static void ResetPosition(bool _destroyOld)
        {
            if (_destroyOld)
            {
                Helper.SetCursorPosition(Position);
                Console.Write(FieldChars.EMPTY);
            }

            Spawn();
        }
    }
}
