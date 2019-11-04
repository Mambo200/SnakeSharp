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

        public static SoundPlayer MusicPlayer { get; private set; }

        public static void Start()
        {
            MusicPlayer = new SoundPlayer();
        }

        /// <summary>
        /// Loads the Music File from Resources.
        /// </summary>
        public static void Load(Stream _byteArray, bool _play = true)
        {
            Stop();
            MusicPlayer.Dispose();
            MusicPlayer = new SoundPlayer(_byteArray);
            if (_play)
                Play();
        }

        /// <summary>
        /// Starts Play the music file.
        /// </summary>
        public static void Play() => MusicPlayer.Play();

        /// <summary>
        /// Stops the music.
        /// </summary>
        public static void Stop() => MusicPlayer.Stop();



        public static void PlayGameOver() => Load(new MemoryStream(Properties.Resources.Game_Over));
    }
}
