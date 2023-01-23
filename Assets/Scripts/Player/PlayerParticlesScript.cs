using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerParticlesScript : MonoBehaviour
    {
        [SerializeField] private PlayerScript PlayerScript;

        [SerializeField] private ParticleSystem _hitParticles;
        
        [SerializeField] private Components.SpawnComponent _footStepParticles;

        internal void SpawnCoinsFromDamage()
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
        
        public void SpawnFootDust()
        { 
            _footStepParticles.Spawn();
        }
    }
}
