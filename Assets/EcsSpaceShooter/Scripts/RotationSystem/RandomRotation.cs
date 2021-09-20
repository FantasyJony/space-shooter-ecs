using Unity.Entities;
using Unity.Mathematics;

namespace SpaceShooter
{
    public struct RandomRotation : IComponentData
    {
        public float angle;
        public float3 axis;
    }
}