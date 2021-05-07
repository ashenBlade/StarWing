using System.Collections.Generic;
using StarWing.Core;
using StarWing.Framework;

namespace StarWing.GameObjects.Manager
{
    public class CollisionManager : Manager
    {
        private List<GameObject> _allGameObjects;

        public CollisionManager()
        {
            _allGameObjects = new List<GameObject>();
        }
        public override void Initialize(IWorld world)
        {
            base.Initialize(world);
            foreach (var gameObject in world.AllGameObjects)
            {
                if (!_allGameObjects.Contains(gameObject))
                {
                    _allGameObjects.Add(gameObject);
                }
            }
            world.GameObjectAdded += WorldOnGameObjectAdded;
            world.GameObjectRemoved += WorldOnGameObjectRemoved;
        }

        private void WorldOnGameObjectRemoved(GameObject obj)
        {
            _allGameObjects.Remove(obj);
        }

        private void WorldOnGameObjectAdded(GameObject obj)
        {
            if (_allGameObjects.Contains(obj))
                return;
            _allGameObjects.Add(obj);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            for (int i = 0; i < _allGameObjects.Count; i++)
            {
                for (int j = i + 1; j < _allGameObjects.Count; j++)
                {
                    var first = _allGameObjects[i];
                    var second = _allGameObjects[j];
                    if (AreColliding(first, second))
                    {
                        first.OnCollision(second);
                        second.OnCollision(first);
                    }
                }
            }
        }

        private bool AreColliding(GameObject first, GameObject second)
        {
            return first.BoundingBox.IntersectsWith(second.BoundingBox);
        }
    }
}