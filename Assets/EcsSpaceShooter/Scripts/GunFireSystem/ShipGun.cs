using Unity.Entities;
using Unity.Mathematics;

namespace SpaceShooter
{
    public struct ShipGun : IComponentData
    {
        public Entity prefab;
        public float rate;
        public float3 startOffset;

        public float nextFire;
        public bool isFire;
        public bool wasFire;
    }
}