using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace SpaceShooter
{
    static class CollideUtility
    {
        public static bool IsCollide(float3 a, float3 b, float dis)
        {
            return math.distancesq(a, b) <= dis * dis;
        }
    }

    public class CollideSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.WithAll<CollidePlayerTag>().ForEach((Entity entity, ref Translation translation, ref LifeOfHp
                lifeOfHp, ref CollidePlayerTag collideTag) =>
            {
                if (lifeOfHp.value <= 0)
                {
                    return;
                }

                float3 pos = translation.Value;
                float radius = collideTag.radius;
                bool isCollideEnter = false;
                
                Entities.WithAll<CollideEnemyTag>().ForEach((Entity otherEntity, ref Translation otherTranslation,
                    ref LifeOfHp
                        otherLifeOfHp, ref CollideEnemyTag otherCollideTag) =>
                {
                    if (otherLifeOfHp.value > 0 && CollideUtility.IsCollide(pos, otherTranslation.Value,radius + otherCollideTag.radius))
                    {
                        isCollideEnter = true;
                        --otherLifeOfHp.value;
                        return;
                    }
                });

                if (isCollideEnter)
                {
                    --lifeOfHp.value;
                }
            });
        }
    }
}