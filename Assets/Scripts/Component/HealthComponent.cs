using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] internal float _health;

        [SerializeField] private UnityEvent _onDamage, _onDie;

        public void ApplyDamage(float damageValue)
        {
            _health -= damageValue;
            _onDamage?.Invoke();
            if (_health <= 0) _onDie?.Invoke();
        }
    }
}
