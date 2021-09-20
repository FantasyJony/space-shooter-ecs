// using Unity.Burst;
// using Unity.Collections;
// using Unity.Entities;
// using Unity.Jobs;
// using Unity.Mathematics;
// using Unity.Transforms;
//
// namespace SpaceShooter
// {
//     public class LifeSystem : SystemBase
//     {
//         EntityCommandBufferSystem m_Barrier;
//
//         protected override void OnCreate()
//         {
//             m_Barrier = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
//         }
//
//         // OnUpdate runs on the main thread.
//         protected override void OnUpdate()
//         {
//             var commandBuffer = m_Barrier.CreateCommandBuffer().AsParallelWriter();
//
//             // var deltaTime = Time.DeltaTime;
//             Entities
//                 .WithName("LifeSystem")
//                 .ForEach((Entity entity, int nativeThreadIndex, ref LifeOfHp lifeOfHp) =>
//             {
//                 if (lifeOfHp.value <= 0)
//                 {
//                     commandBuffer.DestroyEntity(nativeThreadIndex, entity);
//                 }
//                 
//             }).ScheduleParallel();
//
//             m_Barrier.AddJobHandleForProducer(Dependency);
//         }
//     }
// }