using System;
using System.Media;

namespace StarWing.Framework.Sound
{
    public class EmptySoundEffect : ISoundEffect
    {
        public void Play()
        {
        }

        public void Stop()
        {
        }

        public void Pause()
        {
        }

        public bool IsRepeatable { get; set; }
    }
}