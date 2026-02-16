using UnityEngine;

public class Plunger : MonoBehaviour
{
    [SerializeField] private float maxPullDistance = 2f;
    [SerializeField] private float plungingSpeed = 20f;

    private Rigidbody2D rb;
    private Vector3 startPos;
    private SpringJoint2D mySpring;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = rb.position;
        mySpring = GetComponent<SpringJoint2D>();
    }

    private void Update()
    {
        //Pulling down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mySpring.enabled = false;
            transform.Translate(translation:Vector3.down*plungingSpeed*Time.deltaTime);

        }
        else
        {
            mySpring.enabled = true;
            // rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
