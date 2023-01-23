using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components
{
    public class LevelReloadComponent : MonoBehaviour
    {
        public void ReloadLvl()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
         }
    }
}
