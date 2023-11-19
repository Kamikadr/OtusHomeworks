using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Level
{
    [CreateAssetMenu(
        fileName = "BackgroundMoveConfig",
        menuName = "Level/New BackgroundMoveConfig"
    )]
    public class BackgroundMoveConfig: ScriptableObject
    {
        [SerializeField] public float startPositionY;
        [SerializeField] public float endPositionY;
        [SerializeField] public float movingSpeedY;
    }
}