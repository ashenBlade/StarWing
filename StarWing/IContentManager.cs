using System;
using StarWing.Framework.Sound;

namespace StarWing.Framework
{
    public interface IContentManager : IDisposable
    {
        SpriteSheet LoadSpriteSheet(string path);
        ISoundEffect LoadSoundEffect(string path);
    }
}