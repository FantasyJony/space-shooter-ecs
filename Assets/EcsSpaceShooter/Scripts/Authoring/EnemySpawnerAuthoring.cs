
using Unity.Transforms;
using Unity.Mathematics;
using System.Collections.Generic;

using UnityEngine;
using Unity.Entities;

namespace SpaceShooter
{
    public class EnemySpawnerAuthoring : MonoBehaviour , IConvertGameObjectToEntity , IDeclareReferencedPrefabs
    {
        [SerializeField] private GameObject[] m_Hazards;
        [SerializeField] private int m_HazardCount;
        [SerializeField] private float m_SpawnWait;
        [SerializeField] private float m_StartWait;
        [SerializeField] private float m_WaveWait;
        
        [SerializeField] private Vector3 m_SpawnValues;

        [SerializeField] private Vector3 m_Forward;
        
        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            for (int i = 0; i < m_Hazards.Length; i++)
            {
                referencedPrefabs.Add(m_Hazards[i]);
            }
        }
        
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var enemySpawner = new EnemySpawner()
            {
                spawnWait = m_SpawnWait,
                startWait = m_StartWait,
                waveWait = m_WaveWait,
                spawnValues = m_SpawnValues,
                
                waitTag = 0,
                waitTime = 0f,
                spawnCount = 0,

                length = m_Hazards.Length,
                hazardCount = m_HazardCount,
                
                prefab1 = conversionSystem.GetPrimaryEntity(m_Hazards[0]),
                prefab2 = conversionSystem.GetPrimaryEntity(m_Hazards[1]),
                prefab3 = conversionSystem.GetPrimaryEntity(m_Hazards[2]),
                prefab4 = conversionSystem.GetPrimaryEntity(m_Hazards[3]),
                prefab5 = conversionSystem.GetPrimaryEntity(m_Hazards[4]),

                rotation = quaternion.LookRotation(m_Forward , Vector3.up),
            };
            dstManager.AddComponentData(entity, enemySpawner);
        }
    }
}