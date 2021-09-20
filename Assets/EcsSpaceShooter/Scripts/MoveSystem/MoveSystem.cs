using System;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

namespace SpaceShooter
{
    public class MoveSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float deltaTime = UnityEngine.Time.deltaTime;

            Entities
                .WithName("MoveSystem")
                .ForEach((ref Translation translation, in MoveForward moveForward , in MoveSpeed moveSpeed) =>
                {
                    float3 pos = translation.Value + new float3(moveForward.value.x, 0.0f, moveForward.value.y) * moveSpeed.value * deltaTime;
                    translation.Value = pos;

                })
                .ScheduleParallel();
        }
    }
}