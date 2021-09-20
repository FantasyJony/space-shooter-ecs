using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace SpaceShooter
{
    public class BgScrollSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float time = UnityEngine.Time.time;
            
            Entities
                .WithName("BgScrollSystem")
                .ForEach((ref Translation translation, in BgScrollSizeData scrollData) =>
                {
                    float t = time * scrollData.speed;
                    float length = scrollData.tileSizeZ;

                    //Mathf.Repeat
                    //public static float Repeat(float t, float length) => Mathf.Clamp(t - Mathf.Floor(t / length) * length, 0.0f, length);
                    float newPosition = math.clamp(t - math.floor(t / length) * length, 0.0f, length);
                    
                    translation.Value = scrollData.startPosition + math.forward() * newPosition;

                })
                .ScheduleParallel();
        }
    }
}