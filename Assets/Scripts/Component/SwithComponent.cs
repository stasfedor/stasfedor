using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class SwithComponent : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private bool _state;
        [SerializeField] string _animationKey;

        public void Switch()
        {
            _state = !_state;
            _anim.SetBool(_animationKey, _state);
        }

        [ContextMenu("Swich")]
        public void SwitchIt()
        {
            Switch();
        }
    }
}
