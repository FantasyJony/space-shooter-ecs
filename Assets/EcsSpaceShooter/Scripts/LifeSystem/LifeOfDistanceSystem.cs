using Unity.Entities;

namespace SpaceShooter
{
    [UpdateAfter(typeof(MoveSystem))]
    // [UpdateAfter(typeof(EndSimulationEntityCommandBufferSystem))]
    public class LifeOfDistanceSystem : SystemBase
    {
        EntityCommandBufferSystem m_EntityCommandBufferSystem;

        protected override void OnCreate()
        {
            m_EntityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().AsParallelWriter();
            var deltaTime = Time.DeltaTime;
            
            Entities
                .WithName("LifeOfDistanceSystem")
                .ForEach((Entity entity, int nativeThreadIndex, ref LifeOfDistance lifeOfDistance , in MoveSpeed moveSpeed) =>
                {
                    lifeOfDistance.value += moveSpeed.value * deltaTime;
                    
                    if (lifeOfDistance.value >= lifeOfDistance.destroyDistance)
                    {
                        commandBuffer.DestroyEntity(nativeThreadIndex, entity);
                    }
                    
                }).ScheduleParallel();

            m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
        }
    }
}