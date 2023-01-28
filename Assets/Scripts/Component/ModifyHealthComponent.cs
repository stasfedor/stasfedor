using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Components
{
    public class ModifyHealthComponent : MonoBehaviour
    {
        [SerializeField] private float _hpModify;

        public void ApplyModifyHealth(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            if (healthComponent != null)
            {
                healthComponent.ApplyHealthDelta(_hpModify);
            }
        }
    }
}
