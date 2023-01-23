using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts
{
  public class PlayerNewInputScript : MonoBehaviour
    {
        [SerializeField] private PlayerScript PlayerScript;
        
        private InputActions _inputActions;

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

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                PlayerScript.PlayerCollisionScript.Interact();
            }
        }
    }
}
