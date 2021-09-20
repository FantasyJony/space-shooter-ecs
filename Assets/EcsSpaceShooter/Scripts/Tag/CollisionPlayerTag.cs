using Unity.Entities;
using Unity.Mathematics;

namespace SpaceShooter
{
    public struct CollisionPlayerTag : IComponentData
    {
        public float radius;
    }
}