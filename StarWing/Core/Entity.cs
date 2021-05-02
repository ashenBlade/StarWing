using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using StarWing.Framework;

namespace StarWing.ECS
{
    public class Entity
    {
        public string Tag { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
        protected List<IComponent> _components { get; private set; }

        public IEnumerable<IComponent> GetAllComponents() => _components;

        public Entity(string tag = null)
        {
            Tag = tag ?? string.Empty;
            _components = new List<IComponent>();
            IsActive = true;
            IsVisible = true;
        }

        public bool Has<T>() where T : Component
        {
            return _components.Any(component => component.GetType() == typeof(T));
        }

        public T Get<T>() where T : Component
        {
            return _components.FirstOrDefault(component => component.GetType() == typeof(T)) as T;
        }

        public void Add<T>(T component) where T : Component
        {
            if (!_components.Contains(component))
            {
                _components.Add(component);
                ComponentAdded?.Invoke(this, component);
            }
        }

        public void Remove<T>(T component) where T : Component
        {
            if (_components.Remove(component))
            {
                ComponentRemoved?.Invoke(this, component);
            }
        }

        public virtual void Update(GameTime gameTime, Input input)
        { }

        public virtual void Render(Graphics graphics)
        { }

        public void DestroySelf()
        {
            Destroy?.Invoke(this);
            IsActive = false;
            IsVisible = false;
            _components.Clear();
        }

        public event Action<Entity, Component> ComponentAdded;
        public event Action<Entity, Component> ComponentRemoved;
        public event Action<Entity> Destroy;
    }
}