using Unity.Entities;
using Unity.Mathematics;

namespace SpaceShooter
{
    [UpdateBefore(typeof(MoveSystem))]
    [UpdateBefore(typeof(HorizontalRotationSystem))]
    public class PlayerInputForwardSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float horizontal = PlayerInputAction.Instance.horizontalValue;
            float vertical = PlayerInputAction.Instance.verticalValue;

            Entities
                .WithName("PlayerInputForwardSystem")
                .ForEach((ref MoveForward moveForward, in PlayerTag _) =>
                {
                    moveForward.value = new float2() { x = horizontal, y = vertical };
                })
                .ScheduleParallel();
        }
    }
}