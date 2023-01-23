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
        [SerializeField] internal float startSpeed = 1f;

        internal float speed = 0f;
        [SerializeField] internal float _jumpingPower = 1f;

        [Header("Player Stats")] 
        internal int _coins;

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
        
        

        public void AddCoins(int coins)
        {
            _coins += coins;
            Debug.Log($"{coins} coins added. Total coins: {_coins}");
        }
    }
}
