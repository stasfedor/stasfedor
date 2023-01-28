using UnityEngine;
using System;
using PlayerScripts;

namespace Components
{
    public class AddCoinsComponent : MonoBehaviour
    {
        [SerializeField] private int _numCoins;
        private PlayerScript _hero;

        private void Start()
        {
            _hero = FindObjectOfType<PlayerScript>();
        }

        public void Add()
        {
            _hero.AddCoins(_numCoins);
        }
    }
}