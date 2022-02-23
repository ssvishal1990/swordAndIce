using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour
{
    Guard guard;
    // Start is called before the first frame update
    void Start()
    {
        guard = FindObjectOfType<Guard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            Debug.Log("Detected Collision with player");
            if(!guard.isGuardActive()){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }else{
                
            }
            
        }
    }
}
