using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using System.Windows.Media;
using System.Runtime.InteropServices;
using Snake.MultiThreading;


namespace Snake.Music
{
    public static class Music
    {
        private static object loadMusic = new object();

        public static SoundPlayer GameOverPlayer { get; private set; }
        public static SoundPlayer BGMPlayer { get; private set; }

        public static void Start()
        {
            GameOverPlayer = new SoundPlayer(Properties.Resources.Game_Over1);
            BGMPlayer = new SoundPlayer(Properties.Resources.Background_Music);
        }

        /// <summary>
        /// Starts Play the Background music.
        /// </summary>
        public static void PlayBGM() => BGMPlayer.PlayLooping();

        /// <summary>
        /// Stops the Background music.
        /// </summary>
        public static void StopBGM() => BGMPlayer.Stop();


        /// <summary>
        /// Starts Play the game over music
        /// </summary>
        public static void PlayGameOver() => GameOverPlayer.Play();
    }
}
