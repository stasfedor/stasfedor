using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class InteractibleObject : MonoBehaviour
    {
        [SerializeField] private UnityEvent _action;

        public void Interact()
        {
            _action?.Invoke();
        }
    }
}