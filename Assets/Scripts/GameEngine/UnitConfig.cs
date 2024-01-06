using UnityEngine;

namespace GameEngine
{
    [CreateAssetMenu(menuName = "Unit", fileName = "NewUnit")]
    public sealed class UnitConfig : ScriptableObject
    {
        [SerializeField] public Unit unitPrefab;
        [SerializeField] public string unitId;
    }
}