using Unity.Entities;
using Unity.Mathematics;

namespace SpaceShooter
{
    public struct CollisionEnemyTag : IComponentData
    {
        public float radius;
    }
}