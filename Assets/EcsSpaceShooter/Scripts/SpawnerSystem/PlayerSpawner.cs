using  Unity.Entities;
using Unity.Mathematics;

namespace SpaceShooter
{
    public struct PlayerSpawner : IComponentData
    {
        public Entity prefab;
        public float3 position;
        public quaternion quaternion;
        public bool isSpawn;
    }
}