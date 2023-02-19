using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts
{
  public class PlayerNewInputScript : MonoBehaviour
    {
        [SerializeField] private PlayerScript PlayerScript;
        
        internal InputActions _inputActions;
        
        private static readonly int Interaction          = Animator.StringToHash("Interaction");
        private static readonly int Attack1          = Animator.StringToHash("Attack1");

        private void Awake()
        {
            _inputActions = new InputActions();
            _inputActions.Player.Horizontalmovement.performed += OnHorizontalInput;
            _inputActions.Player.Horizontalmovement.canceled += OnHorizontalInput;
            
        }

        private void Start()
        {
            OnEnable();
        }

        private void OnEnable()
        {
            _inputActions.Enable();
        }
        
        public void OnHorizontalInput(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            PlayerScript.PlayerMovementScript.SetDirection(direction);
        }
        
        public void OnVerticalInput(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            PlayerScript.PlayerMovementScript.SetDirection(direction);
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.canceled) 
            {
                PlayerScript.PlayerAnimationScript._animator.SetTrigger(Interaction);
            }
        }
        
        public void OnAttack1(InputAction.CallbackContext context)
        {
            if (context.canceled) 
            {
                if (!PlayerScript.PlayerAnimationScript._isArmed) return;
                PlayerScript.PlayerAnimationScript._animator.SetTrigger(Attack1);
            }
        }
    }
}
