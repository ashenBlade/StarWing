namespace StarWing.Framework.Sound
{
    public interface ISoundEffect
    {
        void Play();
        void Pause();
        void Stop();
        bool IsRepeatable { get; set; }
    }
}