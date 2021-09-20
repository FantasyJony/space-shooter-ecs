using Unity.Entities;
using System;
using Unity.Mathematics;

namespace SpaceShooter
{
    // [GenerateAuthoringComponent]
    public struct MoveForward : IComponentData
    {
        public float2 value;
    }
}