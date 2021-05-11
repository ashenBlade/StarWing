using System;
using System.Collections.Generic;
using System.Drawing;
using StarWing.ECS;
using StarWing.GameObjects.SceneObjects;

namespace StarWing.Core
{
    public interface IWorld
    {
        IEventManager EventManager { get; }
        void RegisterGameObject(GameObject gameObject);
        void RemoveGameObject(GameObject gameObject);
        event Action<GameObject> GameObjectAdded;
        event Action<GameObject> GameObjectRemoved;
        IReadOnlyCollection<GameObject> AllGameObjects { get; }
        RectangleF Bounds { get; }
    }
}