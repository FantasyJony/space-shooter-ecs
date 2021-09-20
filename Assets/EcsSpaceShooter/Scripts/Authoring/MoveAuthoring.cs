using UnityEngine;
using Unity.Entities;

namespace SpaceShooter
{
    public class MoveAuthoring : MonoBehaviour , IConvertGameObjectToEntity
    {
        [SerializeField] private float m_Speed;
        [SerializeField] private Vector3 m_Forward;
        
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new MoveForward() {value =  {x = m_Forward.x , y = m_Forward.z}} );
            dstManager.AddComponentData(entity, new MoveSpeed()
            {
                value = m_Speed,
            });
        }
    }
}