using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace SpaceShooter
{
    [UpdateAfter(typeof(MoveSystem))]
    public class RandomRotationSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float deltaTime = UnityEngine.Time.deltaTime;
            
            Entities
                .WithName("RandomRotationSystem")
                .ForEach((ref Rotation rotation, ref RandomRotation randomRotation, in RotationSpeed rotationSpeed) =>
                {
                    randomRotation.angle = math.clamp( randomRotation.angle + deltaTime * rotationSpeed.value, 0f, 360f);
                    rotation.Value = quaternion.AxisAngle(randomRotation.axis, randomRotation.angle);
                })
                .ScheduleParallel();
        }
    }
}