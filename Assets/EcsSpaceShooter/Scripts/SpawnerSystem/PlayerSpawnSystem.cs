using Unity.Entities;
using Unity.Burst;
using Unity.Transforms;

namespace SpaceShooter
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class PlayerSpawnSystem : SystemBase
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
                .WithName("PlayerSpawnSystem")
                .WithBurst(FloatMode.Default, FloatPrecision.Standard, true)
                .ForEach((Entity entity, int entityInQueryIndex, ref PlayerSpawner spawner) =>
                {
                    if (spawner.isSpawn)
                    {
                        return;
                    }

                    spawner.isSpawn = true;

                    if (spawner.prefab != null)
                    {
                        var instance = commandBuffer.Instantiate(entityInQueryIndex, spawner.prefab);

                        commandBuffer.SetComponent(entityInQueryIndex, instance,
                            new Rotation() { Value = spawner.quaternion });
                        commandBuffer.SetComponent(entityInQueryIndex, instance,
                            new Translation { Value = spawner.position });
                    }
                }).ScheduleParallel();

            m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
        }
    }
}