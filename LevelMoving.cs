using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelMoving : MonoBehaviour
{
    //Reference to the PlayerController
    public PlayerController PC;
    
    public TextMeshProUGUI levelText;

    //Setting if the portal is active or not (if the player can warp to it)
    public bool activePortal = true;

    void Start()
    {
		SetLevelText();
    }

    public void OnTriggerEnter(Collider collision)
    {
        //If the portal is active and interacts with the player - it will be marked as a checkpoint, set to false, and add +1 to the level
        if((collision.transform.tag == "Player") && (activePortal == true))
        {
                //Sets new spawnpoint at checkmark barrier
            PlayerController.LastCheckPointPos = transform.position;
                //Is Portal active - "can it be set as a respawn?"
            activePortal = false;

                //Increase Level
            PC.level = PC.level + 1;
    		SetLevelText();
            Debug.Log("Now Entering: level " + PC.level);

        }
    }
    
    void SetLevelText()
    {
		levelText.text = "Level: " + PC.level.ToString();
    }
}