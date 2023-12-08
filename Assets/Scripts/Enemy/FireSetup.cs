using ShootEmUp.Componets;
using UnityEngine;

namespace ShootEmUp.Enemies
{
    public class FireSetup
    {
        private readonly WeaponComponent _weaponComponent;
        
        private GameObject _target;
        private HitPointsComponent _targetHitPoint;
        
        public FireSetup(WeaponComponent weaponComponent)
        {
            _weaponComponent = weaponComponent;
        }

        public bool TryGetFireData(out FireData fireData)
        {
            fireData = new FireData();
            if (!_targetHitPoint.IsHitPointsExists())
            {
                return false;
            }
            
            fireData.Position = _weaponComponent.Position;
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