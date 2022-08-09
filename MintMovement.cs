using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMovement : MonoBehaviour
{
    public float min=1f;
    public float max=2f;



    public float spinSpeed = 4.0f;
    public float vertSpeed = 1.0f;
    // Use this for initialization
    void Start () {

        min=transform.position.y;
        max=transform.position.y+4;
   
    }
   
    // Update is called once per frame
    void Update () 
    {   
        //Spin in place
            //To change direction put a '-' infront of the spin speed in the inspector
        transform.Rotate(new Vector3(0, 15, 0) * Time.deltaTime * spinSpeed);

        //Move up and down candy cane
        transform.position =new Vector3(transform.position.x, Mathf.PingPong(Time.time*vertSpeed,max-min)+min, transform.position.z);

    }
}
