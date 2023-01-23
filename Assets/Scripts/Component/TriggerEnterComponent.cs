using UnityEngine;

namespace Components
{
    public class TriggerEnterComponent : MonoBehaviour
    {
        [SerializeField] private string _tagTrigger;
        [SerializeField] private EnterEvent _action;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(_tagTrigger))
            {
               _action?.Invoke(other.gameObject);
            }
        }
    }
    
    
}
