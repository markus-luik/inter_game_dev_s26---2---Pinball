using UnityEngine;

public class PolaroidAlignmentTrigger : MonoBehaviour
{

    private string comparisonTag = "SetRigidbody";
    public Transform parentObject;
    private bool triggerState = false;

    void OnTriggerEnter2D(Collider2D col) //checks if object has collider and checks it for triggers
    {
        if (col.CompareTag(comparisonTag))
        {
            Debug.Log("Player aligned to set");
            
            triggerState = true;

            parentObject.position = col.GetComponent<Transform>().position;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag(comparisonTag))
        {
            Debug.Log("Player left set");
            
            triggerState = false;
        }
    }

    void Update()
    {
        if (triggerState)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.0f,1.0f,0.0f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f,0.0f,0.0f);
        }
        
    }
}
