using Cinemachine;
using UnityEngine;

namespace Components
{
    public class CameraStateController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CinemachineVirtualCamera _camera;

        private static readonly int Show = Animator.StringToHash("Show");

        public void SetPosition(Vector3 targetPosition)
        {
            targetPosition.z = _camera.transform.position.z;
            _camera.transform.position = targetPosition;
        }

        public void SetState(bool state) 
        {
            _animator.SetBool(Show, state);
        }
    }
}