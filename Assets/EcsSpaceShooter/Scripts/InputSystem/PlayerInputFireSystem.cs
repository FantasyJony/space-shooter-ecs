using Unity.Entities;

namespace SpaceShooter
{
    [UpdateBefore(typeof(GunFireSystem))]
    public class PlayerInputFireSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var time = UnityEngine.Time.time;
            bool fire = PlayerInputAction.Instance.fire;

            Entities
                .WithName("PlayerInputFireSystem")
                .ForEach((ref ShipGun shipGun, in PlayerTag _) =>
                {
                    if (fire && shipGun.nextFire <= time)
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