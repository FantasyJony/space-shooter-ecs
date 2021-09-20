using UnityEngine;
using Unity.Entities;

namespace SpaceShooter
{
    public class LifeOfHpAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField] private int m_Hp;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new LifeOfHp()
            {
                value = m_Hp,
                isDestroy = false
            });
        }
    }
}