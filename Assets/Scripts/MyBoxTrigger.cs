using UnityEngine;

public class MyBoxTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip wrong;
    [SerializeField] private AudioClip correct;

    /// <summary>
    /// Checks to see if an object entered a trigger
    /// </summary>
    /// <param name="col"></param>
   void OnTriggerEnter2D(Collider2D col) //checks if object has collider and checks it for triggers
    {
        Debug.Log("Something entered the trigger!");



        // Check to see if an object has the payer tag. If it 
        if (col.CompareTag("Player")) //Checks to see if an object has the player tag
        {
            Debug.Log("Object with the Player Tag has entered the trigger");

            //Gets the Sprite Renderer component and changes the color to a random color
            GetComponent<SpriteRenderer>().color = 
                new Color(Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f));

            //Sets the audiosource clip to the "Correct" audio clip
            GetComponent<AudioSource>().clip = correct; 
        }
        else
        {
            //Gets the sprite renderer component and changes the color to black
            GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);
            
            //Sets the position of the game object to a random position within the range specified
            transform.position = new Vector3(Random.Range(-4.0f,4.0f),Random.Range(-3.0f,3.0f));
            
            
            GetComponent<AudioSource>().clip = wrong; //Sets sound to wrong
        }


        GetComponent<AudioSource>().Play(); //Plays sound on enter
    } //code is executed from top to bottom INSIDE a function

    // void OnTriggerExit2D(Collider2D col)
    // {
    //     Debug.Log("Something left the trigger!");

    //     if (col.CompareTag("Player"))
    //     {
    //     GetComponent<SpriteRenderer>().color = 
    //         new Color(Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f));
    //     }
    // }
}
