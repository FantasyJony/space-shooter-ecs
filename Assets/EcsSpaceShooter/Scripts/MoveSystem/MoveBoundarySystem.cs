using System;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

namespace SpaceShooter
{
    [UpdateAfter(typeof(MoveSystem))]
    public class MoveBoundarySystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float4 boundary = new float4(){ x = Boundary.xMin , y = Boundary.xMax , z = Boundary.yMin , w = Boundary.yMax};

            Entities
                .WithName("MoveBoundarySystem")
                .ForEach((ref Translation translation, in MoveForward moveForward , in MoveSpeed moveSpeed , in PlayerTag playerTag) =>
                {
                    var pos = translation.Value;
                    pos.x = math.clamp(pos.x ,boundary.x, boundary.y);
                    pos.z = math.clamp(pos.z ,boundary.z, boundary.w);
                    translation.Value = pos;

                })
                .ScheduleParallel();
        }
    }
}