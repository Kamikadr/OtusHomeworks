using UnityEngine;

namespace ShootEmUp.Componets
{
    public sealed class TeamComponent : MonoBehaviour
    {
        [SerializeField] private bool isPlayer;
        public bool IsPlayer => isPlayer;

        
    }
}