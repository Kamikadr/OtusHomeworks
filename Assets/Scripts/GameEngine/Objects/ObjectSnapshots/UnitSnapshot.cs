using Common.Extensions;
using UnityEngine;

namespace GameEngine
{
    public struct UnitSnapshot
    {
        public string Type;
        public int HitPoints;
        public SerializableVector3 Position;
        public SerializableVector3 Rotation;
    }
}