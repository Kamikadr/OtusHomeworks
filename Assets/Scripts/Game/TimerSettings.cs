using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Game
{
    [Serializable]
    public struct TimerSettings
    {
        [SerializeField] public float cooldownTime;
        [SerializeField] public float cooldownTick;
    }
}