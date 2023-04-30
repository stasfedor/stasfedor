using System;
using Components;
using UnityEditor.Animations;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerAnimationScript : MonoBehaviour
    {
        [SerializeField] private PlayerScript PlayerScript;
        [SerializeField] private HealthComponent HealthComponent;

        internal Animator _animator;
        [SerializeField] private AnimatorController _armed;
        [SerializeField] private AnimatorController _unArmed;
         
        private Rigidbody2D _rb2d => PlayerScript.PlayerCollisionScript._rb2d;
        private Vector2 _direction => PlayerScript.PlayerMovementScript._direction;
        
        private float _horizontalSpeed, _verticalSpeed;

        private static readonly int IsGround        = Animator.StringToHash("OnTheGround");
        private static readonly int SpeedVertical   = Animator.StringToHash("Speed vertical");
        private static readonly int SpeedHorizontal = Animator.StringToHash("Speed horizontal");
        private static readonly int Jump            = Animator.StringToHash("IsJump");
        private static readonly int OnHit           = Animator.StringToHash("OnHit");
        private static readonly int OnHeal          = Animator.StringToHash("OnHeal");
        private static readonly int Health          = Animator.StringToHash("Lifes");
        
        [SerializeField] private SpawnComponent _footStepParticles;
        private float _damageJumpingSpeed => PlayerScript._jumpingPower * PlayerScript._jumpDamageSpeedAlpha;

        internal int _healValue;

        internal bool _isArmed
        {
            get => PlayerScript._isArmed;
            set => PlayerScript._isArmed = value;
        }

        private void Awake()
        {
            Debug.Log("PlayerAnimationScript Awake Starting");
            _animator = GetComponent<Animator>();

            _animator.SetFloat(Health, HealthComponent._health);
        }
        private void Start()
        {
            Debug.Log("PlayerAnimationScript Starting");
            if (_isArmed) _animator.runtimeAnimatorController = _armed;
        }

        private void FixedUpdate()
        {
            Flip();
            HorizontalSpeed();
            VerticalSpeed();
            OnTheGround();
            IsJump();
            
        }

        private void Update()
        {
            
        }

        private void HorizontalSpeed()
        {
            _horizontalSpeed = _rb2d.velocity.x;
            _animator.SetFloat(SpeedHorizontal, Mathf.Abs(_horizontalSpeed));
            //PlayerScript.speed = _animator.GetFloat("Speed");
        }
        
        private void VerticalSpeed()
        {
            _verticalSpeed = _rb2d.velocity.y;
            _animator.SetFloat(SpeedVertical, _verticalSpeed);
            //PlayerScript.speed = _animator.GetFloat("Speed");
        }

        private void OnTheGround()
        {
            _animator.SetBool(IsGround ,PlayerScript.PlayerCollisionScript._isStand);
        }
        
        private void IsJump()
        {
            _animator.SetBool(Jump ,_verticalSpeed > 0.1f);
        }
        
        private void Flip()
        {
            if (_direction.x > 0)
            {
                transform.localScale = Vector3.one;
                //_sprite.flipX = false;
            } else if (_direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                //_sprite.flipX = true;
            }
        }

        public void TakeDamage()
        {
            //PlayerScript.PlayerMovementScript._isJumping = false;
            _rb2d.AddForce(Vector2.up * _damageJumpingSpeed, ForceMode2D.Impulse);
            //_rb2d.velocity = new Vector2(_rb2d.velocity.x, _damageJumpingSpeed);
            _animator.SetTrigger(OnHit);
            _animator.SetFloat(Health, HealthComponent._health);
            PlayerScript.PlayerParticlesScript.SpawnCoinsFromDamage();
        }
        
        public void TakeHeal()
        {
            _animator.SetTrigger(OnHeal);

            _healValue = (int)Math.Ceiling(HealthComponent._health - _animator.GetFloat(Health));
            
            _animator.SetFloat(Health, HealthComponent._health);
            
            PlayerScript.PlayerParticlesScript.SpawnHealParticles();
        }
        
        public void ArmHero()
        {
            _isArmed = true;
            //PlayerScript._isArmed = true;
            _animator.runtimeAnimatorController = _armed;
        }
        
    }
}
