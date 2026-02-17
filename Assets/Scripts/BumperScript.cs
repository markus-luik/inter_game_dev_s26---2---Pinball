using UnityEngine;

public class BumperScript : MonoBehaviour
{

    //GameManager reference
    SimpleGameManager GM;
    // Sprite Renderer reference
    private SpriteRenderer spriteRenderer;


    //Bumper Points
    [SerializeField] private int amountToAdd;

    //Bumper Physics
    [SerializeField] private float bounceForce = 5f;
    [SerializeField] private float cooldownTime = 0.2f;
    private bool canBounce = true;
    
    
    private void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SimpleGameManager>(); //finds ONE game object with GameManager tag and gets its script. 

        spriteRenderer = GetComponent<SpriteRenderer>();
    } 

    private void OnCollisionEnter2D(Collision2D col)
    {
        //checks to see if bounce cooldown has ended
        if (!canBounce) return;

        //checks to see if the bouncer is interacting with ball
        if (col.gameObject.CompareTag("Ball")){ 
            //Adds points
            GM.AddToScore(amountToAdd);

            //Deals with bounce physics
            if (col.rigidbody != null)
            {
                Vector2 bounceDir = col.GetContact(0).normal; //gets bounce direction
                col.rigidbody.AddForce(-bounceDir * bounceForce, ForceMode2D.Impulse); //adds bounce force
                StartCoroutine(BounceCooldown()); //starts bounce cooldown
            }
            else
            {
                Debug.Log("Ball has no rigidbody!");
                return;
            }

            Debug.Log($"Player bounced off of {this.GetInstanceID()} and got {amountToAdd} points!");
        }
    }


    /// <summary>
    /// Coundown until next bounce is available
    /// </summary>
    /// <returns></returns>
    private System.Collections.IEnumerator BounceCooldown()
    {
        //updates if can bounce, changes color accordingly
        canBounce = false;
        spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f);
        yield return new WaitForSeconds(cooldownTime);
        canBounce = true;
        spriteRenderer.color = new Color(1.0f,1.0f,1.0f);
    }

    /// <summary>
    /// Debugging: Press T to test if score gets added
    /// </summary>
    void TestUpdateScore()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GM.AddToScore(amountToAdd);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TestUpdateScore();
    }
}


//IN CLASS
//using System;
// using Unity.Android.Types;
// using UnityEngine;

// public class TestBumper : MonoBehaviour {
    
//     SimpleGameManager GM;
//     [SerializeField] private int amountToAdd = 10;

//     private void Awake() {
//         GM = GameObject.FindGameObjectWithTag("SimpleGameManager").GetComponent<SimpleGameManager>();
//     }

//     void TestUpdateScore() {
//         if (Input.GetKeyDown(KeyCode.T))GM.AddToScore(amountToAdd);
//     }

//     void Update() {
//         TestUpdateScore();
//     }
// }