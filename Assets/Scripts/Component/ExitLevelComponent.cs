using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components
{
    public class ExitLevelComponent : MonoBehaviour
    {
        [SerializeField] private string _sceneName;
        [SerializeField] private float _waitingTime;

        private void ExitIt()
        {
            SceneManager.LoadScene(_sceneName);
        }
        
        public void Exit()
        {
            Invoke("ExitIt", _waitingTime);
        }
    }
}