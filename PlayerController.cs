using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    //NOTES
        //  -Discs that spin, requiring you to run the opposite way (pepermint)
        //  -Jolly Rancher jumps (similar to MC.Honey) that make it so you can't jump
        //  -Jello that bounces you around
        //  -Pretzal hoops (maybe they spin?)

        //KNOWN BUGS
        //  -the ball does not move with the spining peppermint, currently cant figure out how to fix this
        //  -Sometimes velocity on the ball completely changes, going from very fast to very slow

//================VARIABLES================

    //Movement
        // X/Z Movement
    public float speed = 1;
    public Rigidbody rb;
        //Y Movement aka jumping
    public int jumpspeed = 1;
    public bool isGrounded = true;
    public int ground;
            //Avoiding double jumping
        public SphereCollider col;

    //Level Boundaries
        //Reseting when falling too far
    public float threshhold = -6;
    public float resetHeight = -5;
    
    //Level Identification
    public int level = 0;

    //Scoring
    public int score;
    public TextMeshProUGUI scoreText;
        //Win Text
    public GameObject winTextObject;
    
    //Checkpoints
    public static Vector3 LastCheckPointPos = new Vector3(0,2,0);
    //Sound


//================START================
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();

        score = 0;
        SetScoreText ();
        winTextObject.SetActive(false); 
    }

//================UPDATE================
    void Update()
    {
        //Movement - X/Z Axis
        float movementHorizontal = Input.GetAxis ("Horizontal");
        float movementVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (movementHorizontal, 0.0f, movementVertical);

        //rb.velocity = rb.velocity.normalized * speed;
        rb.AddForce(movement * speed);

        //Jumping
            //Need to set seperately since IsGrounded is a boolean and Input is a multifunctional
        if (isGrounded == true)
        {
            if(Input.GetKey(KeyCode.Space))
                {
                    Vector3 jump = new Vector3(0.0f, 10.0f, 0.0f);
                    rb.AddForce(jump * jumpspeed);
                }  
        }

        //Falling off the map restarts you in the test room
        if(transform.position.y < threshhold)
        {
            //Resetting to the last known checkpoint
            Invoke("DeathMovement", 0.0f);
            GameObject.FindGameObjectWithTag("Player").transform.position = LastCheckPointPos;
            
            //Backup
            //Application.LoadLevel(Application.loadedLevel);
        }

        //Win Index
            //Collect all available 'Coins' and reach final level
		if ((score >= 8) && (level == 2))
		{
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
		}

    //-----DEBUG-----
        //THERE IS A BUG WITH THE BALL SPEEDS IN UNITY VS BUILDS, FOR UNITY THE SPEED & JUMP SPEED SHOULD BE 2 BUT ANY
        //BUILD SHOULD HAVE A SPEED & JUMP SPEED OF 10 & 20
        //Editor is 5 & 6

            //If Keypad Plus is pressed - Increase Score exponentially
        if(Input.GetKey(KeyCode.KeypadPlus))
        {
            score = score + 1;
            SetScoreText();
        }

            //If Keypad Enter is pressed - Move ball up 10
        if(Input.GetKey(KeyCode.KeypadEnter))
        {
            transform.position = new Vector3(transform.position.x, 30, transform.position.z);
        }
        
            //If Keypad 0 pressed - restart at Test Screen
        if(Input.GetKey(KeyCode.Keypad0))
        {
            transform.position = new Vector3(0, 2, 0);
        }

            //If Keypad 1 pressed - Warp to lvl 1
        if(Input.GetKey(KeyCode.Keypad1))
        {
            transform.position = new Vector3(0, 2, 95);
        }

            //If Keypad 2 pressed - Warp to lvl 2
        if(Input.GetKey(KeyCode.Keypad2))
        {
            transform.position = new Vector3(0, 20, 130);
        }

        if(Input.GetKey(KeyCode.Keypad3))
        {
            transform.position = new Vector3(0, 39, 173);
        }

            //If Keypad Plus is pressed - Increase Score exponentially
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

            //If Keypad Period is pressed - Warp to last checkpoint
        if(Input.GetKey(KeyCode.KeypadPeriod))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = LastCheckPointPos;
        }

    }

//================OTHER FUNCTIONS================
    
    //Reducing the velocity of the ball upon falling out of the world/dying
    void DeathMovement() 
    {
        rb.velocity = Vector3.one;
        //rb.angularVelocity = Vector3.one;
        Debug.Log("Death Reset");
    }

    //JUMPING
        //GROUND LAYERS - ENTER & EXIT
    void OnCollisionEnter(Collision Ground)
    {
        if(Ground.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }
    void OnCollisionExit(Collision Ground)
    {
        if(Ground.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }



    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);

            score = score + 1;
            SetScoreText ();
        }

    }

    void SetScoreText()
	{
		scoreText.text = "Score: " + score.ToString();
	}

}
