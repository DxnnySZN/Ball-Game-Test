using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
        GetComponent<Renderer>().material.color = Color.red;
        // GetComponent<Renderer> will give the code access to the rendering of the ball
        // the moment the ball comes in contact with the plane, the color of the ball will immediately change to red
    }
}
