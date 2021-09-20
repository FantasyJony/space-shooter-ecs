using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace SpaceShooter
{
    public static class CollisionUtility
    {
        public static bool IsCollision(float3 a, float3 b, float dis)
        {
            return math.distancesq(a, b) <= dis * dis;
        }
    }

    public class CollisionSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.WithAll<CollisionPlayerTag>().ForEach((Entity entity, ref Translation translation, ref LifeOfHp
                lifeOfHp, ref CollisionPlayerTag collisionTag) =>
            {
                if (lifeOfHp.value <= 0)
                {
                    return;
                }

                float3 pos = translation.Value;
                float radius = collisionTag.radius;
                bool isCollection = false;
                
                Entities.WithAll<CollisionEnemyTag>().ForEach((Entity otherEntity, ref Translation otherTranslation,
                    ref LifeOfHp
                        otherLifeOfHp, ref CollisionEnemyTag otherCollisionTag) =>
                {
                    if (otherLifeOfHp.value > 0 && CollisionUtility.IsCollision(pos, otherTranslation.Value,radius + otherCollisionTag.radius))
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