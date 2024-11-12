using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToNextScene()
    {
   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        
        int nextSceneIndex = currentSceneIndex + 1;

       
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Ya estás en la última escena.");
        }
    }
}
