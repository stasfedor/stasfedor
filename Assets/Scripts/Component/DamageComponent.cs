using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private float _damage;

        public void ApplyDamage(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            if (healthComponent != null)
            {
                healthComponent.ApplyDamage(_damage);
            }
        }
    }
}
