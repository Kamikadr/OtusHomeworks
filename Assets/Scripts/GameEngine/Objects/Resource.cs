using UnityEngine;

namespace GameEngine
{
    //Нельзя менять!
    public sealed class Resource : MonoBehaviour, ISaveable<ResourceSnapshot>
    {
        public string ID
        {
            get => id;
        }

        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        [SerializeField]
        private string id;

        [SerializeField]
        private int amount;

        public void SetSnapshot(ResourceSnapshot snapshot)
        {
            amount = snapshot.Amount;
        }

        public ResourceSnapshot GetSnapshot()
        {
            return new ResourceSnapshot
            {
                Amount = Amount
            };
        }
    }
}