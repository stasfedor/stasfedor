using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovementScript : MonoBehaviour
    {
        [SerializeField] private PlayerScript PlayerScript;

        internal Vector2 _direction;
        private Rigidbody2D _rb2d => PlayerScript.PlayerCollisionScript._rb2d;
        private float _playerStartSpeed => PlayerScript.startSpeed;
        private float _jumpingPower => PlayerScript._jumpingPower;
        private float _damageJumpingSpeed => PlayerScript._jumpingPower * 5f;

        internal bool _isJumping;
        private bool _canDoubleJump;
        
        
        private bool _isStand => PlayerScript.PlayerCollisionScript._isStand;

        

        private void Awake()
        {
            Debug.Log("PlayerMovementScript Awake Starting");
        }
        void Start()
        {
            Debug.Log("PlayerMovementScript Starting");
            _rb2d.velocity = new Vector2(0, 0);
        }

        void Update()
        {

        }

        private void FixedUpdate()
        {
            VelocityCalculate();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void StopMovement()
        {
            PlayerScript.speed = 0f;
        }

        public void VelocityCalculate()
        {
            float xVelocity = _direction.x * _playerStartSpeed;
            float yVelocity = CalculateYVelocity();
            _rb2d.velocity = new Vector2(xVelocity, yVelocity);
        }

        private float CalculateYVelocity()
        {
            float yVelocity = _rb2d.velocity.y;
            _isJumping = _direction.y > 0;

            if (_isJumping)
            {
                yVelocity = CalculateJumpVelocity(yVelocity);
                if (_isStand && _rb2d.velocity.y <= 0.1f)
                {
                    _rb2d.AddForce(Vector2.up * _jumpingPower, ForceMode2D.Impulse);
                }
                DoubleJumpLogick();
            }

            if (_rb2d.velocity.y > 0 && _direction.y < .7f)
            {
                yVelocity *= 0.5f;
                //_rb2d.velocity = new Vector2(_rb2d.velocity.x, _rb2d.velocity.y * 0.5f);
            }
            return yVelocity;
        }

        private float CalculateJumpVelocity(float yVelocity)
        {
            bool _isFalling = _rb2d.velocity.y <= 0.1f;
            if (!_isFalling) return yVelocity;

            if (_isStand)
            {
                yVelocity += _jumpingPower;
            } else if (_canDoubleJump)
            {
                yVelocity = _jumpingPower;
                _canDoubleJump = false;
            }
            return yVelocity;
        }

        private void DoubleJumpLogick()
        {
            if (_isStand) _canDoubleJump = true;
        }

        //public void OnDamageJump()
       // {
       //     _rb2d.velocity = new Vector2(_rb2d.velocity.x, _damageJumpingSpeed);
        //}

    }
}
