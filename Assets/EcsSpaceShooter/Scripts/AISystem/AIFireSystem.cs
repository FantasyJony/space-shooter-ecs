using Unity.Entities;

namespace SpaceShooter
{
    [UpdateBefore(typeof(GunFireSystem))]
    public class AIFireSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var time = UnityEngine.Time.time;

            Entities
                .WithName("AIFireSystem")
                .ForEach((ref ShipGun shipGun , in AITag _) =>
                {
                    if (shipGun.nextFire <= time)
                    {
                        shipGun.isFire = true;
                        shipGun.nextFire = time + shipGun.rate;
                    }
                    else
                    {
                        shipGun.isFire = false;
                    }
                })
                .ScheduleParallel();
        }
    }
}