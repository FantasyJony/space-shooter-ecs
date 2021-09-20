using Unity.Entities;
using Unity.Mathematics;

namespace SpaceShooter
{
    public struct AIHorizontalRotation : IComponentData
    {
        public float value;
        public float smoothing;
        
        public float2 maneuverTime;
        public float2 maneuverWait;
        
        public float waitTime;
        public int waitTag; // 0 waitForStart ; 1 waitForManeuverTime ; 2 waitForManeuverWaitTime
    }
}