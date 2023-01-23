using UnityEngine;

namespace PlayerScripts
{
    public class PlayerInputScript : MonoBehaviour
    {
        [SerializeField] private PlayerScript PlayerScript;
        internal bool TouchScreenInputOn = false;

        // Left or Right keyCode
        internal bool IsLeftPressed, IsRightPressed;

        // Up or Down keyCode
        internal bool IsUpPressed, IsDownPressed;

        //Attack KeyCode
        internal bool IsAttack1Pressed, IsAttack2Pressed;

        //Jump KeyCode
        internal bool IsJumpPressed;

        //Enter KeyCode
        internal bool IsEnterPressed;

        private float axisInput;

        //KeyInitialization
        [SerializeField] private KeyCode _left, _right, _up, _down;
        [SerializeField] private KeyCode _leftAlt, _rightAlt, _upAlt, _downAlt;
        [SerializeField] private KeyCode _attack1, _attack2;
        [SerializeField] private KeyCode _attack1Alt, _attack2Alt;
        [SerializeField] private KeyCode _jump, _jumpAlt;
        [SerializeField] private KeyCode _enter, _enterAlt;


        void Start()
        {
            Debug.Log("PlayerInputScript Starting");
        }

        void Update()
        {
            LeftRightKey();
            UpDownKey();
            AttackKey();
            JumpKey();
            EnterKey();
            HorizontalSystem();
        }

        private void LeftRightKey()
        {
            if (TouchScreenInputOn == false)
            {
                if (((Input.GetKey(_left) || Input.GetKey(_leftAlt)) || axisInput < 0)
                    && !IsRightPressed)
                {
                    IsLeftPressed = true;
                }
                else if (((Input.GetKey(_right) || Input.GetKey(_rightAlt)) || axisInput > 0)
                         && !IsLeftPressed)
                {
                    IsRightPressed = true;
                }
                else
                {
                    IsLeftPressed = false;
                    IsRightPressed = false;
                }
            }
        }

        private void UpDownKey()
        {
            if (TouchScreenInputOn == false)
            {
                if ((Input.GetKey(_up) || Input.GetKey(_upAlt)) && !IsDownPressed)
                {
                    IsUpPressed = true;
                }
                else if ((Input.GetKey(_down) || Input.GetKey(_downAlt)) && !IsUpPressed)
                {
                    IsDownPressed = true;
                }
                else
                {
                    IsUpPressed = false;
                    IsDownPressed = false;
                }
            }
        }

        private void AttackKey()
        {
            if (TouchScreenInputOn == false)
            {
                if ((Input.GetKeyDown(_attack1) || Input.GetKeyDown(_attack1Alt)) && !IsAttack2Pressed)
                {
                    IsAttack1Pressed = true;
                }
                else if ((Input.GetKeyDown(_attack2) || Input.GetKeyDown(_attack2Alt)) && !IsAttack1Pressed)
                {
                    IsAttack2Pressed = true;
                }
                else
                {
                    IsAttack1Pressed = false;
                    IsAttack2Pressed = false;
                }
            }
        }

        private void JumpKey()
        {
            if (TouchScreenInputOn == false)
            {
                if (Input.GetKeyDown(_jump) || Input.GetKeyDown(_jumpAlt) || Input.GetButtonDown("JumpGamePad"))
                {
                    IsJumpPressed = true;
                }
                else
                {
                    IsJumpPressed = false;
                }
            }
        }

        private void EnterKey()
        {
            if (TouchScreenInputOn == false)
            {
                if (Input.GetKeyDown(_enter) || Input.GetKeyDown(_enterAlt))
                {
                    IsEnterPressed = true;
                }
                else
                {
                    IsEnterPressed = false;
                }
            }
        }

        private void HorizontalSystem()
        {
            var horizontal = Input.GetAxis("Horizontal");
            axisInput = horizontal;
        }
    }
}
