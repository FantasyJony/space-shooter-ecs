using Unity.Entities;

namespace SpaceShooter
{
    public struct LifeOfDistance : IComponentData
    {
        public float value;
        public float destroyDistance;
    }
}