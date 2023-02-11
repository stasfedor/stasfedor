using UnityEngine;
using System.Collections;
using PlayerScripts;

namespace Components
{
    public class TeleportationComponent : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Transform _destinationTransform;
        [SerializeField] private int _circlesTime;
        [SerializeField] private Vector3 _upDownAlpha;
        [SerializeField] private float _moveTime;
        [SerializeField] private PlayerScript PlayerScript;
        
        private static readonly int IsTeleport        = Animator.StringToHash("Teleport");

        public void Teleport(GameObject target)
        {
            PlayerScript.PlayerAnimationScript._animator.SetTrigger(IsTeleport);
            PlayerScript.PlayerCollisionScript._rb2d.simulated = false;
            StartCoroutine(Delay(target));
            
            
        }
        
        IEnumerator Delay(GameObject target)
        {
            yield return new WaitForSeconds(_circlesTime);
            StartCoroutine(TeleportCoroutine(target));
        }
        
        IEnumerator Delay2(GameObject target)
        {
            yield return new WaitForSeconds(_circlesTime*2f);
            PlayerScript.PlayerCollisionScript._rb2d.simulated = true;
        }
        
        private IEnumerator TeleportCoroutine(GameObject target)
        {
            float moveTime = 0f;
            while (moveTime < _moveTime)
            {
                moveTime += Time.deltaTime;
                var progress = moveTime / _moveTime;
                target.transform.position =
                    Vector2.Lerp(target.transform.position, _destinationTransform.position, progress);
                
            }

            StartCoroutine(Delay2(target));
            yield return null;
        }
    }
}