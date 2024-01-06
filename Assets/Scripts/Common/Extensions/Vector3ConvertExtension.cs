using Common.Types;
using UnityEngine;

namespace Common.Extensions
{
    public static class Vector3ConvertExtension
    {
        public static SerializableVector3 ConvertToSerializableVector3(this Vector3 vector3)
        {
            return new SerializableVector3
            {
                x = vector3.x,
                y = vector3.y,
                z = vector3.z
            };
        }
        
        public static Vector3 ConvertToVector3(this SerializableVector3 serializableVector3)
        {
            return new Vector3
            {
                x = serializableVector3.x,
                y = serializableVector3.y,
                z = serializableVector3.z
            };
        }
        
    }
}