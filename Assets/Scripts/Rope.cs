using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] HingeJoint2D hook;
    [SerializeField] GameObject linkPrefab;
    [SerializeField] int noOfLinks;
    [SerializeField] Vector2 forceForWeight;
    [SerializeField] GameObject weight;
    Rigidbody2D previousRb;
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateLinks();
        // GenerateLastWeight();
        // AttachFinalWeight();
    }

    private void AttachFinalWeight()
    {
        HingeJoint2D weightHingeBody = weight.GetComponent<HingeJoint2D>();
        weightHingeBody.autoConfigureConnectedAnchor = false;
        weightHingeBody.anchor = new Vector2(0f, 0f);
        weightHingeBody.connectedAnchor = new Vector2(0f, -.5f);
        weightHingeBody.connectedBody = previousRb;
    }

    private void GenerateLastWeight()
    {
        // GameObject weight = Instantiate(linkPrefab, transform);
        // weight.GetComponent<Rigidbody2D>().mass = 8;
        // weight.GetComponent<HingeJoint2D>().connectedBody = previousRb;
        // weight.GetComponent<SpriteRenderer>().color = new Color(1,0,0,1);
        // weight.name = "weight";
        // weight.AddComponent<BoxCollider2D>();

        FindObjectOfType<Weight>().ConnectRopeEnd(previousRb);
    }

    private void GenerateLinks()
    {
        previousRb = hook.GetComponent<Rigidbody2D>();
        for(int i = 0 ; i < noOfLinks; i++){
            GameObject link =  Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            link.transform.localScale = hook.transform.localScale;
            joint.connectedBody = previousRb;
            joint.autoConfigureConnectedAnchor = false;
            previousRb = link.GetComponent<Rigidbody2D>();
        }
        GenerateLastWeight();
    }
}


