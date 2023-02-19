using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScripts
{
    [DefaultExecutionOrder(-101)]
    public class PlayerScript : MonoBehaviour
    {
        [Header("Player Scripts")] 
        [SerializeField] internal PlayerNewInputScript  PlayerNewInputScript;
        [SerializeField] internal PlayerMovementScript  PlayerMovementScript;
        [SerializeField] internal PlayerCollisionScript PlayerCollisionScript;
        [SerializeField] internal PlayerAnimationScript PlayerAnimationScript;
        [SerializeField] internal PlayerEffectsScript   PlayerEffectsScript;
        [SerializeField] internal PlayerParticlesScript PlayerParticlesScript;
        //[SerializeField] internal PlayerAttackScript PlayerAttackScript;
        

        [Header("Player Settings")] 
        [Header("Speed and others")]
        [SerializeField] internal float startSpeed = 1f;
        [SerializeField] internal float _jumpingPower = 1f;
        [SerializeField] internal float _jumpDamageSpeedAlpha;
        
        [Header("Animations")]
        [SerializeField] internal float _slamDownVelocity;
        
        [Header("Attacks Damage")] 
        [SerializeField] internal float _attack1Damage;
        [SerializeField] internal float _attack2Damage;
        [SerializeField] internal float _attack3Damage;

        [Header("Stats")] 
        internal int _coins;

        [Header("Statuses")] 
        [SerializeField] public bool _isArmed;
        
        [Space(10)]
        
        internal float speed = 0f;

        private void Awake()
        {
            Debug.Log("Main PlayerScript Awake");
        }

        private void Start()
        {
            Debug.Log("Main PlayerScript Starting");
            _coins = 0;
        }

        void Update()
        {
        
        }
        
        void FixedUpdate()
        {
                
        }
        
        

        public void AddCoins(int coins)
        {
            _coins += coins;
            Debug.Log($"{coins} coins added. Total coins: {_coins}");
        }

        
    }
}
