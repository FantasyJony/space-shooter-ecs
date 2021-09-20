using UnityEngine;
using Unity.Entities;

namespace SpaceShooter
{
    public class LifeOfTimeAuthoring: MonoBehaviour , IConvertGameObjectToEntity
    {
        [SerializeField] private float m_Second;
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new LifeOfTime()
            { 
                value = 0,
                destroyTime = m_Second
            });
        }
    }
}