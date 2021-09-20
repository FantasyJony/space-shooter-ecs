using Unity.Entities;
using Unity.Mathematics;
namespace SpaceShooter
{
    public struct HorizontalAngle : IComponentData
    {
        public float value;
        public float deltaTime;
        public float time;
        public float from;
        public float to;
    }
}