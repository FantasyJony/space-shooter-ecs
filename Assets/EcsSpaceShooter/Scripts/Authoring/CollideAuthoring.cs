using UnityEngine;
using Unity.Entities;

namespace SpaceShooter
{
    enum CollideType
    {
        None = 0,
        Player = 1,
        Enemy = 2,
    }

    public class CollideAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField] private float m_Radius;
        [SerializeField] private CollideType m_CollideType;

        public virtual void Convert(Entity entity, EntityManager dstManager,
            GameObjectConversionSystem conversionSystem)
        {
            if (m_CollideType == CollideType.None)
            {
                Debug.LogError($"m_CollideType = {m_CollideType}");
            }
            else if (m_CollideType == CollideType.Player)
            {
                dstManager.AddComponentData(entity, new CollidePlayerTag() { radius = m_Radius });
            }
            else if (m_CollideType == CollideType.Enemy)
            {
                dstManager.AddComponentData(entity, new CollideEnemyTag() { radius = m_Radius });
            }
        }
    }
}