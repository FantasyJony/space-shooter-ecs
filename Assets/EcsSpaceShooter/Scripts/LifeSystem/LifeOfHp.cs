using Unity.Entities;

namespace SpaceShooter
{
    public struct LifeOfHp : IComponentData
    {
        public int value;
        public bool isDestroy;
    }
}