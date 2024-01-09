using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class PlayerShoutingSystem : SystemBase
{
    public event EventHandler OnShoot;

    protected override void OnCreate()
    {
        RequireForUpdate<Player>();
    }

    protected override void OnUpdate()
    {
        if(Input.GetKeyDown(KeyCode.T)) 
        {
            Entity playerEntity=SystemAPI.GetSingletonEntity<Player>();
            EntityManager.SetComponentEnabled<Stunned>(playerEntity, true);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Entity playerEntity = SystemAPI.GetSingletonEntity<Player>();
            EntityManager.SetComponentEnabled<Stunned>(playerEntity, false);
        }

        if (!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }
        SpawnCubesConfig spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

        EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

        foreach((RefRO<LocalTransform> localTransform,Entity Entity) in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<Player>().WithDisabled<Stunned>().WithEntityAccess())
        {
            
            Entity spawnedEntity = entityCommandBuffer.Instantiate(spawnCubesConfig.CubePrefabEntity);
            entityCommandBuffer.SetComponent(spawnedEntity,new LocalTransform
            {
                Position = localTransform.ValueRO.Position,
                Rotation = quaternion.identity,
                Scale = 1f
            });
            OnShoot?.Invoke(Entity, EventArgs.Empty);
            PlayerShootManager.Instance.PlayerShoot(localTransform.ValueRO.Position);
        }
        entityCommandBuffer.Playback(EntityManager);
    }
}
