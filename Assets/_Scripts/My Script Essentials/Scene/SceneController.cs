using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyUtilities
{
    public class SceneController : Singleton<SceneController>
    {
        private string _currentSceneActive
        {
            get
            {
                return SceneManager.GetActiveScene().name;
            }
        }
  
    }
}