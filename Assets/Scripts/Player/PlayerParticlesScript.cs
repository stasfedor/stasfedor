using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Components;

namespace PlayerScripts
{
    public class PlayerParticlesScript : MonoBehaviour
    {
        [SerializeField] private PlayerScript PlayerScript;

        [SerializeField] private ParticleSystem _hitParticles, _healParticles;
        
        [SerializeField] private Components.SpawnComponent _footStepParticles;
        
        [SerializeField] private HealthComponent HealthComponent;

        public void SpawnCoinsFromDamage()
        {
            if (PlayerScript._coins > 0)
            {
                SpawnCoins();
            }
        }

        private void SpawnCoins()
        {
            int numCoinsToDispose = Mathf.Min(PlayerScript._coins, 5);
            PlayerScript._coins -= numCoinsToDispose;
                
            _hitParticles.gameObject.SetActive(true);
                
            var burst = _hitParticles.emission.GetBurst(0);
            burst.count = numCoinsToDispose;
            _hitParticles.emission.SetBurst(0, burst);
                
            _hitParticles.Play();
            
            Debug.Log($"{numCoinsToDispose} coins lost. Total coins: {PlayerScript._coins}");
        }
        
         public void SpawnHealParticles()
        {
            SpawnHeal();
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

        public void SpawnFootDust()
        { 
            _footStepParticles.Spawn();
        }
    }
}
