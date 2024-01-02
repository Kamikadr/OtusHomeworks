using UnityEngine;

namespace GameEngine
{
    //Нельзя менять!
    public sealed class Unit : MonoBehaviour, ISaveable<UnitSnapshot>
    {
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
            get => this.transform.position;
        }
        
        public Vector3 Rotation
        {
            get => this.transform.eulerAngles;
        }

        [SerializeField]
        private string type;
        
        [SerializeField]
        private int hitPoints;

        private void Reset()
        {
            this.type = this.name;
            this.hitPoints = 10;
        }

        public void SetSnapshot(UnitSnapshot snapshot)
        {
            type = snapshot.Type;
            hitPoints = snapshot.HitPoints;
            transform.eulerAngles = snapshot.Rotation;
            transform.position = snapshot.Position;
        }

        public UnitSnapshot GetSnapshot()
        {
            return new UnitSnapshot
            {
                Type = Type,
                HitPoints = HitPoints,
                Position = Position,
                Rotation = Rotation
            };
        }
    }
}