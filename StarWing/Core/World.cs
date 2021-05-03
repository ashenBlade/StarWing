using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using StarWing.Core;
using StarWing.Framework;

namespace StarWing.ECS
{
    public class World : IWorld
    {
        private List<GameObject> _toAdd;
        private List<GameObject> _toRemove;
        private List<GameObject> _entities;

        public IEventManager EventManager { get; }
        public IReadOnlyCollection<GameObject> AllGameObjects =>
            _entities;

        public World(IEventManager eventManager)
        {
            EventManager = eventManager ?? throw new ArgumentNullException(nameof(eventManager));
            _toAdd = new();
            _toRemove = new();
            _entities = new();
        }

        private void UpdateEntitiesCollection()
        {
            if (_toAdd.Count > 0)
            {
                foreach (var entity in _toAdd.Where(entity => !_entities.Contains(entity)))
                {
                    _entities.Add(entity);
                    entity.Initialize(this);
                    GameObjectAdded?.Invoke(entity);
                }

                _toAdd.Clear();
            }

            if (_toRemove.Count > 0)
            {
                foreach (var entity in _toRemove)
                {
                    if (_entities.Remove(entity))
                    {
                        GameObjectRemoved?.Invoke(entity);
                    }
                }
                _toRemove.Clear();
            }
        }

        public void Update(GameTime gameTime, Input input)
        {
            _entities.ForEach(e => e.Update(gameTime, input));
            UpdateEntitiesCollection();
        }

        public void Render(Graphics graphics)
        {
            foreach (var entity in _entities)
            {
                entity.Render(graphics);
            }
        }


        public void RegisterGameObject(GameObject gameObject)
        {
            if (!_toAdd.Contains(gameObject))
            {
                _toAdd.Add(gameObject);
            }
        }

        public void RemoveGameObject(GameObject gameObject)
        {
            if (!_toRemove.Contains(gameObject))
            {
                _toRemove.Add(gameObject);
            }
        }

        public event Action<GameObject> GameObjectAdded;
        public event Action<GameObject> GameObjectRemoved;
    }
}