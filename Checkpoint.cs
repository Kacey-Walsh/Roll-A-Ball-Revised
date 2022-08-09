using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    //Setting if the checkpoint has been activated or not - to prevent falling onto a farther down one
    public bool Awakened = false;

    public ParticleSystem activationEffectUpper;
    public ParticleSystem activationEffectLower;

    void Start()
    {
        activationEffectUpper.Pause();
        activationEffectLower.Pause();
    }

    private void OnTriggerEnter(Collider collision)
    {
        //If new checkpoint and interacted with player mark as new spawn location and change colors
        if((collision.transform.tag == "Player") && (Awakened == false))
        {
            PlayerController.LastCheckPointPos = transform.position;
            Debug.Log("Checkpoint Aquired");
            GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            
            Awakened = true;
            activationEffectUpper.Play();
            activationEffectLower.Play();
        }
    }


}
