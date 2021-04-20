using System.Collections.Generic;

namespace StarWing
{
    public class GameObjectManager : IGameObjectManager
    {
        private readonly List<GameObject> _gameObjects;

        public GameObjectManager()
        {
            _gameObjects = new List<GameObject>();
        }
        public void Register(GameObject gameObject)
        {
            gameObject.Destroy += (sender, args) => _gameObjects.Remove(gameObject);
            _gameObjects.Add(gameObject);
        }

        public IEnumerable<GameObject> AllGameObjects =>
            _gameObjects;
    }
}