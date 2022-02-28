using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLaserComingFrom : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("inside laser detection");
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
    }
}
