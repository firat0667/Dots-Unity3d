using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnCubeConfigAutHoring : MonoBehaviour
{
    public GameObject CubePrefab;
    public int AmountToSpawn;

    public int AmountFromSpawn;

    public class Baker : Baker<SpawnCubeConfigAutHoring>
    {
        public override void Bake(SpawnCubeConfigAutHoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new SpawnCubesConfig
            {

                CubePrefabEntity = GetEntity(authoring.CubePrefab,TransformUsageFlags.Dynamic),
                AmountToSpawn=authoring.AmountToSpawn,
            });
        }
    }
}

public struct SpawnCubesConfig : IComponentData
{
    public Entity CubePrefabEntity;
    public int AmountToSpawn;
}
