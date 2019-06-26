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
        private static IntPtr pointer = new IntPtr();
        private static MemoryStream musicStream;
        private static object loadMusic = new object();

        private static SoundPlayer musicplayer;
        public static SoundPlayer MusicPlayer
        {
            get
            {
                if (musicplayer == null) musicplayer = new System.Media.SoundPlayer(musicStream);
                return musicplayer;
            }
        }

        public static void Start()
        {
            AsyncCallback c = new AsyncCallback(ProcessDnsInformation);
            byte[] buffer = new byte[1024];
            Properties.Resources.PlayMusic.BeginRead
                (
                buffer,
                0,
                (int)Properties.Resources.PlayMusic.Length,
                c,
                loadMusic
                );


            InputTask.Add(First);
            InputTask.Add(Second);

            //Marshal.FreeHGlobal(pointer);

            
        }

        /// <summary>
        /// Loads the Music File from Resources.
        /// </summary>
        public static void Load()   => MusicPlayer.LoadAsync();

        /// <summary>
        /// Starts Play the music file.
        /// </summary>
        public static void Play()   => MusicPlayer.Play();

        /// <summary>
        /// Stops the music.
        /// </summary>
        public static void Stop()   => MusicPlayer.Stop();

        private static void ProcessDnsInformation (IAsyncResult result)
        {

        }

        private static void First()
        {
            pointer = Marshal.AllocCoTaskMem(1024000000);
        }

        private static void Second()
        {
            System.Threading.Thread.Sleep(1000);
            Marshal.FreeHGlobal(pointer);
        }


    }
}
