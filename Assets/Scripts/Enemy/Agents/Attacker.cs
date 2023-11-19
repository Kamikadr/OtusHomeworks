using UnityEngine;

namespace ShootEmUp
{
    public class Attacker: MonoBehaviour
    {
        [SerializeField] private WeaponComponent weaponComponent;
        private GameObject _target;
        private HitPointsComponent _targetHitPoint;
        
        public bool TryGetFireData(out FireData fireData)
        {
            fireData = new FireData();
            if (!_targetHitPoint.IsHitPointsExists())
            {
                return false;
            }

            fireData.sender = gameObject;
            fireData.position = weaponComponent.Position;
            var vector = (Vector2) _target.transform.position - fireData.position;
            fireData.direction = vector.normalized;
            return true;
        }
        
        public void SetTarget(GameObject target)
        {
            _target = target;
            _targetHitPoint = _target.GetComponent<HitPointsComponent>();
        }
        
        public struct FireData
        {
            public GameObject sender;
            public Vector2 position;
            public Vector2 direction;
        }
    }
}