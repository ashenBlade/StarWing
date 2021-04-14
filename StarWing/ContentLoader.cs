using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using StarWing.Framework.Sound;

namespace StarWing.Framework
{
    public class ContentLoader : IContentLoader
    {
        private Dictionary<string, ISoundEffect> _soundEffects;
        private Dictionary<string, SpriteSheet> _spriteSheets;

        private string GetFullPath(string path)
        {
            var uri = new Uri(path);
            return uri.AbsolutePath;
        }

        public ContentLoader()
        {
            _soundEffects = new Dictionary<string, ISoundEffect>();
            _spriteSheets = new Dictionary<string, SpriteSheet>();
        }
        public ISoundEffect LoadSoundEffect(string path)
        {
            path = path ?? throw new ArgumentNullException(nameof(path));
            var fullPath = GetFullPath(path);
            if (_soundEffects.ContainsKey(fullPath))
            {
                return _soundEffects[fullPath];
            }
            // Not implemented yet
            return null;
        }

        public SpriteSheet LoadSpriteSheet(string path)
        {
            path = path ?? throw new ArgumentNullException(nameof(path));
            var fullPath = GetFullPath(path);
            if (_spriteSheets.ContainsKey(fullPath))
            {
                return _spriteSheets[fullPath];
            }

            var image = Image.FromFile(path);
            var spriteSheet = new SpriteSheet(image);
            _spriteSheets[fullPath] = spriteSheet;
            return spriteSheet;
        }

        public void Initialize()
        {

        }
    }
}