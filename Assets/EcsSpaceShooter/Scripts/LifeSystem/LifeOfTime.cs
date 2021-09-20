using Unity.Entities;

namespace SpaceShooter
{
    public struct LifeOfTime : IComponentData
    {
        public float value;
        public float destroyTime;
    }
}