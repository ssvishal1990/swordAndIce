using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    public void ConnectRopeEnd(Rigidbody2D endRB){
        HingeJoint2D hinge = gameObject.AddComponent<HingeJoint2D>();
        hinge.connectedBody = endRB;
        hinge.autoConfigureConnectedAnchor = false;
        hinge.anchor = new Vector2(0f, 0f);
        hinge.connectedAnchor = new Vector2(0f, 0.5f);
    }

}
