using UnityEngine;

namespace Model
{
    public class GameSession : MonoBehaviour

    {
        [SerializeField] private PlayerData _data;
        public PlayerData Data => _data;

        private void Awake()
        {
            if (IsSessionExit())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
            }
        }

        private bool IsSessionExit()
        {
            var session = FindObjectsOfType<GameSession>();
            foreach (var gameSession in session)
            {
                if (gameSession != this)
                {
                    return true;
                }
            }
            return false;
        }
    }

}