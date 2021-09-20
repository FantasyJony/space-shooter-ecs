using Unity.Entities;
using Unity.Mathematics;

namespace SpaceShooter
{
    public struct CollidePlayerTag : IComponentData
    {
        public float radius;
    }
}