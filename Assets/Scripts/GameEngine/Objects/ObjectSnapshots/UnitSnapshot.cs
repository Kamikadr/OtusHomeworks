using Common.Extensions;
using Common.Types;
using UnityEngine;

namespace GameEngine
{
    public struct UnitSnapshot
    {
        public int Id;
        public string Type;
        public int HitPoints;
        public SerializableVector3 Position;
        public SerializableVector3 Rotation;
    }
}