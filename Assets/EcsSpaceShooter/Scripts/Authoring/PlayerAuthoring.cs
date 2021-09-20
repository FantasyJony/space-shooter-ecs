using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using System.Collections.Generic;

namespace SpaceShooter
{
    public class PlayerAuthoring : CollisionAuthoring
    {
        public override void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            base.Convert(entity, dstManager, conversionSystem);
            dstManager.AddComponentData(entity, new PlayerTag());
        }
    }
}