using Unity.Transforms;
using Unity.Mathematics;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace SpaceShooter
{
    public class PlayerSpawnerAuthoring : MonoBehaviour , IConvertGameObjectToEntity , IDeclareReferencedPrefabs
    {
        [SerializeField] private GameObject m_Prefab;
        [SerializeField] private Vector3 m_Pos;
        [SerializeField] private Quaternion m_Rotation;

        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(m_Prefab);
        }
        
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var spawner = new PlayerSpawner()
            {
                prefab = conversionSystem.GetPrimaryEntity(m_Prefab),
                position  = m_Pos,
                quaternion = m_Rotation,
                isSpawn = false
            };
            dstManager.AddComponentData(entity, spawner);
        }
    }
}