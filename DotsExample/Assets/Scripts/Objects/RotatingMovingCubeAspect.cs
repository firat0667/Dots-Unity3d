using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;



[WithAll]
public readonly partial struct RotatingMovingCubeAspect : IAspect
{
    public readonly RefRO<RotatingCube> rotatingCube;
    public readonly RefRW<LocalTransform> localTransform;
    public readonly RefRO<RotateSpeed> rotateSpeed;
    public readonly RefRO<Movement> movement;

    public void MoveAndRotate(float deltaTime)
    {
        
        localTransform.ValueRW = localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.Value * deltaTime);
        localTransform.ValueRW = localTransform.ValueRO.Translate(movement.ValueRO.movementVector * deltaTime);
    }
}

