using Unity.Entities;

namespace SpaceShooter
{
    public struct DestroyByContact : IComponentData
    {
        public Entity explosion;
        public int score;
    }
}