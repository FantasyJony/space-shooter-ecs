using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;

namespace SpaceShooter
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class EnemySpawnSystem : SystemBase
    {
        EntityCommandBufferSystem m_EntityCommandBufferSystem;

        protected override void OnCreate()
        {
            m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var deltaTime = UnityEngine.Time.deltaTime;
            var seed = (uint)System.DateTime.Now.Ticks;

            var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().AsParallelWriter();

            Entities
                .WithName("EnemySpawnSystem")
                .WithBurst(FloatMode.Default, FloatPrecision.Standard, true)
                .ForEach((Entity entity, int entityInQueryIndex, ref EnemySpawner spawner) =>
                {
                    int waitTag = spawner.waitTag;
                    float waitTime = spawner.waitTime;

                    float tagWaitTime = 0f;

                    if (waitTag == 0)
                    {
                        tagWaitTime = spawner.startWait;
                    }
                    else if (waitTag == 1)
                    {
                        tagWaitTime = spawner.spawnWait;
                    }
                    else if (waitTag == 2)
                    {
                        tagWaitTime = spawner.waveWait;
                    }

                    if (waitTime < tagWaitTime)
                    {
                        spawner.waitTime = waitTime + deltaTime;
                        return;
                    }

                    var random = new Random(seed);
                    var index = random.NextInt(0, spawner.length);

                    Entity e = default;
                    switch (index)
                    {
                        case 0:
                        {
                            e = spawner.prefab1;
                        }
                            break;
                        case 1:
                        {
                            e = spawner.prefab2;
                        }
                            break;
                        case 2:
                        {
                            e = spawner.prefab3;
                        }
                            break;
                        case 3:
                        {
                            e = spawner.prefab4;
                        }
                            break;

                        case 4:
                        {
                            e = spawner.prefab5;
                        }
                            break;
                    }

                    if (e != default)
                    {
                        var instance = commandBuffer.Instantiate(entityInQueryIndex, e);

                        var spawnValues = spawner.spawnValues;
                        float randomX = random.NextFloat(-spawnValues.x, spawnValues.x);
                        float3 pos = new float3() { x = randomX, y = spawnValues.y, z = spawnValues.z };

                        commandBuffer.SetComponent(entityInQueryIndex, instance, new Translation { Value = pos });

                        commandBuffer.SetComponent(entityInQueryIndex, instance,
                            new Rotation() { Value = spawner.rotation });
                    }

                    spawner.waitTime = 0;
                    int spawnCount = spawner.spawnCount;

                    if (waitTag == 0 || waitTag == 1)
                    {
                        if (++spawnCount >= spawner.hazardCount)
                        {
                            spawner.spawnCount = 0;
                            spawner.waitTag = 2;
                        }
                        else
                        {
                            spawner.spawnCount = spawnCount;
                            spawner.waitTag = 1;
                        }
                    }
                    else if (waitTag == 2)
                    {
                        spawner.waitTag = 1;
                    }
                }).ScheduleParallel();

            m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
        }
    }
}