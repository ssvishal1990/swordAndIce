using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevels : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && other.name == "Player"){
            ScenePersistant scenePersistant = FindObjectOfType<ScenePersistant>();
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            scenePersistant.onLevelExitDestroyThisObject();
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
