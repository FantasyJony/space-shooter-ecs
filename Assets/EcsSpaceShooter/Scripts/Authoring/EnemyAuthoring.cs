using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using System.Collections.Generic;

namespace SpaceShooter
{
    public class EnemyAuthoring : CollisionAuthoring
    {
        public override void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            base.Convert(entity, dstManager, conversionSystem);
            dstManager.AddComponentData(entity, new EnemyTag());
            dstManager.AddComponentData(entity, new AITag());
            
            // dstManager.SetComponentData(entity , new Rotation(){Value = quaternion.LookRotation(new float3(0,-180,0),math.up())});
        }
    }
}