using StarWing.Framework;

namespace StarWing.GameObjectModel
{
    public abstract class GameObjectModel
    {
        public Sprite Sprite { get; }

        public GameObjectModel(Sprite sprite)
        {
            Sprite = sprite;
        }
    }
}