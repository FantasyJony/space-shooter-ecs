using UnityEngine;
using Unity.Entities;

namespace SpaceShooter
{
    public class AIHorizontalRotationAuthoring : MonoBehaviour , IConvertGameObjectToEntity
    {
        [SerializeField] private Vector2 m_StartWait;
        [SerializeField] private Vector2 m_ManeuverTime;
        [SerializeField] private Vector2 m_ManeuverWait;
        [SerializeField] private float m_Smoothing;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new AIHorizontalRotation()
            {
                value = 0,
                waitTag = 0,
                waitTime = Random.Range (m_StartWait.x, m_StartWait.y),
                maneuverTime = m_ManeuverTime,
                maneuverWait = m_ManeuverWait,
                smoothing = m_Smoothing,
            });
        }
    }
}