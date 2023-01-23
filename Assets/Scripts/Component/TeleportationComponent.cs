using UnityEngine;

namespace Components
{
    public class TeleportationComponent : MonoBehaviour
    {
        [SerializeField] private Transform _targetTeleportPosition;

        public void Teleport(GameObject target)
        {
            target.transform.position = _targetTeleportPosition.position;
        }
    }
}