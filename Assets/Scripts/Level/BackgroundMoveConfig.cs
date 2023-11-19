using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    [CreateAssetMenu(
        fileName = "BackgroundMoveConfig",
        menuName = "Level/New BackgroundMoveConfig"
    )]
    public class BackgroundMoveConfig: ScriptableObject
    {
        [FormerlySerializedAs("m_startPositionY")] [SerializeField] public float startPositionY;
        [FormerlySerializedAs("m_endPositionY")] [SerializeField] public float endPositionY;
        [FormerlySerializedAs("m_movingSpeedY")] [SerializeField] public float movingSpeedY;
    }
}