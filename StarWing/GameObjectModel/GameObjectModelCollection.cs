using System.Collections.Generic;

namespace StarWing.GameObjectModel
{
    public class GameObjectModelCollection
    {
        public GameObjectModelCollection(ShipModel playerModel, IEnumerable<ShipModel> shipModels, IEnumerable<PowerUpModel> powerUpModels)
        {
            ShipModels = shipModels;
            PowerUpModels = powerUpModels;
            PlayerModel = playerModel;
        }
        public IEnumerable<ShipModel> ShipModels { get; private set; }
        public IEnumerable<PowerUpModel> PowerUpModels { get; private set; }
        public ShipModel PlayerModel { get; private set; }

    }
}