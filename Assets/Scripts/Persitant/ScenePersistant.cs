using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersistant : MonoBehaviour
{
    private void Awake()
    {
        int noOfScnePersistantObjects = FindObjectsOfType<ScenePersistant>().Length;
        if(noOfScnePersistantObjects > 1){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }

    public void onLevelExitDestroyThisObject(){
        Destroy(gameObject);
    }
}
