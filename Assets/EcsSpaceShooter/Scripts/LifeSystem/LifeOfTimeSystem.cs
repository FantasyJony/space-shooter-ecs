using Unity.Entities;

namespace SpaceShooter
{
    public class LifeOfTimeSystem : SystemBase
    {
        EntityCommandBufferSystem m_Barrier;

        protected override void OnCreate()
        {
            m_Barrier = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var commandBuffer = m_Barrier.CreateCommandBuffer().AsParallelWriter();
            var deltaTime = Time.DeltaTime;
            
            Entities
                .WithName("LifeOfTimeSystem")
                .ForEach((Entity entity, int nativeThreadIndex, ref LifeOfTime lifeOfTime) =>
                {
                    lifeOfTime.value += deltaTime;
                    if (lifeOfTime.value >= lifeOfTime.destroyTime)
                    {
                        commandBuffer.DestroyEntity(nativeThreadIndex, entity);
                    }
                    
                }).ScheduleParallel();

            m_Barrier.AddJobHandleForProducer(Dependency);
        }
    }
}