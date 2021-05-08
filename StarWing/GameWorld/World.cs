using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using StarWing.Core;
using StarWing.ECS;
using StarWing.Framework;
using StarWing.GameObjects.Items;
using StarWing.GameObjects.Manager;
using StarWing.GameObjects.SceneObjects;

namespace StarWing.GameWorld
{
    public class World : IWorld
    {
        private List<GameObject> _toAdd;
        private List<GameObject> _toRemove;
        private List<GameObject> _entities;

        private List<Manager> _managers;

        public IEventManager EventManager { get; }
        public IReadOnlyCollection<GameObject> AllGameObjects =>
            _entities;

        public Rectangle Bounds { get; }

        public World(Rectangle bounds, IEventManager eventManager)
        {
            Bounds = bounds;
            // EventManager = eventManager ?? throw new ArgumentNullException(nameof(eventManager));
            _toAdd = new List<GameObject>();
            _toRemove = new List<GameObject>();
            _entities = new List<GameObject>();
            _managers = new List<Manager>();
        }


        public void RegisterManager(Manager manager)
        {
            if (!_managers.Contains(manager))
            {
                manager.Initialize(this);
                _managers.Add(manager);
            }
        }

        private void UpdateEntitiesCollection()
        {
            if (_toAdd.Count > 0)
            {
                foreach (var entity in _toAdd.Where(entity => !_entities.Contains(entity)))
                {
                    _entities.Add(entity);
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
            _managers.ForEach(m => m.Update(gameTime));
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