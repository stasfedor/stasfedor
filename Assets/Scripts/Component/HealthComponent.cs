using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] internal float _health;

        [SerializeField] private UnityEvent _onDamage, _onDie, _onHeal;

        public void ApplyHealthDelta(float healthDelta)
        {
            _health += healthDelta;

            if (healthDelta < 0) _onDamage?.Invoke();
            
            if (healthDelta > 0) _onHeal?.Invoke();
            
            if (_health <= 0) _onDie?.Invoke();
        }
    }
}
