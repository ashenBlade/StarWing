using System.Collections;
using System.Collections.Generic;

namespace StarWing
{
    public interface IGameObjectManager
    {
        void Register(GameObject gameObject);
        IEnumerable<GameObject> AllGameObjects { get; }
        // Player Player { get; }
    }
}