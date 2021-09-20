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
                lifeOfHp, ref CollidePlayerTag collisionTag) =>
            {
                if (lifeOfHp.value <= 0)
                {
                    return;
                }

                float3 pos = translation.Value;
                float radius = collisionTag.radius;
                bool isCollection = false;
                
                Entities.WithAll<CollideEnemyTag>().ForEach((Entity otherEntity, ref Translation otherTranslation,
                    ref LifeOfHp
                        otherLifeOfHp, ref CollideEnemyTag otherCollisionTag) =>
                {
                    if (otherLifeOfHp.value > 0 && CollideUtility.IsCollide(pos, otherTranslation.Value,radius + otherCollisionTag.radius))
                    {
                        isCollection = true;
                        --otherLifeOfHp.value;
                        return;
                    }
                });

                if (isCollection)
                {
                    --lifeOfHp.value;
                }
            });
        }
    }
}