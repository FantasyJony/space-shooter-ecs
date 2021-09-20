using Unity.Transforms;
using Unity.Mathematics;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace SpaceShooter
{
    public class BulletAuthoring : CollisionAuthoring
    {
        public override void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            base.Convert(entity, dstManager, conversionSystem);
            dstManager.AddComponentData(entity, new BulletTag());
        }
    }
}