using UnityEngine;

namespace Components
{
    public class LayerCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer;
        private Collider2D _collider;

        public bool IsTouchingLayer;


        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            IsTouchingLayer = _collider.IsTouchingLayers(_layer);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            IsTouchingLayer = _collider.IsTouchingLayers(_layer);
        }
    }
}