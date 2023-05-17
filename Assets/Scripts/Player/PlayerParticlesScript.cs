using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Components;

namespace PlayerScripts
{
    public class PlayerParticlesScript : MonoBehaviour
    {
        [SerializeField] private PlayerScript PlayerScript;

        [Header("Game Particles")] 
        [SerializeField] private ParticleSystem _hitParticles;
        [SerializeField] private ParticleSystem _healParticles;
        
        [Space] [Header("Hero Particles")]
        [SerializeField] private Components.SpawnComponent _footStepParticles;
        [SerializeField] private Components.SpawnComponent _jumpParticles;
        [SerializeField] private Components.SpawnComponent _slamJumpParticles, _slamJumpHeightParticles;
        
        [Header("Components")]
        [SerializeField] private HealthComponent HealthComponent;


        private void SpawnCoins()
        {
            int numCoinsToDispose = Mathf.Min(PlayerScript._session.Data.Coins, 5);
            PlayerScript._session.Data.Coins -= numCoinsToDispose;
                
            _hitParticles.gameObject.SetActive(true);
                
            var burst = _hitParticles.emission.GetBurst(0);
            burst.count = numCoinsToDispose;
            _hitParticles.emission.SetBurst(0, burst);
                
            _hitParticles.Play();
            
            Debug.Log($"{numCoinsToDispose} coins lost. Total coins: {PlayerScript._session.Data.Coins}");
        }
        
        public void SpawnCoinsFromDamage()
        {
            if (PlayerScript._session.Data.Coins > 0)
            {
                SpawnCoins();
            }
        }
         

        private void SpawnHeal()
        {
            _healParticles.gameObject.SetActive(true);
            
            var burst = _healParticles.emission.GetBurst(0);
            burst.count = PlayerScript.PlayerAnimationScript._healValue;
            _healParticles.emission.SetBurst(0, burst);
            
            _healParticles.Play();
            
            Debug.Log($"{PlayerScript.PlayerAnimationScript._healValue} heal pick up. Total health: {HealthComponent._health}");
        }

        public void SpawnHealParticles()
        {
            SpawnHeal();
        }
        public void SpawnFootDust()
        { 
            _footStepParticles.Spawn();
        }
        public void SpawnJumpDust()
        { 
            _jumpParticles.Spawn();
        }
        public void SpawnSlamJumpDust()
        { 
            _slamJumpParticles.Spawn();
        }
        
        public void SpawnSlamJumpDustHeight()
        { 
            _slamJumpHeightParticles.Spawn();
        }
    }
}
