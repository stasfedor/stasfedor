using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class EnterCollisionComponent : MonoBehaviour
    {
        [SerializeField] private string _tagCollision;
        [SerializeField] private EnterEvent _action;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(_tagCollision))
            {
                _action?.Invoke(other.gameObject);
            }
        }
    }

    [Serializable]
    public class EnterEvent : UnityEvent<GameObject>
    {
        
    }
}