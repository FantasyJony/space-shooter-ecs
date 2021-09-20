using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using System.Collections.Generic;

namespace SpaceShooter
{
    public class GunAuthoring : MonoBehaviour ,IConvertGameObjectToEntity , IDeclareReferencedPrefabs
    {
        [SerializeField] private GameObject m_Bullet;
        [SerializeField] private float m_Rate;
        [SerializeField] private Vector3 m_StartOffset;
        
        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(m_Bullet);
        }
        
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new ShipGun()
            {
                prefab =  conversionSystem.GetPrimaryEntity(m_Bullet),
                startOffset = m_StartOffset,
                rate = m_Rate,
                
                nextFire = 0,
                isFire = false,
                wasFire = false
            });
        }
    }
}