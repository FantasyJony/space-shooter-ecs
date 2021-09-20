using Unity.Transforms;
using Unity.Mathematics;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace SpaceShooter
{
    public class RandomRotationAuthoring: MonoBehaviour , IConvertGameObjectToEntity
    {
        [SerializeField] private float m_RotationSpeed;
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new RotationSpeed() { value = m_RotationSpeed });
            dstManager.AddComponentData(entity, new RandomRotation()
            {
                angle = 0f,
                axis = UnityEngine.Random.onUnitSphere
            } );
        }
    }
}