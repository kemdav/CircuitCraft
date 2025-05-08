using System;
using System.Media;
using WMPLib;  
using System.IO; 
using System.Diagnostics; 

namespace CircuitCraft
{

    public static class AudioManager
    {

        private static WindowsMediaPlayer musicPlayer;
        private static string currentMusicFile = "";

        public static string sfxButtonClickFilePath = Path.Combine(Application.StartupPath, "Audio", "buttonClick.wav");

        static AudioManager()
        {
            try
            {
                musicPlayer = new WindowsMediaPlayer();
                musicPlayer.settings.volume = 50;
                musicPlayer.settings.autoStart = false;
            }
            catch (Exception ex)
            {
                musicPlayer = null; 
            }
        }

        public static void PlayMusic(string filePath, bool loop = true)
        {
            if (musicPlayer == null)
            {
                return;
            }

            if (!File.Exists(filePath))
            {
                return;
            }

            try
            {
                if (musicPlayer.playState == WMPPlayState.wmppsPlaying && currentMusicFile != filePath)
                {
                    musicPlayer.controls.stop();
                }

                musicPlayer.URL = filePath;
                currentMusicFile = filePath;
                musicPlayer.settings.setMode("loop", loop);
                musicPlayer.controls.play();
            }
            catch (Exception ex)
            {
            }
        }

        public static void StopMusic()
        {
            if (musicPlayer != null && musicPlayer.playState != WMPPlayState.wmppsStopped)
            {
                try
                {
                    musicPlayer.controls.stop();
                    currentMusicFile = ""; 
                }
                catch (Exception ex)
                {
                }
            }
        }

        public static void SetMusicVolume(int volume)
        {
            if (musicPlayer == null)
            {
                return;
            }

            if (volume < 0) volume = 0;
            if (volume > 100) volume = 100;

            try
            {
                musicPlayer.settings.volume = volume;
            }
            catch (Exception ex)
            {
            }
        }


        public static int GetMusicVolume()
        {
            if (musicPlayer == null) return 0; 
            try
            {
                return musicPlayer.settings.volume;
            }
            catch
            {
                return 0; 
            }
        }

        public static void PlaySfx(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            try
            {
                SoundPlayer sfxPlayer = new SoundPlayer(filePath);
                sfxPlayer.Play();
            }
            catch (Exception ex)
            {
            }
        }
    }
}