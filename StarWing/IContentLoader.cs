using StarWing.Framework.Sound;

namespace StarWing.Framework
{
    public interface IContentLoader : IGameComponent
    {
        ISoundEffect LoadSoundEffect(string path);
        SpriteSheet LoadSpriteSheet(string path);
    }
}