using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace SpaceShooter
{
    public class HorizontalRotationAuthoring : MonoBehaviour , IConvertGameObjectToEntity
    {
        [SerializeField] private float m_Speed;
        [SerializeField] private Vector3 m_Forward;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new RotationSpeed() { value = m_Speed });
            dstManager.AddComponentData(entity, new HorizontalRotation { value = Quaternion.LookRotation(m_Forward) });
            dstManager.AddComponentData(entity, new HorizontalAngle
            {
                value = 0f,
                @from = 0f,
                to = 0f,
                deltaTime = 0f,
                time = 0f
            });
        }
    }
}