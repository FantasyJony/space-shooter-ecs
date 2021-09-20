using UnityEngine;
using Unity.Entities;

namespace SpaceShooter
{
    public class BgScrollerAuthoring: MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField] private float m_Speed;
        [SerializeField] private float m_TileSizeZ;
        
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponents(entity, new ComponentTypes(
                typeof(BgScrollSizeData)
            ));
            
            dstManager.SetComponentData(entity, new BgScrollSizeData
            {
               speed = m_Speed,
               tileSizeZ = m_TileSizeZ,
               startPosition = transform.position
            });
        }
    }
}