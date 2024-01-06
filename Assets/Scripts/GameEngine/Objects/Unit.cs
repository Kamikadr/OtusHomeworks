using System;
using Common.Extensions;
using Sirenix.OdinInspector;
using Unity.Collections;
using UnityEngine;

namespace GameEngine
{
    //Нельзя менять!
    public sealed class Unit : MonoBehaviour, ISnapshotable<UnitSnapshot>
    {
        public Guid Id
        {
            get => id;
        }
        public string Type
        {
            get => type;
        }

        public int HitPoints
        {
            get => hitPoints;
            set => hitPoints = value;
        }

        public Vector3 Position
        {
            get => transform.position;
        }
        
        public Vector3 Rotation
        {
            get => transform.eulerAngles;
        }

        private Guid id;
        [SerializeField] private string type;
        [SerializeField] private int hitPoints;

        private void Reset()
        {
            type = name;
            hitPoints = 10;
        }

        public void SetUnitId(Guid unitId)
        {
            id = unitId;
        }
        public void SetSnapshot(UnitSnapshot snapshot)
        {
            type = snapshot.Type;
            hitPoints = snapshot.HitPoints;
            transform.eulerAngles = snapshot.Rotation.ConvertToVector3();
            transform.position = snapshot.Position.ConvertToVector3();
        }

        public UnitSnapshot GetSnapshot()
        {
            return new UnitSnapshot
            {
                Type = Type,
                HitPoints = HitPoints,
                Position = Position.ConvertToSerializableVector3(),
                Rotation = Rotation.ConvertToSerializableVector3()
            };
        }
    }
}