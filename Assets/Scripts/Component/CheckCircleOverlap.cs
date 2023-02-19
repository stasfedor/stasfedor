using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Utils;

namespace Components
{
    public class CheckCircleOverlap : MonoBehaviour
    {
        [SerializeField] private float _radius = 1f;
        private readonly Collider2D[] _interactionResult = new Collider2D[5];
        public GameObject[] GetObjectsInRange()
        {
            int size = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _interactionResult);
            
            var overlaps = new List<GameObject>();
            for (int i = 0; i < size; i++)
            {
                overlaps.Add(_interactionResult[i].gameObject);
            }
            return overlaps.ToArray();
        }
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Handles.color = GizmosColors.TransparentRed;
            Handles.DrawSolidDisc(transform.position, Vector3.forward, _radius);
        }
#endif        
    }
}