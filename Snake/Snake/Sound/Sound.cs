using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Sound
{
    public static class SoundPlay
    {
        public static bool IsBeingPlayed { get; private set; }
        private static System.Media.SoundPlayer playerEat = new System.Media.SoundPlayer(Properties.Resources.pacman_chomp);

        public static void MakeEatSound()
        {
            playerEat.Play();
        }
    }
}
