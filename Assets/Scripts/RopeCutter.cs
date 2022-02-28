using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RopeCutter : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire(InputAction.CallbackContext context){
        if(context.performed){
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);
            if(hit.collider ){
                Debug.Log("Detected collision");
                if(hit.collider.tag == "Link"){
                    Destroy(hit.collider.gameObject);
                }
            }else{
                Debug.Log("Collision not detected");
            }
        }
        
    }


}
