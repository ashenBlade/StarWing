using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using StarWing.Framework.Sound;

namespace StarWing.Framework
{
    public class ContentManager : IContentManager
    {
        private Dictionary<string, SpriteSheet> _spriteSheets;
        private Dictionary<string, ISoundEffect> _soundEffects;

        public ContentManager()
        {
            _spriteSheets = new Dictionary<string, SpriteSheet>();
            _soundEffects = new Dictionary<string, ISoundEffect>();
        }

        public SpriteSheet LoadSpriteSheet(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (_spriteSheets.ContainsKey(path) && !_spriteSheets[path].Disposed)
            {
                return _spriteSheets[path];
            }

            Image image = null;
            try
            {
                image = Image.FromFile(path);
            }
            catch (FileNotFoundException e)
            {
                throw;
            }
            catch (OutOfMemoryException e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }

            var sprite = new SpriteSheet(image);
            _spriteSheets[path] = sprite;
            return sprite;
        }

        // Not implemented sound support
        public ISoundEffect LoadSoundEffect(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            return new EmptySoundEffect();
        }

        public FontCollection LoadFont(string path)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }
    }
}