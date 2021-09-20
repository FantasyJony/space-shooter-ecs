using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;

namespace SpaceShooter
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class GunFireSystem : SystemBase
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
                .WithName("GunFireSystem")
                .WithBurst(FloatMode.Default, FloatPrecision.Standard, true)
                .ForEach((Entity entity, int entityInQueryIndex, ref ShipGun gun, in Translation translation,
                    in Rotation rotation) =>
                {
                    if (!gun.isFire)
                    {
                        gun.wasFire = false;
                        return;
                    }

                    if (!gun.wasFire)
                    {
                        if (gun.prefab != null)
                        {
                            var instance = commandBuffer.Instantiate(entityInQueryIndex, gun.prefab);
                            
                            var forward = math.forward(rotation.Value);
                            commandBuffer.SetComponent(entityInQueryIndex, instance,
                                new MoveForward() { value = new float2() { x = forward.x, y = forward.z } });
                            
                            commandBuffer.SetComponent(entityInQueryIndex, instance,
                                new Translation { Value = translation.Value + gun.startOffset });
                        }

                        gun.wasFire = true;
                    }
                }).ScheduleParallel();

            m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
        }
    }
}