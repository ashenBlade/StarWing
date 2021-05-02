using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using StarWing.Framework;

namespace StarWing.ECS
{
    public class World
    {
        private List<Entity> _toAdd;
        private List<Entity> _toRemove;
        private List<Entity> _entities;

        public IReadOnlyCollection<Entity> Entities =>
            _entities;

        public event Action<Entity> EntityAdded;
        public event Action<Entity> EntityRemoved;

        public World()
        {
            _entities = new List<Entity>();
            _toAdd = new List<Entity>();
            _toRemove = new List<Entity>();
        }

        public void AddEntity(Entity entity)
        {
            if (!_toAdd.Contains(entity))
            {
                _toAdd.Add(entity);
            }
        }

        public void DestroyEntity(Entity entity)
        {
            if (!_toRemove.Contains(entity))
            {
                _toRemove.Add(entity);
            }
        }

        private void UpdateEntitiesCollection()
        {
            if (_toAdd.Count > 0)
            {
                foreach (var entity in _toAdd)
                {
                    entity.Destroy += DestroyEntity;
                    _entities.Add(entity);
                    EntityAdded?.Invoke(entity);
                }
                _toAdd.Clear();
            }

            if (_toRemove.Count > 0)
            {
                foreach (var entity in _toRemove)
                {
                    if (_entities.Remove(entity))
                    {
                        EntityRemoved?.Invoke(entity);
                    }
                }
                _toRemove.Clear();
            }
        }

        public void Update(GameTime gameTime, Input input)
        {
            UpdateEntitiesCollection();
            _entities.ForEach(e => e.Update(gameTime, input));
        }

        public void Render(Graphics graphics)
        {
            foreach (var entity in _entities.Where(e => e.IsVisible))
            {
                entity.Render(graphics);
            }
        }
    }
}