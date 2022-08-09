using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    
    /* //Reference to the PlayerController
    private PlayerController PC;

    void OnTriggerEnter(Collider collision)
    {
        //If the player collides with the jump pad, it will leave a debug message.
        if(collision.transform.tag == "Player")
            {                
                Debug.Log("Big Jump");
                
                //If the player jumps while on the jump pad - the velocity is increased to 100
                if(Input.GetKey(KeyCode.Space) && PC.IsGrounded())
                {
                    Vector3 jump = new Vector3(0.0f, 100.0f, 0.0f);
                    PC.rb.AddForce(jump * PC.jumpspeed);
                }
            }
    } */
}
