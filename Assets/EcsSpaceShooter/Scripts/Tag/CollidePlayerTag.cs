using Unity.Entities;
using Unity.Mathematics;

namespace SpaceShooter
{
    public struct CollideEnemyTag : IComponentData
    {
        public float radius;
    }
}