using UnityEngine;
using Unity.Entities;

namespace SpaceShooter
{
    public class LifeOfDistanceAuthoring: MonoBehaviour , IConvertGameObjectToEntity
    {
        [SerializeField] private float m_Distance;
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new LifeOfDistance()
            { 
                value = 0,
                destroyDistance = m_Distance
            });
        }
    }
}