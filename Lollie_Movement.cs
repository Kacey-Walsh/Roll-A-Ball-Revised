using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lollie_Movement : MonoBehaviour
{
    //max rotation (simulate momentum)
    public float leftMax = 80;
    public float rightMax = -40;


    public float swingSpeed = 6.0f;
    // Use this for initialization
    void Start () {

        //min=transform.position.x;
        //max=transform.position.x+4;
   
    }
   
    // Update is called once per frame
    void Update () 
    {   
        






        transform.Rotate(new Vector3(15, 0, 0) * Time.deltaTime * swingSpeed);

        if (transform.rotation.x == leftMax)
        {
            Debug.Log("Hit Critical Max");
        }
        
        //if (transform.rotation.x < leftMax)
        //{
        //    swingSpeed = -6.0f;
        //    Debug.Log("Going Left");
        //}

        //if (transform.rotation.x < rightMax)
        //{
        //    swingSpeed = 6.0f;
        //}


    }
}
