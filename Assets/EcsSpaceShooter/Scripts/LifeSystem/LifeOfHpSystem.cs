using Unity.Entities;
using Unity.Burst;
using Unity.Transforms;

namespace SpaceShooter
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class LifeOfHpDestroyEffectSystem : SystemBase
    {
        EntityCommandBufferSystem m_EntityCommandBufferSystem;

        protected override void OnCreate()
        {
            m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().AsParallelWriter();

            Entities
                .WithName("LifeOfHpDestroyEffectSystem")
                .WithBurst(FloatMode.Default, FloatPrecision.Standard, true)
                .ForEach((Entity entity, int entityInQueryIndex, ref LifeOfHp lifeOfHp,
                    in DestroyByContact destroyByContact, in Translation translation) =>
                {
                    if (lifeOfHp.isDestroy || lifeOfHp.value != 0)
                    {
                        return;
                    }

                    lifeOfHp.isDestroy = true;

                    if (destroyByContact.explosion != null)
                    {
                        var instance = commandBuffer.Instantiate(entityInQueryIndex, destroyByContact.explosion);
                        commandBuffer.SetComponent(entityInQueryIndex, instance,
                            new Translation { Value = translation.Value });
                    }
                }).ScheduleParallel();

            m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
        }
    }

    public class LifeOfHpNotDestroyEffectSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithName("LifeOfHpNotDestroyEffectSystem")
                .ForEach((ref LifeOfHp lifeOfHp, in BulletTag bulletTag) =>
                {
                    if (lifeOfHp.value <= 0)
                    {
                        lifeOfHp.isDestroy = true;
                    }
                })
                .ScheduleParallel();
        }
    }

    public class LifeOfHpDestroyAndRemoveSystem : SystemBase
    {
        EntityCommandBufferSystem m_EntityCommandBufferSystem;

        protected override void OnCreate()
        {
            m_EntityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().AsParallelWriter();

            Entities
                .WithName("LifeOfHpDestroyAndRemoveSystem")
                .ForEach((Entity entity, int nativeThreadIndex, ref LifeOfHp lifeOfHp) =>
                {
                    if (lifeOfHp.value <= 0 && lifeOfHp.isDestroy)
                    {
                        commandBuffer.DestroyEntity(nativeThreadIndex, entity);
                    }
                }).ScheduleParallel();

            m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
        }
    }
}