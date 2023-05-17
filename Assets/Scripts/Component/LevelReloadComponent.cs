using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components
{
    public class LevelReloadComponent : MonoBehaviour
    {
        public void ReloadLvl()
        {
            var session = FindObjectOfType<GameSession>();
            DestroyImmediate(session);
            
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
         }
    }
}
