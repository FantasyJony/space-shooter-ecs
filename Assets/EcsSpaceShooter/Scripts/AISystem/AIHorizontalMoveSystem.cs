using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace SpaceShooter
{
    public class AIHorizontalSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var deltaTime = UnityEngine.Time.deltaTime;
            var seed = (uint)System.DateTime.Now.Ticks;

            Entities
                .WithName("AIHorizontalSystem")
                .ForEach((ref AIHorizontalRotation aiHorizontalRotation,
                    in Translation translation, in AITag _) =>
                {
                    var waitTime = aiHorizontalRotation.waitTime;
                    waitTime -= deltaTime;

                    if (waitTime > 0)
                    {
                        aiHorizontalRotation.waitTime = waitTime;
                        return;
                    }

                    var waitTag = aiHorizontalRotation.waitTag;

                    var random = new Random(seed);

                    if (waitTag == 0 || waitTag == 2)
                    {
                        waitTag = 1;
                        waitTime = random.NextFloat(aiHorizontalRotation.maneuverTime.x,
                            aiHorizontalRotation.maneuverTime.y);
                        
                        aiHorizontalRotation.value = random.NextFloat(0f,1f) * -math.sign(translation.Value.x);
                    }
                    else if (waitTag == 1)
                    {
                        waitTag = 2;
                        aiHorizontalRotation.value  = 0f;
                        waitTime = random.NextFloat(aiHorizontalRotation.maneuverWait.x,
                            aiHorizontalRotation.maneuverWait.y);
                    }

                    aiHorizontalRotation.waitTag = waitTag;
                    aiHorizontalRotation.waitTime = waitTime;
                })
                .ScheduleParallel();
        }
    }

    [UpdateAfter(typeof(AIHorizontalSystem))]
    public class AIHorizontalMoveSystem : SystemBase
    {
        // public static float MoveTowards(float current, float target, float maxDelta) => (double) Mathf.Abs(target - current) <= (double) maxDelta ? target : current + Mathf.Sign(target - current) * maxDelta;
        static float MoveTowards(float current, float target, float maxDelta) => (double) math.abs(target - current) <= (double) maxDelta ? target : current + math.sign(target - current) * maxDelta;

        protected override void OnUpdate()
        {
            var deltaTime = UnityEngine.Time.deltaTime;

            Entities
                .WithName("AIHorizontalMoveSystem")
                .ForEach((ref MoveForward moveForward, in AIHorizontalRotation aiHorizontalRotation,
                    in Translation translation, in AITag _) =>
                {
                    // float newManeuver = Mathf.MoveTowards (GetComponent<Rigidbody>().velocity.x, targetManeuver, smoothing * Time.deltaTime);
                    // public static float MoveTowards(float current, float target, float maxDelta) => (double) Mathf.Abs(target - current) <= (double) maxDelta ? target : current + Mathf.Sign(target - current) * maxDelta;
                    float newManeuver = MoveTowards(moveForward.value.x, aiHorizontalRotation.value, aiHorizontalRotation.smoothing * deltaTime);
                    moveForward.value = new float2() { x = newManeuver, y = moveForward.value.y };

                })
                .ScheduleParallel();
        }
    }
}