using UnityEngine;
using System.Collections.Generic;
using Unity.Entities;

namespace SpaceShooter
{
    public class DestroyByContactAuthoring : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
    {
        [SerializeField] private GameObject m_Explosion;
        [SerializeField] private int m_Score;

        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(m_Explosion);
        }

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var destroyByContact = new DestroyByContact()
            {
                explosion = conversionSystem.GetPrimaryEntity(m_Explosion),
                score = m_Score
            };
            dstManager.AddComponentData(entity, destroyByContact);
        }
    }
}