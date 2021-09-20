using UnityEngine;
using Unity.Entities;

namespace SpaceShooter
{
    enum CollisionType
    {
        None = 0,
        Player = 1,
        Enemy = 2,
    }

    public class CollisionAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField] private float m_Radius;
        [SerializeField] private CollisionType m_CollisionType;

        public virtual void Convert(Entity entity, EntityManager dstManager,
            GameObjectConversionSystem conversionSystem)
        {
            if (m_CollisionType == CollisionType.None)
            {
                Debug.LogError($"m_CollisionType = {m_CollisionType}");
            }
            else if (m_CollisionType == CollisionType.Player)
            {
                dstManager.AddComponentData(entity, new CollisionPlayerTag() { radius = m_Radius });
            }
            else if (m_CollisionType == CollisionType.Enemy)
            {
                dstManager.AddComponentData(entity, new CollisionEnemyTag() { radius = m_Radius });
            }
        }
    }
}