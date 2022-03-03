using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GrapplingHook : MonoBehaviour
{
    [SerializeField] GameObject ropeLinkPrefab;
    [SerializeField] int numberOfLinksLower = 3;

    [SerializeField] 
    GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireGrapplingHook(InputAction.CallbackContext context){
        //  Random between higher and lower
        if(context.started || context.canceled){
            return;
        }
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D rayHit= Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("GrapplingPlatform"));
        Debug.Log("Inside Grapling hook creator");
        if(rayHit.collider){
            
            if(rayHit.collider.tag == "GrapplingPlatform")
            {

                Debug.Log("Grapling tag collider detected");
                bool alreadyExistingLinkDetected = false;
                Transform[] link = gameObject.GetComponentsInChildren<Transform>();
                alreadyExistingLinkDetected = CheckForExistingLink(alreadyExistingLinkDetected, link);
                if (alreadyExistingLinkDetected)
                {
                    // Debug.Log("found child object of type link");
                    DestroyGrapplingHook(context);
                    GenerateGrapplingHook(rayHit);
                }
                else
                {
                    GenerateGrapplingHook(rayHit);
                }

            }else{
                Debug.Log(rayHit.collider.tag + rayHit.collider.gameObject.name);
            }
        }
    }

    private static bool CheckForExistingLink(bool alreadyExistingLinkDetected, Transform[] link)
    {
        for (int i = 0; i < link.Length; i++)
        {
            if (link[i].gameObject.tag == "Link")
            {
                alreadyExistingLinkDetected = true;
            }
        }

        return alreadyExistingLinkDetected;
    }

    public void DestroyGrapplingHook(InputAction.CallbackContext context){
        if(context.canceled || context.started){
            return;
        }
        Debug.Log("Entered Link Destroyer method");
        Transform[] links = GetComponentsInChildren<Transform>();
        foreach(Transform link in links){
            if(link.gameObject.tag == "Link"){
                Destroy(link.gameObject);
            }
        }

    }

    private void GenerateGrapplingHook(RaycastHit2D rayHit)
    {
        int noOfLinks = numberOfLinksLower;
        Rigidbody2D previousRBD = GetComponent<Rigidbody2D>();
        for (int i = 0; i < noOfLinks; i++)
        {
            GameObject link = Instantiate(ropeLinkPrefab, transform, true);
            // GameObject link = Instantiate(ropeLinkPrefab, transform.position, transform.rotation, transform);
            HingeJoint2D hinge = link.GetComponent<HingeJoint2D>();
            hinge.autoConfigureConnectedAnchor = false;
            hinge.connectedBody = previousRBD;
            previousRBD = link.GetComponent<Rigidbody2D>();
            if (i == noOfLinks - 1)
            {
                hinge = link.AddComponent<HingeJoint2D>();
                hinge.autoConfigureConnectedAnchor = false;
                hinge.connectedBody = rayHit.collider.gameObject.GetComponent<Rigidbody2D>();
                
            }
        }
    }
}
