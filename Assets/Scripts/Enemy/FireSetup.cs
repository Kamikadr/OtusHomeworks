using ShootEmUp.Componets;
using UnityEngine;

namespace ShootEmUp.Enemies
{
    public class FireSetup: MonoBehaviour
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
            
            fireData.Position = weaponComponent.Position;
            var vector = (Vector2) _target.transform.position - fireData.Position;
            fireData.Direction = vector.normalized;
            return true;
        }
        
        public void SetTarget(GameObject target)
        {
            _target = target;
            _targetHitPoint = _target.GetComponent<HitPointsComponent>();
        }
        
    }
}