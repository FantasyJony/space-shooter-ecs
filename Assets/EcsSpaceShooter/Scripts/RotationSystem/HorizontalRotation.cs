using Unity.Entities;
using Unity.Mathematics;
namespace SpaceShooter
{
    public struct HorizontalRotation : IComponentData
    {
        public quaternion value;
    }
}