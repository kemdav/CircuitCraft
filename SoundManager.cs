using System;
using System.Media; // For SoundPlayer (SFX)
using WMPLib;      // For WindowsMediaPlayer (Music)
using System.IO;   // For Path checks
using System.Diagnostics; // For Debug output

namespace CircuitCraft
{

    public static class AudioManager
    {
        // --- Music Section (using Windows Media Player) ---

        private static WindowsMediaPlayer musicPlayer;
        private static string currentMusicFile = "";

        public static string sfxButtonClickFilePath = Path.Combine(Application.StartupPath, "Audio", "buttonClick.wav");

        // Static constructor to initialize the music player once
        static AudioManager()
        {
            try
            {
                musicPlayer = new WindowsMediaPlayer();
                // Set default volume (optional)
                musicPlayer.settings.volume = 50; // 0 to 100
                musicPlayer.settings.autoStart = false; // Don't play immediately when URL is set
            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"Error initializing Windows Media Player: {ex.Message}");
                // Consider showing a MessageBox or logging this error more formally
                musicPlayer = null; // Ensure it's null if initialization failed
            }
        }

        /// <summary>
        /// Plays background music from a specified file path.
        /// </summary>
        /// <param name="filePath">Full path to the music file (e.g., MP3, WAV, WMA).</param>
        /// <param name="loop">True to loop the music, false to play once.</param>
        public static void PlayMusic(string filePath, bool loop = true)
        {
            if (musicPlayer == null)
            {
                //Debug.WriteLine("Music player not initialized.");
                return;
            }

            if (!File.Exists(filePath))
            {
                //Debug.WriteLine($"Music file not found: {filePath}");
                return;
            }

            try
            {
                // Stop previous music if playing a new file
                if (musicPlayer.playState == WMPPlayState.wmppsPlaying && currentMusicFile != filePath)
                {
                    musicPlayer.controls.stop();
                }

                musicPlayer.URL = filePath;
                currentMusicFile = filePath;
                musicPlayer.settings.setMode("loop", loop);
                musicPlayer.controls.play();
                //Debug.WriteLine($"Playing music: {filePath}, Loop: {loop}");
            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"Error playing music file {filePath}: {ex.Message}");
            }
        }

        /// <summary>
        /// Stops the currently playing background music.
        /// </summary>
        public static void StopMusic()
        {
            if (musicPlayer != null && musicPlayer.playState != WMPPlayState.wmppsStopped)
            {
                try
                {
                    musicPlayer.controls.stop();
                    currentMusicFile = ""; // Clear current file tracking
                    //Debug.WriteLine("Music stopped.");
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine($"Error stopping music: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Sets the volume for the background music.
        /// </summary>
        /// <param name="volume">Volume level from 0 (mute) to 100 (full).</param>
        public static void SetMusicVolume(int volume)
        {
            if (musicPlayer == null)
            {
                //Debug.WriteLine("Music player not initialized.");
                return;
            }

            // Clamp volume between 0 and 100
            if (volume < 0) volume = 0;
            if (volume > 100) volume = 100;

            try
            {
                musicPlayer.settings.volume = volume;
                //Debug.WriteLine($"Music volume set to: {volume}");
            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"Error setting music volume: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the current music volume (0-100).
        /// </summary>
        public static int GetMusicVolume()
        {
            if (musicPlayer == null) return 0; // Or maybe a default like 50?
            try
            {
                return musicPlayer.settings.volume;
            }
            catch
            {
                return 0; // Return 0 on error
            }
        }

        // --- SFX Section (using SoundPlayer) ---

        /// <summary>
        /// Plays a sound effect from a specified .wav file path.
        /// Plays asynchronously (doesn't block the main thread).
        /// </summary>
        /// <param name="filePath">Full path to the .wav file.</param>
        public static void PlaySfx(string filePath)
        {
            if (!File.Exists(filePath))
            {
                //Debug.WriteLine($"SFX file not found: {filePath}");
                return;
            }

            try
            {
                // Create a new SoundPlayer instance each time for simplicity
                // and to allow overlapping SFX if needed.
                SoundPlayer sfxPlayer = new SoundPlayer(filePath);
                sfxPlayer.Play(); // Play asynchronously
                //Debug.WriteLine($"Playing SFX: {filePath}");

                // Note: SoundPlayer instances playing asynchronously might get garbage collected
                // if the method exits too quickly and nothing holds a reference.
                // For very short sounds or frequent plays, managing instances might be better,
                // but for simplicity, this often works. If sounds cut off, consider managing
                // a list of active SoundPlayer instances.
            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"Error playing SFX file {filePath}: {ex.Message}");
            }
        }
    }
}