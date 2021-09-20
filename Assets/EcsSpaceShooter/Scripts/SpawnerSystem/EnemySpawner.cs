using Unity.Entities;
using Unity.Mathematics;

namespace SpaceShooter
{
    public struct EnemySpawner : IComponentData
    {
        public Entity prefab1;
        public Entity prefab2;
        public Entity prefab3;
        public Entity prefab4;
        public Entity prefab5;

        public int hazardCount;
        public int length;
        
        public float spawnWait;
        public float startWait;
        public float waveWait;
        public float3 spawnValues;

        public quaternion rotation;

        public int spawnCount;
        public int waitTag; // 0 = startWait, 1 = spawnWait, 2 = waveWait
        public float waitTime;
    }
}