using UnityEngine;

namespace CameraSystems
{
    public class FollowSystem : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] float _dampingCameraSmoothTime;

        private void LateUpdate()
        {
            var destination = new Vector3(_target.position.x, _target.position.y, transform.position.z);
            transform.position = Vector3.Lerp (transform.position, destination, Time.deltaTime * _dampingCameraSmoothTime);
        }
    }
}
