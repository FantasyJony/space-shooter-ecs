using Unity.Entities;
using Unity.Mathematics;

namespace SpaceShooter
{
    public struct BgScrollSizeData : IComponentData
    {
        public float speed;
        public float tileSizeZ;
        public float3 startPosition;
    }
}