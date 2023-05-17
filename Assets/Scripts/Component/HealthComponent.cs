using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] internal float _health;

        [SerializeField] private UnityEvent _onDamage, _onDie, _onHeal;
        [SerializeField] private HealthChangeEvent _onChange;
        public void ApplyHealthDelta(float healthDelta)
        {
            _health += healthDelta;
            _onChange?.Invoke(_health);

            if (healthDelta < 0) _onDamage?.Invoke();
            
            if (healthDelta > 0) _onHeal?.Invoke();
            
            if (_health <= 0) _onDie?.Invoke();
        }


        public void SetHealth(float health)
        {
            _health = health;
        }

#if UNITY_EDITOR
        [ContextMenu("UpdateHealth")]
        private void UpdateHealth()
        {
            _onChange?.Invoke(_health);
        }
#endif
        
        [Serializable]
        public class HealthChangeEvent : UnityEvent<float>
        {
            
        }
    }
}
