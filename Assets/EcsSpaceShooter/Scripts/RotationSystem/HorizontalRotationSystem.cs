using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace SpaceShooter
{
    public class HorizontalRotationSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float deltaTime = UnityEngine.Time.deltaTime;
            
            Entities
                .WithName("HorizontalRotationSystem")
                .ForEach((ref Rotation rotation , ref HorizontalAngle hAngle, in MoveForward moveForward, in RotationSpeed rotationSpeed ,  in HorizontalRotation hRotation,
                    in LocalToWorld localToWorld) =>
                {
                    float forwardAngle = -moveForward.value.x / 2f;
                    
                    if (hAngle.to != forwardAngle)
                    {
                        hAngle.from = hAngle.value;
                        hAngle.to = forwardAngle;
                        hAngle.time = (math.abs(hAngle.from) +
                                       math.abs(hAngle.to)) / rotationSpeed.value;
                        hAngle.deltaTime = 0f;
                    }
                    else if (hAngle.from != hAngle.to)
                    {
                        hAngle.deltaTime += deltaTime;
                        float s = hAngle.deltaTime / hAngle.time;
                        s = s > 1f ? 1f : s;
                        hAngle.value = math.lerp(hAngle.from, hAngle.to, s);
                    }

                    rotation.Value = math.mul(math.normalize(hRotation.value), quaternion.AxisAngle(localToWorld.Forward, hAngle.value));

                })
                .ScheduleParallel();
        }
    }
}