using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision Detected qwith   " + other.tag);
        if(other.tag == "Player"){
            Invoke("resetLevel",1f);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void resetLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
